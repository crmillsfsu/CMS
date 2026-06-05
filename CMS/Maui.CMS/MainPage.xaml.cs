using System.ComponentModel;
using System.Runtime.CompilerServices;
using Maui.CMS.ViewModels;
using Microsoft.UI.Xaml.CustomAttributes;

namespace Maui.CMS;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();

		BindingContext = new MainViewViewModel();
	}


	private void AddClicked(object? sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//SiteDetail");
		
	}

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
		(BindingContext as MainViewViewModel).RefreshSitesList();
    }

    private void DeleteClicked(object sender, EventArgs e)
    {
		(BindingContext as MainViewViewModel).DeleteSelectedSite();
    }
}
