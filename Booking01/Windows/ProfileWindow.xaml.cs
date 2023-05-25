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

namespace Booking01.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        MainWindow main;
        public FindHome findHome;
        public ProfileWindow()
        {
            InitializeComponent();
        }

        public void startWin()
        {
            nameBlock.Text = findHome.session.FirstName + " " + findHome.session.LastName;
            emailBlock.Text = findHome.session.Email;
            phoneBlock.Text = findHome.session.PhoneNumber.ToString();
            rentBlock.Text = "Знімає " + findHome.session.Renting.Count.ToString() + " квартири";

            int i = 0;
            foreach (Home item in FindHome.houses)
            {
                if(item.OwnerId == findHome.session.Id)
                {
                    i++;
                }
            }
            ownCountBlock.Text = "Володіє " + i.ToString() + " квартирами";

        }

        private void backButton_Click(object sender, RoutedEventArgs e)
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

        private void ProfileButt_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow profileWindow = new ProfileWindow();
            profileWindow.findHome = findHome;
            profileWindow.startWin();
            profileWindow.Show();
            main.Close();
        }

        private void ownButton_Click(object sender, RoutedEventArgs e)
        {
            MyHousesWindow myHousesWindow = new MyHousesWindow();
            myHousesWindow.findHome = findHome;
            myHousesWindow.itsRent = false;
            myHousesWindow.Show();
            myHousesWindow.CreateGrid();
            this.Close();
        }

        private void rentButton_Click(object sender, RoutedEventArgs e)
        {
            MyHousesWindow myHousesWindow = new MyHousesWindow();
            myHousesWindow.findHome = findHome;
            myHousesWindow.itsRent = true;
            myHousesWindow.Show();
            myHousesWindow.CreateGrid();
            this.Close();
        }
    }


}
