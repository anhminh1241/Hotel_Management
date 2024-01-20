using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelManagement.Models;
using HotelManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using HotelManagement.Services.Impls;
using HotelManagement.DbContext;
using HotelManagement.DTO.Controls;

namespace HotelManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        private readonly AppDbContext _appDbContext;

        public RoomController(IRoomService roomService, AppDbContext appDbContext)
        {
            _roomService = roomService;
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _roomService.GetAllRoom());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(RoomDTO room)
        {
            try
            {
                await _roomService.Create(room);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
            
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RoomDTO room)
        {
            try
            {
                var existingRoom = await _appDbContext.Rooms.FirstOrDefaultAsync(x=> x.Id == id);

                if (existingRoom == null)
                {
                    return NotFound("Room not found");
                }
                existingRoom.Id = id;
                existingRoom.RoomName = room.RoomName;
                existingRoom.Floor = room.Floor;
                existingRoom.RoomTypeId = room.RoomTypeId;
                existingRoom.RoomStatus = room.RoomStatus;

                await _roomService.Update(existingRoom);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            { 
                    var room = await _appDbContext.Rooms.FindAsync(id);
                    if (room == null)
                    {
                        throw new Exception("Room not found");
                    }

                    _appDbContext.Rooms.Remove(room);
                    await _appDbContext.SaveChangesAsync();
                    return Ok();

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }

        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> GetRoomById(int id)
        {
            try
            {
                var room = await _appDbContext.Rooms.Where(x => x.RoomTypeId == id).ToListAsync();
                if (room == null)
                {
                    throw new Exception("Room not found");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
