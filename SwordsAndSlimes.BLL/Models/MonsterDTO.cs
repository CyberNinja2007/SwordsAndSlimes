using System.Collections.Generic;

namespace SwordsAndSlimes.BLL.Models
{
    public class MonsterDTO
    {
        public string Name { get; set; }
        public int? Level { get; set; }
        public int? Health { get; set; }
        public int? Attack { get; set; }
        public string Class { get; set; }
        public IEnumerable<DungeonDTO> Dungeons { get; set; }
    }
}