using DAL.DbObjects;
using Domain.Models;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<DbUser> userManager;

        public UserRepository(UserManager<DbUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<AsyncResult> CreateUser(User user)
        {
            var newUser = new DbUser
            {
                UserName = user.UserName,
                Email = user.Email
            };

            var result = await userManager.CreateAsync(newUser, user.Password);
            var error = result.Errors.FirstOrDefault();
            var errorMessage = error?.Description;

            return new AsyncResult
            {
                Succeeded = result.Succeeded,
                ErrorMessage = errorMessage
            };
        }
    }
}
