using System.Collections.Generic;

#nullable disable

namespace SwordsAndSlimes.DAL.Models
{
    public partial class Monster
    {
        public Monster()
        {
            Battles = new HashSet<Battle>();
            DungeonMonsters = new HashSet<DungeonMonster>();
        }
        public string Name { get; set; }
        public int? Level { get; set; }
        public int? Health { get; set; }
        public int? Attack { get; set; }
        public string Class { get; set; }

        public ICollection<Battle> Battles { get; set; }
        public ICollection<DungeonMonster> DungeonMonsters { get; set; }
    }
}
