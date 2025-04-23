using Backend.Models.Entity;
using Backend.Models.Model;
using Backend.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateController : ControllerBase
    {
        private readonly EstateService _estateService;

        public EstateController(EstateService estateService)
        {
            _estateService = estateService;
        }

        [HttpGet("{estateId}")]
        public ActionResult<Estate> GetEstate(string estateId)
        {
            var estate =  _estateService.GetEstate(estateId);

            if (estate == null)
            {
                return NotFound(new { message = $"Estate with ID '{estateId}' not found." });
            }

            return Ok(estate);
        }

        [HttpPost("updateImg")]
        public ActionResult<List<EstateImg>> updateEstatImage([FromBody] List<EstateImg> EstateImgList)
        {
            var result = _estateService.UpdateEstateImg(EstateImgList);

            return Ok(result);
        }
    }
}
