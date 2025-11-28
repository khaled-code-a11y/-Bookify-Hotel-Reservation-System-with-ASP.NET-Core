

namespace DEPI.DAL.IRepositories
{
    public interface IRoomRepository
    {
        Task<IEnumerable<RoomModel>> GetAllRoomsAsync();
        Task<RoomModel?> GetRoomByIdAsync(int roomId);
        Task AddRoomAsync(RoomModel room);
        Task UpdateRoomAsync(RoomModel room);
        Task DeleteRoomAsync(RoomModel room);
        Task<bool> CheckAvailabilityForDatesAsync(int roomId , DateTime startDate , DateTime endDate);
        Task<int> ReserveRoomAsync(ReservedroomModel reservedRoom);
        Task<IEnumerable<RoomModel>> GetAvailableRoomsAsync(DateTime startDate,DateTime EndDate,int roomCapacity );

    }
}
