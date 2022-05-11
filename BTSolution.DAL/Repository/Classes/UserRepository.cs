//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2022 Simone Di Fonzo. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using System.Data;

using AutoMapper;

using BTSolution.DAL.DTO;
using BTSolution.DAL.Entities;
using BTSolution.DAL.Migrations;
using BTSolution.DAL.Repository.Interfaces;

using Microsoft.EntityFrameworkCore;


namespace BTSolution.DAL.Repository.Classes;

public class UserRepository : IUserRepository
{
    #region Members

    private readonly BTSolutionDbContext _dbContext;
    private readonly IMapper _mapper;

    #endregion

    #region Constructors

    public UserRepository(BTSolutionDbContext dbContext, IMapper mapper)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }

    #endregion

    #region Interface Members

    public void AddUser(UserDTO userDTO)
    {
        _ = userDTO ?? throw new DbUpdateException();

        User? user = _mapper.Map<User>(userDTO);
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }

    public void DeleteUser(int id)
    {
        UserDTO? user = GetUserById(id);
        _ = user ?? throw new DataException();

        UserDTO? userDTO = _mapper.Map<UserDTO>(user);
        _dbContext.Remove(userDTO);
        _dbContext.SaveChanges();
    }

    public UserDTO GetUserById(int userId)
    {
        User? user = _dbContext.Users.FirstOrDefault(user => user.UserId == userId);
        _ = user ?? throw new DataException();

        UserDTO? userDTO = _mapper.Map<UserDTO>(user);
        return userDTO;
    }

    public IEnumerable<UserDTO> GetUsers()
    {
        List<User>? users = _dbContext.Users.ToList();
        _ = users ?? throw new DataException();

        List<UserDTO> usersDTO = _mapper.Map<List<UserDTO>>(users);
        return usersDTO;
    }

    public void UpdateUser(UserDTO userDTO)
    {
        User? user = _dbContext.Users.FirstOrDefault(user => user.UserId == userDTO.UserId);
        _ = user ?? throw new DataException();

        UserDTO? newUser = _mapper.Map<UserDTO>(userDTO);
        _dbContext.Entry(user).CurrentValues.SetValues(newUser);
        _dbContext.SaveChanges();
    }

    #endregion
}