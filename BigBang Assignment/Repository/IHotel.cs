using BigBang_Assignment.Models;
using System.Collections.Generic;

namespace BigBang_Assignment.Repository
{
    public interface IHotel
    {
        IEnumerable<Hotel> GetAllHotels();
        Hotel GetHotelById(int hotelId);
        Hotel AddHotel(Hotel hotel);
        Hotel UpdateHotel(int hotelId, Hotel hotel);
        Hotel DeleteHotel(int hotelId);
        int GetHotelCount();
        IEnumerable<Hotel> FilterHotelsByLocation(string location);
        IEnumerable<Hotel> FilterHotelsByAmenities(string amenities);
    }
}
