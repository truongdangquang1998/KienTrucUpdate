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
    /// Interaction logic for TransferTransactionUC.xaml
    /// </summary>
    public partial class TransferTransactionUC : UserControl
    {
        private string _atmId = ConfigurationManager.AppSettings["atmId"];
        private TransactionService _transactionService;
        public TransferTransactionUC()
        {
            _transactionService = new TransactionService();
            InitializeComponent();
        }



        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            var result = _transactionService.GetTransferTransaction(MainWindow.account, txtTaiKhoanNhan.Text, double.Parse(txtMoney.Text), int.Parse(_atmId));
            MainWindow.mainWindow.ShowAndHideUC("ShowMessagePay", result);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.ShowAndHideUC("Login", null);
        }
    }
}
