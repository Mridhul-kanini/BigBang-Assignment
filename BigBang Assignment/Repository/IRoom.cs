using BigBang_Assignment.Models;

namespace BigBang_Assignment.Repository
{
    public interface IRoom
    {
        Task<IEnumerable<Room>> GetRooms();
        Task<Room> GetRoomById(int roomId);
        Task AddRoom(Room room);
        Task UpdateRoom(int roomId, Room room);
        Task DeleteRoom(int roomId);
        Task<int> GetRoomCount();
    }
}
