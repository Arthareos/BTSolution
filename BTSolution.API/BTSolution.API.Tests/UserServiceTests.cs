// --------------------------------------------------------------------------------------------
// <Copyright>
//     Copyright © 2022 Simone Di Fonzo. All rights reserved.
// </Copyright>
// --------------------------------------------------------------------------------------------

using BTSolution.API.Models;
using BTSolution.API.Repositories.Interfaces;
using BTSolution.API.Services;

using Moq;


namespace BTSolution.API.Tests;

public class UserServiceTests
{
    #region Members

    private readonly UserService _userService;
    private readonly Mock<IUserRepository> _userRepository = new();

    #endregion

    #region Constructors

    public UserServiceTests()
    {
        _userService = new(_userRepository.Object);
    }

    #endregion

    #region Methods - Public

    [Fact]
    public async Task GetUser()
    {
        // Arrange
        var userId = 1;
        var userName = "test";
        var user = new User {UserId = userId, UserName = userName};

        _userRepository.Setup(x => x.GetUser(userId)).ReturnsAsync(user);

        // Act
        var dbUser = await _userService.GetUser(userId);

        // Assert
        Assert.Equal(user, dbUser);
    }

    [Fact]
    public async Task GetUsers()
    {
        // Arrange
        var userName = "test";
        var userList = new List<User> {
            new() {UserId = 1, UserName = userName}
        };

        _userRepository.Setup(x => x.GetUsers()).ReturnsAsync(userList);

        // Act
        var dbUserList = (await _userService.GetUsers()).Where(u => u.UserName == userName).ToList();

        // Assert
        Assert.True(userList[0].Equals(dbUserList[0]));
    }

    #endregion
}