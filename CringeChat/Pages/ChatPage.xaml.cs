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
    /// Interaction logic for ChatPage.xaml
    /// </summary>
    public partial class ChatPage : Page
    {
        public Chatroom  Chatroom { get; set; }
        public ChatPage(Chatroom chatroom)
        {
            InitializeComponent();
            Chatroom = chatroom;
            DataAccess.RefreshListEvent += DataAccess_RefreshListEvent;
            DataContext = this;
        }

        private void DataAccess_RefreshListEvent()
        {
            lvMessages.ItemsSource = DataAccess.GetChatMessages(Chatroom);
            lvMessages.Items.Refresh();
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnChangeTopic_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLeaveChat_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSendMessage_Click(object sender, RoutedEventArgs e)
        {
            var message = new ChatMessage 
            { 
                Chatroom = Chatroom, 
                Employee = App.Employee,
                Message = tbMessage.Text,
                Date = DateTime.Now,
            };

            DataAccess.SaveChatMessage(message);
        }
    }
}
