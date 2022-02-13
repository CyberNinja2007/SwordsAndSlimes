using System.ComponentModel.DataAnnotations;

namespace SwordsAndSlimes.WEB.Models
{
    public class DungeonIndexViewModel
    {
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Изображение")]
        public string Image { get; set; }
    }
}