using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jurmen.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SecuredController : ControllerBase
    {
       [HttpGet]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
       public async Task<IActionResult> GetSecuredData()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            return Ok("This Secured Data is available noly for Authenticated Users.");
        }
    }
}
