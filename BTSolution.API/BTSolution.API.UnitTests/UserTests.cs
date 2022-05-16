using BTSolution.API.Controllers;
using BTSolution.API.Data;
using BTSolution.API.Models;

using Microsoft.AspNetCore.Authorization;

using Moq;


namespace BTSolution.API.UnitTests
{
    public class UserTests
    {
        private readonly UserController _userController;
        private readonly Mock<DataContext> _context = new();

        public UserTests()
        {
            _userController = new UserController(_context.Object);
        }

        [Test]
        public async Task GetByIdAsync_ShouldReturnUser_WhenUserExists()
        {
            //Arrange
            var user = new User{UserName = "whatever"};
            _context.Setup(x => x.)

            //Act

            //Assert
        }
    }
}