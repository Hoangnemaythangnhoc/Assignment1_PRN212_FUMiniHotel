using FUMiniHotelSystem.Models;
using System.Collections.Generic;

namespace FUMiniHotelSystem.DataAccess
{
    public interface IRoomRepository
    {
        List<RoomInformation> GetAllRooms();
        RoomInformation GetRoomById(int id);
        void AddRoom(RoomInformation room);
        void UpdateRoom(RoomInformation room);
        void DeleteRoom(int id);
        List<RoomInformation> SearchRooms(string searchTerm);
        List<RoomType> GetAllRoomTypes();
    }
}
