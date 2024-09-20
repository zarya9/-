using Cactus.Classes;
using Cactus.DBModel;
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

namespace Cactus.Pages
{
    /// <summary>
    /// Логика взаимодействия для VistavkaAdd.xaml
    /// </summary>
    public partial class VistavkaAdd : Page
    {
        DBModel.Vistavka Vist = new DBModel.Vistavka();
        public VistavkaAdd()
        {
            InitializeComponent();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if (string.IsNullOrEmpty(TxtVistName.Text))
                {
                    MessageBox.Show("Введите название выставки!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
                if (string.IsNullOrEmpty(TxtDate.Text))
                {
                    MessageBox.Show("Введите Дату проведения!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
                if (string.IsNullOrEmpty(TxtAddress.Text))
                {
                    MessageBox.Show("Введите место проведения!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
                

                Vist.Name = TxtVistName.Text;
                Vist.Date = Convert.ToDateTime( TxtDate.Text);
                Vist.Place = TxtAddress.Text;
                Vist.Nagrada = TxtNagrada.Text;
                Vist.Comment = TxtComment.Text;

                ConnectionClass.connect.Vistavka.Add(Vist);
                ConnectionClass.connect.SaveChanges();
                NavigationService.Navigate(new Vistavka());
                break;
            }
        }
    }
}
