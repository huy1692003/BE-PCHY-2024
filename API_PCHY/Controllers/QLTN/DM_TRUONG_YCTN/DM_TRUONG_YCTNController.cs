using API_PCHY.Models.QLTN.DM_TRUONG_YCTN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using API_PCHY.Models.QLTN.DM_LOAITHIETBI;

namespace API_PCHY.Controllers.QLTN.DM_TRUONG_YCTN
{
    [Route("api/[controller]")]
    [ApiController]
    public class DM_TRUONG_YCTNController : ControllerBase
    {
        DM_TRUONG_YCTN_Manager manager = new DM_TRUONG_YCTN_Manager();

        [HttpGet("getAll_DM_TRUONG_YCTN")]
        public ActionResult Get()
        {
            try
            {
                List<DM_TRUONG_YCTN_Model> result = manager.getALL_DM_TRUONG_YCTN();

                return result != null ? Ok(result) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("insert_DM_TRUONG_YCTN")]
        [HttpPost]
        public IActionResult insert([FromBody] DM_TRUONG_YCTN_Model a)
        {
            try
            {
                string result = manager.insert_DM_TRUONG_YCTN(a);
                return string.IsNullOrEmpty(result) ? Ok("Thành công") : BadRequest(result);
                
            }
            catch (Exception ex) { return BadRequest(ex.Message); }

        }
    }
}
