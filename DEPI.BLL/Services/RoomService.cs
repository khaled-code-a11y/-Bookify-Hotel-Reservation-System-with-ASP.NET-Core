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
            var roomModel = _mapper.Map<RoomModel>(roomdto);
            await _roomRepository.AddRoomAsync(roomModel);
        }

        public async Task UpdateRoomAsync(RoomDTO roomDto, int roomId)
        {
            var existingRoom = await _roomRepository.GetRoomByIdAsync(roomId);
            if (existingRoom == null) throw new KeyNotFoundException("Room not found");

            _mapper.Map(roomDto, existingRoom);

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


    }
}
