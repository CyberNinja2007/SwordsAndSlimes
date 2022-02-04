using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SwordsAndSlimes.WEB.Models
{
    public class CharacterAboutViewModel
    {
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Уровень")]
        public int? Level { get; set; }
        [Display(Name = "Здоровье")]
        public int? Health { get; set; }
        [Display(Name = "Сила атаки")]
        public int? Attack { get; set; }
        [Display(Name = "Класс")]
        public string Class { get; set; }
        public ICollection<MonsterIndexViewModel> Monsters { get; set; }
        public ICollection<WeaponIndexViewModel> Weapons { get; set; }
    }
}