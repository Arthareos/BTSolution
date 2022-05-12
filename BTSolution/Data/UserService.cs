//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2022 Simone Di Fonzo. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using BTSolution.BL.Interfaces;
using BTSolution.DAL.DTO;


namespace BTSolution.Data;

public class UserService
{
    #region Members

    private readonly IUserLogic _userLogic;

    #endregion

    #region Constructors

    public UserService(IUserLogic userLogic)
    {
        _userLogic = userLogic;
    }

    #endregion

    #region Methods - Public

    public void AddUser(UserDTO userDto)
    {
        _userLogic.AddUser(userDto);
    }

    public void DeleteUser(int userId)
    {
        _userLogic.DeleteUser(userId);
    }

    public async Task<UserDTO> GetUserById(int userId)
    {
        return await Task.FromResult(_userLogic.GetUserById(userId));
    }

    public async Task<IEnumerable<UserDTO>> GetUsers()
    {
        return await Task.FromResult(_userLogic.GetUsers());
    }

    public void UpdateUser(UserDTO userDto)
    {
        _userLogic.UpdateUser(userDto);
    }

    public async Task<int> GetUserCount()
    {
        return await Task.FromResult(_userLogic.GetUserCount());
    }

    #endregion
}