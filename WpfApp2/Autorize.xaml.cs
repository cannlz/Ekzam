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
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Windows.Threading;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Autorize.xaml
    /// </summary>
    public partial class Autorize : Window
    {
        public DispatcherTimer timer = new DispatcherTimer();
        public DispatcherTimer timerForgot = new DispatcherTimer();

        public Autorize()
        {
            InitializeComponent();
            TextPassBox.Visibility = Visibility.Hidden;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += timer_Tick;

            timerForgot.Interval = new TimeSpan(0, 0, 1);
            timerForgot.Tick += timer_Tick;

            LabelLogin.Visibility = Visibility.Hidden;
            ImageBlock.Visibility = Visibility.Hidden; 
        }

        public class rents
        {
            public string name { get; set; }
            public string famil { get; set; }
            public string names { get; set; }
            public string dolznost { get; set; }
            public string photo { get; set; }
        }

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

        private void ButClose_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        string log;
        int index;
        int x = 0;
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (TextPassBox.Text.Length > 0)
            {
                PassBox.Password = TextPassBox.Text;
            }

            if (LoginBox.Text.Length > 0)
            {
                if (PassBox.Password.Length > 0)
                {
                    if (CaptchBox.Text == CapthGenBox.Text)
                    {
                        DataTable dt_apteka = Select("SELECT * FROM [dbo].[users] WHERE [login] = '" + LoginBox.Text + "' AND [pass] = '" + PassBox.Password + "'");
                        if (dt_apteka.Rows.Count > 0)
                        {
                            dt_apteka = Select("SELECT * FROM [dbo].[users]"); // данные из БД  
                            for (int i = 0; i < dt_apteka.Rows.Count; i++) // перебираем данные  
                            {
                                log = dt_apteka.Rows[i][0].ToString();
                                if (log == LoginBox.Text.ToString())
                                {
                                    index = i;
                                }

                            }
                            MainWindow mwnin = new MainWindow();
                            mwnin.Owner = this;
                            mwnin.LabelName.Content = dt_apteka.Rows[index][2].ToString();
                            mwnin.LabelFamil.Content = dt_apteka.Rows[index][3].ToString();
                            mwnin.LabelWork.Content = dt_apteka.Rows[index][5].ToString();
                            mwnin.imagePhoto.Source = new BitmapImage(new Uri(dt_apteka.Rows[index][4].ToString()));
                            mwnin.Show();
                            this.Hide();
                        }
                        else
                        {
                            LabelLogin2.Content = "Неверные данные";
                            LabelPass.Content = "Неверные данные";
                        }
                    }
                }
                else
                {
                    x++;
                    LabelPass.Content = "Пароль не введён";
                }
            }

            else
            {
               x++;
               LabelLogin2.Content = "Логин не введён";
            }

            if (x != 0)
            {
                if (CapthGenBox.Text != "" && CapthGenBox.Text != CaptchBox.Text)
                {
                    timer.Start();
                    LabelLogin.Visibility = Visibility.Visible;
                    LabelLogin2.Visibility = Visibility.Hidden;
                    LoginBox.Visibility = Visibility.Hidden;
                    PassBox.Visibility = Visibility.Hidden;
                    ButShowPass.Visibility = Visibility.Hidden;
                    LabelPass.Visibility = Visibility.Hidden;
                    TextPassBox.Visibility = Visibility.Hidden;
                    ImageLogin.Visibility = Visibility.Hidden;
                    ImagePass.Visibility = Visibility.Hidden;
                    LabelCaptch.Visibility = Visibility.Hidden;
                    LabelVvod.Visibility = Visibility.Hidden;
                    CaptchBox.Visibility = Visibility.Hidden;
                    CapthGenBox.Visibility = Visibility.Hidden;
                    ButNewCaptch.Visibility = Visibility.Hidden;
                    LoginButton.Visibility = Visibility.Hidden;
                    BorderZachem.Visibility = Visibility.Hidden;
                    BorderCaptch.Visibility = Visibility.Hidden;
                    BorderLogin.Visibility = Visibility.Hidden;
                    BorderPass.Visibility = Visibility.Hidden;
                    ForgotBorder.Visibility = Visibility.Hidden;
                    ForogtPass.Visibility = Visibility.Hidden;

                    ImageBlock.Visibility = Visibility.Visible;
                }

                CaptchBox.Text = null;

               
                String allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
                allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";
                allowchar += "1,2,3,4,5,6,7,8,9,0";
                char[] a = { ',' };
                String[] ar = allowchar.Split(a);
                String pwd = "";
                

                Random r = new Random();
                for (int i = 0; i < 4; i++)
                {
                    string temp = ar[(r.Next(0, ar.Length))];
                    pwd += temp;
                }

                if (CapthGenBox.Text != "")
                {
                    CapthGenBox.Text = null;
                }

                CapthGenBox.Text = pwd;    
            }
        }

        int intrerv = 11;
        void timer_Tick(object sender, EventArgs e)
        {
            intrerv--;
            if (intrerv == 0)
            {
                LabelLogin2.Visibility = Visibility.Visible;
                LabelLogin.Visibility = Visibility.Hidden;
                LoginBox.Visibility = Visibility.Visible;
                PassBox.Visibility = Visibility.Visible;
                ButShowPass.Visibility = Visibility.Visible;
                LabelPass.Visibility = Visibility.Visible;

                TextPassBox.Visibility = Visibility.Visible;
                ImageLogin.Visibility = Visibility.Visible;
                ImagePass.Visibility = Visibility.Visible;
                LabelCaptch.Visibility = Visibility.Visible;
                LabelVvod.Visibility = Visibility.Visible;
                CaptchBox.Visibility = Visibility.Visible;
                CapthGenBox.Visibility = Visibility.Visible;
                ButNewCaptch.Visibility = Visibility.Visible;
                LoginButton.Visibility = Visibility.Visible;
                ImageBlock.Visibility = Visibility.Hidden;
                BorderZachem.Visibility = Visibility.Visible;
                BorderCaptch.Visibility = Visibility.Visible;
                BorderLogin.Visibility = Visibility.Visible;
                BorderPass.Visibility = Visibility.Visible;
                ForgotBorder.Visibility = Visibility.Visible;
                ForogtPass.Visibility = Visibility.Visible;

                timer.Stop();
                intrerv = 11;
            }
            LabelLogin.Content = (" Блокировка\nавторизации\n           \n           " + intrerv.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ImageBox.Source = new BitmapImage(new Uri("pack://application:,,,/Close_eye.png"));
            TextPassBox.Text = PassBox.Password;
            TextPassBox.Visibility = Visibility.Visible;
            PassBox.Visibility = Visibility.Hidden;


            Button btn = sender as Button;
            btn.Click -= new RoutedEventHandler(Button_Click);
            btn.Click += new RoutedEventHandler(Button_Click_1);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ImageBox.Source = new BitmapImage(new Uri("pack://application:,,,/eye_open.png"));
            PassBox.Password = TextPassBox.Text;
            TextPassBox.Visibility = Visibility.Hidden;
            PassBox.Visibility = Visibility.Visible;

            Button btn = sender as Button;
            btn.Click -= new RoutedEventHandler(Button_Click_1);
            btn.Click += new RoutedEventHandler(Button_Click);
        }

        private void ButNewCaptch_Click(object sender, RoutedEventArgs e)
        {
            CaptchBox.Text = null;
            String allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";
            allowchar += "1,2,3,4,5,6,7,8,9,0";
            char[] a = { ',' };
            String[] ar = allowchar.Split(a);
            String pwd = "";


            Random r = new Random();
            for (int i = 0; i < 4; i++)
            {
               String temp = ar[(r.Next(0, ar.Length))];
                pwd += temp;
            }

            if (CapthGenBox.Text != "")
            {
                CapthGenBox.Text = null;
            }

            CapthGenBox.Text = pwd;

        }

        private void LoginButton_MouseEnter(object sender, MouseEventArgs e)
        {
            
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void BorderLogin_MouseEnter(object sender, MouseEventArgs e)
        {
            if (LoginBox.Text != "root" || LoginBox.Text == null)
            {
                BorderLogin.BorderBrush = Brushes.White;
            }
            
        }

        private void BorderLogin_MouseLeave(object sender, MouseEventArgs e)
        {
            if (LoginBox.Text.Length > 0)
            {
                BorderLogin.BorderBrush = Brushes.Green;
            }
            else
            {
                BorderLogin.BorderBrush = Brushes.Transparent;
            }
        }

        private void BorderPass_MouseEnter(object sender, MouseEventArgs e)
        {
            BorderPass.BorderBrush = Brushes.White;
            LabelPass.Content = "Пароль";
        }

        private void BorderPass_MouseLeave(object sender, MouseEventArgs e)
        {
            if (PassBox.Password.Length > 0)
            {
                BorderPass.BorderBrush = Brushes.Green;
            }
            else
            {
                BorderPass.BorderBrush = Brushes.Transparent;
            }
        }

        private void BorderZachem_MouseEnter(object sender, MouseEventArgs e)
        {
            BorderZachem.BorderBrush = Brushes.White;
        }

        private void BorderZachem_MouseLeave(object sender, MouseEventArgs e)
        {
            BorderZachem.BorderBrush = Brushes.Transparent;
        }

        private void BorderCaptch_MouseEnter(object sender, MouseEventArgs e)
        {
            BorderCaptch.BorderBrush = Brushes.White;
        }

        private void BorderCaptch_MouseLeave(object sender, MouseEventArgs e)
        {
            BorderCaptch.BorderBrush = Brushes.Transparent;
        }

        public void LoginBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void ForgotBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            ForgotBorder.BorderBrush = Brushes.White;
        }

        private void ForgotBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            ForgotBorder.BorderBrush = Brushes.Transparent;
        }


        private void ForogtPass_Click(object sender, RoutedEventArgs e)
        {
            
            LoginBox.Visibility = Visibility.Hidden;
            PassBox.Visibility = Visibility.Hidden;
            ButShowPass.Visibility = Visibility.Hidden;
            LabelPass.Visibility = Visibility.Hidden;
            TextPassBox.Visibility = Visibility.Hidden;
            ImageLogin.Visibility = Visibility.Hidden;
            ImagePass.Visibility = Visibility.Hidden;
            LabelCaptch.Visibility = Visibility.Hidden;
            LabelVvod.Visibility = Visibility.Hidden;
            CaptchBox.Visibility = Visibility.Hidden;
            CapthGenBox.Visibility = Visibility.Hidden;
            ButNewCaptch.Visibility = Visibility.Hidden;
            LoginButton.Visibility = Visibility.Hidden;
            BorderZachem.Visibility = Visibility.Hidden;
            BorderCaptch.Visibility = Visibility.Hidden;
            BorderLogin.Visibility = Visibility.Hidden;
            BorderPass.Visibility = Visibility.Hidden;
            ForgotBorder.Visibility = Visibility.Hidden;
            ForogtPass.Visibility = Visibility.Hidden;

            BorderClickForg.Visibility = Visibility.Visible;
            LabelForgotPass.Visibility = Visibility.Visible;
            BoderButForg.Visibility = Visibility.Visible;
            ButtobForgotWindow.Visibility = Visibility.Visible;

            Button btn = sender as Button;
            btn.Click -= new RoutedEventHandler(ForogtPass_Click);
            btn.Click += new RoutedEventHandler(ForogtPass_Click_1);
        }

        private void ForogtPass_Click_1(object sender, RoutedEventArgs e)
        {
            LoginBox.Visibility = Visibility.Visible;
            PassBox.Visibility = Visibility.Visible;
            ButShowPass.Visibility = Visibility.Visible;
            LabelPass.Visibility = Visibility.Visible;

            TextPassBox.Visibility = Visibility.Visible;
            ImageLogin.Visibility = Visibility.Visible;
            ImagePass.Visibility = Visibility.Visible;
            LabelCaptch.Visibility = Visibility.Visible;
            LabelVvod.Visibility = Visibility.Visible;
            CaptchBox.Visibility = Visibility.Visible;
            CapthGenBox.Visibility = Visibility.Visible;
            ButNewCaptch.Visibility = Visibility.Visible;
            LoginButton.Visibility = Visibility.Visible;
            ImageBlock.Visibility = Visibility.Hidden;
            BorderZachem.Visibility = Visibility.Visible;
            BorderCaptch.Visibility = Visibility.Visible;
            BorderLogin.Visibility = Visibility.Visible;
            BorderPass.Visibility = Visibility.Visible;
            ForgotBorder.Visibility = Visibility.Visible;
            ForogtPass.Visibility = Visibility.Visible;

            BorderClickForg.Visibility = Visibility.Hidden;
            LabelForgotPass.Visibility = Visibility.Hidden;
            BoderButForg.Visibility = Visibility.Hidden;
            ButtobForgotWindow.Visibility = Visibility.Hidden;

            Button btn = sender as Button;
            btn.Click -= new RoutedEventHandler(ForogtPass_Click_1);
            btn.Click += new RoutedEventHandler(ForogtPass_Click);
        }

        private void BoderButForg_MouseEnter(object sender, MouseEventArgs e)
        {
            BoderButForg.BorderBrush = Brushes.White;
        }

        private void BoderButForg_MouseLeave(object sender, MouseEventArgs e)
        {
            BoderButForg.BorderBrush = Brushes.Transparent;
        }

        private void ButtobForgotWindow_Click(object sender, RoutedEventArgs e)
        {
            LoginBox.Visibility = Visibility.Visible;
            PassBox.Visibility = Visibility.Visible;
            ButShowPass.Visibility = Visibility.Visible;
            LabelPass.Visibility = Visibility.Visible;

            TextPassBox.Visibility = Visibility.Visible;
            ImageLogin.Visibility = Visibility.Visible;
            ImagePass.Visibility = Visibility.Visible;
            LabelCaptch.Visibility = Visibility.Visible;
            LabelVvod.Visibility = Visibility.Visible;
            CaptchBox.Visibility = Visibility.Visible;
            CapthGenBox.Visibility = Visibility.Visible;
            ButNewCaptch.Visibility = Visibility.Visible;
            LoginButton.Visibility = Visibility.Visible;
            ImageBlock.Visibility = Visibility.Hidden;
            BorderZachem.Visibility = Visibility.Visible;
            BorderCaptch.Visibility = Visibility.Visible;
            BorderLogin.Visibility = Visibility.Visible;
            BorderPass.Visibility = Visibility.Visible;
            ForgotBorder.Visibility = Visibility.Visible;
            ForogtPass.Visibility = Visibility.Visible;

            BorderClickForg.Visibility = Visibility.Hidden;
            LabelForgotPass.Visibility = Visibility.Hidden;
            BoderButForg.Visibility = Visibility.Hidden;
            ButtobForgotWindow.Visibility = Visibility.Hidden;
        }

        private void LoginBox_MouseEnter(object sender, MouseEventArgs e)
        {
            LabelLogin2.Content = "Логин";
        }
    }
}
    
