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
    /// Логика взаимодействия для CactusForVisitor.xaml
    /// </summary>
    public partial class CactusForVisitor : Page
    {
        DBModel.Cactus cactusinfo;
        public CactusForVisitor(DBModel.Cactus _cactusinfo)
        {
            InitializeComponent();
            LvCactus.ItemsSource = ConnectionClass.connect.Cactus.ToList();
            cactusinfo = _cactusinfo;
            this.DataContext = _cactusinfo;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            LvCactus.ItemsSource = ConnectionClass.connect.Cactus.Where(z => z.Name.ToLower().Contains(TxtSearch.Text)).ToList();
        }

        private void BtnCact_Click(object sender, RoutedEventArgs e)
        {
            var c = (sender as Button).DataContext as DBModel.Cactus;
            NavigationService.Navigate(new CactusesOnVist(c));
        }

        private void BtnSort_az_Click(object sender, RoutedEventArgs e)
        {
            LvCactus.ItemsSource = ConnectionClass.connect.Cactus.OrderBy(z => z.Name).ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BtnMore_Click(object sender, RoutedEventArgs e)
        {
            var q = (sender as Button).DataContext as DBModel.Cactus;
            NavigationService.Navigate(new MoreCact(q));
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            LvCactus.ItemsSource = ConnectionClass.connect.Cactus.Where(z => z.Name.ToLower().Contains(TxtSearch.Text)).ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
