using Microsoft.AspNetCore.Mvc;
using CMS.Service.Common;
using CMS.Model;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace CMS.WebApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    [Authorize]
    public class OsobeController : ControllerBase
    {
        private readonly IService _service;

        public OsobeController(IService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OsobaDomain>> GetAll()
        {
            var osobe = _service.PrikaziSveOsobe();
            return Ok(osobe);
        }
    }
}
