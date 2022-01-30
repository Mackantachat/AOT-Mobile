using System;

using AOT_Application.Models;

namespace AOT_Application.ViewModels
{
    public class CriminalPersonModel : BaseViewModel
    {
        public CriminalPersonItem CriminalPersonItem { get; set; }

        public CriminalPersonModel(CriminalPersonItem criminalPersonItem = null)
        {
            Title = criminalPersonItem?.EtlSystem;
            CriminalPersonItem = criminalPersonItem;
        }
    }

}