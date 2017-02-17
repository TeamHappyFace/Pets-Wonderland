using System.Collections.Generic;
using PetsWonderland.Business.Models.Hotels;

namespace PetsWonderland.Business.MVP.Hotels.GetAllHotels.ViewModels
{
	public class GetAllHotelsModel
	{
		public IList<Hotel> Hotels { get; set; }
	}
}
