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

namespace Cactus.Pages
{
    /// <summary>
    /// Логика взаимодействия для MoreCact.xaml
    /// </summary>
    public partial class MoreCact : Page
    {
        DBModel.Cactus cactusiki;
        
        //DBModel.Cactus cactusi = new DBModel.Cactus();
        

        public MoreCact(DBModel.Cactus _cactusiki)
        {
            InitializeComponent();
            cactusiki = _cactusiki;
            this.DataContext = cactusiki;
        }

        

        private void BtnBack_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
