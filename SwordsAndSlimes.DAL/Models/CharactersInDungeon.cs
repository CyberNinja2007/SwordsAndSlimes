#nullable disable

namespace SwordsAndSlimes.DAL.Models
{
    public partial class CharactersInDungeon
    {
        public string DungeonName { get; set; }
        public string CharacterName { get; set; }

        public virtual Character Character { get; set; }
        public virtual Dungeon Dungeon { get; set; }
    }
}
