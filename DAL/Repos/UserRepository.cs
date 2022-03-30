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

        public async Task<AsyncResult> LoginUser(LoginCredentials data)
        {
            var user = await userManager.FindByNameAsync(data.UserName);

            if (user == null)
            {
                return new AsyncResult
                {
                    Succeeded = false,
                    ErrorMessage = "Sorry, we couldn't find a user with the given username."
                };
            }

            var passwordOK = await userManager.CheckPasswordAsync(user, data.Password);

            if (!passwordOK)
            {
                return new AsyncResult
                {
                    Succeeded = false,
                    ErrorMessage = "Wrong password! Please, try again!"
                };
            }

            return new AsyncResult
            {
                Succeeded = true
            };
        }
    }
}
