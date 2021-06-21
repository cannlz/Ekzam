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
using System.Data.OleDb;
using System.Windows.Threading;
using System.Windows.Media.Effects;
using System.Windows.Media.Animation;




namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class rents
        {
              public string name { get; set; }
              public string opisanie { get; set; }
              public string costs { get; set; }
              public string nalichie_retsepta { get; set; }
              public string nalichie { get; set; }
              public string image { get; set; }
        }

        public class Dannie
        {
            public string name { get; set; }
            public string famil { get; set; }
            public string dolznost { get; set; }
            public string image { get; set; }
        }

        void Lekarstv()
        {
            DataTable dt_apteka = Select("SELECT * FROM [dbo].[Lekarstvennie_preparats]"); // данные из БД  
            for (int i = 0; i < dt_apteka.Rows.Count; i++) // перебираем данные  
            {
                rents Lol = new rents() // создаём экземпляр класса        
                {
                      image = dt_apteka.Rows[i][3].ToString(), // указываем изображение из таблицы    
                      name = dt_apteka.Rows[i][1].ToString(), // указываем название товара         
                      opisanie = dt_apteka.Rows[i][4].ToString(), // указываем описание
                      costs = dt_apteka.Rows[i][5].ToString(), // указываем цену
                      nalichie_retsepta = dt_apteka.Rows[i][6].ToString(), // указываем наличие рецепта
                      nalichie = dt_apteka.Rows[i][2].ToString() // указываем наличие
                };

                listCatalog.Items.Add(Lol); // выводим строку в список 
            }
        }

        void Kosmetics()
        {
            DataTable dt_apteka = Select("SELECT * FROM [dbo].[Kosmetics_Table]"); // данные из БД  
            for (int i = 0; i < dt_apteka.Rows.Count; i++) // перебираем данные  
            {
                rents Lol = new rents() // создаём экземпляр класса        
                {
                    image = dt_apteka.Rows[i][3].ToString(), // указываем изображение из таблицы    
                    name = dt_apteka.Rows[i][1].ToString(), // указываем название товара         
                    opisanie = dt_apteka.Rows[i][4].ToString(), // указываем описание
                    costs = dt_apteka.Rows[i][5].ToString(), // указываем цену
                    nalichie_retsepta = dt_apteka.Rows[i][6].ToString(), // указываем наличие рецепта
                    nalichie = dt_apteka.Rows[i][2].ToString() // указываем наличие
                };

                listCatalog.Items.Add(Lol); // выводим строку в список 
            }
        }

        void Gomeopatic()
        {
            DataTable dt_apteka = Select("SELECT * FROM [dbo].[Gomeopatic]"); // данные из БД  
            for (int i = 0; i < dt_apteka.Rows.Count; i++) // перебираем данные  
            {
                rents Lol = new rents() // создаём экземпляр класса        
                {
                    image = dt_apteka.Rows[i][3].ToString(), // указываем изображение из таблицы    
                    name = dt_apteka.Rows[i][1].ToString(), // указываем название товара         
                    opisanie = dt_apteka.Rows[i][4].ToString(), // указываем описание
                    costs = dt_apteka.Rows[i][5].ToString(), // указываем цену
                    nalichie_retsepta = dt_apteka.Rows[i][6].ToString(), // указываем наличие рецепта
                    nalichie = dt_apteka.Rows[i][2].ToString() // указываем наличие
                };

                listCatalog.Items.Add(Lol); // выводим строку в список 
            }
        }

        DispatcherTimer timerWork = new DispatcherTimer();
        ShoppingCard shop = new ShoppingCard();


        public MainWindow()
        {
            InitializeComponent();

            timerWork.Interval = new TimeSpan(0, 0, 1);
            timerWork.Tick += timer_Tick;
            timerWork.Start();

            Frame1.Navigate(new ShoppingCard());
        }
        MesBox message = new MesBox();

        int intrervMin = 0;
        int intrervSek = 10;
        int intervLock = 60;
        void timer_Tick(object sender, EventArgs e)
        {
            Labeel.Content = ("Осталось время работы: " + intrervMin + " : " + intrervSek);

            intrervSek--;
            if (intrervSek < 10)
            {
                Labeel.Content = ("Осталось время работы: " + intrervMin + " : 0" + intrervSek);
            }

            if (intrervSek == 0 && intrervMin > 0)
            {
                intrervMin--;
                intrervSek = 59;
            }

            if (intrervMin == 5 && intrervSek == 1)
            {
                TranslateTransform transf = new TranslateTransform();
                message.RenderTransform = transf;
                DoubleAnimation animY = new DoubleAnimation(300, 10, TimeSpan.FromSeconds(1));
                transf.BeginAnimation(TranslateTransform.YProperty, animY);
                message.labelMessage.Content = LabelName.Content.ToString() + ", осталось 5 минут\n до окончания сеанса!";
                message.Show();
            }

            if (intrervMin == 4 && intrervSek == 50)
            {
                TranslateTransform transf = new TranslateTransform();
                message.RenderTransform = transf;
                DoubleAnimation animY = new DoubleAnimation(10, 300, TimeSpan.FromSeconds(1));
                transf.BeginAnimation(TranslateTransform.YProperty, animY);
                message.Close();
            }

            if (intrervMin == 0 && intrervSek <= 1)
            {
                intervLock--;
                BlurEffect blur;
                blur = new BlurEffect();
                blur.Radius = 8;
                Border_1.Effect = blur;
                Border_2.Effect = blur;
                Border_3.Effect = blur;
                StackPanel_4.Effect = blur;
                ReLoginBut.IsEnabled = false;
                ButShoppingCard.IsEnabled = false;
                Labeel.Visibility = Visibility.Hidden;
                LabelGlavLock.Visibility = Visibility.Visible;
                ImageGlavLock.Visibility = Visibility.Visible;
                LabelGlavLock.Content = ("Блокировка: " + intervLock + " секунд(ы)");

                if (intervLock == 0)
                {
                    timerWork.Stop();
                    Autorize autr = new Autorize();
                    autr.Show();
                    this.Close();
                }

            }

            
        }

        public Brush brush = new SolidColorBrush(Color.FromRgb(23, 23, 77));
        public Brush brush1 = new SolidColorBrush(Color.FromRgb(9, 9, 44));

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
        private void ReLoginBut_Click(object sender, RoutedEventArgs e)
        {
            Autorize autr = new Autorize();
            autr.Show();
            this.Close();
        }

        private void Border_1_MouseEnter(object sender, MouseEventArgs e)
        {
            Border_1.BorderBrush = Brushes.White;
        }

        private void Border_1_MouseLeave(object sender, MouseEventArgs e)
        {
            Border_1.BorderBrush = Brushes.Transparent;
        }

        private void Border_2_MouseEnter_1(object sender, MouseEventArgs e)
        {
            Border_2.BorderBrush = Brushes.White;
        }

        private void Border_2_MouseLeave(object sender, MouseEventArgs e)
        {
            Border_2.BorderBrush = Brushes.Transparent;
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void StackPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            Border_1.BorderBrush = Brushes.White;
        }

        private void StackPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            Border_1.BorderBrush = Brushes.Transparent;
        }

        private void StackPanel_MouseEnter_1(object sender, MouseEventArgs e)
        {
            Border_2.BorderBrush = Brushes.White;
        }

        private void StackPanel_MouseLeave_1(object sender, MouseEventArgs e)
        {
            Border_2.BorderBrush = Brushes.Transparent;
        }

        private void Button1_MouseEnter(object sender, MouseEventArgs e)
        {
            Button1.Background = brush;
        }

        private void Button1_MouseLeave(object sender, MouseEventArgs e)
        {
            Button1.Background = brush1;
        }

        private void Button2_MouseEnter(object sender, MouseEventArgs e)
        {
            Button2.Background = brush;
        }

        private void Button2_MouseLeave(object sender, MouseEventArgs e)
        {
            Button2.Background = brush1;
        }

        private void Button3_MouseEnter(object sender, MouseEventArgs e)
        {
            Button3.Background = brush;
        }

        private void Button3_MouseLeave(object sender, MouseEventArgs e)
        {
            Button3.Background = brush1;
        }

        private void Button4_MouseEnter(object sender, MouseEventArgs e)
        {
            Button4.Background = brush;
        }

        private void Button4_MouseLeave(object sender, MouseEventArgs e)
        {
            Button4.Background = brush1;
        }

        private void Button5_MouseEnter(object sender, MouseEventArgs e)
        {
            Button5.Background = brush;
        }

        private void Button5_MouseLeave(object sender, MouseEventArgs e)
        {
            Button5.Background = brush1;
        }

        private void Button6_MouseEnter(object sender, MouseEventArgs e)
        {
            Button6.Background = brush;
        }

        private void Button6_MouseLeave(object sender, MouseEventArgs e)
        {
            Button6.Background = brush1;
        }

        private void Button7_MouseEnter(object sender, MouseEventArgs e)
        {
            Button7.Background = brush;
        }

        private void Button7_MouseLeave(object sender, MouseEventArgs e)
        {
            Button7.Background = brush1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            message.Close();
            this.Close();
        }

        private void StackPanel_DragEnter(object sender, DragEventArgs e)
        {

        }


        private void Button2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {

            LabelTakeTovar.Content = "Лекарственные препараты";
            Frame1.Visibility = Visibility.Hidden;
            listCatalog.Items.Clear();
            Lekarstv();
        }

        private void Button2_Click_1(object sender, RoutedEventArgs e)
        {
            LabelTakeTovar.Content = "Косметические средства";
            Frame1.Visibility = Visibility.Hidden;
            listCatalog.Items.Clear();
            Kosmetics();
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            LabelTakeTovar.Content = "Гомеопатические препараты";
            Frame1.Visibility = Visibility.Hidden;
            listCatalog.Items.Clear();
            Gomeopatic();
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            LabelTakeTovar.Content = "Травы";
            Frame1.Visibility = Visibility.Hidden;
            listCatalog.Items.Clear();
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            LabelTakeTovar.Content = "Косметика и гигиена";
            Frame1.Visibility = Visibility.Hidden;
            listCatalog.Items.Clear();
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            LabelTakeTovar.Content = "Оптика";
            Frame1.Visibility = Visibility.Hidden;
            listCatalog.Items.Clear();
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            LabelTakeTovar.Content = "Диета, спорт, питание";
            Frame1.Visibility = Visibility.Hidden;
            listCatalog.Items.Clear();
        }

        int summ;
        public void ButShoppingCard_Click(object sender, RoutedEventArgs e)
        {

            for (int i = 0; i < shop.ListShoppingCard.Items.Count; i++)
            {
                var selectedItem = (dynamic)shop.ListShoppingCard.Items[i];
                summ += Convert.ToInt32(selectedItem.costs);
                shop.LabelCosts.Content = "Итого к оплате: " + summ.ToString();
            }

            LabelTakeTovar.Content = "Товары в корзине";
            Frame1.Visibility = Visibility.Visible;
            Frame1.Navigate(shop);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        public void BuyButton_Click(object sender, RoutedEventArgs e)
        {

        }

        int iz = 0;
        int colvo = 0;
        public void listCatalog_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            iz = listCatalog.SelectedIndex;
            if (listCatalog.IsMouseCaptured == true)
            {
                colvo++;
                LabelKolVoShoppingCard.Content = colvo.ToString();
            }

            ListView list = new ListView();
            if (iz >= 0)
            {
                var selectedItem = (dynamic)listCatalog.Items[iz];
                shop.ListShoppingCard.Items.Add(selectedItem);
                list.Items.Add(selectedItem);
            }
            

        }
        

    }
}
