using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.IO;
using System.ComponentModel;
using System.IO.IsolatedStorage;
using System.Windows.Controls;
using System.Windows.Navigation;

using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.UI;

using B4B.Phone.Resources;
using B4B_Lab1.Models;
using B4B_Lab1.ViewModels;
using B4B.Phone.ViewModels;
using B4B_Lab1;

namespace B4B.Phone
{
    public partial class GradeScheme : PhoneApplicationPage
    {
        // Constructor
        public GradeScheme()
        {
            InitializeComponent();
            this.Items = new ObservableCollection<ItemViewModel>();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        public ObservableCollection<ItemViewModel> Items { get; private set; }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (DataContext == null)
            {
                string selectedIndex = "";
                if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
                {
                    int index = DetailsPage.index;
                    //we are currently using the list index to display data. This may conflict with reordering features/sort functionality
                    //int index = int.Parse(selectedIndex);
                    DataContext = App.ViewModel.Items[index];
                }
            }
        }

        public void Save(Scheme schemeInfo)
        {
            using (var IS = IsolatedStorageFile.GetUserStoreForApplication())
            {

                //if the file exists we use set the filemode to "append" so that we add the new courses to the current list.
                if (IS.FileExists("scheme.txt"))
                    using (var Stream = IS.OpenFile("scheme.txt", FileMode.Append))
                    {
                        using (var SW = new StreamWriter(Stream))
                        {
                            SW.WriteLine(schemeInfo);
                        }
                    }
                //otherwise we use filemode.Create to make the original file
                else
                    using (var Stream = IS.OpenFile("scheme.txt", FileMode.Create))
                    {
                        using (var SW = new StreamWriter(Stream))
                        {
                            SW.WriteLine(schemeInfo);
                        }
                    }
            }
        }


        private void Load()
        {
            //removes data in memory before loading the new stuff
            //Scheme.Clear();
            using (var IS = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (IS.FileExists("scheme.txt"))
                    using (var Stream = IS.OpenFile("scheme.txt", FileMode.Open))
                    {
                        using (var SR = new StreamReader(Stream))
                        {
                            while (!SR.EndOfStream)
                            {
                                var Line = SR.ReadLine();
                                var Fields = Line.Split(new char[] { ',' });
                                //this will stop the program from processing blank lines
                                if (Fields[0].Equals(""))
                                    break;

                                Scheme myScheme = new Scheme();
                                //myScheme.setScheme(Fields);
                                //use method within myCourse to format a ViewModel representing one course                               
                                Items.Add(myScheme.getVM());
                            }
                        }
                    }
            }
        }

        private void changeScheme(object sender, RoutedEventArgs e)
        {
            // Check if total = 100
            // If no, error
            // If yes, add all entries to course object
            // Return to Details Page
            int assignments, project, midterm, exam, tests, quizzes, misc;
            bool a = int.TryParse(Assignments.Text, out assignments);
            bool p = int.TryParse(Project.Text, out project);
            bool m = int.TryParse(Midterm.Text, out midterm);
            bool ex = int.TryParse(Exam.Text, out exam);
            bool t = int.TryParse(Tests.Text, out tests);
            bool q = int.TryParse(Quizzes.Text, out quizzes);
            bool mi = int.TryParse(Misc.Text, out misc);

            if ((assignments + project + midterm + exam + tests + quizzes + misc) == 100)
            {
                // do stuff
            }
            else
            {
                // error
            }


            //App.ViewModel.Save(myScheme);
            //App.ViewModel.LoadData();

            NavigationService.Navigate(new Uri("/Views/DetailsPage.xaml?selectedItem=" + DataContext, UriKind.Relative));
        }

        private void addCourse(object sender, RoutedEventArgs e)
        {
            // Create new fields 
            TextBlock symbol = new TextBlock();
            TextBox newCategory = new TextBox();
            TextBox newPercentage = new TextBox();

            symbol.Visibility = System.Windows.Visibility.Visible;
            newCategory.Visibility = System.Windows.Visibility.Visible;
            newPercentage.Visibility = System.Windows.Visibility.Visible;
        }

        // Create onkeypress functions
        /*private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            // check if newest field has been changed, and if so try to autocomplete it 


            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }*/

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}