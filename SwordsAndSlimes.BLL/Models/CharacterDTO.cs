using System.Collections.Generic;

namespace SwordsAndSlimes.BLL.Models
{
    public class CharacterDTO
    {
        public string Name { get; set; }
        public int? Level { get; set; }
        public int? Health { get; set; }
        public int? Attack { get; set; }
        public string Class { get; set; }
        public IEnumerable<MonsterDTO> Monsters { get; set; }
        public IEnumerable<WeaponDTO> Weapons { get; set; }
    }
}