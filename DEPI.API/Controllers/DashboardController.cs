
namespace DEPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public DashboardController(IRoomService roomService)
        {
            _roomService = roomService;
        }


        #region Get Dashboard Stats
        [HttpGet("getDashboardStats")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDashboardStats()
        {
            var totalBookings = await _roomService.GetTotalRoomsBookingAsync();
            var totalRevenue = await _roomService.GetTotalRevenueAsync();
            var RecentBooking = await _roomService.GetRecentBookingAsync();
            var dashboardStats = new
            {
                TotalBookings = totalBookings,
                TotalRevenue = totalRevenue,
                RecentBooking = RecentBooking
            };
            return Ok(dashboardStats);
        }
        #endregion

    }
}
