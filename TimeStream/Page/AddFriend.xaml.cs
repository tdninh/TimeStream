using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Globalization;
using Telerik.Windows.Data;
using Telerik.Windows.Controls.Primitives;
using Telerik.Windows.Controls;

namespace TimeStream
{
    //RadJumpList radJumpList = new RadJumpList();
    public partial class AddFriend : PhoneApplicationPage
    {
        private List<string> GetDays()
        {
            List<string> days = new List<string>(12);
            foreach (string dayName in DateTimeFormatInfo.CurrentInfo.DayNames)
            {
                days.Add(dayName);
            }
            return days;
        }

        public AddFriend()
        {
            InitializeComponent();
           
            List<string> days = this.GetDays();
            this.radJumpList.ItemsSource = days;

            // add Alphabet item 
            string alphabet = "#abcdefghijklmnopqrstuvwxyz";
            List<string> groupPickerItems = new List<string>(32);
            foreach (char c in alphabet)
            {
                groupPickerItems.Add(new string(c, 1));
            }
            this.radJumpList.GroupPickerItemsSource = groupPickerItems;
            // Group by first name
            GenericGroupDescriptor<string, string>
            groupByFirstName = new GenericGroupDescriptor<string, string>(day => day.Substring(0, 1).ToLower());
            this.radJumpList.GroupDescriptors.Add(groupByFirstName);
        }

        private void radJumpList_GroupPickerItemTap(object sender, GroupPickerItemTapEventArgs e)
        {
            // bi loi~ do ko tim ra group tuong ung
            foreach (DataGroup group in this.radJumpList.Groups)
            {
                if (object.Equals(e.DataItem, group.Key))
                {
                    e.DataItemToNavigate = group;
                    return;
                }
            }
        }
    }
}