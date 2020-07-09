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
    /// Interaction logic for InputMoneyUC.xaml
    /// </summary>
    public partial class InputMoneyUC : UserControl
    {
        private string _atmId = ConfigurationManager.AppSettings["atmId"];
        private TransactionService _transactionService;
        public InputMoneyUC()
        {
            _transactionService = new TransactionService();

            InitializeComponent();
            tblNote.Text = "Số tiền rút tối đa cho mỗi giao dịch là 5 triệu.\n Quý khác vui lòng nhập số tiền muốn rút!";
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            var result = _transactionService.GetWithdrawlTransaction(MainWindow.account, int.Parse(txtMoney.Text), int.Parse(_atmId));
            MainWindow.mainWindow.ShowAndHideUC("ShowMessageBill", result);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.ShowAndHideUC("Login", null);
        }

        private void txtMoney_KeyUp(object sender, KeyEventArgs e)
        {
            //string regex = @"\^\d$\";
            //if(Regex.IsMatch(e.Key.ToString(), regex))
            //{

            //}

        }
    }
}
