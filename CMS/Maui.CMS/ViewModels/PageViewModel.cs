using Library.CMS.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Vm = Library.CMS.Models;

namespace Maui.CMS.ViewModels
{
    public class PageViewModel
    {
        public Vm.Page? Model
        {
            get; set;
        }

        public PageViewModel(Vm.Page p)
        {
            Model = p;
        }

        public PageViewModel()
        {
            Model = new Vm.Page();
        }

        public string TitleDisplay => $"{Model?.Title}:";
    }
}
