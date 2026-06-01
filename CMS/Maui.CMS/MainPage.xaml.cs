using System.ComponentModel;
using System.Runtime.CompilerServices;
using Maui.CMS.ViewModels;
using Microsoft.UI.Xaml.CustomAttributes;

namespace Maui.CMS;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();

		BindingContext = new MainViewViewModel();
	}


	private void OnCounterClicked(object? sender, EventArgs e)
	{
		count++;

		if (count == 1)
			(BindingContext as MainViewViewModel).ButtonContent = $"Clicked {count} time";
		else
			(BindingContext as MainViewViewModel).ButtonContent = $"Clicked {count} times";
	}
}
