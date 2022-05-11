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

    public async void AddUser(UserDTO userDto)
    {
        await Task.Run(() => _userLogic.AddUser(userDto));
    }

    public async void DeleteUser(int userId)
    {
        await Task.Run(() => _userLogic.DeleteUser(userId));
    }

    public async Task<UserDTO> GetUserById(int userId)
    {
        return await Task.FromResult(_userLogic.GetUserById(userId));
    }

    public async Task<IEnumerable<UserDTO>> GetUsers()
    {
        return await Task.FromResult(_userLogic.GetUsers());
    }

    public async void UpdateUser(UserDTO userDto)
    {
        await Task.Run(() => _userLogic.UpdateUser(userDto));
    }

    #endregion
}