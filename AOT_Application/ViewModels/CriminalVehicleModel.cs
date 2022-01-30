using System;

using AOT_Application.Models;

namespace AOT_Application.ViewModels
{
    public class CriminalVehicleModel : BaseViewModel
    {
        public CriminalVehicleItem CriminalVehicleItem { get; set; }

        public CriminalVehicleModel(CriminalVehicleItem criminalVehicleItem = null)
        {
            Title = criminalVehicleItem?.EtlSystem;
            CriminalVehicleItem = criminalVehicleItem;
        }
    }
}
