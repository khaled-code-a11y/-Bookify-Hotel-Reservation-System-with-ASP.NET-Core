
namespace DEPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IPaymentService _paymentService;

        public RoomController(IRoomService roomService , IPaymentService paymentService)
        {
            _roomService = roomService;
            _paymentService = paymentService;
        }


        #region Get All Rooms
        [HttpGet("getAllRooms")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllRooms()
        {
            var rooms = await _roomService.GetAllRoomsAsync();
            return Ok(rooms);
        }
        #endregion

        #region Get Room By Id
        [HttpGet("getRoomById/{roomId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetRoomById(int roomId)
        {
            var room = await _roomService.GetRoomByIdAsync(roomId);
            return Ok(room);
        }
        #endregion

        #region Add Room
        [HttpPost("addRoom")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddRoom([FromBody] RoomDTO roomdto)
        {
            try
            {
                await _roomService.AddRoomAsync(roomdto);
                return StatusCode(StatusCodes.Status201Created, new { Message = "Room added successfully" });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { Message = "An unexpected error occurred." });
            }
        }
        #endregion

        #region Update Room
        [HttpPut("updateRoom/{roomId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateRoom([FromBody] RoomDTO roomdto, int roomId)
        {
            try
            {
                await _roomService.UpdateRoomAsync(roomdto, roomId);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { Message = "An unexpected error occurred." });
            }
        }
        #endregion

        #region Delete Room
        [HttpDelete("deleteRoom/{roomId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteRoom(int roomId)
        {
            await _roomService.DeleteRoomAsync(roomId);
            return NoContent();           
        }
        #endregion

        #region Check Room Availability
        [HttpGet("checkAvailability")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> CheckAvailability([FromQuery] CheckAvailabiltyDTO checkAvailabilty)
        {
            if (checkAvailabilty.StartDate >= checkAvailabilty.EndDate)
                return BadRequest("Start date must be before end date");

            var isAvailable = await _roomService.checkAvailabiltyAsync(checkAvailabilty);
            return Ok(new { RoomId = checkAvailabilty.RoomId, IsAvailable = isAvailable });
        }
        #endregion

        #region Reserve Room
        [HttpPost("reserveRoom")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ReserveRoom([FromBody] ReserveRoomDTO reservation)
        {
            if (reservation.roomId <= 0)
                return BadRequest(new { Message = "Invalid roomId" });

            if (reservation.customerId <= 0)
                return BadRequest(new { Message = "Invalid customerId" });

            if (reservation.startDate >= reservation.endDate)
                return BadRequest(new { Message = "Start date must be before end date" });

            if (reservation.startDate < DateTime.Today)
                return BadRequest(new { Message = "Cannot reserve dates in the past" });

            try
            {
                var reservationId = await _roomService.ReserveRoomAsync(reservation);

                var paymentDTO = new PaymentDTO
                {
                    Email = reservation.Email, 
                    PaymentMethod = reservation.PaymentMethod, 
                    roomId = reservation.roomId,
                    startDate = reservation.startDate,
                    endDate = reservation.endDate,
                    customerId = reservation.customerId
                };

                await _paymentService.ProcessPaymentAsync(paymentDTO);

                return StatusCode(StatusCodes.Status201Created, new
                {
                    Message = "Room reserved successfully and payment email sent",
                    ReservationId = reservationId,
                    RoomId = reservation.roomId
                });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An unexpected error occurred", Details = ex.Message });
            }
        }
        #endregion

        #region Get Available Rooms
        [HttpGet("searchRooms")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SearchRooms([FromQuery] RoomSearchDTO search)
        {
            if (search.StartDate >= search.EndDate)
                return BadRequest(new { Message = "Start date must be before end date" });

            if (search.RoomCapacity <= 0)
                return BadRequest(new { Message = "Room capacity must be at least 1" });

            if (search.StartDate < DateTime.Today)
                return BadRequest(new { Message = "Cannot search for past dates" });

            var rooms = await _roomService.GetAvailableRoomsAsync(search);

            return Ok(new
            {
                SearchCriteria = new
                {
                    search.StartDate,
                    search.EndDate,
                    search.RoomCapacity
                },
                AvailableRoomsCount = rooms.Count(),
                Rooms = rooms
            });
        }
        #endregion


    }

}



