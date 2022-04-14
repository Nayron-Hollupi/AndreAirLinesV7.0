using System.Collections.Generic;
using System.Threading.Tasks;
using AndreAirlinesDomain.Model;
using LogAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace LogAPI.Controllers
{
   [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {

        private readonly LogService _logService;
        public LogController(LogService logService)
        {
            _logService = logService;
        }

        [HttpGet]
       // [Authorize(Roles = "GetLog")]
        public ActionResult<List<Log>> Get() =>
            _logService.Get();


        [HttpGet("{id:length(24)}", Name = "GetLog")]
     //   [Authorize(Roles = "GetLogId")]
        public ActionResult<Log> Get(string id)
        {
            var log = _logService.Get(id);

            if (log == null)
            {
                return NotFound();
            }

            return log;
        }

        [HttpPost]
      //  [Authorize(Roles = "CreateLog")]
        public ActionResult<Log> Create(Log log)
        {
            _logService.Create(log);
            return CreatedAtRoute("GetLog", new { id = log.Id.ToString() }, log);

        }


        [HttpPut("{id:length(24)}")]
       // [Authorize(Roles = "UpdateLog")]
        public IActionResult Update(string id, Log logIn)
        {
            var log = _logService.Get(id);

            if (log == null)
            {
                return NotFound();
            }

            _logService.Update(id, logIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
      //  [Authorize(Roles = "DeleteLog")]
        public IActionResult Delete(string id)
        {
            var log = _logService.Get(id);

            if (log == null)
            {
                return NotFound();
            }

            _logService.Remove(log.Id);

            return NoContent();
        }
    }
}
