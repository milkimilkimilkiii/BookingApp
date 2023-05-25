using Booking01.MainCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для MyHousesWindow.xaml
    /// </summary>
    public partial class MyHousesWindow : Window
    {

        public FindHome findHome;
        public bool itsRent;
        public MyHousesWindow()
        {
            InitializeComponent();
            itsRent = false;

            
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow profileWindow = new ProfileWindow();
            profileWindow.findHome = findHome;
            profileWindow.startWin();
            profileWindow.Show();
            this.Close();

        }


        void ButtonG_Click(object sender, RoutedEventArgs e)
        {
            int index = (int)((Button)sender).Tag;

            HousePageWindow housePageWindow = new HousePageWindow();

            if (findHome.session != null) //не отображает кнопки на форме если пользователь вошел в акк
            {
                housePageWindow.loginButton.Visibility = Visibility.Collapsed;
                housePageWindow.regButton.Visibility = Visibility.Collapsed;
                housePageWindow.ackButton.Margin = new Thickness(0, 33, 35, 0);
            }

            housePageWindow.homeId = index;
            housePageWindow.findHome = findHome;

            housePageWindow.home = FindHome.houses.Find(x => x.Id == index);

            housePageWindow.PriceTextlock.Text = housePageWindow.home.Price.ToString();
            housePageWindow.AddressTextlock.Text = housePageWindow.home.Address;
            if (housePageWindow.home.HousesType == HousesType.APARTMENT)
            {
                housePageWindow.TypeTextlock.Text = "Apartment";
                housePageWindow.DescTextlock.Text = $"Країна: {housePageWindow.home.Country}\nКількість кімнат: {housePageWindow.home.NumOfRooms}\nКількість спалень: {housePageWindow.home.NumOfBedrooms}\nПоверх: {((Apartment)housePageWindow.home).Floor}\nОпис: {housePageWindow.home.Description}";
            }
            else if (housePageWindow.home.HousesType == HousesType.HOUSE)
            {
                housePageWindow.TypeTextlock.Text = "House";
                housePageWindow.DescTextlock.Text = $"Країна: {housePageWindow.home.Country}\nКількість кімнат: {housePageWindow.home.NumOfRooms}\nКількість спалень: {housePageWindow.home.NumOfBedrooms}\nКількість поверхів: {((House)housePageWindow.home).NumOfFloors}\nОпис: {housePageWindow.home.Description}";
            }

            if ((housePageWindow.findHome.session != null && housePageWindow.findHome.session.IsAdmin == true) || (housePageWindow.findHome.session != null && housePageWindow.home.OwnerId == housePageWindow.findHome.session.Id))
            {
                Button delButton = new Button();
                delButton.Tag = index;

                delButton.Style = (Style)Resources["RoundedButton"];
                delButton.Content = "Видалити";
                delButton.Foreground = new SolidColorBrush(Colors.White);
                delButton.Background = new SolidColorBrush(Color.FromRgb(40, 72, 154));
                delButton.FontSize = 20;
                delButton.HorizontalAlignment = HorizontalAlignment.Right;
                delButton.Margin = new Thickness(0, 0, 30, 40);
                delButton.VerticalAlignment = VerticalAlignment.Bottom;
                delButton.Height = 45;
                delButton.Width = 100;
                delButton.Padding = new Thickness(1, 1, 1, 5);
                delButton.Click += delButton_Click;

                housePageWindow.MainGrid.Children.Add(delButton);
            }

            if (itsRent)
            {
                Button cancelButton = new Button();
                cancelButton.Tag = index;

                cancelButton.Style = (Style)Resources["RoundedButton"];
                cancelButton.Content = "Відміна оренди";
                cancelButton.Foreground = new SolidColorBrush(Colors.White);
                cancelButton.Background = new SolidColorBrush(Color.FromRgb(40, 72, 154));
                cancelButton.FontSize = 20;
                cancelButton.HorizontalAlignment = HorizontalAlignment.Right;
                cancelButton.Margin = new Thickness(0, 0, 30, 40);
                cancelButton.VerticalAlignment = VerticalAlignment.Bottom;
                cancelButton.Height = 45;
                cancelButton.Width = 150;
                cancelButton.Padding = new Thickness(1, 1, 1, 5);
                cancelButton.Click += cancelButton_Click;

                housePageWindow.MainGrid.Children.Add(cancelButton);
            }

            if (!housePageWindow.home.IsFree)
            {
                //housePageWindow.BookButton.IsEnabled = false;
                housePageWindow.BookButton.Background = (Brush)new BrushConverter().ConvertFromString("#CC0000");
                TextBlock textBlock = new TextBlock();
                textBlock.Text = housePageWindow.BookButton.Content.ToString();
                textBlock.TextDecorations = TextDecorations.Strikethrough;
                housePageWindow.BookButton.Content = textBlock;
                housePageWindow.PriceTextlock.Text = "Зайнято";

            }

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(housePageWindow.home.Images[0]);
            image.EndInit();
            housePageWindow.HomeImage.Source = image;

            housePageWindow.Show();
            this.Close();
        }

        private void delButton_Click(object sender, RoutedEventArgs e)
        {
            int index = (int)((Button)sender).Tag;

            findHome.session.DelHouse(FindHome.houses.Find(x => x.Id == index), findHome.session);
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            int index = (int)((Button)sender).Tag;

            findHome.session.cancelRent(FindHome.houses.Find(x => x.Id == index), findHome.session);

            MessageBox.Show("Ви успішно відмінили оренду");
        }

        public void CreateGrid()
        {
            if (itsRent == false)
            {
                textTextBlock.Text = "Ваші домівки:";
                StackPanel stackPanel = new StackPanel();
                List<Home> searchHouses = new List<Home>();
                foreach (Home home in FindHome.houses)
                {
                    if (home.OwnerId == findHome.session.Id)
                    {
                        searchHouses.Add(home);
                    }
                }

                stackPanel.Orientation = Orientation.Vertical;
                stackPanel.VerticalAlignment = VerticalAlignment.Top;
                stackPanel.HorizontalAlignment = HorizontalAlignment.Left;
                stackPanel.Margin = new Thickness(20, 80, 0, 0);

                for (int i = 0; i < searchHouses.Count;)
                {
                    StackPanel stackPanel1 = new StackPanel();
                    stackPanel1.Orientation = Orientation.Horizontal;
                    stackPanel1.VerticalAlignment = VerticalAlignment.Top;
                    stackPanel1.HorizontalAlignment = HorizontalAlignment.Left;
                    stackPanel1.Margin = new Thickness(0, 40, 0, 0);
                    for (int j = 0; j < 3; j++)
                    {
                        //грид
                        Grid grid = new Grid();
                        grid.Width = 350;
                        grid.Height = 200;
                        grid.Margin = new Thickness(45, 0, 0, 0);

                        //кнопка
                        Button button = new Button();
                        button.Tag = searchHouses[i].Id;


                        button.Click += ButtonG_Click;

                        BitmapImage bitmapImage = new BitmapImage();
                        bitmapImage.BeginInit();
                        bitmapImage.UriSource = new Uri(searchHouses[i].Images[0]);
                        bitmapImage.EndInit();

                        ImageBrush imageBrush = new ImageBrush(bitmapImage);
                        button.Background = imageBrush;


                        Rectangle rectangle = new Rectangle();
                        rectangle.Height = 18;
                        SolidColorBrush brush = new SolidColorBrush(Colors.White);
                        rectangle.Fill = brush;
                        rectangle.VerticalAlignment = VerticalAlignment.Bottom;


                        TextBlock textBlock = new TextBlock();
                        textBlock.VerticalAlignment = VerticalAlignment.Bottom;
                        textBlock.FontSize = 15;
                        textBlock.HorizontalAlignment = HorizontalAlignment.Left;
                        textBlock.Text = searchHouses[i].Description;


                        grid.Children.Add(button);
                        grid.Children.Add(rectangle);
                        grid.Children.Add(textBlock);


                        stackPanel1.Children.Add(grid);

                        i++;

                        if (i > searchHouses.Count - 1)
                        {
                            break;
                        }
                    }
                    stackPanel.Children.Add(stackPanel1);
                }
                BottomGrid.Children.Add(stackPanel);
            }

            else
            {
                textTextBlock.Text = "Орендовані будинки:";
                StackPanel stackPanel = new StackPanel();
                List<Home> searchHouses = new List<Home>();
                foreach (int i in findHome.session.Renting)
                {
                    searchHouses.Add(FindHome.houses.Find(x => x.Id == i));
                }

                stackPanel.Orientation = Orientation.Vertical;
                stackPanel.VerticalAlignment = VerticalAlignment.Top;
                stackPanel.HorizontalAlignment = HorizontalAlignment.Left;
                stackPanel.Margin = new Thickness(20, 80, 0, 0);

                for (int i = 0; i < searchHouses.Count;)
                {
                    StackPanel stackPanel1 = new StackPanel();
                    stackPanel1.Orientation = Orientation.Horizontal;
                    stackPanel1.VerticalAlignment = VerticalAlignment.Top;
                    stackPanel1.HorizontalAlignment = HorizontalAlignment.Left;
                    stackPanel1.Margin = new Thickness(0, 40, 0, 0);
                    for (int j = 0; j < 3; j++)
                    {
                        //грид
                        Grid grid = new Grid();
                        grid.Width = 350;
                        grid.Height = 200;
                        grid.Margin = new Thickness(45, 0, 0, 0);

                        //кнопка
                        Button button = new Button();
                        button.Tag = searchHouses[i].Id;


                        button.Click += ButtonG_Click;

                        BitmapImage bitmapImage = new BitmapImage();
                        bitmapImage.BeginInit();
                        bitmapImage.UriSource = new Uri(searchHouses[i].Images[0]);
                        bitmapImage.EndInit();

                        ImageBrush imageBrush = new ImageBrush(bitmapImage);
                        button.Background = imageBrush;


                        Rectangle rectangle = new Rectangle();
                        rectangle.Height = 18;
                        SolidColorBrush brush = new SolidColorBrush(Colors.White);
                        rectangle.Fill = brush;
                        rectangle.VerticalAlignment = VerticalAlignment.Bottom;


                        TextBlock textBlock = new TextBlock();
                        textBlock.VerticalAlignment = VerticalAlignment.Bottom;
                        textBlock.FontSize = 15;
                        textBlock.HorizontalAlignment = HorizontalAlignment.Left;
                        textBlock.Text = searchHouses[i].Description;


                        grid.Children.Add(button);
                        grid.Children.Add(rectangle);
                        grid.Children.Add(textBlock);


                        stackPanel1.Children.Add(grid);

                        i++;

                        if (i > searchHouses.Count - 1)
                        {
                            break;
                        }
                    }
                    stackPanel.Children.Add(stackPanel1);
                }
                BottomGrid.Children.Add(stackPanel);
            }

        }
    }
}
