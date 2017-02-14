using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PetsWonderland.Business.Common.Constants;
using PetsWonderland.Business.Models.Pages.Contracts;

namespace PetsWonderland.Business.Models.Pages
{
    public class Slider : ISlider
    {
        private ICollection<ISlide> slides;

        public Slider()
        {
            this.slides = new HashSet<ISlide>();    
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(ValidationConstants.NameMinLength)]
        [MaxLength(ValidationConstants.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(ValidationConstants.NameMinLength)]
        [MaxLength(ValidationConstants.NameMaxLength)]
        public string Position { get; set; }

        public virtual ICollection<ISlide> Slides
        {
            get
            {
                return this.slides;
            }

            set
            {
                this.slides = value;
            }
        }

        public bool IsDeleted { get; set; }
    }
}
