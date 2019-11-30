using System;
using System.Windows.Forms;
using System.Drawing;

namespace TetrisVideoGame
{
	public class PlayerBoard : Board
	{
		private Label txtplayer;
		private PictureBox txtTitle;
		public PlayerBoard(Form myboard, int blocksize, int col, int row) : base(blocksize, col, row)
		{
			initialize(myboard);
		}
		public override void initialize(Form form)
		{
			txtTitle = new PictureBox();
            txtTitle.Image = Image.FromFile("player_name.png");
            txtTitle.BackColor = Color.Transparent;
            txtTitle.Width = 130;
            txtTitle.Height = 22;
			txtTitle.Left = 777;
			txtTitle.Top = 24;
			form.Controls.Add(txtTitle);

			txtplayer = new Label();
			txtplayer.Text = "player1";
			txtplayer.BackColor = Color.Transparent;
			txtplayer.ForeColor = Color.White;
			txtplayer.Font = new Font("No Continue", 20);
			txtplayer.AutoSize = true;
			txtplayer.BringToFront();
			txtplayer.Left = 807;
			txtplayer.Top = 46;
			form.Controls.Add(txtplayer);

		}
		public void UpdatePlayerName(string name)
		{
			txtplayer.Text = name;
		}
	}
}
