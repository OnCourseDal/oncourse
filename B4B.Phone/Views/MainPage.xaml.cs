using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using B4B.Phone.Resources;
using B4B.Phone.ViewModels;
using B4B_Lab1.ViewModels;

// Database Libraries 
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace B4B.Phone
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the LongListSelector control to the sample data
            DataContext = App.ViewModel;

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        // Handle selection changed on LongListSelector
        private void MainLongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected item is null (no selection) do nothing
            if (MainLongListSelector.SelectedItem == null)
                return;

            // Navigate to the new page
            NavigationService.Navigate(new Uri("/Views/DetailsPage.xaml?selectedItem=" + (MainLongListSelector.SelectedItem as ItemViewModel).ID, UriKind.Relative));

            // Reset selected item to null (no selection)
            MainLongListSelector.SelectedItem = null;
        }

        void submitButtonClickAdd(object sender, RoutedEventArgs e)
        {
            // Add item to file with args
            course.Text = "Course Name";
            hour.Text = "HH";
            min.Text = "MM";
            nextAssign.Text = "Next Assignment";
            currGrade.Text = "Current Grade";

            addForm.Visibility = System.Windows.Visibility.Visible;
            remove.Visibility = System.Windows.Visibility.Visible;
            MainLongListSelector.Visibility = System.Windows.Visibility.Collapsed;
        }

        void submitButtonClickHide(object sender, RoutedEventArgs e)
        {
            // Add item to file with args
            addForm.Visibility = System.Windows.Visibility.Collapsed;
            remove.Visibility = System.Windows.Visibility.Collapsed;
            MainLongListSelector.Visibility = System.Windows.Visibility.Visible;
        }

        void addCourse(object sender, RoutedEventArgs e)
        {
            // Grab all information are store it formatted in a string 
            String courseInfo = "";
            String day = "";
            String ampm = "";

            // Format day
            if (MWF.IsChecked == true)   
                day = "MWF";
            else
                day = "TTh";
            // Format am/pm
            if (AM.IsChecked == true)
                ampm = "AM";
            else
                ampm = "PM";

            courseInfo += course.Text + ",";
            courseInfo += day + " " + hour.Text + ":" + min.Text + ampm + ",";
            courseInfo += nextAssign.Text + ",";
            courseInfo += currGrade.Text;
            //error.Text = courseInfo;
            App.ViewModel.Save(courseInfo);
            App.ViewModel.LoadData();

            //error.Visibility = System.Windows.Visibility.Visible;
            addForm.Visibility = System.Windows.Visibility.Collapsed;
            MainLongListSelector.Visibility = System.Windows.Visibility.Visible;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void LongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

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

        public System.Windows.Media.Color Black { get; set; }
    }
}