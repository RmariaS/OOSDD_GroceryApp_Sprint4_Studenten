using Grocery.Core.Models;
using Grocery.Core.Models;

namespace TestCore
{
    // Tests voor UC13 - Role functionaliteit
    [TestFixture]
    public class TestUC13Roles
    {
        // Happy flow - Controleer of Role enum bestaat en correct is
        [Test]
        public void RoleEnum_HasNoneValue()
        {
            // Arrange & Act
            Role role = Role.None;

            // Assert
            Assert.AreEqual(Role.None, role);
        }

        [Test]
        public void RoleEnum_HasAdminValue()
        {
            // Arrange & Act
            Role role = Role.Admin;

            // Assert
            Assert.AreEqual(Role.Admin, role);
        }

        // Happy flow - Test Client met Role property
        [Test]
        public void Client_CanHaveRoleProperty()
        {
            // Arrange
            var client = new Client(1, "testuser", "Test User", "password", Role.None);

            // Act
            client.Role = Role.Admin;

            // Assert
            Assert.AreEqual(Role.Admin, client.Role);
        }

        // Happy flow - Test default Role is None
        [Test]
        public void Client_DefaultRoleIsNone()
        {
            // Arrange & Act
            var client = new Client(1, "testuser", "Test User", "password", Role.None);

            // Assert
            Assert.AreEqual(Role.None, client.Role);
        }

        // Unhappy flow - Reguliere client is geen admin
        [Test]
        public void Client_WithRoleNone_IsNotAdmin()
        {
            // Arrange
            var client = new Client(1, "user1", "User One", "password", Role.None);

            // Act
            bool isAdmin = client.Role == Role.Admin;

            // Assert
            Assert.IsFalse(isAdmin);
        }

        // Happy flow - Admin check werkt correct
        [Test]
        public void Client_WithRoleAdmin_IsAdmin()
        {
            // Arrange
            var client = new Client(1, "user3", "Admin User", "password", Role.Admin);

            // Act
            bool isAdmin = client.Role == Role.Admin;

            // Assert
            Assert.IsTrue(isAdmin);
        }
    }
}