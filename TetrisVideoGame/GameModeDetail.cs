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
        private PictureBox PicHelp;
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

            PicHelp = new PictureBox();
            PicHelp.Image = Image.FromFile("help.png");
            PicHelp.SizeMode = PictureBoxSizeMode.StretchImage;
            PicHelp.BackColor = Color.Transparent;
            PicHelp.Width = 70;
            PicHelp.Height = 70;
            PicHelp.Left = 975;
            PicHelp.Top = 18;
            PicHelp.Click += PicHelp_OnClick;
            this.Controls.Add(PicHelp);

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
        private void PicHelp_OnClick(object sender, EventArgs e)
        {
            HelpWindows dialog3 = new HelpWindows();
            dialog3.BackColor = Color.FromArgb(240, 240, 240);
            dialog3.StartPosition = FormStartPosition.CenterScreen;
            dialog3.FormBorderStyle = FormBorderStyle.None;
            dialog3.Name = "HelpDialog";
            dialog3.Width = 830;
            dialog3.Height = 650;
            if (dialog3.ShowDialog() == DialogResult.OK)
            {
                dialog3.Dispose();
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
                dialog.ShowDialog();
                if (!dialog.Visible && dialog.flag)
                {
                    if (dialog.txtName.Text != "" || dialog.txtName.Text != null)
                    {
                        dialog.Dispose();
                        TetrisGame game = new TetrisGame(30, 10, 20, dialog.txtName.Text);
                        game.StartPosition = FormStartPosition.CenterScreen;
                        game.Text = "My First Form";
                        game.Width = 950;
                        game.Height = 900;
                        if (MainWindows.theme == 1)
                        {
                            game.BackgroundImage = Image.FromFile("theme1bg.png");
                        }
                        else if (MainWindows.theme == 2)
                        {
                            game.BackgroundImage = Image.FromFile("theme2bg.png");
                        }
                        else if (MainWindows.theme == 3)
                        {
                            game.BackgroundImage = Image.FromFile("theme3bg.png");
                        }
                        else if (MainWindows.theme == 4)
                        {
                            game.BackgroundImage = Image.FromFile("theme4bg.png");
                        }
                        else if (MainWindows.theme == 5)
                        {
                            game.BackgroundImage = Image.FromFile("theme5bg.png");
                        }
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
                dialog.ShowDialog();
                if (!dialog.Visible && dialog.flag)
                {
                    if (dialog.txtName.Text != "" || dialog.txtName.Text != null)
                    {
                        dialog.Dispose();
                        SlipSlideGameMode game = new SlipSlideGameMode(30, 10, 20, dialog.txtName.Text);
                        game.StartPosition = FormStartPosition.CenterScreen;
                        game.Text = "My First Form";
                        game.Width = 950;
                        game.Height = 900;
                        if (MainWindows.theme == 1)
                        {
                            game.BackgroundImage = Image.FromFile("theme1bg.png");
                        }
                        else if (MainWindows.theme == 2)
                        {
                            game.BackgroundImage = Image.FromFile("theme2bg.png");
                        }
                        else if (MainWindows.theme == 3)
                        {
                            game.BackgroundImage = Image.FromFile("theme3bg.png");
                        }
                        else if (MainWindows.theme == 4)
                        {
                            game.BackgroundImage = Image.FromFile("theme4bg.png");
                        }
                        else if (MainWindows.theme == 5)
                        {
                            game.BackgroundImage = Image.FromFile("theme5bg.png");
                        }
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
                dialog.ShowDialog();
                if (!dialog.Visible && dialog.flag)
                {
                    if (dialog.txtName.Text != "" || dialog.txtName.Text != null)
                    {
                        dialog.Dispose();
                        Self_rotate_mode game = new Self_rotate_mode(30, 10, 20, dialog.txtName.Text);
                        game.StartPosition = FormStartPosition.CenterScreen;
                        game.Text = "My First Form";
                        game.Width = 950;
                        game.Height = 900;
                        if (MainWindows.theme == 1)
                        {
                            game.BackgroundImage = Image.FromFile("theme1bg.png");
                        }
                        else if (MainWindows.theme == 2)
                        {
                            game.BackgroundImage = Image.FromFile("theme2bg.png");
                        }
                        else if (MainWindows.theme == 3)
                        {
                            game.BackgroundImage = Image.FromFile("theme3bg.png");
                        }
                        else if (MainWindows.theme == 4)
                        {
                            game.BackgroundImage = Image.FromFile("theme4bg.png");
                        }
                        else if (MainWindows.theme == 5)
                        {
                            game.BackgroundImage = Image.FromFile("theme5bg.png");
                        }
                        game.Visible = true;
                    }
                    this.Hide();
                }
                else
                    this.Show();
            }
            else if (game_mode == 4)
            {
                PlayerNameWindows dialog = new PlayerNameWindows();
                dialog.BackColor = Color.FromArgb(240, 240, 240);
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.FormBorderStyle = FormBorderStyle.None;
                dialog.Name = "PlayerDialog";
                dialog.ShowDialog();
                if (!dialog.Visible && dialog.flag)
                {
                    if (dialog.txtName.Text != "" || dialog.txtName.Text != null)
                    {
                        dialog.Dispose();
                        OppositeMode game = new OppositeMode(30, 10, 20, dialog.txtName.Text);
                        game.StartPosition = FormStartPosition.CenterScreen;
                        game.Text = "My First Form";
                        game.Width = 950;
                        game.Height = 900;
                        if (MainWindows.theme == 1)
                        {
                            game.BackgroundImage = Image.FromFile("theme1bg.png");
                        }
                        else if (MainWindows.theme == 2)
                        {
                            game.BackgroundImage = Image.FromFile("theme2bg.png");
                        }
                        else if (MainWindows.theme == 3)
                        {
                            game.BackgroundImage = Image.FromFile("theme3bg.png");
                        }
                        else if (MainWindows.theme == 4)
                        {
                            game.BackgroundImage = Image.FromFile("theme4bg.png");
                        }
                        else if (MainWindows.theme == 5)
                        {
                            game.BackgroundImage = Image.FromFile("theme5bg.png");
                        }
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
