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
    /// Логика взаимодействия для EditCactus.xaml
    /// </summary>
    public partial class EditCactus : Page
    {
        
        DBModel.Cactus cactedit;
        public EditCactus(DBModel.Cactus _cactedit)
        {
            InitializeComponent();
            cactedit = _cactedit;
            this.DataContext = cactedit;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var t = ConnectionClass.connect.Cactus.Where(z => z.ID ==  cactedit.ID).FirstOrDefault();
            t.Name = TxtCactusName.Text;
            t.Opisaniye = TxtCactusDescription.Text;
            t.Age = Convert.ToInt32(TxtAge.Text);
            t.Cost = Convert.ToInt32(TxtCost.Text);
            t.Instruction = TxtInstruction.Text;
            t.Comment = TxtComment.Text;

            
            ConnectionClass.connect.SaveChanges();
            MessageBox.Show("Запись изменена", "Изменение записи", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService.GoBack();
            
        }
    }
}
