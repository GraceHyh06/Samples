using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SmartTag
{
    /// <summary>
    /// Interaction logic for SmartTagList.xaml
    /// </summary>
    public partial class SmartTagList : UserControl
    {
        public bool IsRemoveVisible { get; set; } = true;

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<SmartTagViewModel> _itemStrings { get; set; } = new ObservableCollection<SmartTagViewModel>();
        public ObservableCollection<SmartTagViewModel> TagViewModels
        {
            get { return _itemStrings; }
            set
            {
                if (_itemStrings == value) return;
                _itemStrings = value;
                if (this.PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ItemStrings"));
            }
        }

        public SmartTagList()
        {
            InitializeComponent();
        }

        public void RefreshList()
        {
            WrapContainer.ItemsSource = TagViewModels;
        }

        public void RefreshList(IEnumerable<string> itemStrings)
        {
            TagViewModels = new ObservableCollection<SmartTagViewModel>();
            foreach (var s in itemStrings)
                TagViewModels.Add(new SmartTagViewModel { Caption = s, IsRemoveVisible = IsRemoveVisible, Id=Guid.NewGuid() });
            WrapContainer.ItemsSource = TagViewModels;
        }

        public event RoutedEventHandler ItemTagRemoveButtonClicked;
        public event RoutedEventHandler ItemTagClicked;

        private void SmartTag_TagClicked(object sender, RoutedEventArgs e)
        {
            if (ItemTagClicked != null)
                ItemTagClicked(sender, e);
        }

        private void SmartTag_TagRemoveButtonClicked(object sender, RoutedEventArgs e)
        {
            if (ItemTagRemoveButtonClicked != null)
                ItemTagRemoveButtonClicked(sender, e);
            e.Handled = true;
        }

        public void AddSmartTag(string tag, bool isChecked=true)
        {
            TagViewModels.Add(new SmartTagViewModel { Caption = tag, IsRemoveVisible = IsRemoveVisible, IsChecked=isChecked, Id = Guid.NewGuid() });
            RefreshList();
        }

        public void RemoveSmartTag(string tag)
        {
            var st = TagViewModels.FirstOrDefault(s => s.Caption == tag);
            if (st != null)
                TagViewModels.Remove(st);
            RefreshList();
        }
        public void RemoveSmartTag(Guid id)
        {
            var st = TagViewModels.FirstOrDefault(s => s.Id == id);
            if (st != null)
                TagViewModels.Remove(st);
            RefreshList();
        }

        public void UnCheckedTag(string tag)
        {
            var sts = TagViewModels.Where(s => s.Caption == tag).ToList();
            foreach (var st in sts)
                st.IsChecked = false;
            RefreshList();
        }

        public void CheckedTag(string tag)
        {
            var sts = TagViewModels.Where(s => s.Caption == tag).ToList();
            foreach (var st in sts)
                st.IsChecked = true;
            RefreshList();
        }
    }
}
