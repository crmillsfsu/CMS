using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Maui.CMS.ViewModels;

public class MainViewViewModel : INotifyPropertyChanged
{
    public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
	{
		if (propertyName is null)
		{
			throw new ArgumentNullException(nameof(propertyName));
		}

		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

    public event PropertyChangedEventHandler? PropertyChanged;
    private string buttonContent;
	public string ButtonContent {
		get
		{
			return buttonContent;
		}

		set
		{
			if(buttonContent != value)
			{
				buttonContent = value;
			}

			NotifyPropertyChanged();
		}
	} 

    
}