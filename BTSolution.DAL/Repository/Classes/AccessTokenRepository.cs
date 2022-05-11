//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2022 Simone Di Fonzo. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using System.Data;

using AutoMapper;

using BTSolution.DAL.DTO;
using BTSolution.DAL.Entities;
using BTSolution.DAL.Migrations;
using BTSolution.DAL.Repository.Interfaces;


namespace BTSolution.DAL.Repository.Classes;

public class AccessTokenRepository : IAccessTokenRepository
{
    #region Members

    private readonly BTSolutionDbContext _dbContext;
    private readonly IMapper _mapper;

    #endregion

    #region Constructors

    public AccessTokenRepository(BTSolutionDbContext dbContext, IMapper mapper)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }

    #endregion

    #region Interface Members

    public void CreateToken(int userId)
    {
        string token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

        AccessTokenDTO accessTokenDTO = new(){
            CreationDate = DateTime.Now,
            Token = token,
            UserId = userId,
            TokenId = GetNumberOfTokens()
        };

        AccessToken accessToken = _mapper.Map<AccessToken>(accessTokenDTO);
        _dbContext.AccessTokens.Add(accessToken);
        _dbContext.SaveChanges();
    }

    public int GetNumberOfTokens()
    {
        return _dbContext.AccessTokens.ToList().Count;
    }

    public IEnumerable<AccessTokenDTO> GetAllTokens()
    {
        List<AccessToken>? accessTokens = _dbContext.AccessTokens.ToList();
        _ = accessTokens ?? throw new DataException();

        List<AccessTokenDTO> accessTokenDtos = _mapper.Map<List<AccessTokenDTO>>(accessTokens);
        return accessTokenDtos;
    }

    public IEnumerable<AccessTokenDTO> GetTokensByUserId(int userId)
    {
        List<AccessToken>? accessTokens = _dbContext.AccessTokens.Where(token => token.UserId == userId).ToList();
        _ = accessTokens ?? throw new DataException();

        List<AccessTokenDTO> accessTokenDtos = _mapper.Map<List<AccessTokenDTO>>(accessTokens);
        return accessTokenDtos;
    }

    #endregion
}