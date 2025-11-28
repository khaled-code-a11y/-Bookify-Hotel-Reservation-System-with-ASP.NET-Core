using DEPI.DAL.Entities;
using DEPI.DAL.IRepositories;

namespace DEPI.DAL.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly AppDbContext _dbContext;

        public RoomRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<RoomModel>> GetAllRoomsAsync()
        {
            return await _dbContext.Rooms.ToListAsync();
        }

        public async Task<RoomModel?> GetRoomByIdAsync(int roomId)
        {
            return await _dbContext.Rooms.FindAsync(roomId);
        }

        public async Task AddRoomAsync(RoomModel room)
        {
            await _dbContext.Rooms.AddAsync(room);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRoomAsync(RoomModel room)
        {
            _dbContext.Rooms.Update(room);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRoomAsync(RoomModel room)
        {
            _dbContext.Rooms.Remove(room);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> CheckAvailabilityForDatesAsync(int roomId, DateTime startDate, DateTime endDate)
        {
            var room = await _dbContext.Rooms.FindAsync(roomId);

            if (room == null || !room.isAvailable)
                return false;

            var hasConflict = await _dbContext.reservedrooms
                .Where(r => r.RoomId == roomId && r.Status != "Cancelled")
                .AnyAsync(r => r.CheckIN < endDate && r.CheckOUT > startDate);

            return !hasConflict;

        }

        public async Task<int> ReserveRoomAsync(ReservedroomModel reservedRoom)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                var room = await _dbContext.Rooms.FindAsync(reservedRoom.RoomId);
                if (room == null)
                    throw new KeyNotFoundException($"Room with ID {reservedRoom.RoomId} not found");

                var customer = await _dbContext.Customers.FindAsync(reservedRoom.CustomerId);
                if (customer == null)
                    throw new KeyNotFoundException($"Customer with ID {reservedRoom.CustomerId} not found");

                var isAvailable = await CheckAvailabilityForDatesAsync(
                    reservedRoom.RoomId,
                    reservedRoom.CheckIN,
                    reservedRoom.CheckOUT);

                if (!isAvailable)
                    throw new InvalidOperationException("Room is not available for the selected dates");

                await _dbContext.reservedrooms.AddAsync(reservedRoom);
                await _dbContext.SaveChangesAsync();

                await transaction.CommitAsync();

                return reservedRoom.ReservedId;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<IEnumerable<RoomModel>> GetAvailableRoomsAsync(DateTime startDate, DateTime endDate, int roomCapacity)
        {
            var availableRooms = await _dbContext.Rooms
                .Include(r => r.RoomType)
                .Where(r => r.isAvailable &&
                r.RoomType != null &&
                r.RoomType.RoomCapacity >= roomCapacity &&
                    !r.ReservedRooms!.Any(rr =>
                        rr.Status != "Cancelled" &&
                        rr.CheckIN < endDate &&
                        rr.CheckOUT > startDate
                    )
                )
                .ToListAsync();

            return availableRooms;

        }


    }
}
