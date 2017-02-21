using System;

namespace PetsWonderland.Business.MVP.Hotels.GetAllHotels.Args
{
    public class GetAllHotelsArgs : EventArgs
    {
        public int StartAt { get; set; }

        public int Count { get; set; }
    }
}
