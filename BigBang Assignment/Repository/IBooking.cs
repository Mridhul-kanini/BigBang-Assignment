using BigBang_Assignment.Models;
using System.Collections.Generic;

namespace BigBang_Assignment.Repository
{
    public interface IBookingRepository
    {
        IEnumerable<Booking> GetAllBookings();
        Booking GetBookingById(int bookingId);
        Booking AddBooking(Booking booking);
        Booking UpdateBooking(int bookingId, Booking booking);
        Booking DeleteBooking(int bookingId);
    }
}
