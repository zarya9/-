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

namespace Cactus.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditVist.xaml
    /// </summary>
    public partial class EditVist : Page
    {
        DBModel.Vistavka vistedit;
        public EditVist(DBModel.Vistavka _vistedit)
        {
            InitializeComponent();
            vistedit = _vistedit;
            this.DataContext = vistedit;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var w = ConnectionClass.connect.Vistavka.Where(z => z.ID == vistedit.ID).FirstOrDefault();
            w.Name = TxtVistName.Text;
            w.Date = Convert.ToDateTime(TxtDate.Text);
            w.Place = TxtAddress.Text;
            w.Nagrada = TxtNagrada.Text;
            w.Comment = TxtComment.Text;


            ConnectionClass.connect.SaveChanges();
            MessageBox.Show("Запись изменена", "Изменение записи", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService.GoBack();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
