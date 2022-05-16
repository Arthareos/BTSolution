// --------------------------------------------------------------------------------------------
// <Copyright>
//     Copyright © 2022 Simone Di Fonzo. All rights reserved.
// </Copyright>
// --------------------------------------------------------------------------------------------

using BTSolution.API.Models;


namespace BTSolution.API.Repositories.Interfaces;

public interface IUserRepository
{
    #region Methods - Public

    void CreateUser(User user);
    void DeleteUser(int userId);
    Task<List<User>> GetUsers();
    Task<User> GetUser(int userId);

    #endregion
}