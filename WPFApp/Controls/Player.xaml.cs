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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFApp.Windows;

namespace WPFApp.Controls
{
    /// <summary>
    /// Interaction logic for Player.xaml
    /// </summary>
    public partial class Player : UserControl
    {
        StartingEleven player = new StartingEleven();
        public Player(StartingEleven startingEleven)
        {
            InitializeComponent();
            player = startingEleven;

            string name = startingEleven.Name;
            name = new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(name.ToLower());
            lblPlayer.Content = name;
            lblShirtNumber.Content = startingEleven.ShirtNumber;
        }

        public string PlayerName { get; set; }
        public int ShirtNumber { get; set; }

        private void Grid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) => new PlayerInfo(player).Show();
    }
}
