//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2022 Simone Di Fonzo. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using BTSolution.BL.Interfaces;
using BTSolution.DAL.DTO;


namespace BTSolution.Data;

public class AccessTokenService
{
    #region Members

    private readonly IAccessTokenLogic _accessTokenLogic;

    #endregion

    #region Constructors

    public AccessTokenService(IAccessTokenLogic accessTokenLogic)
    {
        _accessTokenLogic = accessTokenLogic;
    }

    #endregion

    #region Methods - Public

    public async void CreateToken(int userId)
    {
        await Task.Run(() => _accessTokenLogic.CreateToken(userId));
    }

    public async Task<IEnumerable<AccessTokenDTO>> GetAccessTokensByUserId(int userId)
    {
        return await Task.FromResult(_accessTokenLogic.GetAccessTokensByUserId(userId));
    }

    public async Task<IEnumerable<AccessTokenDTO>> GetAllAccessTokens()
    {
        return await Task.FromResult(_accessTokenLogic.GetAllAccessTokens());
    }

    public async Task<int> GetNumberOfTokens()
    {
        return await Task.FromResult(_accessTokenLogic.GetNumberOfTokens());
    }

    #endregion
}