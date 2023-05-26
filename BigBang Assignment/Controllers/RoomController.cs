using BigBang_Assignment.Models;
using BigBang_Assignment.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigBang_Assignment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoom _roomRepository;

        public RoomController(IRoom roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet("hotel/{hotelId}")]
        public async Task<IActionResult> GetRoomsByHotelId(int hotelId)
        {
            try
            {
                var rooms = await _roomRepository.GetRoomsByHotelId(hotelId);
                return Ok(rooms);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving rooms.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomById(int id)
        {
            try
            {
                var room = await _roomRepository.GetRoomById(id);
                if (room == null)
                    return NotFound();

                return Ok(room);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving the room.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddRoom(Room room)
        {
            try
            {
                await _roomRepository.AddRoom(room);
                return CreatedAtAction(nameof(GetRoomById), new { id = room.RoomId }, room);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while adding the room.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(int id, Room room)
        {
            try
            {
                await _roomRepository.UpdateRoom(id, room);
                return Ok(room);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while updating the room.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            try
            {
                await _roomRepository.DeleteRoom(id);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while deleting the room.");
            }
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetRoomCount()
        {
            try
            {
                var roomCount = await _roomRepository.GetRoomCount();
                return Ok(roomCount);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving room count.");
            }
        }

       
    }
}
