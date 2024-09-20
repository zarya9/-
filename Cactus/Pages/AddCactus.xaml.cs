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
using Cactus.Pages;
using System.IO;
using Microsoft.Win32;

namespace Cactus.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddCactus.xaml
    /// </summary>
    public partial class AddCactus : Page
    {
        DBModel.Cactus cactusi = new DBModel.Cactus();

        public AddCactus()
        {
            InitializeComponent();
        }
        

        
        

        private void TxtCactusName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsLetter(e.Text, 0))
            {

                e.Handled = true;
            }
        }

        private void TxtAge_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }

        private void TxtCactusDescription_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void TxtCost_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }

        //private void BtnAddImage_Click_1(object sender, RoutedEventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
        //    if (openFileDialog.ShowDialog().GetValueOrDefault())
        //    {
        //        cactusi.Image = File.ReadAllBytes(openFileDialog.FileName);
        //        MemoryStream byteStream = new MemoryStream(cactusi.Image);
        //        BitmapImage image = new BitmapImage();
        //        image.BeginInit();
        //        image.StreamSource = byteStream;
        //        image.EndInit();
        //        IPicture.Source = image;
        //    }
        //}

        private void TxtInstruction_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void TxtComment_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }



        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if (string.IsNullOrEmpty(TxtCactusName.Text))
                {
                    MessageBox.Show("Введите название кактуса!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
                if (string.IsNullOrEmpty(TxtCactusDescription.Text))
                {
                    MessageBox.Show("Введите описание!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
                if (string.IsNullOrEmpty(TxtAge.Text))
                {
                    MessageBox.Show("Введите Возраст кактуса!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
                if (string.IsNullOrEmpty(TxtCost.Text))
                {
                    MessageBox.Show("Введите цену!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
                
                cactusi.Name = TxtCactusName.Text;
                cactusi.Opisaniye = TxtCactusDescription.Text;
                cactusi.Age = Convert.ToInt32(TxtAge.Text);
                cactusi.Cost = Convert.ToInt32(TxtCost.Text);
                cactusi.Instruction = TxtInstruction.Text;
                cactusi.Comment = TxtComment.Text;

                ConnectionClass.connect.Cactus.Add(cactusi);
                ConnectionClass.connect.SaveChanges();

                NavigationService.GoBack();
                break;
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();    
        }
    }
}
