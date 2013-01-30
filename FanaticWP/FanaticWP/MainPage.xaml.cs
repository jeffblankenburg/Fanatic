using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using FanaticWP.Resources;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FanaticWP
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Random r = new Random();
            //int random = r.Next(0, 7);
            //SetBackground(random);
        }

        private void SetBackground(int random)
        {
            ImageBrush imgBrush = new ImageBrush();
            
            switch (random)
            {
                case 0:
                    imgBrush.ImageSource = new BitmapImage(new Uri("Assets/images/Baseball.png", UriKind.Relative));
                    break;
                case 1:
                    imgBrush.ImageSource = new BitmapImage(new Uri("Assets/images/Basketball.png", UriKind.Relative));
                    break;
                case 2:
                    imgBrush.ImageSource = new BitmapImage(new Uri("Assets/images/Football.png", UriKind.Relative));
                    break;
                case 3:
                    imgBrush.ImageSource = new BitmapImage(new Uri("Assets/images/Hockey.png", UriKind.Relative));
                    break;
                case 4:
                    imgBrush.ImageSource = new BitmapImage(new Uri("Assets/images/Soccer.png", UriKind.Relative));
                    break;
                case 5:
                    imgBrush.ImageSource = new BitmapImage(new Uri("Assets/images/Golf.png", UriKind.Relative));
                    break;
                case 6:
                    imgBrush.ImageSource = new BitmapImage(new Uri("Assets/images/Tennis.png", UriKind.Relative));
                    break;
            }
            BackgroundImage.ImageSource = imgBrush.ImageSource;
        }

        private void NewUserButton_Click(object sender, EventArgs e)
        {
            SetAppBar(1);
        }

        private void SetAppBar(int p)
        {
            ApplicationBar = new ApplicationBar();
            ApplicationBar.Opacity = .2;
            switch (p)
            {
                case 0:
                    NameBox.Visibility = Visibility.Collapsed;
                    ApplicationBarIconButton button1 = new ApplicationBarIconButton();
                    button1.IconUri = new Uri("Assets/AppBar/new.png", UriKind.Relative);
                    button1.Text = "new user";
                    button1.Click += NewUserButton_Click;
                    ApplicationBarIconButton button2 = new ApplicationBarIconButton();
                    button2.IconUri = new Uri("Assets/AppBar/next.png", UriKind.Relative);
                    button2.Text = "log in";
                    button2.Click += LogInButton_Click;
                    ApplicationBarIconButton button3 = new ApplicationBarIconButton();
                    button3.IconUri = new Uri("Assets/AppBar/questionmark.png", UriKind.Relative);
                    button3.Text = "help";
                    button3.Click += HelpButton_Click;
                    ApplicationBar.Buttons.Add(button1);
                    ApplicationBar.Buttons.Add(button2);
                    ApplicationBar.Buttons.Add(button3);
                    break;
                case 1:
                    NameBox.Visibility = Visibility.Visible;
                    ApplicationBarIconButton button4 = new ApplicationBarIconButton();
                    button4.IconUri = new Uri("Assets/AppBar/save.png", UriKind.Relative);
                    button4.Text = "save";
                    button4.Click += SaveButton_Click;
                    ApplicationBarIconButton button5 = new ApplicationBarIconButton();
                    button5.IconUri = new Uri("Assets/AppBar/cancel.png", UriKind.Relative);
                    button5.Text = "cancel";
                    button5.Click += CancelButton_Click;
                    ApplicationBar.Buttons.Add(button4);
                    ApplicationBar.Buttons.Add(button5);
                    break;
            }
        }

        void SaveButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Home.xaml", UriKind.Relative));
        }

        void CancelButton_Click(object sender, EventArgs e)
        {
            SetAppBar(0);
        }

        private  void LogInButton_Click(object sender, EventArgs e)
        {
            //LoginEvent le = new LoginEvent { user_id = 1 };
            //await App.MobileService.GetTable<LoginEvent>().InsertAsync(le);

            NavigationService.Navigate(new Uri("/Home.xaml", UriKind.Relative));
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Help.xaml", UriKind.Relative));
        }
    }
}