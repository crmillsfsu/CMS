using Library.CMS.DTO;
using Library.CMS.Models;
using Library.CMS.Util;
using Newtonsoft.Json;

namespace Library.CMS.Services {
    public  class SiteServiceProxy
    {
        private SiteServiceProxy()
        {
            var sitesString = new WebRequestHandler().Get("/Sites").Result;
            var mySites = JsonConvert.DeserializeObject<List<Site>>(sitesString);
            sites = mySites ?? new List<Site>();

        }

        private int LastKey => Sites.Any() ? Sites.Select(s => s.Id).Max() : 0;

        public void AddOrUpdate(Site? site)
        {
            if(site == null) return;

            if(site.Id == 0)
            {
                //site.Id = LastKey + 1;
                sites.Add(site);
            }

            var response = new WebRequestHandler().Post("/Site", new SiteDTO(site)).Result;
            var newSite = JsonConvert.DeserializeObject<SiteDTO>(response);
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
            var response = new WebRequestHandler().Delete($"/Sites/{id}").Result;
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