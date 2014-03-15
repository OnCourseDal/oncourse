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
                ObservableCollection<ItemViewModel> items = new ObservableCollection<ItemViewModel>();

                return items;
            }

        }
}
