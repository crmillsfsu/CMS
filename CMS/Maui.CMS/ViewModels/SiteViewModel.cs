using Library.CMS.Models;
using Library.CMS.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Maui.CMS.ViewModels
{
    public class SiteViewModel
    {
        public SiteViewModel()
        {
            Model = new Site();
            SetUpCommands();
        }

        public SiteViewModel(Site s)
        {
            Model = s;
            SetUpCommands();
        }

        private void SetUpCommands()
        {
            DeleteCommand = new Command(DoDelete);
            EditCommand = new Command(DoEdit);
        }

        private void DoEdit()
        {
            if (Model?.Id > 0)
            {
                Shell.Current.GoToAsync($"//SiteDetail?siteId={Model?.Id}");
            }
        }

        private void DoDelete() {
            SiteServiceProxy.Current.Delete(Model.Id);
        }

        public Site Model { get; set; }

        public string? Name
        {

            get
            {
                return Model.Name;
            }

            set
            {
                if (Model.Name != value)
                {
                    Model.Name = value;
                }
            }
        }

        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
    }
}
