using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TetrisVideoGame
{
    class SettingWindow : Form
    {
        private PictureBox PicBack;
        private PictureBox pointer1;
        private PictureBox theme1, theme2, theme3, theme4, theme5;
        private PictureBox bgm1, bgm2;
        private PictureBox on, off;
        private PictureBox audioIcon;

        public SettingWindow()
        {
            this.ShowInTaskbar = false;
            this.BackgroundImage = Image.FromFile("settingbg.png");
            this.MaximumSize = new Size(732, 530);

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

            theme1 = new PictureBox();
            theme1.Image = Image.FromFile("theme1.png");
            theme1.SizeMode = PictureBoxSizeMode.StretchImage;
            theme1.BackColor = Color.Transparent;
            theme1.Width = 238;
            theme1.Height = 50;
            theme1.Left = 99;
            theme1.Top = 209;
            theme1.Click += theme1_OnClick;
            this.Controls.Add(theme1);

            theme2 = new PictureBox();
            theme2.Image = Image.FromFile("theme2.png");
            theme2.SizeMode = PictureBoxSizeMode.StretchImage;
            theme2.BackColor = Color.Transparent;
            theme2.Width = 238;
            theme2.Height = 50;
            theme2.Left = 99;
            theme2.Top = 264;
            theme2.Click += theme2_OnClick;
            this.Controls.Add(theme2);

            theme3 = new PictureBox();
            theme3.Image = Image.FromFile("theme3.png");
            theme3.SizeMode = PictureBoxSizeMode.StretchImage;
            theme3.BackColor = Color.Transparent;
            theme3.Width = 238;
            theme3.Height = 50;
            theme3.Left = 99;
            theme3.Top = 319;
            theme3.Click += theme3_OnClick;
            this.Controls.Add(theme3);

            theme4 = new PictureBox();
            theme4.Image = Image.FromFile("theme4.png");
            theme4.SizeMode = PictureBoxSizeMode.StretchImage;
            theme4.BackColor = Color.Transparent;
            theme4.Width = 238;
            theme4.Height = 50;
            theme4.Left = 99;
            theme4.Top = 374;
            theme4.Click += theme4_OnClick;
            this.Controls.Add(theme4);

            theme5 = new PictureBox();
            theme5.Image = Image.FromFile("theme5.png");
            theme5.SizeMode = PictureBoxSizeMode.StretchImage;
            theme5.BackColor = Color.Transparent;
            theme5.Width = 238;
            theme5.Height = 50;
            theme5.Left = 99;
            theme5.Top = 429;
            theme5.Click += theme5_OnClick;
            this.Controls.Add(theme5);

            pointer1 = new PictureBox();
            pointer1.Image = Image.FromFile("pointer.png");
            pointer1.SizeMode = PictureBoxSizeMode.StretchImage;
            pointer1.BackColor = Color.Transparent;
            pointer1.Width = 45;
            pointer1.Height = 25;
            pointer1.Visible = true;
            pointer1.Left = 45;
            pointer1.Top = 218;
            this.Controls.Add(pointer1);

            bgm1 = new PictureBox();
            bgm1.SizeMode = PictureBoxSizeMode.StretchImage;
            bgm1.Image = Image.FromFile("bgm1.png");
            bgm1.BackColor = Color.Transparent;
            bgm1.Width = 173;
            bgm1.Height = 47;
            bgm1.Left = 450;
            bgm1.Top = 190;
            bgm1.Click += bgm1_OnClick;
            this.Controls.Add(bgm1);

            bgm2 = new PictureBox();
            bgm2.SizeMode = PictureBoxSizeMode.StretchImage;
            bgm2.Image = Image.FromFile("bgm2.png");
            bgm2.BackColor = Color.Transparent;
            bgm2.Width = 181;
            bgm2.Height = 47;
            bgm2.Left = 450;
            bgm2.Top = 248;
            bgm2.Click += bgm2_OnClick;
            this.Controls.Add(bgm2);

            on = new PictureBox();
            on.SizeMode = PictureBoxSizeMode.StretchImage;
            on.Image = Image.FromFile("on.png");
            on.BackColor = Color.Transparent;
            on.Width = 62;
            on.Height = 47;
            on.Left = 450;
            on.Top = 407;
            on.Click += on_OnClick;
            this.Controls.Add(on);

            off = new PictureBox();
            off.SizeMode = PictureBoxSizeMode.StretchImage;
            off.Image = Image.FromFile("off.png");
            off.BackColor = Color.Transparent;
            off.Width = 70;
            off.Height = 47;
            off.Left = 537;
            off.Top = 407;
            off.Click += off_OnClick;
            this.Controls.Add(off);

            audioIcon = new PictureBox();
            audioIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            audioIcon.Image = Image.FromFile("audio.png");
            audioIcon.BackColor = Color.Transparent;
            audioIcon.Width = 30;
            audioIcon.Height = 30;
            audioIcon.Left = 567;
            audioIcon.Top = 363;
            this.Controls.Add(audioIcon);

            setTheme();
            setBGM();
            setVolume();
        }

        private void PicBack_OnClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }
        private void theme1_OnClick(object sender, EventArgs e)
        {
            pointer1.Top = 218;
            pointer1.Image = Image.FromFile("pointer.png");
            MainWindows.theme = 1;
        }
        private void theme2_OnClick(object sender, EventArgs e)
        {
            pointer1.Top = 273;
            pointer1.Image = Image.FromFile("pointer2.png");
            MainWindows.theme = 2;
        }
        private void theme3_OnClick(object sender, EventArgs e)
        {
            pointer1.Top = 328;
            pointer1.Image = Image.FromFile("pointer3.png");
            MainWindows.theme = 3;
        }
        private void theme4_OnClick(object sender, EventArgs e)
        {
            pointer1.Top = 383;
            pointer1.Image = Image.FromFile("pointer4.png");
            MainWindows.theme = 4;
        }
        private void theme5_OnClick(object sender, EventArgs e)
        {
            pointer1.Top = 438;
            pointer1.Image = Image.FromFile("pointer5.png");
            MainWindows.theme = 5;
        }
        private void bgm1_OnClick(object sender, EventArgs e)
        {
            bgm1.Image = Image.FromFile("bgm1_selected.png");
            bgm2.Image = Image.FromFile("bgm2.png");
            MainWindows.bgm = 1;
        }
        private void bgm2_OnClick(object sender, EventArgs e)
        {
            bgm1.Image = Image.FromFile("bgm1.png");
            bgm2.Image = Image.FromFile("bgm2_selected.png");
            MainWindows.bgm = 2;
        }
        private void on_OnClick(object sender, EventArgs e)
        {
            on.Image = Image.FromFile("on_selected.png");
            off.Image = Image.FromFile("off.png");
            MainWindows.volume = true;
            audioIcon.Image = Image.FromFile("audio.png");
        }
        private void off_OnClick(object sender, EventArgs e)
        {
            on.Image = Image.FromFile("on.png");
            off.Image = Image.FromFile("off_selected.png");
            MainWindows.volume = false;
            audioIcon.Image = Image.FromFile("mute.png");
        }
        private void setTheme()
        {
            if (MainWindows.theme == 1)
            {
                pointer1.Top = 218;
                pointer1.Image = Image.FromFile("pointer.png");
            }
            else if (MainWindows.theme == 2)
            {
                pointer1.Top = 273;
                pointer1.Image = Image.FromFile("pointer2.png");
            }
            else if (MainWindows.theme == 3)
            {
                pointer1.Top = 328;
                pointer1.Image = Image.FromFile("pointer3.png");
            }
            else if (MainWindows.theme == 4)
            {
                pointer1.Top = 383;
                pointer1.Image = Image.FromFile("pointer4.png");
            }
            else if (MainWindows.theme == 5)
            {
                pointer1.Top = 438;
                pointer1.Image = Image.FromFile("pointer5.png");
            }
        }
        private void setBGM()
        {
            if (MainWindows.bgm == 1)
            {
                bgm1.Image = Image.FromFile("bgm1_selected.png");
            }
            else if (MainWindows.bgm == 2)
            {
                bgm2.Image = Image.FromFile("bgm2_selected.png");
            }
        }
        private void setVolume()
        {
            if (MainWindows.volume)
            {
                on.Image = Image.FromFile("on_selected.png");
                audioIcon.Image = Image.FromFile("audio.png");
            }
            else
            {
                off.Image = Image.FromFile("off_selected.png");
                audioIcon.Image = Image.FromFile("mute.png");
            }
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
