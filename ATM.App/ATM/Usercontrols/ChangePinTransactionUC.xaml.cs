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
    /// Interaction logic for ChangePinTransactionUC.xaml
    /// </summary>
    public partial class ChangePinTransactionUC : UserControl
    {
        private string _atmId = ConfigurationManager.AppSettings["atmId"];
        private StaffService _staffService;
        private TransactionService _transactionService;
        public ChangePinTransactionUC()
        {
            _transactionService = new TransactionService();
            _staffService = new StaffService();
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

            MainWindow.mainWindow.ShowAndHideUC("Login", null);
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            var result = _transactionService.GetChangePinTransaction(MainWindow.account, txtPassOld.Password, txtPassNew.Password);
            MainWindow.mainWindow.ShowAndHideUC("ShowMessage", result);
        }
    }
}
