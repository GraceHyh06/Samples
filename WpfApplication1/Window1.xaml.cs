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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        List<SmartTagViewModel> _listItems { get; set; }
        public Window1()
        {
            _listItems = new List<SmartTagViewModel> { new SmartTagViewModel("test 4")
                , new SmartTagViewModel("test 5")
                , new SmartTagViewModel("test 6") };
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WrapContainer.ItemsSource = _listItems;

        }
    }
}
