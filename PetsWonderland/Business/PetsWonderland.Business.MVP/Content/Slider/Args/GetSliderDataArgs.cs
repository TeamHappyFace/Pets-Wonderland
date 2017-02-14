using System;

namespace PetsWonderland.Business.MVP.Content.Slider.Args
{
    public class GetSliderDataArgs : EventArgs
    {
        public GetSliderDataArgs(string position)
        {
            this.Position = position;
        }

        public string Position { get; private set; }
    }
}
