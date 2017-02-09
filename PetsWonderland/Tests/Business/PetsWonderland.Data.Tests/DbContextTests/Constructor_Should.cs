using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PetsWonderland.Business.Data;

namespace PetsWonderland.Data.Tests.DbContextTests
{
    [TestFixture]
    public class Constructor_Should
    {
        public void HaveParameterlessConstructor()
        {
            // Arrange & Act
            var dbContext = new PetsWonderlandDbContext();

            // Assert
            Assert.IsInstanceOf<PetsWonderlandDbContext>(dbContext);
        }


    }
}
