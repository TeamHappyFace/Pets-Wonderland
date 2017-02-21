using System;

namespace PetsWonderland.Business.MVP.Identity.ChangeImage.Args
{
	public class GetImageArgs : EventArgs
	{
		public string UserId { get; set; }
	}
}
