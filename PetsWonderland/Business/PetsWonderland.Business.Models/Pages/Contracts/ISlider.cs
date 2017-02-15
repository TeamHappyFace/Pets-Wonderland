using System.Collections.Generic;

namespace PetsWonderland.Business.Models.Pages.Contracts
{
    public interface ISlider
    {
        int Id { get; set; }

        string Name { get; set; }

        string Position { get; set; }

        ICollection<Slide> Slides { get; set; }

        bool IsDeleted { get; set; }
    }
}