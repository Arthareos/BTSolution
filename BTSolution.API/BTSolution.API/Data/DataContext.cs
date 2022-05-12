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
    public DataContext(DbContextOptions<DataContext> options) : base(options) {}

    public DbSet<User> Users { get; set; }
    public DbSet<AccessToken> AccessTokens { get; set; }
}