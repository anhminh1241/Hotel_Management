using HotelManagement.DbContext;
using HotelManagement.Models;
using HotelManagement.Repositories.Interfaces;

namespace HotelManagement.Repositories
{
    public class RoomRepo : BaseRepo<Room, int>, IRoomRepo
    {
        public RoomRepo(AppDbContext context) : base(context)
        {
        }
    }
}
