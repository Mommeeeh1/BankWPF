using BankWPF.Managers;
using BankWPF.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserManager userManager = new();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new(userManager);
            registerWindow.Show(); 
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            List<User> users = userManager.GetAllUsers();

            string username = txtUsername.Text;
            string password = pswPassword.Password;

            bool isFoundUser = false;

            foreach (User user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    // Logga in
                    isFoundUser = true;

                    if (user is Client)
                    {
                        AccountsWindow accountsWindow = new(userManager, user);
                        accountsWindow.Show();
                    }
                    else if (user is Admin)
                    {
                        AdminWindow adminWindow = new(userManager, user);
                        adminWindow.Show();
                    }
                }
            }

            if (!isFoundUser)
            {
                MessageBox.Show("Username or password is incorrect", "Warning");
            }
        }
    }
}