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
		private Button btnExit;
		private PictureBox logo;
		private Label title;
		//private TetrisGame game;
		private UpSideDownMode game;
		private PlayerNameWindows dialog;
		private HighScoreWindows dialog2;
		private HelpWindows dialog3;

		public MainWindows()
		{
			//this.BackgroundImage = Image.FromFile("tetris.jpg");
			this.MaximumSize = new Size(420,680);
			title = new Label();
			title.Text = "Tetris Game";
			title.BackColor = Color.Transparent;
			title.Visible = true;
			title.ForeColor = Color.FromArgb(64, 64, 64);
			title.Font = new Font("Arial", 25, FontStyle.Bold);
			title.BringToFront();
			title.AutoSize = true;
			title.Left = 105;
			title.Top = 70;
			this.Controls.Add(title);

			logo = new PictureBox();
			logo.Image = Image.FromFile("logo.png");
			logo.SizeMode = PictureBoxSizeMode.StretchImage;
			logo.Width = 110;
			logo.Height = 80;
			logo.Visible = true;
			logo.Left = 155;
			logo.Top = 150;
			this.Controls.Add(logo);


			btnStart = new Button();
			btnStart.Text = "Start";
			btnStart.FlatStyle = FlatStyle.Flat;
			btnStart.BackColor = Color.FromArgb(64, 64, 64);
			btnStart.Font = new Font("Arial", 15, FontStyle.Regular);
			btnStart.ForeColor = Color.White;
			btnStart.AutoSize = true;
			btnStart.Width = 220;
			btnStart.Height = 60;
			btnStart.Left = 100;
			btnStart.Top = 280;
			btnStart.DialogResult = DialogResult.OK;
			btnStart.Click += this.Btn_Start;
			this.Controls.Add(btnStart);

			btnHighScore = new Button();
			btnHighScore.Text = "High Score";
			btnHighScore.FlatStyle = FlatStyle.Flat;
			btnHighScore.Font = new Font("Arial", 15, FontStyle.Regular);
			btnHighScore.AutoSize = true;
			btnHighScore.Width = 220;
			btnHighScore.Height = 60;
			btnHighScore.Left = 100;
			btnHighScore.Top = 370;
			btnHighScore.Click += this.Btn_HighScore;
			this.Controls.Add(btnHighScore);

			btnHelp = new Button();
			btnHelp.Text = "Help";
			btnHelp.FlatStyle = FlatStyle.Flat;
			btnHelp.Font = new Font("Arial", 15, FontStyle.Regular);
			btnHelp.AutoSize = true;
			btnHelp.Width = 220;
			btnHelp.Height = 60;
			btnHelp.Left = 100;
			btnHelp.Top = 460;
			btnHelp.Click += this.Btn_Help;
			this.Controls.Add(btnHelp);

			btnExit = new Button();
			btnExit.Text = "Exit";
			btnExit.FlatStyle = FlatStyle.Flat;
			btnExit.Font = new Font("Arial", 15, FontStyle.Regular);
			btnExit.AutoSize = true;
			btnExit.Width = 220;
			btnExit.Height = 60;
			btnExit.Left = 100;
			btnExit.Top = 550;
			btnExit.Click += Btn_Exit;
			this.Controls.Add(btnExit);
		}
		private void Btn_Start(object sender, EventArgs e)
		{
			
			dialog = new PlayerNameWindows();
			dialog.BackColor = Color.FromArgb(240, 240, 240);
			dialog.StartPosition = FormStartPosition.CenterScreen;
			dialog.FormBorderStyle = FormBorderStyle.None;
			dialog.Name = "PlayerDialog";
			dialog.Width = 350;
			dialog.Height = 250;
			dialog.ShowDialog();
			if (dialog.Visible == false && dialog.flag)
			{
				if (dialog.txtName.Text != "" || dialog.txtName.Text != null)
				{
					dialog.Dispose();
					//game = new TetrisGame(30, 10, 20, dialog.txtName.Text);
					game = new UpSideDownMode(30, 10, 20, dialog.txtName.Text);
					game.StartPosition = FormStartPosition.CenterScreen;
					game.Text = "My First Form";
					game.Width = 850;
					game.Height = 850;
					game.Visible = true;
				}
				this.Hide();
			}
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

		private void Btn_Exit(object sender, EventArgs e)
		{
			this.Dispose();
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
