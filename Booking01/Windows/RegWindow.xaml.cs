using Booking01.MainCode;
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
    /// <summary>
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        FindHome findHome = new FindHome();
        MainWindow main;
        public RegWindow()
        {
            InitializeComponent();
        }

        private void logibutton_Click(object sender, RoutedEventArgs e)
        {
            main = new MainWindow();
            if (main.findHome.Registration(emailTextBlock.Text, passTextBlock.Text, nameTextBlock.Text, "1990.09.09", pahoneTextBlock.Text))
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
                main.findHome = findHome;

                MessageBox.Show("Успішна реєстрація");

                main.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Спробуйте ще");
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

        private void nameTextBlock_GotFocus(object sender, RoutedEventArgs e)
        {
            nameTextBlock.Text = string.Empty;
        }

        private void emailTextBlock_GotFocus(object sender, RoutedEventArgs e)
        {
            emailTextBlock.Text = string.Empty;
        }

        private void passTextBlock_GotFocus(object sender, RoutedEventArgs e)
        {
            passTextBlock.Text = string.Empty;
        }

        private void pahoneTextBlock_GotFocus(object sender, RoutedEventArgs e)
        {
            pahoneTextBlock.Text = string.Empty;
        }
    }
}
