using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
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


namespace WPFApp.Windows
{
    /// <summary>
    /// Interaction logic for PlayerInfo.xaml
    /// </summary>
    public partial class PlayerInfo : Window
    {
        StartingEleven player = new StartingEleven();
        public PlayerInfo(StartingEleven player)
        {
            InitializeComponent();
            this.player = player;
            Init();
        }

        private void Init()
        {
            string name = player.Name;
            name = new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(name.ToLower());
            lblNameData.Content = name;
            lblShirtNumberData.Content = player.ShirtNumber;
            lblPositionData.Content = player.Position;
            lblCaptainData.Content = player.Captain;
            lblScoredGoalsData.Content = "null";
            lblYellowCardsData.Content = "null";

            var uriSource = new Uri(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, $"DataLayer/Assets/defaultUser.png"));
            PlayerImage.Source = new BitmapImage(uriSource);
            string[] filePaths = Directory.GetFiles(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, $"Pictures/Saved/"));
            for (int i = 0; i < filePaths.Length; i++)
            {
                string exactFile = ($"{filePaths[i].Substring(filePaths[i].IndexOf("d/") + 2)}");
                string parsedFile = exactFile.Remove(exactFile.IndexOf('.'));
                if (name == parsedFile)
                {
                    uriSource = new Uri(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, $"Pictures/Saved/{name}.jfif"));
                    PlayerImage.Source = new BitmapImage(uriSource);
                }
            }
        }
    }
}
