using BigBang_Assignment.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigBang_Assignment.Repository
{
    public class RoomRepository : IRoom
    {
        private readonly HotelContext _dbContext;

        public RoomRepository(HotelContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Room>> GetRooms()
        {
            try
            {
                return _dbContext.Rooms.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving room with ID : {ex.Message}");
                return null;
            }

        }


        public async Task<Room> GetRoomById(int RoomId)
        {
            return await _dbContext.Rooms.FindAsync(RoomId);
        }

        public async Task AddRoom(Room room)
        {
            _dbContext.Rooms.Add(room);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRoom(int RoomId, Room room)
        {
            var existingRoom = await _dbContext.Rooms.FindAsync(RoomId);

            if (existingRoom != null)
            {
                existingRoom.RoomName = room.RoomName;
                existingRoom.Price = room.Price;
                existingRoom.RoomAvailability = room.RoomAvailability;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteRoom(int RoomId)
        {
            var room = await _dbContext.Rooms.FindAsync(RoomId);

            if (room != null)
            {
                _dbContext.Rooms.Remove(room);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<int> GetRoomCount()
        {
            return await _dbContext.Rooms.CountAsync();
        }
    }
}
