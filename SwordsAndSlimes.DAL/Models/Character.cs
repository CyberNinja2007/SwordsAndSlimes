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

        public ICollection<Battle> Battles { get; set; }
        public ICollection<CharactersInDungeon> CharactersInDungeons { get; set; }
        public ICollection<CharactersWeapon> CharactersWeapons { get; set; }
    }
}
