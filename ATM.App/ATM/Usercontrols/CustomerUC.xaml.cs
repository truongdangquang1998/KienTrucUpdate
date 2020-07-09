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
    /// Interaction logic for CustomerUC.xaml
    /// </summary>
    public partial class CustomerUC : UserControl
    {
        private string atmId = ConfigurationManager.AppSettings["atmId"];
        private TransactionService _transactionService;
        public CustomerUC()
        {
            _transactionService = new TransactionService();
            InitializeComponent();
        }

        private void btnRutTien_Click(object sender, RoutedEventArgs e)
        {
            //var result = _transactionService.GetWithdrawlTransaction()
            MainWindow.mainWindow.ShowAndHideUC("HowMuch", null);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.ShowAndHideUC("Login", null);
        }

        private void btnDoiMatKhau_Click(object sender, RoutedEventArgs e)
        {

            MainWindow.mainWindow.ShowAndHideUC("ChangePinTransaction", null);
        }

        private void btnNapTien_Click(object sender, RoutedEventArgs e)
        {
            //var result = _transactionService.GetPaymentTransaction()
            MainWindow.mainWindow.ShowAndHideUC("PaymentTransaction", null);
        }

        private void btnXemSoDu_Click(object sender, RoutedEventArgs e)
        {
            var result = _transactionService.GetCheckBalanceTransaction(MainWindow.account);
            MainWindow.mainWindow.ShowAndHideUC("ShowMessageBalance", result);
        }

        private void btnChuyenTien_Click(object sender, RoutedEventArgs e)
        {
            //var result = _transactionService.GetTransferTransaction()
            MainWindow.mainWindow.ShowAndHideUC("TransferTransaction", null);
        }
    }
}
