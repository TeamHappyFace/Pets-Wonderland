using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Data.Repositories;
using PetsWonderland.Business.Models.Animals;
using PetsWonderland.Business.Models.Pages;
using PetsWonderland.Business.Models.Pages.Contracts;

namespace PetsWonderland.Data.Tests.GenericRepositoryTests
{
    [TestFixture]
    public class GetFirst_Should
    {

        [TestCase("test")]
        public void ReturnCorrectObject_IfFound(string nameSearch)
        {
            // Arrange
            var data = new List<ISlider>
            {
                new Slider {Name = "test", Position = "asdas"},
                new Slider {Name = "as6dasdasd", Position = "4asdas"},        
            }
            .AsQueryable();

            var mockedSet = new Mock<IDbSet<ISlider>>();  
            mockedSet.As<IQueryable<ISlider>>().Setup(x => x.Provider).Returns(data.Provider);
            mockedSet.As<IQueryable<ISlider>>().Setup(x => x.Expression).Returns(data.Expression);
            mockedSet.As<IQueryable<ISlider>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockedSet.As<IQueryable<ISlider>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());

            var mockedContenxt = new Mock<IPetsWonderlandDbContext>();
            mockedContenxt.Setup(x => x.Set<ISlider>()).Returns(mockedSet.Object);
                      
            // Act                           
            var repo = new GenericRepository<ISlider>(mockedContenxt.Object);
            var result = repo.GetFirst(x => x.Name == nameSearch);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.AreEqual(result.Name, nameSearch);
        }
    }
}
