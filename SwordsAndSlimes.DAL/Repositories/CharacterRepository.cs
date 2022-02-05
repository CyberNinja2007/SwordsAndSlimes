using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SwordsAndSlimes.DAL.Abstraction;
using SwordsAndSlimes.DAL.Data;
using SwordsAndSlimes.DAL.Models;

namespace SwordsAndSlimes.DAL.Repositories
{
    public class CharacterRepository : IRepository<Character>
    {
        private readonly CourseachContext _context;

        public CharacterRepository(CourseachContext context)
        {
            _context = context; 
        }

        public IEnumerable<Character> GetAll()
        {
            return _context.Characters.ToList();
        }

        public Character Get(string name)
        {
            return  _context.Characters
                .Include(c => c.CharactersWeapons)
                .ThenInclude(c => c.Weapon)
                .Include(c => c.Battles)
                .ThenInclude(c => c.Monster)
                .AsNoTracking()
                .FirstOrDefault(m => m.Name == name);
        }

        public void Create(Character character)
        {
            _context.Characters.Add(character);
        }

        public void Update(Character character)
        {
            try
            {
                _context.Characters.Update(character);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.Characters.Find(character) == null)
                {
                    throw new Exception(
                        $"Выбранный персонаж не найден!");
                }
                else
                {
                    throw new Exception(
                        $"Произошла ошибка при редактировании персонажа {character.Name}!\nПопробуйте ещё раз!");
                }
            }
        }

        public void Delete(string name)
        {
            var character = _context.Characters.FirstOrDefault(m => m.Name == name);

            if (character != null)
            {
                _context.Characters.Remove(character);
            }
        }
    }
}