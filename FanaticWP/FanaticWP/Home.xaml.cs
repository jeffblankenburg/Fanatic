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
        double[] counter = new double[]{0, 0};
        double team1Score = 90;
        double team2Score = 57;
        
        public Home()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            TwentiethOfASecond.Completed += TwentiethOfASecond_Completed;
            DisplayTotals();
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
            Team1Score.Text = String.Format("{0:n0}", counter[0]);
            Team2Score.Text = String.Format("{0:n0}", counter[1]);
            TotalScore.Text = String.Format("{0:n0}", (counter[0] + counter[1]));

            if ((team1Score > counter[0]) || (team2Score > counter[1]))
            {
                TwentiethOfASecond.Begin();
            }
            else
            {
                Team1Score.Text = String.Format("{0:n0}", team1Score);
                Team2Score.Text = String.Format("{0:n0}", team2Score);
                TotalScore.Text = String.Format("{0:n0}", (team1Score + team2Score));
            }

            
        }
    }
}