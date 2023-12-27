using HotelAppLibraray.Data;
using HotelAppLibraray.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace HotelDesktopApp
{
    
    public partial class MainWindow : Window
    {
        private readonly IDataBaseData _db;



        public MainWindow(IDataBaseData db)
        {
            InitializeComponent();
            _db = db;
        }

		


		private void searchForGuest_Click(object sender, RoutedEventArgs e)
        {
            List<BookingFullModel> bookings = _db.SearchBookings(lastNameText.Text);
            guestList.ItemsSource = bookings;
          
        }

        private void CheckInButton_Click(object sender, RoutedEventArgs e)
        {
            var checkInForm = App.serviceProvider.GetService<CheckInForm>();
            var model = (BookingFullModel)((Button)e.Source).DataContext; 
            checkInForm.PopulateCheckInInfo(model);
            checkInForm.Show();
        }
    }
}
