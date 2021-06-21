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
using System.Drawing.Imaging;
using BarcodeLib;
using System.IO;
namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для FinishBuy.xaml
    /// </summary>
    public partial class FinishBuy : Page
    {
        public FinishBuy()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BorderOplata2.Background = Brushes.Green;
            ButNalichiy.IsEnabled = false;
        }

        private void BorderStoimost_MouseEnter(object sender, MouseEventArgs e)
        {
            BorderStoimost.BorderBrush = Brushes.White;
        }

        private void BorderStoimost_MouseLeave(object sender, MouseEventArgs e)
        {
            BorderStoimost.BorderBrush = Brushes.Transparent;
        }

        private void BorderOplata_MouseEnter(object sender, MouseEventArgs e)
        {
            BorderOplata.BorderBrush = Brushes.White;
        }

        private void BorderOplata_MouseLeave(object sender, MouseEventArgs e)
        {
            BorderOplata.BorderBrush = Brushes.Transparent;

        }

        private void BorderOplata2_MouseEnter(object sender, MouseEventArgs e)
        {
            BorderOplata2.BorderBrush = Brushes.White;
        }

        private void BorderOplata2_MouseLeave(object sender, MouseEventArgs e)
        {
            BorderOplata2.BorderBrush = Brushes.Transparent;
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            BorderBuy.BorderBrush = Brushes.White;
        }

        private void BorderBuy_MouseLeave(object sender, MouseEventArgs e)
        {
            BorderBuy.BorderBrush = Brushes.Transparent;
        }

        private void BorderImage_MouseEnter(object sender, MouseEventArgs e)
        {
            BorderImage.BorderBrush = Brushes.White;
        }

        private void BorderImage_MouseLeave(object sender, MouseEventArgs e)
        {
            BorderImage.BorderBrush = Brushes.Transparent;
        }

        private void ButNalichiy_Click(object sender, RoutedEventArgs e)
        {
            BorderOplata.Background = Brushes.Green;
            ButCard.IsEnabled = false;
        }
    }
}
