using Library.CMS.Models;

namespace API.CMS.Database
{

    public static class FakeDatabase
    {
        public static List<Site> Sites = new List<Site>
            {
                new Site{Name = "Site 1", Id = 1}
                , new Site{Name = "Site 2", Id = 2}
            };
    }
}
