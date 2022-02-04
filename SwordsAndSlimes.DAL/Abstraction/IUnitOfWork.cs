using System;
using SwordsAndSlimes.DAL.Models;

namespace SwordsAndSlimes.DAL.Abstraction
{
    public interface IUnitOfWork
    {
        IRepository<Character> Characters { get;}
        IRepository<Dungeon> Dungeons { get;}
        IRepository<Monster> Monsters { get;}
        IRepository<Weapon> Weapons { get;}
        int Save();
    }
}