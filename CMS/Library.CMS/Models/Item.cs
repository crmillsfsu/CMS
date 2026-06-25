namespace Library.CMS.Models;

public class Item
{
    public string? Title {get; set;}
    public string? Content {get; set;}

    public override string ToString() => $"{Title}: {Content}";
}