using Library.CMS.DTO;
using Library.CMS.Models;
using Newtonsoft.Json;

namespace API.CMS.Database
{
    public class Filebase
    {
        private string _root;
        private string _siteRoot;
        private static Filebase? _instance;


        public static Filebase Current
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Filebase();
                }

                return _instance;
            }
        }

        private Filebase()
        {
            _root = @"C:\temp";
            _siteRoot = $"{_root}\\Sites";
        }

        public int LastSiteKey
        {
            get
            {
                if (Sites.Any())
                {
                    return Sites.Select(x => x.Id).Max();
                }
                return 0;
            }
        }

        public SiteDTO AddOrUpdate(SiteDTO site)
        {
            //set up a new Id if one doesn't already exist
            if(site.Id <= 0)
            {
                site.Id = LastSiteKey + 1;
            }

            //go to the right place
            string path = $"{_siteRoot}\\{site.Id}.json";
            

            //if the item has been previously persisted
            if(File.Exists(path))
            {
                //blow it up
                File.Delete(path);
            }

            //write the file
            File.WriteAllText(path, JsonConvert.SerializeObject(new Site(site)));

            //return the item, which now has an id
            return site;
        }
        
        public List<SiteDTO> Sites
        {
            get
            {
                var root = new DirectoryInfo(_siteRoot);
                var _sites = new List<SiteDTO>();
                foreach(var siteFile in root.GetFiles())
                {
                    var patient = JsonConvert
                        .DeserializeObject<Site>
                        (File.ReadAllText(siteFile.FullName));
                    if(patient != null)
                    {
                        _sites.Add(new SiteDTO(patient));
                    }

                }
                return _sites;
            }
        }


        public SiteDTO? Delete(string type, int id)
        {
            var path = string.Empty;
            if(type.Equals("site", StringComparison.InvariantCultureIgnoreCase))
            {
                path += _siteRoot;
            }
            path = $"{path}\\{id}.json";

            //if the item has been previously persisted
            Site? returnSite = null;
            if (File.Exists(path))
            {
                returnSite = JsonConvert.DeserializeObject<Site>(File.ReadAllText(path));
                //blow it up
                File.Delete(path);
            }

            return returnSite == null ? null : new SiteDTO(returnSite);
        }
    }


   
}