using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace TetrisVideoGame
{
    class GameModeDetail : Form
    {
        private int game_mode = 0;
        private PictureBox PicBack;
        private PictureBox PicStart;

        public GameModeDetail()
        {
            this.game_mode = game_mode;
            this.Name = "GameModeDetail";
            this.MaximumSize = new Size(1084, 910);
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Width = 1084;
            this.Height = 910;
           
            PicBack = new PictureBox();
            PicBack.Image = Image.FromFile("back.png");
            PicBack.SizeMode = PictureBoxSizeMode.StretchImage;
            PicBack.BackColor = Color.Transparent;
            PicBack.Width = 50;
            PicBack.Height = 50;
            PicBack.Left = 48;
            PicBack.Top = 18;
            PicBack.Click += PicBack_OnClick;
            this.Controls.Add(PicBack);

            PicStart = new PictureBox();
            PicStart.Image = Image.FromFile("buttonStart.png");
            PicStart.SizeMode = PictureBoxSizeMode.StretchImage;
            PicStart.BackColor = Color.Transparent;
            PicStart.Width = 232;
            PicStart.Height = 63;
            PicStart.Left = 775;
            PicStart.Top = 795;
            PicStart.Click += PicStart_OnClick;
            
            this.Controls.Add(PicStart);


        }
        private void PicBack_OnClick(object sender, EventArgs e)
        {
            var forms = Application.OpenForms.Cast<Form>().Where(x => x.Name == "GameModeMenu").FirstOrDefault();
            if (forms != null)
            {
                forms.Show();
                this.Dispose();
            }
        }
        private void PicStart_OnClick(object sender, EventArgs e)
        {
            
        }
    }
}
