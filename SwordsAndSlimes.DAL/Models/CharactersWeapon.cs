#nullable disable

namespace SwordsAndSlimes.DAL.Models
{
    public partial class CharactersWeapon
    {
        public string CharacterName { get; set; }
        public string WeaponName { get; set; }

        public Character Character { get; set; }
        public Weapon Weapon { get; set; }
    }
}
