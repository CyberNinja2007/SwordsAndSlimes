using SwordsAndSlimes.DAL.Abstraction;
using SwordsAndSlimes.DAL.Data;
using SwordsAndSlimes.DAL.Models;

namespace SwordsAndSlimes.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CourseachContext _context;
        private CharacterRepository _characters;
        private DungeonRepository _dungeons;
        private MonsterRepository _monsters;
        private WeaponRepository _weapons;

        public UnitOfWork(CourseachContext context)
        {
            _context = context;
        }

        public IRepository<Character> Characters
        {
            get
            {
                if (_characters == null)
                    _characters = new CharacterRepository(_context);
                return _characters;
            }
        }

        public IRepository<Dungeon> Dungeons
        {
            get
            {
                if (_dungeons == null)
                    _dungeons = new DungeonRepository(_context);
                return _dungeons;
            }
        }

        public IRepository<Monster> Monsters
        {
            get
            {
                if (_monsters == null)
                    _monsters = new MonsterRepository(_context);
                return _monsters;
            }
        }

        public IRepository<Weapon> Weapons
        {
            get
            {
                if (_weapons == null)
                    _weapons = new WeaponRepository(_context);
                return _weapons;
            }
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}