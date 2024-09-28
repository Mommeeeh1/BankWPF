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
    /// Interaction logic for AccountsWindow.xaml
    /// </summary>
    public partial class AccountsWindow : Window
    {
        private Client client = new();
        public AccountsWindow(UserManager userManager, User user)
        {
            InitializeComponent();
            this.client = user as Client;
            UpdateUi();
        }

        private void UpdateUi()
        {
            lblSavingsBalance.Content = this.client.SavingsAccount.Balance.ToString();
            lblSalaryBalance.Content = this.client.SalaryAccount.Balance.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Skicka pengar från sparkontot till lönekontot för användaren
            string transferAmount = txtTransferAmount.Text;

            decimal transferAmountD = Convert.ToDecimal(transferAmount);

            AccountManager accountManager = new();

            accountManager.TransferFunds(client.SavingsAccount, client.SalaryAccount, transferAmountD);

            UpdateUi();
        }
    }
}
