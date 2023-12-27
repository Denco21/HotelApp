using System;
using System.Globalization;
using System.Windows.Data;
using HotelAppLibraray.Data;
using HotelAppLibraray.Models;
using Microsoft.Extensions.DependencyInjection;


namespace HotelDesktopApp
{
	public class CurrencyConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is decimal decimalValue)
			{
				return decimalValue.ToString("C", CultureInfo.GetCultureInfo("sv-SE"));
			}

			return value.ToString();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
