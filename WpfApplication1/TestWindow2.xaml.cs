using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for TestWindow2.xaml
    /// </summary>
    public partial class TestWindow2 : Window
    {

        public TestWindow2()
        {
            InitializeComponent();
        }

        private void SmartTag_TagRemoveButtonClicked(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show($"{((SmartTag)sender).Caption} remove clicked");
        }

        private void SmartTag_TagClicked(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show($"{((SmartTag)sender).Caption} clicked");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TagListSource.IsRemoveVisible = false;
            TagListSource.RefreshList(new List<string> { "3", "4", "5", "6" });

            var count = TagListSource.WrapContainer.Items.Count;
        }

        private void TagList1_ItemTagClicked(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show($"{((SmartTag)sender).Caption} remove clicked");
        }

        private void TagList1_ItemTagRemoveButtonClicked(object sender, RoutedEventArgs e)
        {
            var tag = (SmartTag)sender;
            TagList1.RemoveSmartTag((Guid)tag.Tag);
            if (!TagList1.TagViewModels.Any(t => t.Caption == tag.Caption))
                TagListSource.UnCheckedTag(tag.Caption);
        }

        private void TagListSource_ItemTagClicked(object sender, RoutedEventArgs e)
        {
            var tag = (SmartTag)sender;
            TagListSource.CheckedTag(tag.Caption);
            //tag.TagColor = Colors.LightGreen;
            TagList1.AddSmartTag(tag.Caption, true);
        }
    }
}
