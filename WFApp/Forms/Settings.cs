using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFApp.Forms
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            Repository.LoadSettings();


        }

        private void RefreshForm()
        {
            this.Controls.Clear();
            InitializeComponent();
        }

        //Pritiskom na gumb mijenjamo jezik
        private void BtnLanguage_Click(object sender, EventArgs e)
        {
            if (Thread.CurrentThread.CurrentCulture.Name == Repository.HR)
            {
                Repository.SetCulture(Repository.EN);
                FileSettings.language = "Croatian";
                RefreshForm();
            }
            else
            {
                Repository.SetCulture(Repository.HR);
                FileSettings.language = "Engleski";
                RefreshForm();
            }
        }


        private void Settings_Load(object sender, EventArgs e)
        {
            Repository.LoadSettings();
            Repository.LoadLanguage();
            RefreshForm();
        }

        private void ddlChampionship_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ddlChampionship.SelectedItem)
            {
                case "Male":
                    FileSettings.gender = false;
                    break;
                case "Female":
                    FileSettings.gender = true;
                    break;
                case "Muški":
                    FileSettings.gender = false;
                    break;
                case "Ženski":
                    FileSettings.gender = true;
                    break;

            }

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to save changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Hide();
                Repository.SaveSettings();
                Repository.LoadSettings();
                new Main().Show();
            }
        }

        //skirva settings prikazuje main
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Hide();
                new Main().Show();
            }
        }

        //Zatvara aplikaciju
        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Dispose();
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
                return;
            }
        }
    }
}
