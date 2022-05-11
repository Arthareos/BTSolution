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

    void AddUser(UserDTO userDTO);
    void DeleteUser(int id);
    UserDTO GetUserById(int id);
    IEnumerable<UserDTO> GetUsers();
    void UpdateUser(UserDTO userDTO);

    #endregion
}