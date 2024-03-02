using System.Collections.Generic;
using System.Threading.Tasks;
using HandMadeCraftAdminServer.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace HandMadeCraftAdminServer.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetUserById(string id);
        Task UpdateUser(User user);
        Task DeleteUser(string id);
    }
}