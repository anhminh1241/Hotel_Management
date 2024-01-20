using HotelManagement.DbContext;
using HotelManagement.Models;
using HotelManagement.Repositories.Interfaces;

namespace HotelManagement.Repositories
{
    public class BookingRepo : BaseRepo<Booking, int>, IBookingRepo
    {
        public BookingRepo(AppDbContext context) : base(context)
        {
        }
    }
}
