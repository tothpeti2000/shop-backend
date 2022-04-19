using Domain.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class UserService
    {
        private readonly IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AsyncResult> CreateUser(User user)
        {
            return await repository.CreateUserAsync(user);
        }

        public async Task<AsyncResult> LoginUser(LoginCredentials data)
        {
            return await repository.LoginUserAsync(data);
        }
    }
}
