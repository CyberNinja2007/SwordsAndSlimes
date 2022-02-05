#nullable disable

namespace SwordsAndSlimes.DAL.Models
{
    public partial class DungeonWeapon
    {
        public string DungeonName { get; set; }
        public string WeaponName { get; set; }

        public Dungeon Dungeon { get; set; }
        public Weapon Weapon { get; set; }
    }
}
