using BankWPF.Managers;
using BankWPF.Models;
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
using System.Windows.Shapes;

namespace BankWPF
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private List<Client> clients = new();
        private UserManager userManager;
        public AdminWindow(UserManager userManager, User user)
        {
            InitializeComponent();

            this.userManager = userManager;

            FilterClients();
            DisplayFunds();
        }

        private void DisplayFunds()
        {
            foreach (Client client in clients)
            {
                // Skapa ett nytt list view item
                ListViewItem listViewItem = new();

                // Sätta content på list view item:et till en formaterad sträng
                listViewItem.Content = client.GetInfo();
                listViewItem.Tag = client;

                // Lägga till list view item:et till vår list view
                lvAccounts.Items.Add(listViewItem);
            }

        }
        private void FilterClients()
        {
            List<User> users = new();

            users = this.userManager.GetAllUsers();

            foreach (User user in users)
            {
                if (user is Client)
                {
                    clients.Add(user as Client);
                }
            }
        }
        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem selectedItem = lvAccounts.SelectedItem as ListViewItem;

            Client selectedClient = selectedItem.Tag as Client;

            userManager.DeleteUser(selectedClient);

            clients.Clear();
            lvAccounts.Items.Clear();

            FilterClients();
            DisplayFunds();
        }
    }
}
