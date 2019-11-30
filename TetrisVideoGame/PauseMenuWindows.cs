using System;
using System.Drawing;
using System.Windows.Forms;

namespace TetrisVideoGame
{
	public class PauseMenuWindows:Form
	{
		private Button btnResume;
		private Button btnHelp;
		private Button btnExit;


		public PauseMenuWindows()
		{
			this.MaximumSize = new Size(400, 370);
            this.Width = 400;
            this.Height = 370;
            this.BackgroundImage = Image.FromFile("bg.png");

            btnResume = new Button();
			btnResume.Text = "Resume";
			btnResume.FlatStyle = FlatStyle.Flat;
			btnResume.BackColor = Color.FromArgb(72, 72, 72);
            btnResume.Font = new Font("Segeo UI", 15, FontStyle.Bold);
			btnResume.ForeColor = Color.FromArgb(255, 234, 234);
            btnResume.AutoSize = true;
			btnResume.Width = 300;
			btnResume.Height = 60;
			btnResume.Left = 50;
			btnResume.Top = 80;
			btnResume.DialogResult = DialogResult.OK;
			this.Controls.Add(btnResume);

			btnHelp = new Button();
			btnHelp.Text = "Help";
			btnHelp.FlatStyle = FlatStyle.Flat;
			btnHelp.BackColor = Color.FromArgb(72, 72, 72);
            btnHelp.Font = new Font("Segeo UI", 15, FontStyle.Bold);
            btnHelp.ForeColor = Color.FromArgb(255, 234, 234);
            btnHelp.AutoSize = true;
			btnHelp.Width = 300;
			btnHelp.Height = 60;
			btnHelp.Left = 50;
			btnHelp.Top = 160;
			btnHelp.DialogResult = DialogResult.No;
			this.Controls.Add(btnHelp);

			btnExit = new Button();
			btnExit.Text = "Exit";
			btnExit.FlatStyle = FlatStyle.Flat;
			btnExit.BackColor = Color.FromArgb(72, 72, 72);
            btnExit.Font = new Font("Segeo UI", 15, FontStyle.Bold);
            btnExit.ForeColor = Color.FromArgb(255, 234, 234);
            btnExit.AutoSize = true;
			btnExit.Width = 300;
			btnExit.Height = 60;
			btnExit.Left = 50;
			btnExit.Top = 240;
			btnExit.DialogResult = DialogResult.Cancel;
			this.Controls.Add(btnExit);
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
