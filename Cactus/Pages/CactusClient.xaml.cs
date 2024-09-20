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
    /// Логика взаимодействия для CactusClient.xaml
    /// </summary>
    public partial class CactusClient : Page
    {
        DBModel.Cactus cactusiki;
        public CactusClient(DBModel.Cactus _cactusiki)
        {
            InitializeComponent();
            cactusiki = _cactusiki;
            this.DataContext = cactusiki;
        }
    }
}
