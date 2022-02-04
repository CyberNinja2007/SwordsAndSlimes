using System.Collections.Generic;
#nullable disable

namespace SwordsAndSlimes.DAL.Models
{
    public partial class Character
    {
        public Character()
        {
            Battles = new HashSet<Battle>();
            CharactersInDungeons = new HashSet<CharactersInDungeon>();
            CharactersWeapons = new HashSet<CharactersWeapon>();
        }
        public string Name { get; set; }
        public int? Level { get; set; }
        public int? Health { get; set; }
        public int? Attack { get; set; }
        public string Class { get; set; }

        public virtual ICollection<Battle> Battles { get; set; }
        public virtual ICollection<CharactersInDungeon> CharactersInDungeons { get; set; }
        public virtual ICollection<CharactersWeapon> CharactersWeapons { get; set; }
    }
}
