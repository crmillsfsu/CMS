using Library.CMS.Models;

namespace Library.CMS.Services {
    public  class SiteServiceProxy
    {
        private SiteServiceProxy()
        {
            sites = new List<Site>
            {
                new Site{Name = "Site 1", Id = 1}
                , new Site{Name = "Site 2", Id = 2}
            };

        }

        private int LastKey => Sites.Select(s => s.Id).Max();

        public void AddOrUpdate(Site? site)
        {
            if(site == null) return;

            if(site.Id == 0)
            {
                site.Id = LastKey + 1;
                sites.Add(site);
            }

        }

        private static SiteServiceProxy? instance;
        private static object _instanceLock = new object();

        public static SiteServiceProxy Current
        {
            get
            {
                lock(_instanceLock){
                    if(instance == null)
                    {
                        instance = new SiteServiceProxy();
                    }
                }
                return instance;
            }
        }

        public Site? Delete(int id)
        {
            var site = Sites.FirstOrDefault(s => s.Id == id);
            if (site != null)
            {
                sites.Remove(site);
            }

            return site;
        }

        private List<Site> sites;
        public List<Site> Sites {
            get
            {
                return sites;
            }
            set
            {
                if(sites != value)
                {
                    sites = value;
                }
            }
        }
    }
}