//   --------------------------------------------------------------------------------------------
//   <Copyright>
//       Copyright © 2022 Simone Di Fonzo. All rights reserved.
//   </Copyright>
//   --------------------------------------------------------------------------------------------

namespace BTSolution.API.Models;

public class AccessTokenForTransfer
{
    #region Constructors

    public AccessTokenForTransfer(AccessToken token)
    {
        AccessTokenId = token.AccessTokenId;
        ExpiryDate = token.CreationDate.Subtract(new DateTime(1970, 1, 1)).TotalSeconds.ToString();
        Token = token.Token;
        UserId = token.UserId;
    }

    #endregion

    #region Properties

    public int AccessTokenId { get; set; }
    public string ExpiryDate { get; set; }
    public string Token { get; set; }
    public int UserId { get; set; }
    public string? UserName { get; set; }

    #endregion

    #region Methods - Public

    public static AccessTokenForTransfer ConvertForTransfer(AccessToken token)
    {
        return new AccessTokenForTransfer(token);
    }

    public static IEnumerable<AccessTokenForTransfer> ConvertForTransfer(IEnumerable<AccessToken> tokens)
    {
        return tokens.Select(accessToken => new AccessTokenForTransfer(accessToken)).ToList();
    }

    #endregion
}