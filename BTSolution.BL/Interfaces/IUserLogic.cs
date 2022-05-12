//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2022 Simone Di Fonzo. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using BTSolution.DAL.DTO;


namespace BTSolution.BL.Interfaces;

public interface IUserLogic
{
    #region Methods - Public

    void AddUser(UserDTO userDto);
    void DeleteUser(int userId);
    UserDTO GetUserById(int userId);
    IEnumerable<UserDTO> GetUsers();
    void UpdateUser(UserDTO userDto);
    public int GetUserCount();

    #endregion
}