﻿using APIPCHY_PhanQuyen.Models.QLKC.HT_QUYEN_NGUOIDUNG;
using Microsoft.AspNetCore.Mvc;

namespace APIPCHY_PhanQuyen.Controllers.QLKC.HT_QUYEN_NGUOIDUNG
{
    [Route("APIPCHY/[controller]")]
    [ApiController]
    public class HT_QUYEN_NGUOIDUNGController : ControllerBase
    {
        HT_QUYEN_NGUOIDUNG_Manager manager = new HT_QUYEN_NGUOIDUNG_Manager();

        [HttpGet("getByUserId/{maNguoiDung}")]
        public IActionResult get_QUYEN_NGUOIDUNG_byID(string maNguoiDung)
        {
            if (maNguoiDung == null)
            {
                return BadRequest("Ma nguoi dung ko dc trong");
            }

            var listRole = manager.Get_QUYEN_NGUOIDUNG_BY_USERID(maNguoiDung);

            if (listRole == null || listRole.Count == 0)
            {
                return NotFound("Ko tim thay id nguoi dung");
            }

            return Ok(listRole);
        }



        [HttpPost("createMultiple")]
        public void PostInsertQuyenMultiple([FromBody] HT_QUYEN_NGUOIDUNG_Model[] list)
        {
            foreach (var item in list)
            {
                manager.Insert_HT_QUYEN_NGUOIDUNG(item);
            }
        }

        [HttpPost("create")]
        public void PostInsertQuyen([FromBody] HT_QUYEN_NGUOIDUNG_Model quyen)
        {
            manager.Insert_HT_QUYEN_NGUOIDUNG(quyen);
        }

        [HttpPatch("update")]
        public void UpdateQuyen([FromBody] HT_QUYEN_NGUOIDUNG_Model quyen)
        {
            manager.Update_HT_QUYEN_NGUOIDUNG(quyen);
        }

        [HttpGet("delete/{id}")]
        //[Authorize]
        public IActionResult DeleteQuyen(int id)
        {
            manager.Delete_HT_QUYEN_NGUOIDUNG(id);
            return Ok("Xoa thanh cong");
        }

    }
}

