using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SwordsAndSlimes.WEB.Models
{
    public class CharacterAboutViewModel
    {
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Класс")]
        public string Class { get; set; }
        [Display(Name = "Уровень")]
        public int Level { get; set; }
        [Display(Name = "Здоровье")]
        public int Health { get; set; }
        [Display(Name = "Сила атаки")]
        public int Attack { get; set; }
        [Display(Name = "Защита")]
        public int Defence { get; set; }
        [Display(Name = "Крит урон")]
        public int CritDamage { get; set; }
        [Display(Name = "Шанс Крита")]
        public int CritChance { get; set; }
        [Display(Name = "Восстановление энергии")]
        public int EnergyRecharge { get; set; }
        [Display(Name = "Мастерство стихий")]
        public int Endurance { get; set; }
        public ICollection<MonsterIndexViewModel> Monsters { get; set; }
        public ICollection<WeaponIndexViewModel> Weapons { get; set; }
    }
}