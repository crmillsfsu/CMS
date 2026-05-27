namespace Library.CMS.Models;

public class Site
{
    public string? Name{get; set;}
    private string? owner;
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
    public List<string> Content {get; set;}

    public Site()
    {
        Users = new List<string>();
        Content = new List<string>();
    }

    public override string ToString() => $"{Name}";
}