using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;

namespace api_pchy.controllers
{
    [Route("APIPCHY/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        [HttpPost("image")]
        public IActionResult UploadAnhChuKyNhayImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Không có tệp nào được tải lên.");
            }

            // Định nghĩa thư mục nơi tệp sẽ được lưu
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/chukynhay");

            // Kiểm tra và tạo thư mục nếu chưa tồn tại
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Tạo tên tệp duy nhất để tránh trùng lặp
            var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";

            // Đường dẫn đầy đủ đến tệp sẽ lưu
            var filePath = Path.Combine(folderPath, uniqueFileName);

            try
            {
                // Lưu tệp vào thư mục
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                // Trả về đường dẫn tệp tương đối
                var relativePath = Path.Combine("/images/chukynhay", uniqueFileName).Replace("\\", "/");
                return Ok(new { FilePath = relativePath });
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu xảy ra lỗi
                return StatusCode(StatusCodes.Status500InternalServerError, $"Đã xảy ra lỗi khi tải tệp lên: {ex.Message}");
            }
        }
    }
}
