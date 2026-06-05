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
    
	public ObservableCollection<Site> Sites
	{
		get
		{
			var sites = SiteServiceProxy.Current.Sites;
			if(sites != null)
			{
				return new ObservableCollection<Site>(sites);
			}
			return new ObservableCollection<Site>();
		}
	}

	public Site? SelectedSite {get; set;}

    
}