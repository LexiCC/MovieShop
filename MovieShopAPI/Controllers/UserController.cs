using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("purchases")]
        public async Task<IActionResult> Purchases()
        {
            // get the list of movies for user
            // get the userid, httpcontext
            // mechanism to handle exception globally
            // Exception filters in ASP.NET
            return Ok();
        }
    }
}