using HotelManagement.Models;
using HotelManagement.Repositories.Interfaces;

namespace HotelManagement.Services.Impls
{
    public class BookingService
    {
        private readonly IBookingRepo _bookingRepo;

        public BookingService(IBookingRepo bookingRepo)
        {
            _bookingRepo = bookingRepo;

            //public async Task Create(Room room)
            //{
            //    await _roomRepo.Add(room);
            //}

            //public Task<List<Room>> GetAllRoom()
            //{
            //    return _roomRepo.FindAll().ToListAsync();
            //}
        }
    }
}
