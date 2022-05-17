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

public class AccessTokenServiceTests
{
    #region Members

    private readonly AccessTokenService _accessTokenService;
    private readonly Mock<IUserRepository> _userRepository = new();
    private readonly Mock<IAccessTokenRepository> _accessTokenRepository = new();

    #endregion

    #region Constructors

    public AccessTokenServiceTests()
    {
        _accessTokenService = new(_userRepository.Object, _accessTokenRepository.Object);
    }

    #endregion

    #region Methods - Public

    [Fact]
    public async Task GetValidAccessTokens()
    {
        // Arrange
        var accessTokenList = new List<AccessTokenForTransfer> {
            new() {
                AccessTokenId = 1,
                ExpiryDate = (int) Math.Truncate(DateTime.Now.Subtract(DateTime.UnixEpoch).TotalSeconds) + 10,
                Token = Guid.NewGuid().ToString(),
                UserId = 1,
                UserName = "test"
            }
        };

        _accessTokenRepository.Setup(x => x.GetAccessTokens()).ReturnsAsync(accessTokenList);

        // Act
        var dbAccessTokenList = (await _accessTokenService.GetValidAccessTokens()).ToList();

        // Assert
        Assert.True(accessTokenList[0].Equals(dbAccessTokenList[0]));
    }

    #endregion
}