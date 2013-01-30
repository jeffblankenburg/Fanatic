using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace FanaticWP
{
    public partial class Home : PhoneApplicationPage
    {
        double[] counter = new double[]{0, 0, 0};
        double team1Score = 90;
        double team2Score = 57;
        double team3Score = 1042;
        List<Friend> friends = new List<Friend>();
        List<Badge> badges = new List<Badge>();
        
        public Home()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            TwentiethOfASecond.Completed += TwentiethOfASecond_Completed;
            DisplayTotals();
            friends.Clear();
            friends.Add(new Friend { Name="Mark   Hindsbo", Image="Assets/photos/mark.jpg" });
            friends.Add(new Friend { Name = "Harry   Mower", Image = "Assets/photos/harry.jpg" });
            friends.Add(new Friend { Name = "Dan   Kasun", Image = "Assets/photos/dan.jpg" });
            friends.Add(new Friend { Name = "Scott   Davidson", Image = "Assets/photos/scott.jpg" });
            friends.Add(new Friend { Name = "Jacquelyn   Crowhurst", Image = "Assets/photos/jacs.jpg" });
            friends.Add(new Friend { Name = "Matt   Thompson", Image = "Assets/photos/matt.jpg" });
            badges.Add(new Badge { Title = "BEEN   TO   10   GAMES", Image = "Assets/icons/badges/BeenToTen.png" });
            badges.Add(new Badge { Title = "WIN   BY   28   OR   MORE", Image = "Assets/icons/badges/TheBeatdown.png" });
            BadgesPanel.ItemsSource = badges;
        }

        void TwentiethOfASecond_Completed(object sender, EventArgs e)
        {
            DisplayTotals();
        }

        private void Team_Tap(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("/TeamDetail.xaml", UriKind.Relative));
        }

        private void DisplayTotals()
        {
            counter[0] += team1Score * .04;
            counter[1] += team2Score * .04;
            counter[2] += team3Score * .04;
            Team1Score.Text = String.Format("{0:n0}", counter[0]);
            Team2Score.Text = String.Format("{0:n0}", counter[1]);
            Team3Score.Text = String.Format("{0:n0}", counter[2]);
            TotalScore.Text = String.Format("{0:n0}", (counter[0] + counter[1] + counter[2]));

            if ((team1Score > counter[0]) || (team2Score > counter[1]) || (team3Score > counter[2]))
            {
                TwentiethOfASecond.Begin();
            }
            else
            {
                Team1Score.Text = String.Format("{0:n0}", team1Score);
                Team2Score.Text = String.Format("{0:n0}", team2Score);
                Team3Score.Text = String.Format("{0:n0}", team3Score);
                TotalScore.Text = String.Format("{0:n0}", (team1Score + team2Score + team3Score));
            }

            
        }

        private void Image_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SocialNetworkPanel.Visibility = Visibility.Collapsed;
            FriendsPanel.ItemsSource = friends;
            FriendsPanel.Visibility = Visibility.Visible;

        }

        private void Team_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("/TeamStats.xaml", UriKind.Relative));
        }

        private void Team_Tap2(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("/TeamStats2.xaml", UriKind.Relative));
        }
    }
}