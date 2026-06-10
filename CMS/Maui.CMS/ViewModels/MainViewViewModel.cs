using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Library.CMS.Models;
using Library.CMS.Services;

namespace Maui.CMS.ViewModels;

public class MainViewViewModel : INotifyPropertyChanged
{
    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
	{
		if (propertyName is null)
		{
			throw new ArgumentNullException(nameof(propertyName));
		}

		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

    public void DeleteSelectedSite()
	{
        if (SelectedSite != null)
        {
            SiteServiceProxy.Current.Delete(SelectedSite.Id);
            RefreshSitesList();
        }
    }

    public void RefreshSitesList()
	{
		NotifyPropertyChanged("Sites");
	}

    public event PropertyChangedEventHandler? PropertyChanged;
    
	public ObservableCollection<SiteViewModel> Sites
	{
		get
		{
			var sites = SiteServiceProxy.Current.Sites
				.Where(s => s?.Name?.ToUpper()?
				.Contains(Query?.ToUpper() ?? string.Empty) ?? false)
				.Select(s => new SiteViewModel(s)).ToList();
			
			if(sites != null)
			{
				return new ObservableCollection<SiteViewModel>(sites);
			}
			return new ObservableCollection<SiteViewModel>();
		}
	}

	public Site? SelectedSite {get; set;}
	public string? Query { get; set; }

}