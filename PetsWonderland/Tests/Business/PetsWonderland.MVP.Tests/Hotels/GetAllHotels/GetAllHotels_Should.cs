using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.MVP.Hotels.GetAllHotels;
using PetsWonderland.Business.MVP.Hotels.GetAllHotels.Args;
using PetsWonderland.Business.MVP.Hotels.GetAllHotels.ViewModels;
using PetsWonderland.Business.MVP.Hotels.GetAllHotels.Views;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.MVP.Tests.Hotels.GetAllHotels
{
    [TestFixture]
    public class GetAllHotels_Should
    {
       /* [Test]
        public void ReturnAllHotelRequestsToView_WhenParameterAreValid()
        {
            var mockedGetAllHotelsView = new Mock<IGetAllHotelsView>();
            var mockedHotelService = new Mock<IHotelService>();

            mockedGetAllHotelsView
                .SetupGet(x => x.Model)
                .Returns(new GetAllHotelsModel());

            var getAllHotelsPresenter = new GetAllHotelsPresenter(
                mockedGetAllHotelsView.Object,
                mockedHotelService.Object);

            var args = new GetAllHotelsArgs()
            {
                Count = 1,
                StartAt = 0,             
            };

            mockedGetAllHotelsView.Raise(x => x.GetAllHotels += null, args);

            mockedHotelService.Verify(
                x => x.GetHotels(args.StartAt, args.Count),
                Times.Once);
        }*/
    }
}
