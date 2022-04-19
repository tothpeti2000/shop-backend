using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        public Task<AsyncResult> CreateUserAsync(User user);
        public Task<AsyncResult> LoginUserAsync(LoginCredentials data);
    }
}
