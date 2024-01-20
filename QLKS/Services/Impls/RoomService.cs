using Microsoft.EntityFrameworkCore;
using HotelManagement.Models;
using HotelManagement.Repositories;
using HotelManagement.Repositories.Interfaces;
using HotelManagement.DTO.Controls;
using AutoMapper;

namespace HotelManagement.Services.Impls
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepo _roomRepo;
        private readonly IMapper _mapper;

        public RoomService(IRoomRepo roomRepo, IMapper mapper)
        {
            _roomRepo = roomRepo;
            _mapper = mapper;
        }

        public async Task Create(RoomDTO room)
        {
            await _roomRepo.Add(_mapper.Map<Room>(room) );
        }

        public Task<List<Room>> GetAllRoom()
        {
            return _roomRepo.FindAll().ToListAsync();
        }
        public async Task Delete(int id)
        {
            await _roomRepo.Delete(id);
        }
        public async Task Update( Room room)
        {
            await _roomRepo.Update(room);
        }

        
    }
}
