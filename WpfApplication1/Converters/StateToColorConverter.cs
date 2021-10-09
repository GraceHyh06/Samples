using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfApplication1
{
    public class StateToColorConverter : IMultiValueConverter
    {
        static Dictionary<Tuple<bool, bool, bool>, Color> _stateToColorDictionary = new Dictionary<Tuple<bool, bool, bool>, Color> {
            { new Tuple<bool, bool, bool>(false, false, false), Colors.LightGray },
            { new Tuple<bool, bool, bool>(false, false, true), Colors.DarkGray },
            { new Tuple<bool, bool, bool>(false, true, false), Colors.LightGreen },
            { new Tuple<bool, bool, bool>(false, true, true), Colors.DarkGreen },
            { new Tuple<bool, bool, bool>(true, false, false), Colors.Green },
            { new Tuple<bool, bool, bool>(true, false, true), Colors.DarkGreen },
            { new Tuple<bool, bool, bool>(true, true, false), Colors.Green },
            { new Tuple<bool, bool, bool>(true, true, true), Colors.DarkGreen },
        };
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Visibility.Collapsed;
            var isShow = (bool)value;
            return isShow ? Visibility.Visible : Visibility.Collapsed;
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var isSelected = (bool)values[0];
            var isChecked = (bool)values[1];
            var isBorder = (bool)values[2];
            return _stateToColorDictionary[new Tuple<bool, bool, bool>(isSelected, isChecked, isBorder)];
        }


        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
