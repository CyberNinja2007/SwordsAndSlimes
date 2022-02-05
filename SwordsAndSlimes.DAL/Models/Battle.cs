#nullable disable

namespace SwordsAndSlimes.DAL.Models
{
    public class Battle
    {
        public string CharacterName { get; set; }
        public string MonsterName { get; set; }
        public string WeaponName { get; set; }

        public Character Character { get; set; }
        public Monster Monster { get; set; }
        public Weapon Weapon { get; set; }
    }
}
