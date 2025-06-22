using FUMiniHotelSystem.Models;
using System;
using System.Collections.Generic;

namespace FUMiniHotelSystem.BusinessLogic
{
    public interface IBookingService
    {
        List<BookingReservation> GetAllBookings();
        List<BookingReservation> GetBookingsByCustomerId(int customerId);
        BookingReservation GetBookingById(int id);
        bool AddBooking(BookingReservation booking);
        bool UpdateBooking(BookingReservation booking);
        bool CancelBooking(int id);
        List<RoomInformation> GetAvailableRooms(DateTime startDate, DateTime endDate);
        bool IsRoomAvailable(int roomId, DateTime startDate, DateTime endDate, int? excludeBookingId = null);
        bool ValidateBooking(BookingReservation booking);
    }
}
