using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Matches
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
