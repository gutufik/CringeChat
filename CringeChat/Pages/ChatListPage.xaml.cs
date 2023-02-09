﻿using System;
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

namespace CringeChat.Pages
{
    /// <summary>
    /// Interaction logic for ChatListPage.xaml
    /// </summary>
    public partial class ChatListPage : Page
    {
        public string EmployeeName { get; set; }
        public ChatListPage()
        {
            InitializeComponent();
            EmployeeName = App.Employee.Name;
            DataContext = this;
        }

        private void btnFinder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}