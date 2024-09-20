


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
using Cactus.Classes;
using Cactus.DBModel;
using Cactus.Pages;

namespace Cactus.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        MainWindow _mainWindow;
        public Authorization(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;

        }

        private void ButtonLogIn_Click(object sender, RoutedEventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Password;

            var user = ConnectionClass.connect.Logins.FirstOrDefault(log => log.Login == login && log.Password == password);
            if (user == null)
            {
                MessageBox.Show("Пользователь не найден!");
                return;
            }
            string rights = ConnectionClass.connect.Users.FirstOrDefault(us => us.ID == user.UserID).Access;
            MessageBox.Show($"Вы авторизовались как {rights}!");
            if (rights == "Admin     ")
            {
                NavigationService.Navigate(new Vistavka());
            }
            else if (rights == "Visitor   ")
            {
                NavigationService.Navigate(new VistavkaGuest());
            }
            


        }
    }
}
