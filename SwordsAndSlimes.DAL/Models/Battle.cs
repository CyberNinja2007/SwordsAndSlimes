#nullable disable

namespace SwordsAndSlimes.DAL.Models
{
    public class Battle
    {
        public string CharacterName { get; set; }
        public string MonsterName { get; set; }
        public string WeaponName { get; set; }

        public virtual Character Character { get; set; }
        public virtual Monster Monster { get; set; }
        public virtual Weapon Weapon { get; set; }
    }
}
