using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SwordsAndSlimes.WEB.Models
{
    public class DungeonAboutViewModel
    {
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Изображение")]
        public string Image { get; set; }
        public ICollection<CharacterIndexViewModel> Characters { get; set; }
    }
}