using BigBang_Assignment.Models;
using System.ComponentModel.DataAnnotations;

namespace BigBang_Assignment.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public int Price { get; set; }
        public int RoomAvailability { get; set; }

        public Hotel? Hotel { get; set; }
    }
}
