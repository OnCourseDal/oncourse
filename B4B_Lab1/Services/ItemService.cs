using B4B_Lab1.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B4B_Lab1.Services
{
        public static class ItemService
        {
            public static ObservableCollection<ItemViewModel> GetItems()
            {
                //TODO: Connect to web service
                ObservableCollection<ItemViewModel> items = new ObservableCollection<ItemViewModel>();

                // Sample data; replace with real data
                /*items.Add(new ItemViewModel() { ID = "0", LineOne = "CSCI 4116", LineTwo = "Current Grade: ", LineThree = "Assignment due March 5 @ 3:00pm" });
                items.Add(new ItemViewModel() { ID = "1", LineOne = "CSCI 3130", LineTwo = "Current Grade: ", LineThree = "" });
                items.Add(new ItemViewModel() { ID = "2", LineOne = "CSCI 3136", LineTwo = "Current Grade: ", LineThree = "" });
                items.Add(new ItemViewModel() { ID = "3", LineOne = "MUSC 2600Y", LineTwo = "Current Grade: ", LineThree = "" });
                items.Add(new ItemViewModel() { ID = "4", LineOne = "CSCI 4152", LineTwo = "Current Grade: ", LineThree = "Project presentation @ 12:00pm today" });
                */
                return items;
            }

        }
}
