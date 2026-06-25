using Library.CMS.DTO;
using System.Data.Common;
using System.Windows.Input;

namespace Library.CMS.Models;

public class Site
{

    public int LegacyValue1 { get; set; }
    public int LegacyValue2 { get; set; }
    public int LegacyValue3 { get; set; }
    public int LegacyValue4 { get; set; }
    public int LegacyValue5 { get; set; }
    public int LegacyValue6 { get; set; }
    public int LegacyValue7 { get; set; }
    public int LegacyValue8 { get; set; }

    public string? Name{get; set;}
    private string? owner;

    public int Id {get; set;}
    public string? Owner{
        get
        {
            return owner;
        }
        set
        {
            if(owner != value)
            {
                owner = value;
            }
        }
    }
    public List<string> Users {get; set;}
    public List<Page> Content {get; set;}

    public Site()
    {
        Users = new List<string>();
        Content = new List<Page>();
    }

    public override string ToString() => $"{Name}";

    public Site(SiteDTO dto)
    {
        Name = dto.Name;
        Owner = dto.Owner;
        Id = dto.Id;
        Content = dto.Content;
        Users = dto.Users;
    }

}