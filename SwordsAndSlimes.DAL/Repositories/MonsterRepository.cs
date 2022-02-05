using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SwordsAndSlimes.DAL.Abstraction;
using SwordsAndSlimes.DAL.Data;
using SwordsAndSlimes.DAL.Models;

namespace SwordsAndSlimes.DAL.Repositories
{
    public class MonsterRepository : IRepository<Monster>
    {
        private readonly CourseachContext _context;

        public MonsterRepository(CourseachContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Monster> GetAll()
        {
            return _context.Monsters.ToList();
        }

        public Monster Get(string name)
        {
            return  _context.Monsters
                .Include(c => c.DungeonMonsters)
                .ThenInclude(c => c.Dungeon)
                .AsNoTracking()
                .FirstOrDefault(m => m.Name == name);
        }

        public void Create(Monster monster)
        {
            _context.Monsters.Add(monster);
        }

        public void Update(Monster monster)
        {
            try
            {
                _context.Monsters.Update(monster);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.Monsters.Find(monster) == null)
                {
                    throw new Exception(
                        $"Выбранный монстр не найден!");
                }
                else
                {
                    throw new Exception(
                        $"Произошла ошибка при редактировании монстра {monster.Name}!\nПопробуйте ещё раз!");
                }
            }
        }

        public void Delete(string name)
        {
            var monster = _context.Monsters.FirstOrDefault(m => m.Name == name);

            if (monster != null)
            {
                _context.Monsters.Remove(monster);
            }
        }
    }
}