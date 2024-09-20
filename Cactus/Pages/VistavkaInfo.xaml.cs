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
    /// Логика взаимодействия для VistavkaInfo.xaml
    /// </summary>
    public partial class VistavkaInfo : Page
    {
        DBModel.Vistavka vistav;
        public VistavkaInfo(DBModel.Vistavka _vistav)
        {
            InitializeComponent();
            vistav = _vistav;
            this.DataContext = _vistav;
        }

        private void BtnBack_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
