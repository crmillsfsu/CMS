using System.ComponentModel;
using System.Runtime.CompilerServices;
using Library.CMS.Models;
using Library.CMS.Services;
using Maui.CMS.ViewModels;
using Microsoft.UI.Xaml.CustomAttributes;

namespace Maui.CMS.Views;

public partial class SiteDetailView : ContentPage, INotifyPropertyChanged
{
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
        SiteServiceProxy.Current.Add(site);
        if (site != null)
        {
            Shell.Current.GoToAsync("//MainPage");
        }
	}

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new Site();
    }
}