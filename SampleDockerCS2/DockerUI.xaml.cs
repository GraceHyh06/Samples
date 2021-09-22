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
using System.Windows.Navigation;
using System.Windows.Shapes;
using corel = Corel.Interop.VGCore;

namespace SampleDockerCS2
{
    public partial class DockerUI : UserControl
    {
        private corel.Application corelApp;
        private Styles.StylesController stylesController;
        public DockerUI(object app)
        {
            InitializeComponent();
            try
            {
                this.corelApp = app as corel.Application;
                stylesController = new Styles.StylesController(this.Resources, this.corelApp);
            }
            catch
            {
                global::System.Windows.MessageBox.Show("VGCore Erro");
            }

        }
        public DockerUI()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            stylesController?.LoadThemeFromPreference();
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("Corel Draw泊坞窗测试\nHello, World!");
        }
    }
}
