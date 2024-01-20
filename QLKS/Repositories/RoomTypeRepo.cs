using HotelManagement.DbContext;
using HotelManagement.Models;
using HotelManagement.Repositories.Interfaces;

namespace HotelManagement.Repositories
{
    public class RoomTypeRepo : BaseRepo<RoomType, int>, IRoomTypeRepo { 
        public RoomTypeRepo(AppDbContext context) : base(context)
        {
        }
    }
}
