//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2022 Simone Di Fonzo. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using BTSolution.DAL.DTO;


namespace BTSolution.DAL.Repository.Interfaces;

public interface IUserRepository
{
    #region Methods - Public

    void AddUser(UserDTO userDto);
    void DeleteUser(int userId);
    UserDTO GetUserById(int userId);
    IEnumerable<UserDTO> GetUsers();
    void UpdateUser(UserDTO userDto);

    #endregion
}