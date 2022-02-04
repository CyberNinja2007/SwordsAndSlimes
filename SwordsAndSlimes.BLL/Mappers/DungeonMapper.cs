using System.Linq;
using SwordsAndSlimes.BLL.Models;
using SwordsAndSlimes.DAL.Models;

namespace SwordsAndSlimes.BLL.Mappers
{
    public static class DungeonMapper
    {
        public static Dungeon ToEntity(this DungeonDTO dungeon)
        {
            return new Dungeon()
            {
                Name = dungeon.Name,
                Image = dungeon.Image
            };
        }
        
        public static DungeonDTO ToDTO(this Dungeon dungeon)
        {
            return new DungeonDTO()
            {
                Name = dungeon.Name,
                Image = dungeon.Image,
                Characters = dungeon.CharactersInDungeons.Select(x => new CharacterDTO()
                {
                    Name = x.Character.Name,
                    Class = x.Character.Class,
                    Level = x.Character.Level,
                    Attack = x.Character.Attack,
                    Health = x.Character.Health
                })
            };
        }
    }
}