using System;
using System.Collections.Generic;
using System.Text;

namespace AOT_Application.Models
{
    public enum MenuItemType
    {
        Login,
        //Browse,
        //About,
        ListFierExtinguisher,
        ListVeciel,
        ListCriminalPerson,
        ListCriminalVehicle,
        ListEventNotify,
        ItemsPage
    }
   
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
  
}
