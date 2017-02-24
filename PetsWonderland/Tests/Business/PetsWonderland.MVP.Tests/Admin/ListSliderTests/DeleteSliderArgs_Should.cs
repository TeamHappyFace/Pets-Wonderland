using NUnit.Framework;
using PetsWonderland.Business.MVP.Admin.ListSlider.Args;

namespace PetsWonderland.MVP.Tests.Admin.ListSliderTests
{
    [TestFixture]
    public class DeleteSliderArgs_Should
    {
        [TestCase(32)]   
        [TestCase(321)]   
        public void ReturnSliderIdSetValueCorrectly(int sliderId)
        {
            var deleteArgs = new DeleteSliderArgs{ SliderId = sliderId };

            Assert.AreEqual(deleteArgs.SliderId, sliderId);
        }
    }
}
