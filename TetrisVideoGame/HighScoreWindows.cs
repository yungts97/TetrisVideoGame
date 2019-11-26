using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace TetrisVideoGame
{
	public class HighScoreWindows:Form
	{
		private Label title;
		private PictureBox titleBox;

		/*
		private ListView mylist;
		private ColumnHeader columnHeader1;
		private ColumnHeader columnHeader2;
		private ColumnHeader columnHeader3;
		private ColumnHeader columnHeader4;
		private ColumnHeader columnHeader5;
		*/

		private Button btnOk;
		private DataRecorder recorder;

		public HighScoreWindows()
		{
			this.MaximumSize = new Size(630, 450);
			this.BackgroundImage = Image.FromFile("bg.png");
			this.BackgroundImageLayout = ImageLayout.Stretch;
			this.Width = 630;
			this.Height = 450;
			this.ShowInTaskbar = false;
			recorder = new DataRecorder();

			titleBox = new PictureBox();
			titleBox.Image = Image.FromFile("Player_High_Score_Board.png");
			titleBox.SizeMode = PictureBoxSizeMode.StretchImage;
			titleBox.BackColor = Color.Transparent;
			titleBox.Top = 23;
			titleBox.Left = 128;
			titleBox.Width = 374;
			titleBox.Height = 43;
			this.Controls.Add(titleBox);
			/*
			title = new Label();
			title.Text = "Player High Score Board";
			title.BackColor = Color.Transparent;
			title.Visible = true;
			title.ForeColor = Color.FromArgb(64, 64, 64);
			title.Font = new Font("Arial", 15, FontStyle.Bold);
			title.BringToFront();
			title.AutoSize = true;
			title.Left = 48;
			title.Top = 35;
			this.Controls.Add(title);
			*/

			btnOk = new Button();
			btnOk.Text = "Ok";
			btnOk.FlatStyle = FlatStyle.Flat;
			btnOk.BackColor = Color.FromArgb(64, 64, 64);
			btnOk.Font = new Font("Arial", 10, FontStyle.Regular);
			btnOk.ForeColor = Color.White;
			btnOk.AutoSize = true;
			btnOk.Width = 130;
			btnOk.Height = 40;
			btnOk.Left = 480;
			btnOk.Top = 400;
			btnOk.DialogResult = DialogResult.OK;
			this.Controls.Add(btnOk);

			//start of list
			/*
			mylist = new ListView();
			columnHeader1 = new ColumnHeader();
			columnHeader2 = new ColumnHeader();
			columnHeader3 = new ColumnHeader();
			columnHeader4 = new ColumnHeader();
			columnHeader5 = new ColumnHeader();

			columnHeader1.Text = "No";
			columnHeader1.Width = 30;

			columnHeader2.Text = "Player Name";
			columnHeader2.Width = 150;

			columnHeader3.Text = "Level";
			columnHeader3.Width = 50;

			columnHeader4.Text = "Lines Cleared";
			columnHeader4.Width = 100;

			columnHeader5.Text = "Scores";
			columnHeader5.Width = 200;

			mylist.Columns.AddRange(new ColumnHeader[] {
				columnHeader1,
				columnHeader2,
				columnHeader3,
				columnHeader4,
				columnHeader5});

			mylist.ForeColor = Color.Black;
			mylist.FullRowSelect = true;
			mylist.GridLines = true;
			mylist.HoverSelection = true;
			mylist.LabelEdit = true;
			mylist.Location = new Point(50, 83);
			mylist.Size = new Size(535, 300);
			mylist.UseCompatibleStateImageBehavior = false;
			mylist.View = View.Details;

			this.Controls.Add(mylist);
			//end of list

			loadData();
			*/
			//mylist.Location = new Point(50, 83);
			//mylist.Size = new Size(535, 300);


			//continue to tweak highscore view
			int left = 50;
			int top = 90;


			List<Player> players = recorder.RetrieveData();
			var descPlayers = players.OrderByDescending(p => p.Score); // descending order
			int i = 0;
			int y = 0;


			Label[,] scoreview = new Label[descPlayers.Count(), 5];

			foreach (Player p in descPlayers)
			{
				int x = 0;
				string[] heading = { "No", "Name", "Level","Lines", "Scores" };
				string[] row = { i.ToString(), p.Name, p.Level.ToString(), p.ClearedLines.ToString(), p.Score.ToString() };

				foreach (String s in row)
				{
					Label l = new Label();
					scoreview[y, x] = l;
					if (y == 0)
					{
						l.Text = heading[x];
						l.Font = new Font("Arial", 12, FontStyle.Bold);
					}
					else 
					{
						l.Text = row[x];
					}
					l.ForeColor = Color.White;
					l.BackColor = Color.Transparent;
					l.Left = left;
					l.Top = top;
					l.Width = 120;
					l.Height = 30;

					l.Location = new Point(left + x * l.Width, top + y * l.Height);

					this.Controls.Add(scoreview[y, x]);
					x++;
				}
				++i;
				y++;
				if (y >= 10)
				{
					break;
				}
			}

			/*
			for (int i = 0; i < y; i++)
			{
				for (int j = 0; j < x; j++)
				{
					Label l = new Label();
					scoreview[i, j] = l;
					if (j == 0 && i > 0)
					{
						l.Text = (i).ToString();
					}
					else 
					{
						l.Text = "Hello";
					}
					l.Left = left;
					l.Top = top;
					l.Width = 100;
					l.Height = 30;

					l.Location = new Point(left + j * l.Width, top + i * l.Height);

					this.Controls.Add(scoreview[i, j]);
				}
			}
			*/
		}


		public void loadData()
		{
			List<Player> players = recorder.RetrieveData();
			var descPlayers = players.OrderByDescending(x => x.Score); // descending order
			int i = 1;
			foreach (Player x in descPlayers)
			{
				string[] row = { i.ToString(), x.Name, x.Level.ToString(), x.ClearedLines.ToString(), x.Score.ToString()};

				/*
				//print to labels
				ListViewItem item = new ListViewItem(row);
				mylist.Items.Add(item);

				*/

				++i;
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
