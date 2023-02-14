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
using CringeChat.DataBase;

namespace CringeChat.Pages
{
    /// <summary>
    /// Interaction logic for AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
            tbName.Text = Properties.Settings.Default.Username;
            pbPassword.Password = Properties.Settings.Default.Password;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            var username = tbName.Text;
            var password = pbPassword.Password.ToString();
            if (DataAccess.GetEmployee(username, password) != null)
            {
                App.Employee = DataAccess.GetEmployee(username, password);

                if ((bool)cbRememberMe.IsChecked) 
                {
                    Properties.Settings.Default.Username = App.Employee.Username;
                    Properties.Settings.Default.Password = password;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.Reset();
                    Properties.Settings.Default.Save();
                }
                NavigationService.Navigate(new Pages.ChatListPage());
            }
            else
                MessageBox.Show("Unknown username or password");

        }

        private void bnCancel_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Close();
        }
    }
}
