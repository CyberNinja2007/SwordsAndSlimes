using System.Collections.Generic;

namespace SwordsAndSlimes.BLL.Models
{
    public class CharacterDTO
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public string Class { get; set; }
        public int Defence { get; set; }
        public int CritDamage { get; set; }
        public int CritChance { get; set; }
        public int EnergyRecharge { get; set; }
        public int Endurance { get; set; }
        public IEnumerable<MonsterDTO> Monsters { get; set; }
        public IEnumerable<WeaponDTO> Weapons { get; set; }
    }
}