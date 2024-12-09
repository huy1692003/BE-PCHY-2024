using Microsoft.AspNetCore.Mvc;
using API_PCHY.Models.QLTN.QLTN_YCTN;
using System;
using System.Threading.Tasks;

namespace API_PCHY.Controllers.QLTN.QLTN_YCTN
{
    [Route("APIPCHY/[controller]")]
    [ApiController]
    public class QLTN_YCTNController : ControllerBase
    {
        private readonly QLTN_YCTN_Manager _manager;

        public QLTN_YCTNController()
        {
            _manager = new QLTN_YCTN_Manager();
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] QLTN_YCTN_Model model)
        {
            try
            {
                bool result = _manager.create_QLTN_YCTN(model);
                return result ? Ok("Tạo mới thành công") : BadRequest("Tạo mới thất bại");
            }
            catch (Exception ex)
            {
                return BadRequest($"Lỗi: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("GiaoNhiemVu")]
        public IActionResult GiaoNhiemVu([FromBody] QLTN_YCTN_Model model)
        {
            try
            {
                bool result = _manager.giao_nhiem_vu_YCTN(model);
                return result ? Ok("Cập nhật giao nhiệm vụ thành công") : BadRequest("Cập nhật giao nhiệm vụ thất bại");
            }
            catch (Exception ex)
            {
                return BadRequest($"Lỗi: {ex.Message}");
            }
        }

        /// <summary>
        /// Bước 4: LẬP KHẢO SÁT PHƯƠNG ÁN THI CÔNG 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        //{
        //  "ma_yctn": "YCTN.TN-11",
        //  "file_pa_thi_cong": "/fileYCTN/PA-TC-T12.doc",
        //  "nguoi_th_ks_lap_pa_thi_cong": "123241212",
        //  "ngay_ks_lap_pa_thi_cong": "2024-12-06T08:16:07.447Z"
        //} 
        [HttpPost]
        [Route("KhaoSatPhuongAn")]
        public IActionResult KhaoSatPhuongAnThiCong([FromBody] QLTN_YCTN_Model model)
        {
            try
            {
                bool result = _manager.khao_sat_phuong_an_YCTN(model);
                return result ? Ok("Khảo sát thành công") : BadRequest("Khảo sát thất bại");
            }
            catch (Exception ex)
            {
                return BadRequest($"Lỗi: {ex.Message}");
            }
        }
 

        [HttpGet]
        [Route("SearchMaYCTN")]
        public IActionResult SearchMaYCTN(string maYCTN)
        {
            try
            {
                var result = _manager.search_Ma_YCTN(maYCTN);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Lỗi: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetByMAYCTN")]
        public IActionResult GetByID(string MA_YCTN)
        {
            try
            {
                var result = _manager.get_QLTN_YCTN_ByID(MA_YCTN);
                if (result == null)
                {
                    return NotFound("Không tìm thấy dữ liệu");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Lỗi: {ex.Message}");
            }
        }
    }
}
