using System;
using System.Windows.Forms;
using System.Drawing;

namespace TetrisVideoGame
{
	public class PlayerBoard : Board
	{
		private Label txtplayer;
		private Label txtTitle;
		public PlayerBoard(Form myboard, int blocksize, int col, int row) : base(blocksize, col, row)
		{
			initialize(myboard);
		}
		public override void initialize(Form form)
		{
			txtTitle = new Label();
			txtTitle.Text = "Player Name: ";
			txtTitle.ForeColor = Color.Black;
			txtTitle.Font = new Font("Arial", 13, FontStyle.Bold);
			txtTitle.AutoSize = true;
			txtTitle.Left = 240;
			txtTitle.Top = 60;
			form.Controls.Add(txtTitle);

			txtplayer = new Label();
			txtplayer.Text = "player1";
			txtplayer.BackColor = Color.Transparent;
			txtplayer.ForeColor = Color.Black;
			txtplayer.Font = new Font("Arial", 13, FontStyle.Bold);
			txtplayer.AutoSize = true;
			txtplayer.BringToFront();
			txtplayer.Left = 360;
			txtplayer.Top = 60;
			form.Controls.Add(txtplayer);

		}
		public void UpdatePlayerName(string name)
		{
			txtplayer.Text = name;
		}
	}
}
