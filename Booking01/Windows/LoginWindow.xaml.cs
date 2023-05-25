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

    public partial class LoginWindow : Window
    {
        MainWindow main;
        public FindHome findHome;

        public LoginWindow()
        {
            InitializeComponent();
            main = new MainWindow();
        }

        private void logibutton_Click(object sender, RoutedEventArgs e)
        {
           
            if(findHome.Login(emailTextBlock.Text, passTextBlock.Text))
            {

                main.loginButton.Visibility = Visibility.Collapsed;
                main.regButton.Visibility = Visibility.Collapsed;
                main.newAdButton.Margin = new Thickness(0,33,180,0);

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
                main.findHome = findHome;
                main.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Не вірний логін або пароль");
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

        private void emailTextBlock_GotFocus(object sender, RoutedEventArgs e)
        {
            emailTextBlock.Text = string.Empty;
        }

        private void passTextBlock_GotFocus(object sender, RoutedEventArgs e)
        {
            passTextBlock.Text = string.Empty;
        }
    }
}
