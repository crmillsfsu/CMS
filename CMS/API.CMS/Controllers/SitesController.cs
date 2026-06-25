using API.CMS.Database;
using API.CMS.EC;
using Library.CMS.DTO;
using Library.CMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.CMS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SitesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<SiteDTO> Get()
        {
            return new SiteEC().GetSites();
        }

        [HttpPost]
        public SiteDTO AddOrUpdate([FromBody] SiteDTO dto)
        {
            return new SiteEC().AddOrUpdate(dto);
        }

        [HttpDelete("{id}")]
        public SiteDTO? DeleteById(int id)
        {
            return new SiteEC().Delete(id);
        }
    }
}
