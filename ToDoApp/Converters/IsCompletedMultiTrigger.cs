using System;
using System.Globalization;
using Xamarin.Forms;

namespace ToDoApp.Converters
{
    public class IsCompletedMultiTrigger : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var completed = (string)value;
            bool IsDate = DateTime.TryParse(completed, out DateTime result);
            if (IsDate)
            {
                return IsDate;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

