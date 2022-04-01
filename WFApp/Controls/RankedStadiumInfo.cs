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
    public partial class RankedStadiumInfo : UserControl
    {
        public Games Stadium { get; private set; }

        public RankedStadiumInfo(Games stadium)
        {
            InitializeComponent();
            Stadium = stadium;
            SetData(Stadium);
        }

        private void SetData(Games stadium)
        {
            lblLocation.Text = stadium.Location;
            lblVisitors.Text = stadium.Attendance.ToString();
            lblHomeTeam.Text = stadium.HomeTeamCountry;
            lblAwayTeam.Text = stadium.AwayTeamCountry;
        }
    }
}
