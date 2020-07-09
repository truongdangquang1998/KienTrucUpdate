using ATM.ApiServices;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Interaction logic for StaffUC.xaml
    /// </summary>
    public partial class StaffUC : UserControl
    {
        private string _atmId = ConfigurationManager.AppSettings["atmId"];
        private StaffService _staffService;
        private TransactionService _transactionService;
        public StaffUC()
        {
            _transactionService = new TransactionService();
            _staffService = new StaffService();
            InitializeComponent();
        }

        private void ThongKeGiaoDich_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.ShowAndHideUC("", null);
        }

        private void btnKiemTraLuongTien_Click(object sender, RoutedEventArgs e)
        {
            var result = _staffService.GetStaffCheckBalance(int.Parse(_atmId));
            MainWindow.mainWindow.ShowAndHideUC("CheckMoneyATM", result);
        }

        private void btnShutdow_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Bạn muốn tắt máy", "Shut down", MessageBoxButton.OKCancel);
            if (MessageBoxResult.OK == result)
            {
                Environment.Exit(-1);
            }
        }

        private void btnNapTien_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.ShowAndHideUC("", null);
        }

        private void btnDoiMatKhau_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.ShowAndHideUC("ChangePinTransaction", null);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.ShowAndHideUC("Login", null);
        }
    }
}
