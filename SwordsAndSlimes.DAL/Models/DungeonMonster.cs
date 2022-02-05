#nullable disable

namespace SwordsAndSlimes.DAL.Models
{
    public partial class DungeonMonster
    {
        public string DungeonName { get; set; }
        public string MonsterName { get; set; }

        public Dungeon Dungeon { get; set; }
        public Monster Monster { get; set; }
    }
}
