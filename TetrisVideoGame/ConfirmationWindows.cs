﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace TetrisVideoGame
{
	public class ConfirmationWindows: Form
	{
		private Button btnConfirm;
		private Button btnCancel;
		private Label message;

		public ConfirmationWindows()
		{
			this.MaximumSize = new Size(350, 130);
			this.ShowInTaskbar = false;

			message = new Label();
			message.Text = "Are you sure you want to exit?";
			message.ForeColor = Color.FromArgb(64, 64, 64);
			message.Font = new Font("Arial", 12, FontStyle.Bold);
			message.AutoSize = true;
			message.Left = 50;
			message.Top = 30;
			this.Controls.Add(message);

			btnConfirm = new Button();
			btnConfirm.Text = "Confirm";
			btnConfirm.FlatStyle = FlatStyle.Flat;
			btnConfirm.BackColor = Color.FromArgb(64, 64, 64);
			btnConfirm.Font = new Font("Arial", 12, FontStyle.Regular);
			btnConfirm.ForeColor = Color.White;
			btnConfirm.AutoSize = true;
			btnConfirm.Width = 95;
			btnConfirm.Height = 35;
			btnConfirm.Left = 65;
			btnConfirm.Top = 75;
			btnConfirm.DialogResult = DialogResult.OK;
			this.Controls.Add(btnConfirm);

			btnCancel = new Button();
			btnCancel.Text = "Cancel";
			btnCancel.FlatStyle = FlatStyle.Flat;
			btnCancel.Font = new Font("Arial", 12, FontStyle.Regular);
			btnCancel.AutoSize = true;
			btnCancel.Width = 95;
			btnCancel.Height = 30;
			btnCancel.Left = 195;
			btnCancel.Top = 75;
			btnCancel.DialogResult = DialogResult.Cancel;
			this.Controls.Add(btnCancel);
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
