using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace travel_app.Converters
{
    public class StarVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int rating && parameter is string starNumber)
            {
                int starIndex = int.Parse(starNumber);
                return starIndex <= rating; // Muestra la estrella si el índice es menor o igual a la valoración
            }
            return false; // No muestra la estrella si no se cumple la condición
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
