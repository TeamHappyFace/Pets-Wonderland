using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PetsWonderland.Business.Models.UserRoles;

namespace PetsWonderland.Models.Tests.UserRolesTests
{
    [TestFixture]
    public class ApplicationRoleTests
    {
        [Test]
        public void Constructor_ShouldHaveParameterlessConstructor()
        {
            // Arrange & Act
            var obj = new ApplicationRole();

            // Assert
            Assert.IsInstanceOf<ApplicationRole>(obj);
        }

        [TestCase("Admin")]
        [TestCase("Manager")]
        public void Constructor_ShouldHaveConstructorWithNameParameter(string roleName)
        {
            // Arrange & Act
            var obj = new ApplicationRole(roleName);

            // Assert
            Assert.IsInstanceOf<ApplicationRole>(obj);
            Assert.AreEqual(obj.Name, roleName);
        }

        [TestCase("Lorem ipsum dolro sit amet")]
        public void HotelId_ShouldGetAndSetDataCorrectly(string description)
        {
            // Arrange & Act
            var role = new ApplicationRole { Description = description };

            //Assert
            Assert.AreEqual(role.Description, description);
        }
    }
}
