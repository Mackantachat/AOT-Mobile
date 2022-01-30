using System;

using AOT_Application.Models;

namespace AOT_Application.ViewModels
{
    public class HistoryCriminalPersonModel : BaseViewModel
    {
        public HistoryCriminalPersonItem HistoryCriminalPersonItem { get; set; }
        public Item Item { get; set; }

        public HistoryCriminalPersonModel(HistoryCriminalPersonItem historyCriminalPersonItem = null)
        {
            Title = historyCriminalPersonItem?.Text;
            HistoryCriminalPersonItem = historyCriminalPersonItem;
        }
        public HistoryCriminalPersonModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}