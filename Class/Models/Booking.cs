namespace BigBang_Assignment.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public DateTime BookedDate { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public Hotel? Hotel { get; set; }
        public Room? Room { get; set; }
        public Customer? Customer { get; set; }
        public Booking()
        {
            BookedDate = DateTime.Now;
        }
    }
}
