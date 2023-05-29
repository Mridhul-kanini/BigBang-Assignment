using BigBang_Assignment.Models;
using BigBang_Assignment.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BigBang_Assignment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        [HttpGet]
        public IActionResult GetAllBookings()
        {
            try
            {
                var bookings = _bookingRepository.GetAllBookings();
                return Ok(bookings);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving bookings.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetBookingById(int BookingId)
        {
            try
            {
                var booking = _bookingRepository.GetBookingById(BookingId);
                if (booking == null)
                    return NotFound();

                return Ok(booking);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving the booking.");
            }
        }

        [HttpPost]
        public IActionResult AddBooking(Booking booking)
        {
            try
            {
                var newBooking = _bookingRepository.AddBooking(booking);
                if (newBooking == null)
                {
                    return BadRequest("Invalid booking data");
                }

                return CreatedAtAction(nameof(GetBookingById), new { id = newBooking.BookingId }, newBooking);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the booking: {ex.Message}");
                return StatusCode(500, "An error occurred while adding the booking. Please try again later.");
            }
        }


        [HttpPut("{id}")]
        public IActionResult UpdateBooking(int BookingId, Booking booking)
        {
            try
            {
                var updatedBooking = _bookingRepository.UpdateBooking(BookingId, booking);
                if (updatedBooking == null)
                    return NotFound();

                return Ok(updatedBooking);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while updating the booking.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int BookingId)
        {
            try
            {
                var deletedBooking = _bookingRepository.DeleteBooking(BookingId);
                if (deletedBooking == null)
                    return NotFound();

                return Ok(deletedBooking);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while deleting the booking.");
            }
        }
    }
}
