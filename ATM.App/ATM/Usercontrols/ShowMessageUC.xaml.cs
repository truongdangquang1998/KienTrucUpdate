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

namespace ATM.Usercontrols
{
    /// <summary>
    /// Interaction logic for ShowMessageUC.xaml
    /// </summary>
    public partial class ShowMessageUC : UserControl
    {
        public ShowMessageUC()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.ShowAndHideUC("Login", null);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.ShowAndHideUC("Login", null);
        }
    }
}
