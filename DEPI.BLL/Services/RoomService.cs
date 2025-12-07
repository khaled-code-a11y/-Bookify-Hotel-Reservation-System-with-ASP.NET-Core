using DEPI.BLL.DTOS;

namespace DEPI.BLL.Services
{
    public class RoomService : IRoomService
    {
        private readonly IMapper _mapper;
        private readonly IRoomRepository _roomRepository;

        public RoomService(IMapper mapper, IRoomRepository roomRepository)
        {
            _mapper = mapper;
            _roomRepository = roomRepository;
        }

        public async Task<IEnumerable<RoomModel>> GetAllRoomsAsync()
        {
            return await _roomRepository.GetAllRoomsAsync();
        }

        public async Task<RoomModel?> GetRoomByIdAsync(int roomId)
        {
            var room = await _roomRepository.GetRoomByIdAsync(roomId);
            if (room == null) throw new KeyNotFoundException("Room not found");
            return room;
        }

        public async Task AddRoomAsync(RoomDTO roomdto)
        {
           
            var room = new RoomModel
            {
                RoomNumber = roomdto.RoomNumber,
                TypeId = roomdto.TypeId,
                isAvailable = roomdto.isAvailable,
            }; 
            await _roomRepository.AddRoomAsync(room);
        }

        public async Task UpdateRoomAsync(RoomDTO roomDto, int roomId)
        {
            var existingRoom = await _roomRepository.GetRoomByIdAsync(roomId);
            if (existingRoom == null)
                throw new KeyNotFoundException("Room not found");

            existingRoom.RoomNumber = roomDto.RoomNumber;
            existingRoom.TypeId = roomDto.TypeId;
            existingRoom.isAvailable = roomDto.isAvailable;

            await _roomRepository.UpdateRoomAsync(existingRoom);
        }

        public async Task DeleteRoomAsync(int roomId)
        {
            var room = await _roomRepository.GetRoomByIdAsync(roomId);
            if (room == null) throw new KeyNotFoundException("Room not found");

            await _roomRepository.DeleteRoomAsync(room);
        }

        public async Task<bool> checkAvailabiltyAsync(CheckAvailabiltyDTO checkAvailabilty)
        {
            return await _roomRepository.CheckAvailabilityForDatesAsync(
                 checkAvailabilty.RoomId,
                 checkAvailabilty.StartDate,
                 checkAvailabilty.EndDate);
        }

        public async Task<int> ReserveRoomAsync(ReserveRoomDTO reserveRoom)
        {
            var reserveRoomModel = new ReservedroomModel
            {
                RoomId = reserveRoom.roomId,
                CustomerId = reserveRoom.customerId,
                CheckIN = reserveRoom.startDate,
                CheckOUT = reserveRoom.endDate,
                Status = "Pending" 
            };

            return await _roomRepository.ReserveRoomAsync(reserveRoomModel);

        }

        public async Task<IEnumerable<RoomModel>> GetAvailableRoomsAsync(RoomSearchDTO search)
        {
            return await _roomRepository.GetAvailableRoomsAsync
                (
                search.StartDate,
                search.EndDate,
                search.RoomCapacity
                );

        }

        public Task<int> GetTotalRoomsBookingAsync()
        {
            return _roomRepository.GetTotalRoomsBookingAsync();
        }

        public Task<int> GetTotalRevenueAsync()
        {
            return _roomRepository.GetTotalRevenueAsync();
        }

        public async Task<List<RecentBookingDTO>> GetRecentBookingAsync()
        {
            var bookings = await _roomRepository.getRecentBookingAsync();

            return bookings.Select(b => new RecentBookingDTO
            {
                UserName = b.Customer?.User!.Name ?? string.Empty,
                RoomNumber = b.Room?.RoomNumber.ToString() ?? string.Empty,
                Amount = b.Payment?.Sum(p => p.Amount) ?? 0,
                PaymentStatus = b.Status
            }).ToList();
        }


    }


}

