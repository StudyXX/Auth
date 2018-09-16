using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientCredSample.Controllers
{
    [Produces("application/json")]
    [Route("Identity")]
    [Authorize]
    public class IdentityController : Controller
    {
        public IActionResult Get()
        {
            return new JsonResult(User.Claims.Select(item => new
            {
                item.Type,
                item.Value
            }));
        }
    }
}