using DataModels;
using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<DtoUser> _userRepo;
      
        public UserService(IRepository<DtoUser> userRepo)
        {
            _userRepo = userRepo;
           
        }

        public UserModel Authenticate(string username, string password)
        {

            throw new NotImplementedException();


        }

        public void Register(RegisterModel registerModel)
        {
            
        }
    }
}
