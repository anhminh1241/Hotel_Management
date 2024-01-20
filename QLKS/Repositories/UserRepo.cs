using HotelManagement.DbContext;
using HotelManagement.Models;
using HotelManagement.Repositories.Interfaces;

namespace HotelManagement.Repositories
{
    public class UserRepo : BaseRepo<User, int>, IUserRepo
    {
        public UserRepo(AppDbContext context) : base(context)
        {
           
        }
    }
}
