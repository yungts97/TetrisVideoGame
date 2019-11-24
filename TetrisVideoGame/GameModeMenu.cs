using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace TetrisVideoGame
{
    class GameModeMenu : Form
    {
        private PictureBox PicBack;
        private PictureBox PicTitle;
        private PictureBox gameMode1, gameMode2, gameMode3, gameMode4;
      
        public GameModeMenu()
        {
            this.MaximumSize = new Size(1084, 713);
            this.Name = "GameModeMenu";
            this.BackgroundImage = Image.FromFile("bg.png");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Width = 1084;
            this.Height = 713;

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

            PicTitle = new PictureBox();
            PicTitle.Image = Image.FromFile("gameTitle.png");
            PicTitle.BackColor = Color.Transparent;
            PicTitle.Top = 23;
            PicTitle.Left = 355;
            PicTitle.Width = 374;
            PicTitle.Height = 43;
            PicTitle.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(PicTitle);


            gameMode1 = new PictureBox();
            gameMode1.Image = (Bitmap)Resource1.ResourceManager.GetObject("mode_1");
            gameMode1.SizeMode = PictureBoxSizeMode.AutoSize;
            gameMode1.BackColor = Color.Transparent;
            gameMode1.Left = 48;
            gameMode1.Top = 105;
            gameMode1.MouseMove += this.gameMode1_Hover;
            gameMode1.Click += this.gameMode1_OnClick;
            this.Controls.Add(gameMode1);

            gameMode2 = new PictureBox();
            gameMode2.Image = (Bitmap)Resource1.ResourceManager.GetObject("mode_2"); 
            gameMode2.SizeMode = PictureBoxSizeMode.AutoSize;
            gameMode2.BackColor = Color.Transparent;
            gameMode2.Left = 300;
            gameMode2.Top = 105;
            gameMode2.MouseMove += this.gameMode2_Hover;
            gameMode2.Click += this.gameMode2_OnClick;
            this.Controls.Add(gameMode2);

            gameMode3 = new PictureBox();
            gameMode3.Image = (Bitmap)Resource1.ResourceManager.GetObject("mode_3");
            gameMode3.SizeMode = PictureBoxSizeMode.AutoSize;
            gameMode3.BackColor = Color.Transparent;
            gameMode3.Left = 553;
            gameMode3.Top = 105;
            gameMode3.MouseMove += this.gameMode3_Hover;
            gameMode3.Click += this.gameMode3_OnClick;
            this.Controls.Add(gameMode3);

            gameMode4 = new PictureBox();
            gameMode4.Image = (Bitmap)Resource1.ResourceManager.GetObject("mode_4"); 
            gameMode4.SizeMode = PictureBoxSizeMode.AutoSize;
            gameMode4.BackColor = Color.Transparent;
            gameMode4.Left = 806;
            gameMode4.Top = 105;
            gameMode4.MouseMove += this.gameMode4_Hover;
            gameMode4.Click += this.gameMode4_OnClick;
            this.Controls.Add(gameMode4);

           

        }
       
        private void PicBack_OnClick(object sender, EventArgs e)
        {
            var forms = Application.OpenForms.Cast<Form>().Where(x => x.Name == "MainScreen").FirstOrDefault();
            if (forms != null)
            {
                forms.Show();
                this.Dispose();
            }
        }

        private void gameMode1_Hover(object sender, EventArgs e)
        {
            gameMode1.Image = (Bitmap)Resource1.ResourceManager.GetObject("mode1");
            gameMode2.Image = (Bitmap)Resource1.ResourceManager.GetObject("mode_2");
            gameMode3.Image = (Bitmap)Resource1.ResourceManager.GetObject("mode_3");
            gameMode4.Image = (Bitmap)Resource1.ResourceManager.GetObject("mode_4");
        }
        private void gameMode2_Hover(object sender, EventArgs e)
        {
            gameMode1.Image = (Bitmap)Resource1.ResourceManager.GetObject("mode_1");
            gameMode2.Image = (Bitmap)Resource1.ResourceManager.GetObject("mode2");
            gameMode3.Image = (Bitmap)Resource1.ResourceManager.GetObject("mode_3");
            gameMode4.Image = (Bitmap)Resource1.ResourceManager.GetObject("mode_4");
        }
        private void gameMode3_Hover(object sender, EventArgs e)
        {
            gameMode1.Image = (Bitmap)Resource1.ResourceManager.GetObject("mode_1");
            gameMode2.Image = (Bitmap)Resource1.ResourceManager.GetObject("mode_2");
            gameMode3.Image = (Bitmap)Resource1.ResourceManager.GetObject("mode3");
            gameMode4.Image = (Bitmap)Resource1.ResourceManager.GetObject("mode_4");
        }
        private void gameMode4_Hover(object sender, EventArgs e)
        {
            gameMode1.Image = (Bitmap)Resource1.ResourceManager.GetObject("mode_1");
            gameMode2.Image = (Bitmap)Resource1.ResourceManager.GetObject("mode_2");
            gameMode3.Image = (Bitmap)Resource1.ResourceManager.GetObject("mode_3");
            gameMode4.Image = (Bitmap)Resource1.ResourceManager.GetObject("mode4");
        }
        private void gameMode1_OnClick(object sender, EventArgs e)
        {
            GameModeDetail gameModeDetail1 = new GameModeDetail();
            gameModeDetail1.FormBorderStyle = FormBorderStyle.None;
            gameModeDetail1.StartPosition = FormStartPosition.CenterScreen;
            gameModeDetail1.BackgroundImage = Image.FromFile("mode1_detail.png");
            this.Hide();
            gameModeDetail1.ShowDialog();
        }
        private void gameMode2_OnClick(object sender, EventArgs e)
        {
            GameModeDetail gameModeDetail1 = new GameModeDetail();
            gameModeDetail1.FormBorderStyle = FormBorderStyle.None;
            gameModeDetail1.StartPosition = FormStartPosition.CenterScreen;
            gameModeDetail1.BackgroundImage = Image.FromFile("mode2_detail.png");
            this.Hide();
            gameModeDetail1.ShowDialog();
        }
        private void gameMode3_OnClick(object sender, EventArgs e)
        {
            GameModeDetail gameModeDetail1 = new GameModeDetail();
            gameModeDetail1.FormBorderStyle = FormBorderStyle.None;
            gameModeDetail1.StartPosition = FormStartPosition.CenterScreen;
            gameModeDetail1.BackgroundImage = Image.FromFile("mode3_detail.png");
            this.Hide();
            gameModeDetail1.ShowDialog();
        }
        private void gameMode4_OnClick(object sender, EventArgs e)
        {
            GameModeDetail gameModeDetail1 = new GameModeDetail();
            gameModeDetail1.FormBorderStyle = FormBorderStyle.None;
            gameModeDetail1.StartPosition = FormStartPosition.CenterScreen;
            gameModeDetail1.BackgroundImage = Image.FromFile("mode4_detail.png");
            this.Hide();
            gameModeDetail1.ShowDialog();
        }


        #region windows shadow effect
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        private bool m_aeroEnabled;

        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;

        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);
        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]

        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );

        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();
                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW; return cp;
            }
        }
        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0; DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 0,
                            rightWidth = 0,
                            topHeight = 0
                        }; DwmExtendFrameIntoClientArea(this.Handle, ref margins);
                    }
                    break;
                default: break;
            }
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT) m.Result = (IntPtr)HTCAPTION;
        }
        #endregion
    }
}
