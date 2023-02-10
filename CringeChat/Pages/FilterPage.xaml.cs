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
    /// Interaction logic for FilterPage.xaml
    /// </summary>
    public partial class FilterPage : Page
    {
        public List<Department> Departments { get; set; }
        public List<Employee> Employees { get; set; }
        public FilterPage()
        {
            InitializeComponent();
            Departments = DataAccess.GetDepartments();
            Employees = new List<Employee>();
            DataContext = this;
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void cbDepartment_Click(object sender, RoutedEventArgs e)
        {
            Employees = new List<Employee>();
            foreach (Department department in Departments)
            {
                if (department.IsChecked)
                    Employees.AddRange(department.Employees);
            }
            lvEmployees.ItemsSource = Employees;
            lvEmployees.Items.Refresh();
        }

        private void lvEmployees_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedMember = (sender as ListView).SelectedItem as Employee;

            NavigationService.Navigate(new ChatPage(
                new Chatroom {
                EmployeeChats = new List<EmployeeChat>
                {
                    new EmployeeChat{Employee = App.Employee},
                    new EmployeeChat{Employee = selectedMember},
                } 
        }));
        }
    }
}
