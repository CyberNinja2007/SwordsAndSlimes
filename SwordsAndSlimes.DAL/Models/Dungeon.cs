using System.Collections.Generic;

#nullable disable

namespace SwordsAndSlimes.DAL.Models
{
    public partial class Dungeon
    {
        public Dungeon()
        {
            CharactersInDungeons = new HashSet<CharactersInDungeon>();
            DungeonMonsters = new HashSet<DungeonMonster>();
            DungeonWeapons = new HashSet<DungeonWeapon>();
        }
        public string Name { get; set; }
        public string Image { get; set; }

        public virtual ICollection<CharactersInDungeon> CharactersInDungeons { get; set; }
        public virtual ICollection<DungeonMonster> DungeonMonsters { get; set; }
        public virtual ICollection<DungeonWeapon> DungeonWeapons { get; set; }
    }
}
