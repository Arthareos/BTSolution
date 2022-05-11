//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2022 Simone Di Fonzo. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using System.Data.Common;

using BTSolution.BL.Interfaces;
using BTSolution.DAL.DTO;
using BTSolution.DAL.Repository.Interfaces;


namespace BTSolution.BL.Classes;

public class UserLogic : IUserLogic
{
    #region Members

    private readonly IUserRepository _userRepository;

    #endregion

    #region Constructors

    public UserLogic(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    #endregion

    #region Interface Members

    public void AddUser(UserDTO userDto)
    {
        try {
            _userRepository.AddUser(userDto);
        } catch (DbException exception) {
            throw exception;
        }
    }

    public void DeleteUser(int userId)
    {
        try {
            _userRepository.DeleteUser(userId);
        } catch (DbException exception) {
            throw exception;
        }
    }

    public UserDTO GetUserById(int userId)
    {
        try {
            return _userRepository.GetUserById(userId);
        } catch (DbException exception) {
            throw exception;
        }
    }

    public IEnumerable<UserDTO> GetUsers()
    {
        try {
            return _userRepository.GetUsers();
        } catch (DbException exception) {
            throw exception;
        }
    }

    public void UpdateUser(UserDTO userDto)
    {
        try {
            _userRepository.UpdateUser(userDto);
        } catch (DbException exception) {
            throw exception;
        }
    }

    #endregion
}