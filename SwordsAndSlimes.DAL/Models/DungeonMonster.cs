#nullable disable

namespace SwordsAndSlimes.DAL.Models
{
    public partial class DungeonMonster
    {
        public string DungeonName { get; set; }
        public string MonsterName { get; set; }

        public virtual Dungeon Dungeon { get; set; }
        public virtual Monster Monster { get; set; }
    }
}
