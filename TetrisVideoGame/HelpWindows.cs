using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;


namespace TetrisVideoGame
{
	public class HelpWindows:Form
	{
		private Label title;
		private PictureBox downkey;
		private PictureBox upkey;
		private PictureBox leftkey;
		private PictureBox rightkey;
		private PictureBox spacekey;
		private PictureBox shiftkey;
		private PictureBox esckey;
		private PictureBox num1key;
		private PictureBox num2key;
		private PictureBox num3key;
		private Label down_des;
		private Label up_des;
		private Label left_des;
		private Label right_des;
		private Label space_des;
		private Label shift_des;
		private Label esc_des;
		private Label num1_des;
		private Label num2_des;
		private Label num3_des;
		private Button btnOk;

		public HelpWindows()
		{
			this.ShowInTaskbar = false;
			this.MaximumSize = new Size(830,600);

			title = new Label();
			title.Text = "Help Center";
			title.BackColor = Color.Transparent;
			title.Visible = true;
			title.ForeColor = Color.FromArgb(64, 64, 64);
			title.Font = new Font("Arial", 25, FontStyle.Bold);
			title.BringToFront();
			title.AutoSize = true;
			title.Left = 320;
			title.Top = 35;
			this.Controls.Add(title);

			downkey = new PictureBox();
			downkey.Image = Image.FromFile("keys/downkey.png");
			downkey.SizeMode = PictureBoxSizeMode.StretchImage;
			downkey.Width = 50;
			downkey.Height = 50;
			downkey.Visible = true;
			downkey.Left = 75;
			downkey.Top = 110;
			this.Controls.Add(downkey);

			down_des = new Label();
			down_des.Text = "Tetromino falling quickly.";
			down_des.BackColor = Color.Transparent;
			down_des.Visible = true;
			down_des.ForeColor = Color.FromArgb(64, 64, 64);
			down_des.Font = new Font("Arial", 10, FontStyle.Bold);
			down_des.BringToFront();
			down_des.AutoSize = true;
			down_des.Left = 140;
			down_des.Top = 130;
			this.Controls.Add(down_des);

			upkey = new PictureBox();
			upkey.Image = Image.FromFile("keys/upkey.png");
			upkey.SizeMode = PictureBoxSizeMode.StretchImage;
			upkey.Width = 50;
			upkey.Height = 50;
			upkey.Visible = true;
			upkey.Left = 75;
			upkey.Top = 190;
			this.Controls.Add(upkey);

			up_des = new Label();
			up_des.Text = "Rotate the Tetromino.";
			up_des.BackColor = Color.Transparent;
			up_des.Visible = true;
			up_des.ForeColor = Color.FromArgb(64, 64, 64);
			up_des.Font = new Font("Arial", 10, FontStyle.Bold);
			up_des.BringToFront();
			up_des.AutoSize = true;
			up_des.Left = 140;
			up_des.Top = 210;
			this.Controls.Add(up_des);

			leftkey = new PictureBox();
			leftkey.Image = Image.FromFile("keys/leftkey.png");
			leftkey.SizeMode = PictureBoxSizeMode.StretchImage;
			leftkey.Width = 50;
			leftkey.Height = 50;
			leftkey.Visible = true;
			leftkey.Left = 75;
			leftkey.Top = 270;
			this.Controls.Add(leftkey);

			left_des = new Label();
			left_des.Text = "Move the Tetromino to the left.";
			left_des.BackColor = Color.Transparent;
			left_des.Visible = true;
			left_des.ForeColor = Color.FromArgb(64, 64, 64);
			left_des.Font = new Font("Arial", 10, FontStyle.Bold);
			left_des.BringToFront();
			left_des.AutoSize = true;
			left_des.Left = 140;
			left_des.Top = 290;
			this.Controls.Add(left_des);

			rightkey = new PictureBox();
			rightkey.Image = Image.FromFile("keys/rightkey.png");
			rightkey.SizeMode = PictureBoxSizeMode.StretchImage;
			rightkey.Width = 50;
			rightkey.Height = 50;
			rightkey.Visible = true;
			rightkey.Left = 75;
			rightkey.Top = 350;
			this.Controls.Add(rightkey);

			right_des = new Label();
			right_des.Text = "Move the Tetromino to the right.";
			right_des.BackColor = Color.Transparent;
			right_des.Visible = true;
			right_des.ForeColor = Color.FromArgb(64, 64, 64);
			right_des.Font = new Font("Arial", 10, FontStyle.Bold);
			right_des.BringToFront();
			right_des.AutoSize = true;
			right_des.Left = 140;
			right_des.Top = 370;
			this.Controls.Add(right_des);

			shiftkey = new PictureBox();
			shiftkey.Image = Image.FromFile("keys/shiftkey.png");
			shiftkey.SizeMode = PictureBoxSizeMode.StretchImage;
			shiftkey.Width = 100;
			shiftkey.Height = 50;
			shiftkey.Visible = true;
			shiftkey.Left = 75;
			shiftkey.Top = 430;
			this.Controls.Add(shiftkey);

			shift_des = new Label();
			shift_des.Text = "Hold a Tetromino.";
			shift_des.BackColor = Color.Transparent;
			shift_des.Visible = true;
			shift_des.ForeColor = Color.FromArgb(64, 64, 64);
			shift_des.Font = new Font("Arial", 10, FontStyle.Bold);
			shift_des.BringToFront();
			shift_des.AutoSize = true;
			shift_des.Left = 190;
			shift_des.Top = 450;
			this.Controls.Add(shift_des);

			spacekey = new PictureBox();
			spacekey.Image = Image.FromFile("keys/spacekey.png");
			spacekey.SizeMode = PictureBoxSizeMode.StretchImage;
			spacekey.Width = 160;
			spacekey.Height = 50;
			spacekey.Visible = true;
			spacekey.Left = 425;
			spacekey.Top = 110;
			this.Controls.Add(spacekey);

			space_des = new Label();
			space_des.Text = "Tetromino fall instantly.";
			space_des.BackColor = Color.Transparent;
			space_des.Visible = true;
			space_des.ForeColor = Color.FromArgb(64, 64, 64);
			space_des.Font = new Font("Arial", 10, FontStyle.Bold);
			space_des.BringToFront();
			space_des.AutoSize = true;
			space_des.Left = 600;
			space_des.Top = 130;
			this.Controls.Add(space_des);

			esckey = new PictureBox();
			esckey.Image = Image.FromFile("keys/esckey.png");
			esckey.SizeMode = PictureBoxSizeMode.StretchImage;
			esckey.Width = 50;
			esckey.Height = 50;
			esckey.Visible = true;
			esckey.Left = 425;
			esckey.Top = 190;
			this.Controls.Add(esckey);

			esc_des = new Label();
			esc_des.Text = "Pause the game.";
			esc_des.BackColor = Color.Transparent;
			esc_des.Visible = true;
			esc_des.ForeColor = Color.FromArgb(64, 64, 64);
			esc_des.Font = new Font("Arial", 10, FontStyle.Bold);
			esc_des.BringToFront();
			esc_des.AutoSize = true;
			esc_des.Left = 490;
			esc_des.Top = 210;
			this.Controls.Add(esc_des);

			num1key = new PictureBox();
			num1key.Image = Image.FromFile("keys/num1key.png");
			num1key.SizeMode = PictureBoxSizeMode.StretchImage;
			num1key.Width = 50;
			num1key.Height = 50;
			num1key.Visible = true;
			num1key.Left = 425;
			num1key.Top = 270;
			this.Controls.Add(num1key);

			num1_des = new Label();
			num1_des.Text = "Use a color bomb.";
			num1_des.BackColor = Color.Transparent;
			num1_des.Visible = true;
			num1_des.ForeColor = Color.FromArgb(64, 64, 64);
			num1_des.Font = new Font("Arial", 10, FontStyle.Bold);
			num1_des.BringToFront();
			num1_des.AutoSize = true;
			num1_des.Left = 490;
			num1_des.Top = 290;
			this.Controls.Add(num1_des);

			num2key = new PictureBox();
			num2key.Image = Image.FromFile("keys/num2key.png");
			num2key.SizeMode = PictureBoxSizeMode.StretchImage;
			num2key.Width = 50;
			num2key.Height = 50;
			num2key.Visible = true;
			num2key.Left = 425;
			num2key.Top = 350;
			this.Controls.Add(num2key);

			num2_des = new Label();
			num2_des.Text = "Use a horizontal bomb.";
			num2_des.BackColor = Color.Transparent;
			num2_des.Visible = true;
			num2_des.ForeColor = Color.FromArgb(64, 64, 64);
			num2_des.Font = new Font("Arial", 10, FontStyle.Bold);
			num2_des.BringToFront();
			num2_des.AutoSize = true;
			num2_des.Left = 490;
			num2_des.Top = 370;
			this.Controls.Add(num2_des);

			num3key = new PictureBox();
			num3key.Image = Image.FromFile("keys/num3key.png");
			num3key.SizeMode = PictureBoxSizeMode.StretchImage;
			num3key.Width = 50;
			num3key.Height = 50;
			num3key.Visible = true;
			num3key.Left = 425;
			num3key.Top = 430;
			this.Controls.Add(num3key);

			num3_des = new Label();
			num3_des.Text = "Use a large bomb.";
			num3_des.BackColor = Color.Transparent;
			num3_des.Visible = true;
			num3_des.ForeColor = Color.FromArgb(64, 64, 64);
			num3_des.Font = new Font("Arial", 10, FontStyle.Bold);
			num3_des.BringToFront();
			num3_des.AutoSize = true;
			num3_des.Left = 490;
			num3_des.Top = 450;
			this.Controls.Add(num3_des);

			btnOk = new Button();
			btnOk.Text = "Ok";
			btnOk.FlatStyle = FlatStyle.Flat;
			btnOk.BackColor = Color.FromArgb(64, 64, 64);
			btnOk.Font = new Font("Arial", 10, FontStyle.Regular);
			btnOk.ForeColor = Color.White;
			btnOk.AutoSize = true;
			btnOk.Width = 130;
			btnOk.Height = 40;
			btnOk.Left = 650;
			btnOk.Top = 530;
			btnOk.DialogResult = DialogResult.OK;
			this.Controls.Add(btnOk);
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
