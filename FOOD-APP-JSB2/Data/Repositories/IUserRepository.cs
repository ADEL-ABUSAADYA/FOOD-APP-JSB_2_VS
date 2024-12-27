using FOOD_APP_JSB_2.Models;
using Microsoft.EntityFrameworkCore;

namespace FOOD_APP_JSB_2.Data.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<(int ID, bool TwoFactorAuth)> LogInUser(string email, string password);
    }
}
