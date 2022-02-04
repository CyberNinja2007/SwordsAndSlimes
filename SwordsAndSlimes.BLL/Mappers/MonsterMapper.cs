using System.Linq;
using SwordsAndSlimes.BLL.Models;
using SwordsAndSlimes.DAL.Models;

namespace SwordsAndSlimes.BLL.Mappers
{
    public static class MonsterMapper
    {
        public static Monster ToEntity(this MonsterDTO monster)
        {
            return new Monster()
            {
                Name = monster.Name,
                Class = monster.Class,
                Level = monster.Level,
                Attack = monster.Attack,
                Health = monster.Health
            };
        }
        
        public static MonsterDTO ToDTO(this Monster monster)
        {
            return new MonsterDTO()
            {
                Name = monster.Name,
                Class = monster.Class,
                Level = monster.Level,
                Attack = monster.Attack,
                Health = monster.Health,
                Dungeons = monster.DungeonMonsters.Select(x => new DungeonDTO()
                {
                    Name = x.Dungeon.Name,
                    Image = x.Dungeon.Image
                }),
            };
        }
    }
}