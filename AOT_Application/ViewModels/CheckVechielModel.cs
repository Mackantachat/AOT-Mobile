using System;

using AOT_Application.Models;

namespace AOT_Application.ViewModels
{
    public class CheckVechielModel : BaseViewModel
    {
        public CheckVechielItem CheckVechielItem { get; set; }

        public CheckVechielModel(CheckVechielItem checkVechielItem = null)
        {
            Title = checkVechielItem?.EtlSystem;
            CheckVechielItem = checkVechielItem;
        }
    }
}