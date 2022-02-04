using System.ComponentModel.DataAnnotations;

namespace SwordsAndSlimes.WEB.Models
{
    public class WeaponIndexViewModel
    {
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Уровень")]
        public int? Level { get; set; }
        [Display(Name = "Сила атаки")]
        public int? Attack { get; set; }
        [Display(Name = "Класс")]
        public string Class { get; set; }
    }
}