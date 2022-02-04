using System.Collections.Generic;

namespace SwordsAndSlimes.BLL.Models
{
    public class WeaponDTO
    {
        public string Name { get; set; }
        public int? Level { get; set; }
        public int? Attack { get; set; }
        public string Class { get; set; }
        public IEnumerable<CharacterDTO> Characters { get; set; }
        public IEnumerable<DungeonDTO> Dungeons { get; set; }
    }
}