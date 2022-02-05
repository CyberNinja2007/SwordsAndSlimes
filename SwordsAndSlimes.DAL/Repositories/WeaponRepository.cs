using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SwordsAndSlimes.DAL.Abstraction;
using SwordsAndSlimes.DAL.Data;
using SwordsAndSlimes.DAL.Models;

namespace SwordsAndSlimes.DAL.Repositories
{
    public class WeaponRepository : IRepository<Weapon>
    {
        private readonly CourseachContext _context;

        public WeaponRepository(CourseachContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Weapon> GetAll()
        {
            return _context.Weapons.ToList();
        }

        public Weapon Get(string name)
        {
            return  _context.Weapons
                .Include(c => c.CharactersWeapons)
                .ThenInclude(c => c.Character)
                .Include(c => c.DungeonWeapons)
                .ThenInclude(c => c.Dungeon)
                .AsNoTracking()
                .FirstOrDefault(m => m.Name == name);
        }

        public void Create(Weapon weapon)
        {
            _context.Weapons.Add(weapon);
        }

        public void Update(Weapon weapon)
        {
            try
            {
                _context.Weapons.Update(weapon);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.Weapons.Find(weapon) == null)
                {
                    throw new Exception(
                        $"Выбранное оружие не найдено!");
                }
                else
                {
                    throw new Exception(
                        $"Произошла ошибка при редактировании оружия {weapon.Name}!\nПопробуйте ещё раз!");
                }
            }
        }

        public void Delete(string name)
        {
            var weapon = _context.Weapons.FirstOrDefault(m => m.Name == name);

            if (weapon != null)
            {
                _context.Weapons.Remove(weapon);
            }
        }
    }
}