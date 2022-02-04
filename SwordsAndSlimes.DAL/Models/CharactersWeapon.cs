#nullable disable

namespace SwordsAndSlimes.DAL.Models
{
    public partial class CharactersWeapon
    {
        public string CharacterName { get; set; }
        public string WeaponName { get; set; }

        public virtual Character Character { get; set; }
        public virtual Weapon Weapon { get; set; }
    }
}
