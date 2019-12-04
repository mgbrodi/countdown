using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CountdownService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountdownController : ControllerBase
    {
        // GET api/countdown
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Big Surprise!" };
        }

        // GET api/countdown/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "You have "+id.ToString()+" seconds left! Expiration set for "+DateTime.Now.AddSeconds(id).ToString();
        }
    }
}
