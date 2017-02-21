using System.Collections.Generic;
using PetsWonderland.Business.Models.Hotels;

namespace PetsWonderland.Business.MVP.Hotels.AddHotel.ViewModels
{
    public class AddHotelModel
    {
        public Hotel HotelToAdd { get; set; }

        public IList<Hotel> Hotels { get; set; }
    }
}
