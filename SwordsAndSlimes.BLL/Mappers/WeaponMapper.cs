using System.Linq;
using SwordsAndSlimes.BLL.Models;
using SwordsAndSlimes.DAL.Models;

namespace SwordsAndSlimes.BLL.Mappers
{
    public static class WeaponMapper
    {
        public static Weapon ToEntity(this WeaponDTO weapon)
        {
            return new Weapon()
            {
                Name = weapon.Name,
                Class = weapon.Class,
                Level = weapon.Level,
                Attack = weapon.Attack
            };
        }
        
        public static WeaponDTO ToDTO(this Weapon weapon)
        {
            return new WeaponDTO()
            {
                Name = weapon.Name,
                Class = weapon.Class,
                Level = weapon.Level,
                Attack = weapon.Attack,
                Characters = weapon.CharactersWeapons.Select(x => new CharacterDTO()
                {
                    Name = x.Character.Name,
                    Class = x.Character.Class,
                    Level = x.Character.Level,
                    Attack = x.Character.Attack,
                    Health = x.Character.Health
                }),
                Dungeons = weapon.DungeonWeapons.Select(x => new DungeonDTO()
                {
                    Name = x.Dungeon.Name,
                    Image = x.Dungeon.Image
                })
            };
        }
    }
}