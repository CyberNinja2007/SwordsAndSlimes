using System.Collections.Generic;

namespace SwordsAndSlimes.BLL.Models
{
    public class DungeonDTO
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public IEnumerable<CharacterDTO> Characters{ get; set; }
    }
}