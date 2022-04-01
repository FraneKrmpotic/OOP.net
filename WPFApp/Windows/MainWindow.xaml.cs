using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using WpfAnimatedGif;
using WPFApp.Controls;
using WPFApp.Windows;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HashSet<Games> matches = new HashSet<Games>();
        HashSet<Results> results = new HashSet<Results>();
        HashSet<StartingEleven> startingEleven = new HashSet<StartingEleven>();

        Results country = new Results();
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            Repository.LoadSettings();
            Repository.LoadLanguage();
            FillData();
            ddlCountries.SelectedIndex = FileSettings.countryIndex;
            ddlVersusCountries.SelectedIndex = FileSettings.versusCountryIndex;
            var uriSource = new Uri(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, $"DataLayer/Assets/settings.png"));
            imageSettings.Source = new BitmapImage(uriSource);
        }

        //Lodam drzave u ddl
        private async void FillData()
        {
            try
            {
                results = await Repository.LoadJsonResults();

                foreach (var resultItem in results)
                {
                    ddlCountries.Items.Add(resultItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Izvrsava se kod promijene odabira
        private void DdlCountries_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ddlVersusCountries.Items.Clear();
            FileSettings.country = ddlCountries.SelectedItem.ToString().Substring(0, ddlCountries.SelectedItem.ToString().IndexOf("(")).Trim();
            FileSettings.countryIndex = ddlCountries.SelectedIndex;
            Repository.SaveSettings();
            FillPlayerData();
            AddHomePlayers();
            AddAwayPlayers();
        }

        //Dodaje domace igrace na svoje pozicije
        private void AddHomePlayers()
        {
            hGoalie.Children.Clear();
            hDefender.Children.Clear();
            hForward.Children.Clear();
            hMidField.Children.Clear();
            foreach (var matchesItem in matches)
            {
                if (matchesItem.HomeTeamStatistics.Country == FileSettings.country)
                {
                    startingEleven = new HashSet<StartingEleven>();
                    foreach (var startingElevenItem in matchesItem.HomeTeamStatistics.StartingEleven)
                    {
                        startingEleven.Add(startingElevenItem);
                    }
                }
            }
            foreach (var startingElevenItem in startingEleven)
            {
                switch (startingElevenItem.Position)
                {
                    case Position.Defender:
                        hDefender.Children.Add(new Player(startingElevenItem));
                        break;
                    case Position.Forward:
                        hForward.Children.Add(new Player(startingElevenItem));
                        break;
                    case Position.Goalie:
                        hGoalie.Children.Add(new Player(startingElevenItem));
                        break;
                    case Position.Midfield:
                        hMidField.Children.Add(new Player(startingElevenItem));
                        break;
                    default:
                        break;
                }
            }
        }

        //Kada se promjeni odabir protivnicke ekipe ovo se izvrsava
        private void DdlVersusCountries_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ddlVersusCountries.SelectedItem == null)
                return;

            FileSettings.versusCountry = ddlVersusCountries.SelectedItem.ToString();
            FileSettings.versusCountryIndex = ddlVersusCountries.SelectedIndex;
            Repository.SaveSettings();
            AddHomePlayers();
            AddAwayPlayers();
            GetResult();
        }

        //Dodaje protivnicke igrace 
        private void AddAwayPlayers()
        {
            aGoalie.Children.Clear();
            aDefender.Children.Clear();
            aForward.Children.Clear();
            aMidField.Children.Clear();
            foreach (var matchesItem in matches)
            {
                if (matchesItem.AwayTeamStatistics.Country == FileSettings.versusCountry)
                {
                    startingEleven = new HashSet<StartingEleven>();
                    foreach (var startingElevenItem in matchesItem.AwayTeamStatistics.StartingEleven)
                    {
                        startingEleven.Add(startingElevenItem);
                    }
                }
            }
            foreach (var startingElevenItem in startingEleven)
            {
                switch (startingElevenItem.Position)
                {
                    case Position.Defender:
                        aDefender.Children.Add(new Player(startingElevenItem));
                        break;
                    case Position.Forward:
                        aForward.Children.Add(new Player(startingElevenItem));
                        break;
                    case Position.Goalie:
                        aGoalie.Children.Add(new Player(startingElevenItem));
                        break;
                    case Position.Midfield:
                        aMidField.Children.Add(new Player(startingElevenItem));
                        break;
                    default:
                        break;
                }
            }
        }

        //Dovlaci rezultat
        private void GetResult()
        {
            foreach (var resultItems in matches)
            {
                if (FileSettings.country == resultItems.HomeTeamStatistics.Country)
                {
                    lblResult.Content = $"{resultItems.HomeTeam.Goals} : {resultItems.AwayTeam.Goals}";
                }
            }
        }

        //Loda igrace i ubacuje protivnicke drzave u ddl
        private async void FillPlayerData()
        {
            try
            {
                matches = await Repository.LoadJsonMatches();
                foreach (var matchesItem in matches)
                {
                    if (matchesItem.HomeTeamStatistics.Country == FileSettings.country)
                    {
                        ddlVersusCountries.Items.Add(matchesItem.AwayTeamCountry);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Gasi aplikaciju
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //Pokrece animaciju ucitavanja i otvara prozor s informacijama
        private void BtnInfoCountry_Click(object sender, RoutedEventArgs e)
        {
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, $"WPFApp/Materials/countryLoading.gif"));
            image.EndInit();
            ImageBehavior.SetAnimatedSource(loadingCountry, image);

            Task.Factory.StartNew(() => Thread.Sleep(1 * 1000))
            .ContinueWith((t) =>
            {
                country = new Results();
                foreach (var item in results)
                {
                    if (item.Country == FileSettings.country)
                    {
                        country = item;
                    }
                }
                new Information(country).Show();

                image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, $"WPFApp/Materials/invisible.png"));
                image.EndInit();
                ImageBehavior.SetAnimatedSource(loadingCountry, image);
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void BtnInfoVersusCountry_Click(object sender, RoutedEventArgs e)
        {
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, $"WPFApp/Materials/countryLoading.gif"));
            image.EndInit();
            ImageBehavior.SetAnimatedSource(loadingCountry, image);

            Task.Factory.StartNew(() => Thread.Sleep(1 * 1000))
            .ContinueWith((t) =>
            {
                country = new Results();
                foreach (var item in results)
                {
                    if (item.Country == FileSettings.versusCountry)
                    {
                        country = item;
                    }
                }
                new Information(country).Show();
                image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, $"WPFApp/Materials/invisible.png"));
                image.EndInit();
                ImageBehavior.SetAnimatedSource(loadingCountry, image);
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new Settings().Show();
        }
    }
}

