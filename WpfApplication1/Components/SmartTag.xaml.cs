using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for SmartTag.xaml
    /// </summary>
    public partial class SmartTag : UserControl
    {
        public static readonly DependencyProperty CaptionProperty =
               DependencyProperty.Register(
                     "Caption",
                      typeof(string),
                      typeof(SmartTag));

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Caption 
        {
            get
            {
                return (String)GetValue(CaptionProperty);
            }
            set
            {
                SetValue(CaptionProperty, value);
            }
        }

        public static readonly DependencyProperty RemoveVisibilityProperty =
       DependencyProperty.Register(
             "RemoveVisibility",
              typeof(Visibility),
              typeof(SmartTag));

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Visibility RemoveVisibility
        {
            get
            {
                return (Visibility)GetValue(RemoveVisibilityProperty);
            }
            set
            {
                SetValue(RemoveVisibilityProperty, value);
            }
        }

        public static readonly DependencyProperty TagColorProperty =
       DependencyProperty.Register(
             "TagColor",
              typeof(Color),
              typeof(SmartTag),
              new PropertyMetadata(Colors.LightGray));

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color TagColor
        {
            get
            {
                return (Color)GetValue(TagColorProperty);
            }
            set
            {
                SetValue(TagColorProperty, value);
            }
        }

        public static readonly DependencyProperty TagBorderColorProperty =
       DependencyProperty.Register(
             "TagBorderColor",
              typeof(Color),
              typeof(SmartTag),
              new PropertyMetadata(Colors.LightGray));

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color TagBorderColor
        {
            get
            {
                return (Color)GetValue(TagBorderColorProperty);
            }
            set
            {
                SetValue(TagBorderColorProperty, value);
            }
        }

        public event RoutedEventHandler TagRemoveButtonClicked;
        public event RoutedEventHandler TagClicked;

        public SmartTag()
        {
            InitializeComponent();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (TagRemoveButtonClicked != null)
                TagRemoveButtonClicked(this, e);
            e.Handled = true;
        }

        private void Tag_Click(object sender, RoutedEventArgs e)
        {
            if (TagClicked != null)
                TagClicked(this, e);
        }
    }
}
