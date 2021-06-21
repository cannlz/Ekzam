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
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using BarcodeLib;
using System.IO;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для ShoppingCard.xaml
    /// </summary>
    public partial class ShoppingCard : Page
    {
        
        public ShoppingCard()
        {
            InitializeComponent();

        }

        private void ButtonBuy2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BordBuy_MouseEnter(object sender, MouseEventArgs e)
        {
            BordBuy.BorderBrush = Brushes.White;
        }

        private void BordBuy_MouseLeave(object sender, MouseEventArgs e)
        {
            BordBuy.BorderBrush = Brushes.Transparent;
        }

        public class rents
        {
            public string name { get; set; }
            public string opisanie { get; set; }
            public string costs { get; set; }
            public string nalichie_retsepta { get; set; }
            public string nalichie { get; set; }
            public string image { get; set; }
            
        }
        public int summ;

        
        public DataTable Select(string selectSQL) // функция подключения к базе данных и обработка запросов
        {
            DataTable dataTable = new DataTable("dataBase");                // создаём таблицу в приложении
                                                                            // подключаемся к базе данных
            SqlConnection sqlConnection = new SqlConnection("server=DELOWERPC;Trusted_Connection=Yes;DataBase=apteka;");
            sqlConnection.Open();                                           // открываем базу данных
            SqlCommand sqlCommand = sqlConnection.CreateCommand();          // создаём команду
            sqlCommand.CommandText = selectSQL;                             // присваиваем команде текст
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand); // создаём обработчик
            sqlDataAdapter.Fill(dataTable);                                 // возращаем таблицу с результатом
            return dataTable;
        }

        DateTime date = DateTime.Now;
        FinishBuy page = new FinishBuy();
        private void ButtonBuy_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < ListShoppingCard.Items.Count; i++)
            {
                var selectedItem = (dynamic)ListShoppingCard.Items[i];
                page.ListBuy.Items.Add(selectedItem);
            }

            string gener = "91" + date.Day + date.Month + date.Year + "342";
            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            System.Drawing.Image img = b.Encode(BarcodeLib.TYPE.UPCA, gener, System.Drawing.Color.Black, System.Drawing.Color.White, 290, 120);

            MemoryStream ms = new MemoryStream();
            img.Save(ms, ImageFormat.Bmp);//save image in memory

            byte[] buffer = ms.GetBuffer();
            //Create new MemoryStream that has the contents of buffer
            MemoryStream bufferPasser = new MemoryStream(buffer);
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.StreamSource = bufferPasser;
            bitmap.EndInit();
            page.ImageStrih.Source = bitmap;//I set the source of the image control type as the new //BitmapImage created earlier.
            page.LabelStoimostLast.Content = LabelCosts.Content;
            NavigationService.Navigate(page);
        }

        private void ListShoppingCard_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
