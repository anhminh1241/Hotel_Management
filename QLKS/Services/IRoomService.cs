using HotelManagement.DTO.Controls;
using HotelManagement.Models;

namespace HotelManagement.Services
{
    public interface IRoomService
    {
       Task<List<Room>> GetAllRoom(); 
       Task Create(RoomDTO room);
       Task Delete(int id);
       Task Update(Room existingRoom);
    }
}
