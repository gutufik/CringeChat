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
    /// Interaction logic for ChatListPage.xaml
    /// </summary>
    public partial class ChatListPage : Page
    {
        public Employee Employee { get; set; }
        public List<Chatroom> Chatrooms { get; set; }
        public ChatListPage()
        {
            InitializeComponent();
            Employee = App.Employee;
            Chatrooms = DataAccess.GetChatrooms();
            DataContext = this;
        }

        private void btnFinder_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.FilterPage());
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Close();
        }

        private void lvChats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var chatroom = (lvChats.SelectedItem as EmployeeChat).Chatroom;
            NavigationService.Navigate(new ChatPage(chatroom));
        }
    }
}
