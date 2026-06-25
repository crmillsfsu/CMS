using API.CMS.Database;
using Library.CMS.DTO;
using Library.CMS.Models;

namespace API.CMS.EC
{
    public class SiteEC
    {
        public SiteEC()
        {

        }

        public IEnumerable<SiteDTO> GetSites()
        {
            return FakeDatabase.Sites.Take(100).Select(s => new SiteDTO(s));
        }

        public SiteDTO AddOrUpdate(SiteDTO dto)
        {
            if(dto.Id <= 0)
            {
                dto.Id = FakeDatabase.LastKey + 1;
                FakeDatabase.Sites.Add(new Site(dto));
            }
            else
            {
                var site = new Site(dto);
                var existingSite = FakeDatabase.Sites.FirstOrDefault(s => s.Id == dto.Id);

                if (existingSite != null)
                {
                    var index = FakeDatabase.Sites.IndexOf(existingSite);
                    FakeDatabase.Sites.Remove(existingSite);
                    FakeDatabase.Sites.Insert(index, site);
                }
            }

            return dto;
        }

        public SiteDTO? Delete(int id)
        {
            var siteToDelete = FakeDatabase.Sites.FirstOrDefault(s => s.Id == id);

            if (siteToDelete == null)
            {
                return null;
            }
            FakeDatabase.Sites.Remove(siteToDelete);
            return new SiteDTO(siteToDelete);
        }
    }
}
