using APIPCHY_PhanQuyen.Models.QLKC.D_DVIQLY;
using iTextSharp.text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
namespace APIPCHY_PhanQuyen.Controllers.QLKC.D_DVIQLY
{
    [Route("APIPCHY/[controller]")]
    [ApiController]
    public class D_DVIQLYController : ControllerBase
    {
        D_DVIQLY_Manager db = new D_DVIQLY_Manager();

        [Route("getAllD_DVQLY")]
        [HttpGet]
        public IActionResult getAllD_DVQLY()
        {
            try
            {
                List<D_DVIQLY_Model> result = db.getAllD_DVIQLY();
                return result != null ? Ok(result) : NotFound();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
