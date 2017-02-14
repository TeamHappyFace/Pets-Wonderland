using System.ComponentModel.DataAnnotations;
using PetsWonderland.Business.Models.Pages.Contracts;

namespace PetsWonderland.Business.Models.Pages
{
    public class Slide : ISlide
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Title { get; set; }

        public string Caption { get; set; }

        public int SliderId { get; set; }

        public virtual ISlider Slider { get; set; }
    }
}
