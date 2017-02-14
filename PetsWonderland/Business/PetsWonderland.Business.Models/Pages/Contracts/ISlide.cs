namespace PetsWonderland.Business.Models.Pages.Contracts
{
    public interface ISlide
    {
        int Id { get; set; }

        string Image { get; set; }

        string Title { get; set; }

        string Caption { get; set; }

        int SliderId { get; set; }

        ISlider Slider { get; set; }
    }
}