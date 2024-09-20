using Cactus.Classes;
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
using Cactus.DBModel;
using System.ComponentModel;


namespace Cactus.Pages
{
    /// <summary>
    /// Логика взаимодействия для Vistavka.xaml
    /// </summary>
    public partial class Vistavka : Page 
    {
        private cactusEntities cactus;
        public Vistavka()
        {
            InitializeComponent();
            LvVistavka.ItemsSource = ConnectionClass.connect.Vistavka.ToList();
            Refresh();
            
            //CommandBindings.Add(new CommandBinding(ApplicationCommands.Close, CloseCommand_Executed));
        }

        //private void CloseCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        //{
        //    NavigationService.GoBack();
        //}

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                NavigationService.GoBack();  
            }
        }

        public void Refresh()
        {
            LvVistavka.ItemsSource = ConnectionClass.connect.Vistavka.ToList();
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            LvVistavka.ItemsSource = ConnectionClass.connect.Vistavka.Where(z => z.Name.ToLower().Contains(TxtSearch.Text)).ToList();

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {

        }

        

        private void BtnSort_az_Click(object sender, RoutedEventArgs e)
        {
            LvVistavka.ItemsSource = ConnectionClass.connect.Vistavka.OrderBy(z => z.Name).ToList();

        }

        

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var i = (sender as Button).DataContext as DBModel.Cactus;
            NavigationService.Navigate(new EditCactus(i));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new VistavkaAdd());
        }

        private void BtnMore_Click(object sender, RoutedEventArgs e)
        {
            var l = (sender as Button).DataContext as DBModel.Vistavka;
            NavigationService.Navigate(new VistavkaInfo(l));
        }

        private void BtnDelete_Click_1(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                var c = LvVistavka.SelectedItem as DBModel.Vistavka;
                if (c != null)
                {
                    ConnectionClass.connect.Vistavka.Remove(c);
                    ConnectionClass.connect.SaveChanges();
                    LvVistavka.ItemsSource = ConnectionClass.connect.Vistavka.ToList();
                }
                else
                {
                    MessageBox.Show("Для начала нужно выбрать!!!");
                }
            }
        }

        private void BtnCact_Click(object sender, RoutedEventArgs e)
        {
            var l = (sender as Button).DataContext as DBModel.Cactus;
            NavigationService.Navigate(new CactusesOnVist(l));
        }

        private void BtnEdit_Click_1(object sender, RoutedEventArgs e)
        {
            var o = (sender as Button).DataContext as DBModel.Vistavka;
            NavigationService.Navigate( new EditVist(o));
        }
    }
}
