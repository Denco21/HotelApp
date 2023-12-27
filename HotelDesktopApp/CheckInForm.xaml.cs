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
using System.Windows.Shapes;
using System.Globalization;

namespace HotelDesktopApp
{
    /// <summary>
    /// Interaction logic for CheckInForm.xaml
    /// </summary>
    public partial class CheckInForm : Window
    {
        private readonly IDataBaseData _db;
        private  BookingFullModel _data = null;


        public CheckInForm(IDataBaseData db)
        {
            InitializeComponent();
            _db = db;
        }

        public IDataBaseData Db { get; }

        public void PopulateCheckInInfo(BookingFullModel data)
        {
            _data = data;
            firstNameText.Text = data.FirstName;
            lastNameText.Text = data.LastName;
            titleText.Text = data.Title;
            roomNumberText.Text = data.RoomNumber.ToString();
			totalCostText.Text = data.TotalCost.ToString("C", CultureInfo.GetCultureInfo("sv-SE"));

		}

        private void checkInUser_Click(object sender, RoutedEventArgs e)
        {
            _db.CheckInGuest(_data.Id);
    
            this.Close();
        }

    }
}
