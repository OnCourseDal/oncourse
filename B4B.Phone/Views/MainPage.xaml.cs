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
using B4B_Lab1.Models;

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

            //This will find out the index of what is clicked. This info is used to load the details page. (DetailsPage.xaml.cs
            //TODO: This may need to be changed because there may be issues if there are deleted values/unsaved values. Maybe use Course.idUnique instead?
            NavigationService.Navigate(new Uri("/Views/DetailsPage.xaml?selectedItem=" + MainLongListSelector.ItemsSource.IndexOf(MainLongListSelector.SelectedItem as ItemViewModel), UriKind.Relative));
            // Reset selected item to null (no selection)
            MainLongListSelector.SelectedItem = null;
        }

        void submitButtonClickAdd(object sender, RoutedEventArgs e)
        {
            // Add item to file with args
            //PARAM: This must be updated to reflect any changes in new parameters
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
            addForm.Visibility = System.Windows.Visibility.Collapsed;
            remove.Visibility = System.Windows.Visibility.Collapsed;
            MainLongListSelector.Visibility = System.Windows.Visibility.Visible;
        }

        void addCourse(object sender, RoutedEventArgs e)
        {
            //PARAM: This must be updated to reflect any changes in new parameters
            // Grab all information are store it formatted in a string 
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

            int h = 0;
            int m = 0;
            bool hResult = int.TryParse(hour.Text, out h);
            bool mResult = int.TryParse(min.Text, out m);

            if (m == 0 || h == 0) {
                error.Text = "Hour and minute fields must be numbers";

            }   else {
                Course myCourse = new Course();
                myCourse.CourseName = course.Text;
                myCourse.Day = day + " " + hour.Text + ":" + min.Text + ampm;
                myCourse.NextAssign = nextAssign.Text;
                myCourse.CurrGrade = currGrade.Text;
                //should this save and load? Might cause issues when editinf specific fields, or we can hack and make it save for every change
                App.ViewModel.Save(myCourse);
                App.ViewModel.LoadData();
                addForm.Visibility = System.Windows.Visibility.Collapsed;
                MainLongListSelector.Visibility = System.Windows.Visibility.Visible;
            }
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

        public System.Windows.Media.Color Black { get; set; }
    }
}