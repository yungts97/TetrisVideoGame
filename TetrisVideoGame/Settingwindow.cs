using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Media;

namespace TetrisVideoGame
{
    public class SettingWindow : Form
    {
        private Label title;
        private Button btnChangeBgi;
        private Button btnOk;
        private Button btnMute;
        //private SoundPlayer bgmplayer;
        string[] images = System.IO.Directory.GetFiles("C:\\Users\\Ballo\\Documents\\GitHub\\TetrisVideoGame\\TetrisVideoGame\\bin\\Debug\\image", "*.jpg");
        private int i = 0;

        public SettingWindow()
        {
            this.MaximumSize = new Size(420, 680);
            this.BackgroundImage = Image.FromFile("image/background_1.jpg");
            this.ShowInTaskbar = false;

            /*bgmplayer = new SoundPlayer("bgm.wav");

			if (!GlobalVariable.mute)
				bgmplayer.PlayLooping(); */

            title = new Label();
            title.Text = "Setting";
            title.BackColor = Color.Transparent;
            title.Visible = true;
            title.ForeColor = Color.FromArgb(255, 255, 255);
            title.Font = new Font("Times New Roman", 15, FontStyle.Bold);
            title.BringToFront();
            title.AutoSize = true;
            title.Left = 175;
            title.Top = 70;
            this.Controls.Add(title);

            btnChangeBgi = new Button();
            btnChangeBgi.Text = "Change Background image";
            btnChangeBgi.FlatStyle = FlatStyle.Flat;
            btnChangeBgi.BackColor = Color.Transparent;
            btnChangeBgi.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            btnChangeBgi.ForeColor = Color.White;
            btnChangeBgi.AutoSize = true;
            btnChangeBgi.Width = 130;
            btnChangeBgi.Height = 40;
            btnChangeBgi.Left = 130;
            btnChangeBgi.Top = 160;
            btnChangeBgi.Click += this.BtnChangeBgi;
            this.Controls.Add(btnChangeBgi);

            btnMute = new Button();
            btnMute.Text = "Mute";
            btnMute.FlatStyle = FlatStyle.Flat;
            btnMute.BackColor = Color.Transparent;
            btnMute.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            btnMute.ForeColor = Color.White;
            btnMute.AutoSize = true;
            btnMute.Width = 168;
            btnMute.Height = 40;
            btnMute.Left = 130;
            btnMute.Top = 250;
            btnMute.Click += this.BtnMute;
            this.Controls.Add(btnMute);

            btnOk = new Button();
            btnOk.Text = "Ok";
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.BackColor = Color.Transparent;
            btnOk.Font = new Font("Arial", 10, FontStyle.Regular);
            btnOk.ForeColor = Color.White;
            btnOk.AutoSize = true;
            btnOk.Width = 130;
            btnOk.Height = 40;
            btnOk.Left = 280;
            btnOk.Top = 630;
            btnOk.DialogResult = DialogResult.OK;
            this.Controls.Add(btnOk);
        }

        public void BtnChangeBgi(object sender, EventArgs e)
        {

            if (images.Length == 0)
                return;

            var image = Image.FromFile(images[i]);
            this.BackgroundImage = image;
            GlobalVariable.image = images[i];
            if (++i >= images.Length) i = 0;

            //this.BackgroundImage = Image.FromFile("image/background_2.jpg");


        }
        public void BtnMute(object sender, EventArgs e)
        {
            mute();
            //Console.WriteLine(GlobalVariable.mute.ToString());
        }
        public static void mute()
        {
            GlobalVariable.mute = !(GlobalVariable.mute);
        }

    }
}
