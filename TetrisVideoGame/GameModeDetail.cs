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

        public GameModeDetail(int game_mode)
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
            if (game_mode == 1)
            {
                PlayerNameWindows dialog = new PlayerNameWindows();
                dialog.BackColor = Color.FromArgb(240, 240, 240);
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.FormBorderStyle = FormBorderStyle.None;
                dialog.Name = "PlayerDialog";
                dialog.Width = 350;
                dialog.Height = 250;
                this.Hide();
                dialog.ShowDialog();
                if (!dialog.Visible && dialog.flag)
                {
                    if (dialog.txtName.Text != "" || dialog.txtName.Text != null)
                    {
                        dialog.Dispose();
                        TetrisGame game = new TetrisGame(30, 10, 20, dialog.txtName.Text);
                        game.StartPosition = FormStartPosition.CenterScreen;
                        game.Text = "My First Form";
                        game.Width = 850;
                        game.Height = 850;
                        game.Visible = true;
                    }
                    this.Hide();
                }
                else
                    this.Show();
            }
            else if (game_mode == 2)
            {
                PlayerNameWindows dialog = new PlayerNameWindows();
                dialog.BackColor = Color.FromArgb(240, 240, 240);
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.FormBorderStyle = FormBorderStyle.None;
                dialog.Name = "PlayerDialog";
                dialog.Width = 350;
                dialog.Height = 250;
                this.Hide();
                dialog.ShowDialog();
                if (!dialog.Visible && dialog.flag)
                {
                    if (dialog.txtName.Text != "" || dialog.txtName.Text != null)
                    {
                        dialog.Dispose();
                        SlipSlideGameMode game = new SlipSlideGameMode(30, 10, 20, dialog.txtName.Text);
                        game.StartPosition = FormStartPosition.CenterScreen;
                        game.Text = "My First Form";
                        game.Width = 850;
                        game.Height = 850;
                        game.Visible = true;
                    }
                    this.Hide();
                }
                else
                    this.Show();
            }
            else if (game_mode == 3)
            {
                PlayerNameWindows dialog = new PlayerNameWindows();
                dialog.BackColor = Color.FromArgb(240, 240, 240);
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.FormBorderStyle = FormBorderStyle.None;
                dialog.Name = "PlayerDialog";
                dialog.Width = 350;
                dialog.Height = 250;
                dialog.ShowDialog();
                if (!dialog.Visible && dialog.flag)
                {
                    if (dialog.txtName.Text != "" || dialog.txtName.Text != null)
                    {
                        dialog.Dispose();
                        Self_rotate_mode game = new Self_rotate_mode(30, 10, 20, dialog.txtName.Text);
                        game.StartPosition = FormStartPosition.CenterScreen;
                        game.Text = "My First Form";
                        game.Width = 850;
                        game.Height = 850;
                        game.Visible = true;
                    }
                    this.Hide();
                }
                else
                    this.Show();
            }
        }
    }
}
