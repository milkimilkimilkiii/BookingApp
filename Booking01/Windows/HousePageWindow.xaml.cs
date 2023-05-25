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
using Booking01.MainCode;

namespace Booking01.Windows
{

    public partial class HousePageWindow : Window
    {
        MainWindow main;
        public FindHome findHome;
        public Home home;
        public int homeId;
        public HousePageWindow()
        {
            InitializeComponent();

        }
        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.findHome = findHome;
            loginWindow.Show();
            this.Close();
        }

        private void regButton_Click(object sender, RoutedEventArgs e)
        {
            RegWindow regWindow = new RegWindow();
           
            regWindow.Show();
            this.Close();
        }

        private void ackButton_Click(object sender, RoutedEventArgs e)
        {
            main = new MainWindow();
            if (findHome.session != null)
            {
                main.loginButton.Visibility = Visibility.Collapsed;
                main.regButton.Visibility = Visibility.Collapsed;
                main.newAdButton.Margin = new Thickness(0, 33, 180, 0);

                Button button = new Button();
                button.VerticalAlignment = VerticalAlignment.Top;
                button.HorizontalAlignment = HorizontalAlignment.Right;
                button.Width = 70;
                button.Height = 70;
                button.Margin = new Thickness(0, 15, 15, 0);
                string imagePath = "profilePic.jpg";
                BitmapImage bitmap = new BitmapImage(new Uri(imagePath, UriKind.Relative));
                ImageBrush brush = new ImageBrush(bitmap);
                button.Background = brush;
                button.Click += ProfileButt_Click;

                main.TopGrid.Children.Add(button);

            }
            main.findHome = findHome;
            main.Show();
            this.Close();
        }

        private void BookButton_Click(object sender, RoutedEventArgs e)
        {
            if (home.IsFree && findHome.session != null)
            {
                if(home.OwnerId != findHome.session.Id)
                {
                    findHome.session.Book(home, findHome.session, DateTime.Now);
                }
                else
                {
                    MessageBox.Show("Ви не можете забронювати свій будинок!");
                }

            }
            else
            {
                MessageBox.Show("спочатку увійдіть до облікового запису");
            }
        }

        private void ProfileButt_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow profileWindow = new ProfileWindow();
            profileWindow.findHome = findHome;
            profileWindow.startWin();
            profileWindow.Show();
            main.Close();
        }
    }
}
