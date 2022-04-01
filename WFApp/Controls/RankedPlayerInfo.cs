using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFApp.Controls
{
    public partial class RankedPlayerInfo : UserControl
    {
        public TeamEvent Player { get; private set; }

        public RankedPlayerInfo(TeamEvent player)
        {
            InitializeComponent();
            Player = player;
            SetData(player);
        }

        private void SetData(TeamEvent player)
        {
            lblName.Text = player.Player;
            lblGoals.Text = "Goals: " + player.Goals.ToString();
            lblYellowCards.Text = "Yellow cards:" + player.YellowCards.ToString();
            pbRankedPlayer.Image = Repository.GetPicture();
            player.RankedPicture = pbRankedPlayer.Image;
        }
    }
}
