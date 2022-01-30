using System;

using AOT_Application.Models;

namespace AOT_Application.ViewModels
{
    public class ExtingguisherModel : BaseViewModel
    {
        public ExtingguisherItem ExtingguisherItem { get; set; }

        public ExtingguisherModel(ExtingguisherItem extingguisherItem = null)
        {
            Title = extingguisherItem?.EtlSystem;
            ExtingguisherItem = extingguisherItem;
        }
    }
}