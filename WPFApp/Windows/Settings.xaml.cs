using DataLayer;
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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            Init();
            InitializeComponent();
        }

        private void Init()
        {
            Repository.LoadSettings();
            Repository.LoadLanguage();
        }

        //Zatvar applikaciju
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnAccept_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            FileSettings.gender = (bool)rbtnFemale.IsChecked;
            FileSettings.language = (bool)rbtnEnglish.IsChecked ? "Croatian" : "Engleski";
            Repository.SaveSettings();
            new MainWindow().Show();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new MainWindow().Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Repository.LoadSettings();
            Repository.LoadLanguage();
            LoadGender();
            LoadLanguage();
        }

        private void LoadGender()
        {
            if (FileSettings.gender)
            {
                rbtnFemale.IsChecked = true;
            }
            else
            {
                rbtnMale.IsChecked = true;
            }
        }

        private void LoadLanguage()
        {
            if (FileSettings.language == "Croatian")
            {
                rbtnEnglish.IsChecked = true;
            }
            else
            {
                rbtnCroatian.IsChecked = true;
            }
        }
    }
}
