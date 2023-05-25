using Booking01.MainCode;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace Booking01.Windows
{

    public partial class CreateWindow : Window
    {
        MainWindow main;
        private BitmapImage loadedImage;
        string pathToImage;
        public FindHome findHome;
        HousesType housesType;
        int NumOfRoom;
        int NumOfBedroom;
        int NumOfFloor;
        int floor;


        public CreateWindow()
        {
            InitializeComponent();
            findHome = new FindHome();
            NumOfRoom = 1;
            NumOfBedroom = 1;
            NumOfFloor = 1;
            floor = 1;
        }

        private void logibutton_Click(object sender, RoutedEventArgs e)
        {
            if(findHome.session != null)
            {

                MainWindow main = new MainWindow();
                float price = -1;
                try
                {
                    //floor = int.Parse(floo);
                    price = float.Parse(priceTextBlock.Text);
                }catch(Exception ex) { MessageBox.Show("Введіть цифри у полі \"ціна\""); }

                if(main.findHome.AddHome(ref findHome.session, housesType, descriptionTextBlock.Text, price, countryTextBlock.Text, NumOfRoom, NumOfFloor, NumOfBedroom, addressTextBlock.Text, pathToImage, floor))
                {
                    MainWindow mainWindow = new MainWindow();

                    if (findHome.session != null)
                    {
                        mainWindow.loginButton.Visibility = Visibility.Collapsed;
                        mainWindow.regButton.Visibility = Visibility.Collapsed;
                    }

                    mainWindow.findHome = findHome;

                    MessageBox.Show("Оголошення створено");

                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Щось пішло не так");
                }
            }
            else
            {
                MessageBox.Show("Ви повинні увійти в аккаунт");
            }
        }


        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

            RadioButton radioButton = sender as RadioButton;

            if (radioButton.IsChecked == true)
            {
                if (radioButton.Content.ToString() == "House")
                {
                    textBlockResult.Text = "Выбрано: House";
                    housesType = HousesType.HOUSE;
                }
                else if (radioButton.Content.ToString() == "Apartment")
                {
                    textBlockResult.Text = "Выбрано: Apartment";
                    housesType = HousesType.APARTMENT;
                }
            }
        }

        private void RadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton.IsChecked == false)
            {
                textBlockResult.Text = "Выбрано: ";
            }
        }


        private void imagebutton_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg;*.png)|*.jpg;*.png|All files (*.*)|*.*";
            openFileDialog.Title = "Выберите изображение";

            Nullable<bool> result = openFileDialog.ShowDialog();

            if (result == true)
            {
                try
                {
                    string filePath = openFileDialog.FileName;

                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.UriSource = new Uri(filePath);
                    image.EndInit();

                    loadedImage = image;

                    ImageBrush imageBrush = new ImageBrush(loadedImage);
                    imagebutton.Background = imageBrush;

                    string imageName = Path.GetFileName(filePath);
                    string projectPath = Directory.GetCurrentDirectory();
                    string destinationFolderPath = Path.Combine(projectPath, "HousesImages"); 

                    if (!Directory.Exists(destinationFolderPath))
                    {
                        Directory.CreateDirectory(destinationFolderPath);
                    }

                    string destinationPath = Path.Combine(destinationFolderPath, imageName);
                    File.Copy(filePath, destinationPath, true);


                    pathToImage = destinationPath;

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки изображения: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int selectedIndex = floorBoxNumber.SelectedIndex + 1;
            floorTextBlock.Text = "поверх: " + selectedIndex.ToString();
            floor = selectedIndex;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int selectedIndex = florBoxNumber.SelectedIndex + 1;
            florTextBlock.Text = "кількість поверхів: " + selectedIndex.ToString();
            NumOfFloor = selectedIndex;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            int selectedIndex = bedroomBoxNumber.SelectedIndex + 1;
            bedroomTextBlock.Text = "кількість спалень: " + selectedIndex.ToString();
            NumOfBedroom = selectedIndex;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            int selectedIndex = roomBoxNumber.SelectedIndex + 1;
            roomTextBlock.Text = "кількість кімнат: " + selectedIndex.ToString();
            NumOfRoom = selectedIndex;
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

        private void ProfileButt_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow profileWindow = new ProfileWindow();
            profileWindow.findHome = findHome;
            profileWindow.startWin();
            profileWindow.Show();
            main.Close();
        }

        private void addressTextBlock_GotFocus(object sender, RoutedEventArgs e)
        {
            addressTextBlock.Text = "";
        }

        private void countryTextBlock_GotFocus(object sender, RoutedEventArgs e)
        {
            countryTextBlock.Text = "";
        }

        private void priceTextBlock_GotFocus(object sender, RoutedEventArgs e)
        {
            priceTextBlock.Text = "";
        }

        private void descriptionTextBlock_GotFocus(object sender, RoutedEventArgs e)
        {
            descriptionTextBlock.Text = "";
        }
    }

    
}
