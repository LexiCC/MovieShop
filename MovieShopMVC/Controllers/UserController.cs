using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace MovieShopMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        //show all the movies purchased by currently loged in user
       
        [HttpGet]
        public async Task<IActionResult> Purchases()
        {
            // first whether user is loged in 
            // if the user is not loged in, 
            // redirect to login Page
            // 10:00 AM user email/password => something that can be used at 10:05
            // cookies, authtication cookies that can be used across http request and check whether
            // user is loged in or not.
            // cookies -> location? 
            // 10:05 he/she calls user/purchases
            // look for  the authCookie and look for exp time and get the userid
            // Http Request is independect of each other
            // userid, fo to purchase table and get all the movies purchased
            // display as movie cards, use movie card partial view
            // var data = this.HttpContext.Request.Cookies["MovieShopAuthCookie"];
            //var isLogedIn = this.HttpContext.User.Identity.IsAuthenticated;
            //if (!isLogedIn)
            //{
            //    //redirect to login page
            //}
            // Filters in ASP.NET
            var userId = Convert.ToInt32( this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            //  call the USerService -> GetMoviesPurchasedByUser(int userId) -> List<MovieCard>
            // send it to database
            // dectypt the cookie and get the userid from claims and expiration time from the cookie
            // use the useid to go to database and get the movies purchased
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            var userId = Convert.ToInt32(this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return View();
        }

        public async Task<IActionResult> Reviews()
        {
            var userId = Convert.ToInt32(this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            return View();
        }
    }
}