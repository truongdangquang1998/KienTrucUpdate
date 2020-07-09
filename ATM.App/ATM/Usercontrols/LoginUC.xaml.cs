using ApiModel;
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
    /// Interaction logic for LoginUC.xaml
    /// </summary>
    public partial class LoginUC : UserControl
    {
        private string atmId = ConfigurationManager.AppSettings["atmId"];
        private LoginService _loginService;
        public LoginUC()
        {
            _loginService = new LoginService();
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var account = _loginService.GetLoginAsync(txtUser.Text, txtPass.Password, int.Parse(atmId));
            if (account.Result == "Success")
            {
                if (account.Role == ApiUserLoginModel.AccountRole.Staff)
                    MainWindow.mainWindow.ShowAndHideUC("Staff", account);
                else
                    MainWindow.mainWindow.ShowAndHideUC("Customer", account);
            }
            else
            {
                MessageBox.Show(account.ErrorMessages[0], "Error", MessageBoxButton.OK);
            }
        }
    }
}
