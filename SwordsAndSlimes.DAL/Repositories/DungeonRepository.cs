using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SwordsAndSlimes.DAL.Abstraction;
using SwordsAndSlimes.DAL.Data;
using SwordsAndSlimes.DAL.Models;

namespace SwordsAndSlimes.DAL.Repositories
{
    public class DungeonRepository : IRepository<Dungeon>
    {
        private readonly CourseachContext _context;

        public DungeonRepository(CourseachContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Dungeon> GetAll()
        {
            return _context.Dungeons.ToList();
        }

        public Dungeon Get(string name)
        {
            return  _context.Dungeons.FirstOrDefault(m => m.Name == name);
        }

        public void Create(Dungeon dungeon)
        {
            _context.Dungeons.Add(dungeon);
        }

        public void Update(Dungeon dungeon)
        {
            try
            {
                _context.Dungeons.Update(dungeon);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.Dungeons.Find(dungeon) == null)
                {
                    throw new Exception(
                        $"Выбранное подземелье не найдено!");
                }
                else
                {
                    throw new Exception(
                        $"Произошла ошибка при редактировании подземелья {dungeon.Name}!\nПопробуйте ещё раз!");
                }
            }
        }

        public void Delete(string name)
        {
            var dungeon = _context.Dungeons.FirstOrDefault(m => m.Name == name);

            if (dungeon != null)
            {
                _context.Dungeons.Remove(dungeon);
            }
        }
    }
}