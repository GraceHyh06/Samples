using System.Collections.Generic;
using System.ComponentModel;

namespace WpfApplication1
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<EvernoteTagItem> _selectedTags = new List<EvernoteTagItem>();
        public List<EvernoteTagItem> SelectedTags
        {
            get { return _selectedTags; }
            set
            {
                _selectedTags = value;
                if (_selectedTags != value)
                    OnPropertyChanged("SelectedTags");
            }
        }

        public ViewModel()
        {
            this.SelectedTags = new List<EvernoteTagItem>() { new EvernoteTagItem("news"), new EvernoteTagItem("priority") };
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}