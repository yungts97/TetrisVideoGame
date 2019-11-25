using System;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;

namespace TetrisVideoGame
{
	public class MainWindows : Form
	{
		private Button btnStart;
		private Button btnHighScore;
		private Button btnHelp;
        private Button btnSetting;
		private Button btnExit;
		private PictureBox logo;
        private PictureBox pointer;
        private GameModeMenu gameModeMenu;
		private TetrisGame game;
		private PlayerNameWindows dialog;
		private HighScoreWindows dialog2;
		private HelpWindows dialog3;

		public MainWindows()
		{
			this.MaximumSize = new Size(850,713);
            this.Width = 850;
            this.Height = 713;

            logo = new PictureBox();
			logo.Image = Image.FromFile("logo1.png");
			logo.SizeMode = PictureBoxSizeMode.StretchImage;
			logo.Width = 420;
			logo.Height = 100;
			logo.Visible = true;
			logo.Left = 215;
			logo.Top = 50;
			this.Controls.Add(logo);

            btnStart = new Button();
			btnStart.Text = "Start";
			btnStart.FlatStyle = FlatStyle.Flat;
			btnStart.BackColor = Color.FromArgb(64, 64, 64);
			btnStart.Font = new Font("Arial", 15, FontStyle.Regular);
			btnStart.ForeColor = Color.White;
			btnStart.AutoSize = true;
			btnStart.Width = 300;
			btnStart.Height = 60;
			btnStart.Left = 275;
			btnStart.Top = 220;
			btnStart.DialogResult = DialogResult.OK;
			btnStart.Click += this.Btn_Start;
            btnStart.MouseMove += this.btnStart_MouseMove;
            this.Controls.Add(btnStart);

			btnHighScore = new Button();
			btnHighScore.Text = "High Score";
			btnHighScore.FlatStyle = FlatStyle.Flat;
			btnHighScore.Font = new Font("Arial", 15, FontStyle.Regular);
            btnHighScore.ForeColor = Color.White;
            btnHighScore.AutoSize = true;
			btnHighScore.Width = 300;
			btnHighScore.Height = 60;
			btnHighScore.Left = 275;
			btnHighScore.Top = 310;
			btnHighScore.Click += this.Btn_HighScore;
            btnHighScore.MouseMove += this.btnHighScore_MouseMove;
            this.Controls.Add(btnHighScore);

			btnHelp = new Button();
			btnHelp.Text = "Help";
			btnHelp.FlatStyle = FlatStyle.Flat;
			btnHelp.Font = new Font("Arial", 15, FontStyle.Regular);
            btnHelp.ForeColor = Color.White;
            btnHelp.AutoSize = true;
			btnHelp.Width = 300;
			btnHelp.Height = 60;
			btnHelp.Left = 275;
			btnHelp.Top = 400;
			btnHelp.Click += this.Btn_Help;
            btnHelp.MouseMove += this.btnHelp_MouseMove;
            this.Controls.Add(btnHelp);

            btnSetting = new Button();
            btnSetting.Text = "Setting";
            btnSetting.FlatStyle = FlatStyle.Flat;
            btnSetting.Font = new Font("Arial", 15, FontStyle.Regular);
            btnSetting.ForeColor = Color.White;
            btnSetting.AutoSize = true;
            btnSetting.Width = 300;
            btnSetting.Height = 60;
            btnSetting.Left = 275;
            btnSetting.Top = 490;
            btnSetting.Click += Btn_Setting;
            btnSetting.MouseMove += this.btnSetting_MouseMove;
            this.Controls.Add(btnSetting);

            btnExit = new Button();
			btnExit.Text = "Exit";
			btnExit.FlatStyle = FlatStyle.Flat;
			btnExit.Font = new Font("Arial", 15, FontStyle.Regular);
            btnExit.ForeColor = Color.White;
            btnExit.AutoSize = true;
			btnExit.Width = 300;
			btnExit.Height = 60;
			btnExit.Left = 275;
			btnExit.Top = 580;
			btnExit.Click += Btn_Exit;
            btnExit.MouseMove += this.btnExit_MouseMove;
            this.Controls.Add(btnExit);

            pointer = new PictureBox();
            pointer.Image = Image.FromFile("pointer.png");
            pointer.SizeMode = PictureBoxSizeMode.StretchImage;
            pointer.Width = 60;
            pointer.Height = 35;
            pointer.Visible = true;
            pointer.Left = 200;
            pointer.Top = 230;
            this.Controls.Add(pointer);

        }

        private void btnStart_MouseMove(object sender, EventArgs e)
        {
            pointer.Top = 230;
        }
        private void btnHighScore_MouseMove(object sender, EventArgs e)
        {
            pointer.Top = 320;
        }
        private void btnHelp_MouseMove(object sender, EventArgs e)
        {
            pointer.Top = 410;
        }
        private void btnSetting_MouseMove(object sender, EventArgs e)
        {
            pointer.Top = 500;
        }
        private void btnExit_MouseMove(object sender, EventArgs e)
        {
            pointer.Top = 590;
        }
        private void Btn_Start(object sender, EventArgs e)
		{
            gameModeMenu = new GameModeMenu();
           
            gameModeMenu.StartPosition = FormStartPosition.CenterScreen;
            gameModeMenu.FormBorderStyle = FormBorderStyle.None;
            this.Hide();
            gameModeMenu.ShowDialog();
            /*dialog = new PlayerNameWindows();
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
					game = new TetrisGame(30, 10, 20, dialog.txtName.Text);
					game.StartPosition = FormStartPosition.CenterScreen;
					game.Text = "My First Form";
					game.Width = 850;
					game.Height = 850;
					game.Visible = true;
				}
				this.Hide();
			}
            else
                this.Show();*/
        }
		private void Btn_HighScore(object sender, EventArgs e)
		{
			dialog2 = new HighScoreWindows();
			dialog2.BackColor = Color.FromArgb(240, 240, 240);
			dialog2.StartPosition = FormStartPosition.CenterScreen;
			dialog2.FormBorderStyle = FormBorderStyle.None;
			dialog2.Name = "HighScoreDialog";
			dialog2.Width = 630;
			dialog2.Height = 450;
			if (dialog2.ShowDialog() == DialogResult.OK)
			{
				dialog2.Dispose();
			}
		}
		private void Btn_Help(object sender, EventArgs e)
		{
			dialog3 = new HelpWindows();
			dialog3.BackColor = Color.FromArgb(240, 240, 240);
			dialog3.StartPosition = FormStartPosition.CenterScreen;
			dialog3.FormBorderStyle = FormBorderStyle.None;
			dialog3.Name = "HelpDialog";
			dialog3.Width = 830;
			dialog3.Height = 600;
			if (dialog3.ShowDialog() == DialogResult.OK)
			{
				dialog3.Dispose();
			}
		}

        private void Btn_Setting(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Btn_Exit(object sender, EventArgs e)
		{
			this.Dispose();
		}

        private bool MouseIsOverControl(Button btn)
        {
            if (btn.ClientRectangle.Contains(btn.PointToClient(Cursor.Position)))
            {
                return true;
            }
            return false;
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
