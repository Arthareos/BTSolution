//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2022 Simone Di Fonzo. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using BTSolution.DAL.DTO;


namespace BTSolution.BL.Interfaces;

public interface IAccessTokenLogic
{
    #region Methods - Public

    void CreateToken(int userId);
    IEnumerable<AccessTokenDTO> GetAccessTokensByUserId(int userId);
    IEnumerable<AccessTokenDTO> GetAllAccessTokens();
    int GetNumberOfTokens();

    #endregion
}