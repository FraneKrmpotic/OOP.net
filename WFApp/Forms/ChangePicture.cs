using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFApp.Forms
{
    public partial class ChangePicture : Form
    {
        public ChangePicture(PictureBox picture)
        {
            InitializeComponent();
            InitSetup(picture);
        }

        private void InitSetup(PictureBox picture)
        {
            pb.Image = picture.Image;
        }

        public PictureBox GetUpdatedPicture()
        {
            return pb;
        }

        //Otvara file dialong i sprema sliku 
        private void BtnChangePicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Pictures|*.bmp;*.jpg;*.jfif;*.jpeg;*.png;|All files|*.*",
                InitialDirectory = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Pictures")
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Main mainForm = new Main();
                mainForm.Refresh();
                pb.ImageLocation = ofd.FileName;
            }
        }
    }
}
