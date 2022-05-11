//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2022 Simone Di Fonzo. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using System.Data.Common;

using BTSolution.BL.Interfaces;
using BTSolution.DAL.DTO;
using BTSolution.DAL.Repository.Interfaces;


namespace BTSolution.BL.Classes;

public class AccessTokenLogic : IAccessTokenLogic
{
    #region Members

    private readonly IAccessTokenRepository _accessTokenRepository;

    #endregion

    #region Constructors

    public AccessTokenLogic(IAccessTokenRepository accessTokenRepository)
    {
        _accessTokenRepository = accessTokenRepository;
    }

    #endregion

    #region Interface Members

    public void CreateToken(int userId)
    {
        try {
            _accessTokenRepository.CreateToken(userId);
        } catch (DbException exception) {
            throw exception;
        }
    }

    public IEnumerable<AccessTokenDTO> GetAccessTokensByUserId(int userId)
    {
        try {
            return _accessTokenRepository.GetAccessTokensByUserId(userId);
        } catch (DbException exception) {
            throw exception;
        }
    }

    public IEnumerable<AccessTokenDTO> GetAllAccessTokens()
    {
        try {
            return _accessTokenRepository.GetAllAccessTokens();
        } catch (DbException exception) {
            throw exception;
        }
    }

    public int GetNumberOfTokens()
    {
        try {
            return _accessTokenRepository.GetNumberOfTokens();
        } catch (DbException exception) {
            throw exception;
        }
    }

    #endregion
}