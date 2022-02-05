#nullable disable

namespace SwordsAndSlimes.DAL.Models
{
    public partial class CharactersInDungeon
    {
        public string DungeonName { get; set; }
        public string CharacterName { get; set; }

        public Character Character { get; set; }
        public Dungeon Dungeon { get; set; }
    }
}
