using API.CMS.Database;
using Library.CMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.CMS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SiteController : ControllerBase
    {
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<Site> Get()
        {
            return FakeDatabase.Sites;
        }
    }
}
