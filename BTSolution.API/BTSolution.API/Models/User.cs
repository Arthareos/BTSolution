//   --------------------------------------------------------------------------------------------
//   <Copyright>
//       Copyright © 2022 Simone Di Fonzo. All rights reserved.
//   </Copyright>
//   --------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;


namespace BTSolution.API.Models;

public class User
{
    #region Properties

    [Key] public int UserId { get; set; }

    [Required] public string UserName { get; set; } = string.Empty;

    #endregion
}