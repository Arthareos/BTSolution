//   --------------------------------------------------------------------------------------------
//   <Copyright>
//       Copyright © 2022 Simone Di Fonzo. All rights reserved.
//   </Copyright>
//   --------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BTSolution.API.Models;

public class AccessToken
{
    #region Properties

    [Key] public int AccessTokenId { get; set; }

    [Required] public DateTime CreationDate { get; set; } = DateTime.Now;

    [Required] public string Token { get; set; } = string.Empty;

    [Required] public User User { get; set; }

    #endregion
}