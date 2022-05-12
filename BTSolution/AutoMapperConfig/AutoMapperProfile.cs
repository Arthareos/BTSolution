//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2022 Simone Di Fonzo. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using AutoMapper;

using BTSolution.DAL.DTO;
using BTSolution.DAL.Entities;


namespace BTSolution.AutoMapperConfig;

public class AutoMapperProfile : Profile
{
    #region Constructors

    public AutoMapperProfile()
    {
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<AccessToken, AccessTokenDTO>().ReverseMap();
    }

    #endregion
}