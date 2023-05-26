using BigBang_Assignment.Models;
using BigBang_Assignment.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BigBang_Assignment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotel _hotelRepository;

        public HotelController(IHotel hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        [HttpGet]
        public IActionResult GetAllHotels()
        {
            try
            {
                var hotels = _hotelRepository.GetAllHotels();
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving hotels: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetHotelById(int id)
        {
            try
            {
                var hotel = _hotelRepository.GetHotelById(id);
                if (hotel == null)
                    return NotFound("Hotel not found.");

                return Ok(hotel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving the hotel: {ex.Message}");
            }
        }


        [HttpPost]
        public IActionResult AddHotel(Hotel hotel)
        {
            try
            {
                var newHotel = _hotelRepository.AddHotel(hotel);
                return CreatedAtAction(nameof(GetHotelById), new { id = newHotel.HotelId }, newHotel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding the hotel: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateHotel(int id, Hotel hotel)
        {
            try
            {
                var updatedHotel = _hotelRepository.UpdateHotel(id, hotel);
                if (updatedHotel == null)
                    return NotFound();

                return Ok(updatedHotel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the hotel: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHotel(int id)
        {
            try
            {
                var deletedHotel = _hotelRepository.DeleteHotel(id);
                if (deletedHotel == null)
                    return NotFound();

                return Ok(deletedHotel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the hotel: {ex.Message}");
            }
        }

        [HttpGet("count")]
        public IActionResult GetHotelCount()
        {
            try
            {
                var count = _hotelRepository.GetHotelCount();
                return Ok(count);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving the hotel count: {ex.Message}");
            }
        }

        [HttpGet("filter/location/{location}")]
        public IActionResult FilterHotelsByLocation(string location)
        {
            try
            {
                var filteredHotels = _hotelRepository.FilterHotelsByLocation(location);
                return Ok(filteredHotels);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while filtering hotels by location: {ex.Message}");
            }
        }

        [HttpGet("filter/amenities/{amenities}")]
        public IActionResult FilterHotelsByAmenities(string amenities)
        {
            try
            {
                var filteredHotels = _hotelRepository.FilterHotelsByAmenities(amenities);
                return Ok(filteredHotels);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while filtering hotels by amenities: {ex.Message}");
            }
        }
    }
}
