using System.ComponentModel;
using System.Runtime.CompilerServices;
using Library.CMS.Models;
using Library.CMS.Services;
using Maui.CMS.ViewModels;
using Microsoft.UI.Xaml.CustomAttributes;

namespace Maui.CMS.Views;

[QueryProperty(nameof(SiteId), "siteId")]
public partial class SiteDetailView : ContentPage, INotifyPropertyChanged
{
    public int SiteId { get; set; }
    public SiteDetailView()
    {
        InitializeComponent();
        
    }
    private void CancelClicked(object? sender, EventArgs e)
	{
        Shell.Current.GoToAsync("//MainPage");		
	}

    private void OkClicked(object? sender, EventArgs e)
	{
        var site = (BindingContext as Site);
        SiteServiceProxy.Current.AddOrUpdate(site);
        if (site != null)
        {
            Shell.Current.GoToAsync("//MainPage");
        }
	}

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        if (SiteId == 0)
        {
            BindingContext = new Site();
        }
        else
        {
            BindingContext = SiteServiceProxy.Current.Sites.FirstOrDefault(s => s.Id == SiteId) ?? new Site();
            //BindingContext = SiteServiceProxy.Current.GetById(SiteId) ?? new Site();
        }

    }
}