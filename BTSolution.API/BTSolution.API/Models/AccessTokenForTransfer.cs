// --------------------------------------------------------------------------------------------
// <Copyright>
//     Copyright © 2022 Simone Di Fonzo. All rights reserved.
// </Copyright>
// --------------------------------------------------------------------------------------------

namespace BTSolution.API.Models;

public class AccessTokenForTransfer
{
    #region Constructors

    public AccessTokenForTransfer() {}
    public AccessTokenForTransfer(AccessToken token)
    {
        var creationDateToUnix = (int) Math.Truncate(token.CreationDate.Subtract(DateTime.UnixEpoch).TotalSeconds);
        var expiryDateToUnix = creationDateToUnix + token.Duration;

        AccessTokenId = token.AccessTokenId;
        ExpiryDate = expiryDateToUnix;
        Token = token.Token;
        UserId = token.UserId;
    }

    #endregion

    #region Properties

    public int AccessTokenId { get; set; }
    public int ExpiryDate { get; set; }
    public string Token { get; set; }
    public int UserId { get; set; }
    public string? UserName { get; set; }

    #endregion

    #region Methods - Public

    public static List<AccessTokenForTransfer> ConvertForTransfer(List<AccessToken> tokens)
    {
        return tokens.Select(accessToken => new AccessTokenForTransfer(accessToken)).ToList();
    }

    #endregion
}