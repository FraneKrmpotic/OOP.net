using DataLayer.Models;
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

namespace WPFApp.Windows
{
    /// <summary>
    /// Interaction logic for Information.xaml
    /// </summary>
    public partial class Information : Window
    {
        Results result = new Results();
        public Information(Results result)
        {
            InitializeComponent();
            this.result = result;
            Init();
        }
        private void Init()
        {
            lblCountryData.Content = result.Country;
            lblCodeData.Content = result.FifaCode;
            lblGamesPlayedData.Content = result.GamesPlayed;
            lblWinsData.Content = result.Wins;
            lblLossesData.Content = result.Losses;
            lblDrawsData.Content = result.Draws;
            lblGoalsForData.Content = result.GoalsFor;
            lblGoalsAgainstsData.Content = result.GoalsAgainst;
            lblGoalDifferentialData.Content = result.GoalDifferential;
        }
    }
}
