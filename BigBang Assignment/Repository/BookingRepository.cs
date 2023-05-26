using BigBang_Assignment.Models;
using System.Collections.Generic;
using System.Linq;

namespace BigBang_Assignment.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly HotelContext _context;

        public BookingRepository(HotelContext context)
        {
            _context = context;
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            return _context.Bookings.ToList();
        }

        public Booking GetBookingById(int bookingId)
        {
            try
            {
                return _context.Bookings.FirstOrDefault(b => b.BookingId == bookingId);
            }
            catch (Exception ex)
            {
               
                Console.WriteLine("An error occurred while retrieving the booking: " + ex.Message);
                return null; 
            }
        }


        public Booking AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
            return booking;
        }

        public Booking UpdateBooking(int bookingId, Booking booking)
        {
            var existingBooking = _context.Bookings.FirstOrDefault(b => b.BookingId == bookingId);
            if (existingBooking != null)
            {
                existingBooking.CheckIn = booking.CheckIn;
                existingBooking.CheckOut = booking.CheckOut;
                existingBooking.Hotel = booking.Hotel;
                existingBooking.Room = booking.Room;
                existingBooking.Customer = booking.Customer;
                _context.SaveChanges();
            }
            return existingBooking;
        }

        public Booking DeleteBooking(int bookingId)
        {
            var booking = _context.Bookings.FirstOrDefault(b => b.BookingId == bookingId);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
            }
            return booking;
        }
    }
}
