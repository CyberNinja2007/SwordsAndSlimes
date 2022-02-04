using System.Linq;
using SwordsAndSlimes.BLL.Models;
using SwordsAndSlimes.DAL.Models;

namespace SwordsAndSlimes.BLL.Mappers
{
    public static class CharacterMapper
    {
        public static Character ToEntity(this CharacterDTO character)
        {
            return new Character()
            {
                Name = character.Name,
                Class = character.Class,
                Level = character.Level,
                Attack = character.Attack,
                Health = character.Health
            };
        }
        
        public static CharacterDTO ToDTO(this Character character)
        {
            return new CharacterDTO()
            {
                Name = character.Name,
                Class = character.Class,
                Level = character.Level,
                Attack = character.Attack,
                Health = character.Health,
                Monsters = character.Battles.Select(x => new MonsterDTO()
                {

                    Name = x.Monster.Name,
                    Class = x.Monster.Class,
                    Level = x.Monster.Level,
                    Attack = x.Monster.Attack,
                    Health = x.Monster.Health
                }),
                Weapons = character.CharactersWeapons.Select(x => new WeaponDTO()
                {
                    Name = x.Weapon.Name,
                    Class = x.Weapon.Class,
                    Level = x.Weapon.Level,
                    Attack = x.Weapon.Attack,
                })
            };
        }
    }
}