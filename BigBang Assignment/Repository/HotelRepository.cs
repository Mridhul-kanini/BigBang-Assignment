using BigBang_Assignment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BigBang_Assignment.Repository
{
    public class HotelRepository : IHotel
    {
        private readonly HotelContext _context;

        public HotelRepository(HotelContext context)
        {
            _context = context;
        }

        public IEnumerable<Hotel> GetAllHotels()
        {
            return _context.Hotels.ToList();
        }

        public Hotel GetHotelById(int hotelId)
        {
            return _context.Hotels.Find(hotelId);
        }

        public Hotel AddHotel(Hotel hotel)
        {
           
            _context.Hotels.Add(hotel);
            _context.SaveChanges();

            return hotel;
        }

        public Hotel UpdateHotel(int hotelId, Hotel hotel)
        {
            var existingHotel = _context.Hotels.FirstOrDefault(h => h.HotelId == hotelId);

            if (existingHotel == null)
                return null;

            existingHotel.HotelName = hotel.HotelName;
            existingHotel.HotelLocation = hotel.HotelLocation;
            existingHotel.HotelAmenities = hotel.HotelAmenities;

            _context.SaveChanges();

            return existingHotel;
        }

        public Hotel DeleteHotel(int hotelId)
        {
            var hotel = _context.Hotels.FirstOrDefault(h => h.HotelId == hotelId);

            if (hotel == null)
                return null;

            _context.Hotels.Remove(hotel);
            _context.SaveChanges();

            return hotel;
        }

        public int GetHotelCount()
        {
            return _context.Hotels.Count();
        }

        public IEnumerable<Hotel> FilterHotelsByLocation(string location)
        {
            return _context.Hotels.Where(h => h.HotelLocation == location).ToList();
        }

        public IEnumerable<Hotel> FilterHotelsByAmenities(string amenities)
        {
            return _context.Hotels.Where(h => h.HotelAmenities.Contains(amenities)).ToList();
        }
    }
}
