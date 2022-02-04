using System.Collections.Generic;

#nullable disable

namespace SwordsAndSlimes.DAL.Models
{
    public partial class Weapon
    {
        public Weapon()
        {
            Battles = new HashSet<Battle>();
            CharactersWeapons = new HashSet<CharactersWeapon>();
            DungeonWeapons = new HashSet<DungeonWeapon>();
        }
        public string Name { get; set; }
        public int? Level { get; set; }
        public int? Attack { get; set; }
        public string Class { get; set; }

        public virtual ICollection<Battle> Battles { get; set; }
        public virtual ICollection<CharactersWeapon> CharactersWeapons { get; set; }
        public virtual ICollection<DungeonWeapon> DungeonWeapons { get; set; }
    }
}
