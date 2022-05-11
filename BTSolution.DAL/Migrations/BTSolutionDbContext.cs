//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2022 Simone Di Fonzo. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using BTSolution.DAL.Entities;

using Microsoft.EntityFrameworkCore;


namespace BTSolution.DAL.Migrations;

public class BTSolutionDbContext : DbContext
{
    #region Constructors

    public BTSolutionDbContext(DbContextOptions<BTSolutionDbContext> options) : base(options)
    {
    }

    #endregion

    #region Properties

    public DbSet<AccessToken> AccessTokens { get; set; }

    public DbSet<User> Users { get; set; }

    #endregion
}