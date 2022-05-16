//   --------------------------------------------------------------------------------------------
//   <Copyright>
//       Copyright © 2022 Simone Di Fonzo. All rights reserved.
//   </Copyright>
//   --------------------------------------------------------------------------------------------

using BTSolution.API.Models;

using Microsoft.EntityFrameworkCore;


namespace BTSolution.API.Data;

public class DataContext : DbContext
{
    #region Constructors

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    #endregion

    #region Properties

    public DbSet<AccessToken> AccessTokens { get; set; }

    public DbSet<User?> Users { get; set; }

    #endregion
}