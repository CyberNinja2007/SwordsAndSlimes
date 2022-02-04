#nullable disable

namespace SwordsAndSlimes.DAL.Models
{
    public partial class DungeonWeapon
    {
        public string DungeonName { get; set; }
        public string WeaponName { get; set; }

        public virtual Dungeon Dungeon { get; set; }
        public virtual Weapon Weapon { get; set; }
    }
}
