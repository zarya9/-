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
    /// Логика взаимодействия для VistavkaGuest.xaml
    /// </summary>
    public partial class VistavkaGuest : Page
    {
        private cactusEntities vist;

        public VistavkaGuest()
        {
            InitializeComponent();
            LvVistavka.ItemsSource = ConnectionClass.connect.Vistavka.ToList();

        }
    
        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            LvVistavka.ItemsSource = ConnectionClass.connect.Vistavka.Where(z => z.Name.ToLower().Contains(TxtSearch.Text)).ToList();

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            LvVistavka.ItemsSource = ConnectionClass.connect.Vistavka.Where(z => z.Name.ToLower().Contains(TxtSearch.Text)).ToList();

        }

        private void BtnSort_az_Click(object sender, RoutedEventArgs e)
        {
            LvVistavka.ItemsSource = ConnectionClass.connect.Vistavka.OrderBy(z => z.Name).ToList();
        }

        private void BtnMore_Click(object sender, RoutedEventArgs e)
        {
            var b = (sender as Button).DataContext as DBModel.Vistavka;
            NavigationService.Navigate( new VistavkaInfo(b));
        }

        private void BtnCact_Click(object sender, RoutedEventArgs e)
        {
            var c = (sender as Button).DataContext as DBModel.Cactus;
            NavigationService.Navigate(new CactusForVisitor(c));
        }
    }
}
