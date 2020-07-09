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
    /// Interaction logic for HowMuch.xaml
    /// </summary>
    public partial class HowMuch : UserControl
    {
        private string _string1;
        public string String1
        {
            get { return _string1; }
            set
            {
                _string1 = value;
            }
        }




        private string _atmId;
        private TransactionService _transactionService;
        public HowMuch()
        {

            _atmId = ConfigurationManager.AppSettings["atmId"];
            _transactionService = new TransactionService();
            InitializeComponent();
        }

        private void btn500_Click(object sender, RoutedEventArgs e)
        {
            var result = _transactionService.GetWithdrawlTransaction(MainWindow.account, 500000, int.Parse(_atmId));
            MainWindow.mainWindow.ShowAndHideUC("ShowMessageBill", result);
        }

        private void btn1000_Click(object sender, RoutedEventArgs e)
        {
            var result = _transactionService.GetWithdrawlTransaction(MainWindow.account, 1000000, int.Parse(_atmId));
            MainWindow.mainWindow.ShowAndHideUC("ShowMessageBill", result);
        }

        private void btn1500_Click(object sender, RoutedEventArgs e)
        {
            var result = _transactionService.GetWithdrawlTransaction(MainWindow.account, 1500000, int.Parse(_atmId));
            MainWindow.mainWindow.ShowAndHideUC("ShowMessageBill", result);
        }

        private void btn2000_Click(object sender, RoutedEventArgs e)
        {
            var result = _transactionService.GetWithdrawlTransaction(MainWindow.account, 2000000, int.Parse(_atmId));
            MainWindow.mainWindow.ShowAndHideUC("ShowMessageBill", result);
        }

        private void btn300_Click(object sender, RoutedEventArgs e)
        {
            var result = _transactionService.GetWithdrawlTransaction(MainWindow.account, 3000000, int.Parse(_atmId));
            MainWindow.mainWindow.ShowAndHideUC("ShowMessageBill", result);
        }

        private void btnOther_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.ShowAndHideUC("InputMoney", null);

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.ShowAndHideUC("Login", null);
        }
    }
}
