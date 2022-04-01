using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFApp.Controls;

namespace WFApp.Forms
{
    public partial class Main : Form
    {

        //VArijable za printanje
        List<TeamEvent> userRankedPlayerControlsList = new List<TeamEvent>();
        List<Games> userRankedStadiumControlsList = new List<Games>();

        //Lista favorita
        HashSet<string> userFavourites = new HashSet<string>();


        public Main()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            Repository.LoadSettings();
            Repository.LoadLanguage();
            userFavourites = Repository.LoadFavourites();
            FillDataAsync();
            FillPlayerDataAsync();
            InitDnD();
        }



        //Drag and drop inicijalizacija
        private void InitDnD()
        {
            //Igraci
            pnlPlayerContainer.DragEnter += PnlContainer_DragEnter;
            pnlPlayerContainer.DragDrop += PnlPlayerContainer_DragDrop;

            //Favoriti
            pnlFavoritePlayerContainer.DragEnter += PnlContainer_DragEnter;
            pnlFavoritePlayerContainer.DragDrop += pnlFavouritePlayerContainer_DragDrop;
        }

        //efekt za ikonicu
        private void PnlContainer_DragEnter(object sender, DragEventArgs e)
        => e.Effect = DragDropEffects.Move;

        //prebacuje igraca u favorite
        private void pnlFavouritePlayerContainer_DragDrop(object sender, DragEventArgs e)
        {
            var playerInfo = (PlayerInfo)e.Data.GetData(typeof(PlayerInfo));

            if (playerInfo.Parent == pnlPlayerContainer && (pnlFavoritePlayerContainer.Controls.Count) < 3)
            {
                playerInfo.selected = true;
                pnlFavoritePlayerContainer.Controls.Add(playerInfo);

                userFavourites.Add(playerInfo.FavouriteName);
            }
        }

        //prebacuje igraca iz favorita
        private void PnlPlayerContainer_DragDrop(object sender, DragEventArgs e)
        {
            var playerInfo = (PlayerInfo)e.Data.GetData(typeof(PlayerInfo));

            if (playerInfo.Parent == pnlFavoritePlayerContainer)
            {
                playerInfo.selected = false;
                pnlPlayerContainer.Controls.Add(playerInfo);

                userFavourites.Remove(playerInfo.FavouriteName);
            }
        }        

        //Otvaranje settings-a
        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Repository.SaveSettings();
            Repository.SaveFavourites(userFavourites);
            new Settings().Show();
        }

        //puni ddl s drzavama
        private async void FillDataAsync()
        {
            lblInfo.Text = "Waiting to fetch data!";
            try
            {
                HashSet<Teams> teams = await Repository.LoadJsonTeams();

                foreach (var orderedTeam in teams)
                {
                    ddlCountry.Items.Add(orderedTeam);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                lblInfo.Text = ex.Message;
            }
        }

        //Kada se promjeni odabir u ddl-u ucitava sve podatke vezane za tu drzavu u panele
        private void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            FileSettings.country = ddlCountry.SelectedItem.ToString().Substring(0, ddlCountry.SelectedItem.ToString().IndexOf("(")).Trim();
            Repository.SaveSettings();
            FillPlayerDataAsync();
        }

        private async void FillPlayerDataAsync()
        {
            lblInfo.Text = "Fetching data...";

            pnlPlayerContainer.Controls.Clear();
            pnlRankedPlayerContainer.Controls.Clear();
            pnlRankedStadiumContainer.Controls.Clear();
            pnlFavoritePlayerContainer.Controls.Clear();

            try
            {
                HashSet<Games> Games = await Repository.LoadJsonMatches();
                lblTest.Text = FileSettings.country;

                StartingEleven player = new StartingEleven();
                TeamEvent rankedPlayer = new TeamEvent();
                Games stadium = new Games();

                HashSet<StartingEleven> playerList = new HashSet<StartingEleven>();
                HashSet<TeamEvent> rankedPlayerList = new HashSet<TeamEvent>();
                HashSet<Games> rankedStadiumList = new HashSet<Games>();

                HashSet<PlayerInfo> userPlayerControls = new HashSet<PlayerInfo>();
                HashSet<RankedPlayerInfo> userRankedPlayerControls = new HashSet<RankedPlayerInfo>();
                HashSet<RankedStadiumInfo> userRankedStadiumControls = new HashSet<RankedStadiumInfo>();

                userRankedPlayerControlsList = new List<TeamEvent>();
                userRankedStadiumControlsList = new List<Games>();

                foreach (var players in Games)
                {
                    if (players.HomeTeamStatistics.Country == FileSettings.country)
                    {
                        rankedStadiumList.Add(players);
                        foreach (var playerItem in players.HomeTeamStatistics.StartingEleven)
                        {
                            playerList.Add(playerItem);

                            foreach (var rankedItem in players.HomeTeamEvents)
                            {
                                rankedPlayerList.Add(rankedItem);
                            }
                        }
                        foreach (var playerItem in players.HomeTeamStatistics.Substitutes)
                        {
                            playerList.Add(playerItem);

                            foreach (var rankedItem in players.HomeTeamEvents)
                            {
                                rankedPlayerList.Add(rankedItem);
                            }
                        }
                    }
                    if (players.AwayTeamStatistics.Country == FileSettings.country)
                    {
                        rankedStadiumList.Add(players);
                        foreach (var playerItem in players.AwayTeamStatistics.StartingEleven)
                        {
                            playerList.Add(playerItem);

                            foreach (var rankedItem in players.AwayTeamEvents)
                            {
                                rankedPlayerList.Add(rankedItem);
                            }
                        }
                        foreach (var playerItem in players.AwayTeamStatistics.Substitutes)
                        {
                            playerList.Add(playerItem);

                            foreach (var rankedItem in players.AwayTeamEvents)
                            {
                                rankedPlayerList.Add(rankedItem);
                            }
                        }
                    }
                }

                //Igraci
                IEnumerable<StartingEleven> sortedPlayers = playerList.OrderBy(item => item.ShirtNumber);

                foreach (var playerItem in sortedPlayers)
                {
                    rankedPlayer = new TeamEvent();
                    foreach (var rankedItem in rankedPlayerList)
                    {
                        if (playerItem.Name == rankedItem.Player)
                        {
                            string rankedPlayerName = rankedItem.Player;
                            rankedPlayerName = new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(rankedPlayerName.ToLower());
                            rankedPlayer.Player = rankedPlayerName;
                            switch (rankedItem.TypeOfEvent)
                            {
                                case "goal":
                                    rankedPlayer.Goals++;
                                    break;
                                case "yellow-card":
                                    rankedPlayer.YellowCards++;
                                    break;
                            }
                        }
                    };

                    if (!(rankedPlayer.Goals == 0 && rankedPlayer.YellowCards == 0))
                    {
                        userRankedPlayerControls.Add(new RankedPlayerInfo(rankedPlayer));
                        userRankedPlayerControlsList.Add(rankedPlayer);
                    }
                    string playerName = playerItem.Name;
                    playerName = new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(playerName.ToLower());
                    playerItem.Name = playerName;
                    userPlayerControls.Add(new PlayerInfo(playerItem));
                }

                //Ne rangirani igraci
                foreach (var unrankedplayerItem in userPlayerControls)
                {
                    pnlPlayerContainer.Controls.Add(unrankedplayerItem);
                    //Favoriti
                    foreach (var favouriteItem in userFavourites)
                    {
                        if (unrankedplayerItem.Player.Name == favouriteItem)
                        {
                            unrankedplayerItem.selected = true;
                            pnlFavoritePlayerContainer.Controls.Add(unrankedplayerItem);
                        }
                    }
                }

                //Rangirani igraci
                IEnumerable<RankedPlayerInfo> sortedRankedPlayer1 = userRankedPlayerControls.OrderBy(Item => -Item.Player.YellowCards);
                IEnumerable<RankedPlayerInfo> sortedRankedPlayer = sortedRankedPlayer1.OrderBy(Item => -Item.Player.Goals);
                foreach (var rankedPlayerItem in sortedRankedPlayer)
                {
                    pnlRankedPlayerContainer.Controls.Add(rankedPlayerItem);
                }

                //Stadion
                IEnumerable<Games> sortedStadium = rankedStadiumList.OrderBy(item => -item.Attendance);

                foreach (var stadiumItem in sortedStadium)
                {
                    userRankedStadiumControls.Add(new RankedStadiumInfo(stadiumItem));
                    userRankedStadiumControlsList.Add(stadiumItem);
                }

                foreach (var rankedStadiumItem in userRankedStadiumControls)
                {
                    pnlRankedStadiumContainer.Controls.Add(rankedStadiumItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                lblInfo.Text = ex.Message;
            }
            lblInfo.Text = "Data is fatched!";
        }


        //Klik na settings sprema settings i favorite
        private void miSettings_Click(object sender, EventArgs e)
        {
            Hide();
            Repository.SaveSettings();
            Repository.SaveFavourites(userFavourites);
            new Settings().Show();
        }

        //Prikazuje dokument za printanje
        private void miPreviewPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog.ShowDialog();
        }

        //Printa dokument
        private void miPrintDocument_Click(object sender, EventArgs e)
        {
            printDocument.Print();
        }

        //Kreira dokument za printanje
        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            int x = 100;
            int y = 100;

            List<TeamEvent> sortedRankedPlayer1 = userRankedPlayerControlsList.OrderBy(Item => -Item.YellowCards).ToList();
            List<TeamEvent> sortedRankedPlayer = sortedRankedPlayer1.OrderBy(Item => -Item.Goals).ToList();
            //Igraci
            e.Graphics.DrawString("RANKED PLAYERS", Font, Brushes.Black, x, y);
            for (int i = 0; i < sortedRankedPlayer.Count; i++)
            {
                e.Graphics.DrawString("Player: " + sortedRankedPlayer[i].Player + " - - -" +
                    " Goals: " + sortedRankedPlayer[i].Goals + " - - -" +
                    " Yellow cards: " + sortedRankedPlayer[i].YellowCards,
                    Font, Brushes.Black, x, y += 20);
            }

            //Stadioni
            e.Graphics.DrawString("RANKED STADIUMS", Font, Brushes.Black, x, y += 40);
            for (int i = 0; i < userRankedStadiumControlsList.Count; i++)
            {
                e.Graphics.DrawString("Location: " + userRankedStadiumControlsList[i].Location + " - - -" +
                    " Attendance: " + userRankedStadiumControlsList[i].Attendance,
                    Font, Brushes.Black, x, y += 20);
            }
        }

        //Zatvaranje forme 
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Repository.SaveFavourites(userFavourites);
                Dispose();
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
                return;
            }
        }

        //Esc
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                DialogResult result = MessageBox.Show("Do you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Dispose();
                    Application.Exit();
                }
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }




    }
}
