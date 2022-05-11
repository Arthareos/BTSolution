//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2022 Simone Di Fonzo. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

namespace BTSolution.DAL.DTO;

public class AccessTokenDTO
{
    #region Properties

    public DateTime CreationDate { get; set; }
    public string Token { get; set; }
    public int TokenId { get; set; }
    public int UserId { get; set; }

    #endregion
}