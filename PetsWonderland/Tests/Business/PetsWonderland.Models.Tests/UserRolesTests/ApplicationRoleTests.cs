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
            var obj = new ApplicationRole();

            Assert.IsInstanceOf<ApplicationRole>(obj);
        }

        [TestCase("Admin")]
        [TestCase("Manager")]
        public void Constructor_ShouldHaveConstructorWithNameParameter(string roleName)
        {
            var obj = new ApplicationRole(roleName);

            Assert.IsInstanceOf<ApplicationRole>(obj);
            Assert.AreEqual(obj.Name, roleName);
        }

        [TestCase("Lorem ipsum dolro sit amet")]
        public void HotelId_ShouldGetAndSetDataCorrectly(string description)
        {
            var role = new ApplicationRole { Description = description };

            Assert.AreEqual(role.Description, description);
        }
    }
}
