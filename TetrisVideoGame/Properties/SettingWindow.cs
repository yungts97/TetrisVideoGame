using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
namespace TetrisVideoGame
{
	public class SettingWindow:Form
	{
		private Label title;
		private Button btnChangeBgi;
		private Button btnOk;
		private Button btnMute;
		private PictureBox picturebox1;

		public SettingWindow()
		{
			this.MaximumSize = new Size(420, 680);
			this.BackgroundImage = Image.FromFile("background_1.jpg");
			this.ShowInTaskbar = false;


			title = new Label();
			title.Text = "Setting";
			title.BackColor = Color.Transparent;
			title.Visible = true;
			title.ForeColor = Color.FromArgb(255, 255, 255);
			title.Font = new Font("Times New Roman", 15, FontStyle.Bold);
			title.BringToFront();
			title.AutoSize = true;
			title.Left = 175;
			title.Top = 70;
			this.Controls.Add(title);

			btnChangeBgi = new Button();
			btnChangeBgi.Text = "Change Background image";
			btnChangeBgi.FlatStyle = FlatStyle.Flat;
			btnChangeBgi.BackColor = Color.Transparent;
			btnChangeBgi.Font = new Font("Times New Roman", 10, FontStyle.Regular);
			btnChangeBgi.ForeColor = Color.White;
			btnChangeBgi.AutoSize = true;
			btnChangeBgi.Width = 130;
			btnChangeBgi.Height = 40;
			btnChangeBgi.Left = 130;
			btnChangeBgi.Top = 160;

			this.Controls.Add(btnChangeBgi);

			btnMute = new Button();
			btnMute.Text = "Mute";
			btnMute.FlatStyle = FlatStyle.Flat;
			btnMute.BackColor = Color.Transparent;
			btnMute.Font = new Font("Times New Roman", 10, FontStyle.Regular);
			btnMute.ForeColor = Color.White;
			btnMute.AutoSize = true;
			btnMute.Width = 168;
			btnMute.Height = 40;
			btnMute.Left = 130;
			btnMute.Top = 250;
			this.Controls.Add(btnMute);

			btnOk = new Button();
			btnOk.Text = "Ok";
			btnOk.FlatStyle = FlatStyle.Flat;
			btnOk.BackColor = Color.Transparent;
			btnOk.Font = new Font("Arial", 10, FontStyle.Regular);
			btnOk.ForeColor = Color.White;
			btnOk.AutoSize = true;
			btnOk.Width = 130;
			btnOk.Height = 40;
			btnOk.Left = 280;
			btnOk.Top = 630;
			btnOk.DialogResult = DialogResult.OK;
			this.Controls.Add(btnOk);

		


	}


	}
}
