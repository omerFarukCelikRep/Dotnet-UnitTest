using Xunit;
using UnitTest.Functionality;
using System.Linq;

namespace UnitTest.Test
{
    public class UserManagementTesting
    {
        [Fact]
        public void Add_CreateUser()
        {
            // Arrange
            var userManagement = new UserManagement();
        
            // Act
            userManagement.Add(new("Ömer Faruk", "Çelik"));
        
            // Assert
            var savedUser = Assert.Single(userManagement.AllUsers);

            Assert.NotNull(savedUser); //checking that the usermanagement list is not empty
            Assert.Equal("Ömer Faruk", savedUser.firstName);
            Assert.Equal("Çelik", savedUser.lastName);

            Assert.False(savedUser.VerifiedEmail);
        }

        [Fact]
        public void Update_UpdatePhoneNumber()
        {
            // Arrange
            var userManagement = new UserManagement();
        
            // Act
            userManagement.Add(new("Ömer Faruk", "Çelik"));

            var firstUser = userManagement.AllUsers.First();

            firstUser.Phone = "5264216532";

            userManagement.UpdatePhone(firstUser);
        
            // Assert
            var savedUser = Assert.Single(userManagement.AllUsers);

            Assert.NotNull(savedUser);
            Assert.Equal("5264216532", savedUser.Phone);
        }
    }
}