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
    /// Логика взаимодействия для CactusesOnVist.xaml
    /// </summary>
    public partial class CactusesOnVist : Page
    {
        DBModel.Cactus cact;
        
        public CactusesOnVist(DBModel.Cactus _cact)
        {
            InitializeComponent();
            cact = _cact;
            this.DataContext = cact;
            LvCactus.ItemsSource = ConnectionClass.connect.Cactus.ToList();
            Refresh();
        }

        public void Refresh()
        {
            LvCactus.ItemsSource = null;
            LvCactus.ItemsSource = ConnectionClass.connect.Cactus.ToList();
        }

        private void BtnMore_Click(object sender, RoutedEventArgs e)
        {
            var j = (sender as Button).DataContext as DBModel.Cactus;
            NavigationService.Navigate(new MoreCact(j));
            
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            LvCactus.ItemsSource = ConnectionClass.connect.Cactus.Where(z => z.Name.ToLower().Contains(TxtSearch.Text)).ToList();

        }

        private void BtnSort_az_Click(object sender, RoutedEventArgs e)
        {
            LvCactus.ItemsSource = ConnectionClass.connect.Cactus.OrderBy(z => z.Name).ToList();

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {

        }

        

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                var c = LvCactus.SelectedItem as DBModel.Cactus;
                if (c != null)
                {
                    ConnectionClass.connect.Cactus.Remove(c);
                    ConnectionClass.connect.SaveChanges();
                    LvCactus.ItemsSource = ConnectionClass.connect.Cactus.ToList();
                }
                else
                {
                    MessageBox.Show("Для начала нужно выбрать!!!");
                }
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate( new AddCactus());
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var p = (sender as Button).DataContext as DBModel.Cactus;
            NavigationService.Navigate(new EditCactus(p));
        }
    }
}
