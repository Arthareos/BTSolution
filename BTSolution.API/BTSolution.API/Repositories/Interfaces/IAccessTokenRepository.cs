// --------------------------------------------------------------------------------------------
// <Copyright>
//     Copyright © 2022 Simone Di Fonzo. All rights reserved.
// </Copyright>
// --------------------------------------------------------------------------------------------

using BTSolution.API.Models;


namespace BTSolution.API.Repositories.Interfaces;

public interface IAccessTokenRepository
{
    void CreateAccessToken(AccessToken accessToken);
    void DeleteUserAccessTokens(int userId);
    Task<List<AccessTokenForTransfer>> GetAccessTokens();
}