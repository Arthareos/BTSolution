//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2022 Simone Di Fonzo. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using BTSolution.DAL.DTO;


namespace BTSolution.DAL.Repository.Interfaces;

public interface IAccessTokenRepository
{
    #region Methods - Public

    void CreateToken(int userId);
    int GetNumberOfTokens();
    IEnumerable<AccessTokenDTO> GetAllTokens();
    IEnumerable<AccessTokenDTO> GetTokensByUserId(int id);

    #endregion
}