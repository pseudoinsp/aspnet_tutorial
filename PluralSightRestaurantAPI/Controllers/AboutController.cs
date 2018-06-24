using Microsoft.AspNetCore.Mvc;

namespace PluralSightRestaurantAPI.Controllers
{
    //   [controller] == "about"
    [Route("company/[controller]/[action]")]
    public class AboutController : Controller
    {
        [Route("")]
        public string Phone()
        {
            return "1+555+555+5555";
        }

        // == [Route("address")]
        //[Route("[action]")]
        public string Address()
        {
            return "USA";
        }
    }
}
