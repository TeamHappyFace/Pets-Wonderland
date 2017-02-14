using System.ComponentModel.DataAnnotations;

namespace PetsWonderland.Business.Models.Pages
{
    public class Slide
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Title { get; set; }

        public string Caption { get; set; }

        public int SliderId { get; set; }

        public virtual Slider Slider { get; set; }
    }
}
