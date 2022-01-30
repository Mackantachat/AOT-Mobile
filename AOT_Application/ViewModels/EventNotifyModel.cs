using System;
using System.Collections.Generic;
using System.Text;
using AOT_Application.Models;


namespace AOT_Application.ViewModels
{
    public class EventNotifyModel : BaseViewModel
    {
        public EventNotifyItem EventNotifyItem { get; set; }

        public EventNotifyModel(EventNotifyItem eventNotifyItem = null)
        {
            Title = eventNotifyItem?.EtlSystem;
            EventNotifyItem = eventNotifyItem;
        }
    }
}
