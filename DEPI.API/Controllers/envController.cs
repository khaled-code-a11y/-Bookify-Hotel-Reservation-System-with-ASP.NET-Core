using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DEPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class envController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public envController(IWebHostEnvironment env)
        {
            _env = env;
        }
        #region Upload Image
        [HttpPost("UploadImage")]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile image)
        {
            if (image == null || image.Length == 0)
                return BadRequest("No image provided.");

            // Ensure the folder exists
            string folderPath = Path.Combine(_env.WebRootPath, "images/rooms");
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            // Generate unique file name
            string fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
            string filePath = Path.Combine(folderPath, fileName);

            // Save the file
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            // Return the relative path or full URL
            string imageUrl = $"images/rooms/{fileName}";
            return Ok(new { ImageUrl = imageUrl });
        }
        #endregion

    }
}
