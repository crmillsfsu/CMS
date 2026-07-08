using API.CMS.Database;
using Library.CMS.DTO;
using Library.CMS.Models;
using Microsoft.Extensions.FileSystemGlobbing.Abstractions;

namespace API.CMS.EC
{
    public class SiteEC
    {
        public SiteEC()
        {

        }

        public IEnumerable<SiteDTO> GetSites()
        {
            return Filebase.Current.Sites.Take(100);
        }

        public SiteDTO AddOrUpdate(SiteDTO dto)
        {

            return Filebase.Current.AddOrUpdate(dto);
            
        }

        public SiteDTO? Delete(int id)
        {
            return Filebase.Current.Delete("site", id);
        }
    }
}
