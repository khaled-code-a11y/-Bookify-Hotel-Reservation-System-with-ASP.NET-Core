

namespace DEPI.BLL.IServices
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomModel>> GetAllRoomsAsync();
        Task<RoomModel?> GetRoomByIdAsync(int roomId);
        Task AddRoomAsync(RoomDTO roomdto);
        Task UpdateRoomAsync(RoomDTO room, int roomId);
        Task DeleteRoomAsync(int roomId);
        Task<bool> checkAvailabiltyAsync(CheckAvailabiltyDTO checkAvailabilty);
        Task<int> ReserveRoomAsync(ReserveRoomDTO reserveRoom);
        Task<IEnumerable<RoomModel>> GetAvailableRoomsAsync(RoomSearchDTO search);
        Task<int> GetTotalRoomsBookingAsync();
        Task<int> GetTotalRevenueAsync();
        Task<List<RecentBookingDTO>> GetRecentBookingAsync();

    }

}
