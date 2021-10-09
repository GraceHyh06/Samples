using System;
using System.ComponentModel;
using System.Windows;

namespace WpfApplication1
{
    public class SmartTagViewModel : ObservableObject
    {
        public SmartTagViewModel()
        {

        }
        public SmartTagViewModel(string caption)
        {
            Caption = caption;
        }

        public Guid? Id { get; set; }
        public string Caption { get; set; }

        bool _isChecked;
        public bool IsChecked { 
            get { return _isChecked; }
            set { 
                _isChecked = value;
                RaisePropertyChanged("IsChecked");
            } 
        }
        public bool IsRemoveVisible { get; set; }
    }
}
