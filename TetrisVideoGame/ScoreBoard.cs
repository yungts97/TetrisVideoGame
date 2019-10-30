using System;
using System.Windows.Forms;
using System.Drawing;

namespace TetrisVideoGame
{
	public class ScoreBoard:Board
	{
		private Label txtScore;
		private Label txtTitle;
		public ScoreBoard(Form myboard, int blocksize, int col, int row) : base(blocksize, col, row)
		{
			initialize(myboard);
		}
		public override void initialize(Form form)
		{
			txtTitle = new Label();
			txtTitle.Text = "Score";
			txtTitle.ForeColor = Color.Black;
			txtTitle.Font = new Font("Arial", 13, FontStyle.Bold);
			txtTitle.AutoSize = true;
			txtTitle.Left = 640;
			txtTitle.Top = 520;
			form.Controls.Add(txtTitle);

			txtScore = new Label();
			txtScore.Text = "0";
			txtScore.BackColor = Color.Black;
			txtScore.ForeColor = Color.White;
			txtScore.Font = new Font("Arial", 15, FontStyle.Bold);
			txtScore.AutoSize = true;
			txtScore.BringToFront();
			txtScore.Left = 660;
			txtScore.Top = 560;
			form.Controls.Add(txtScore);

			for (int i = 0; i < _rows; ++i)
			{
				for (int j = 0; j < _columns; ++j)
				{
					grids[i, j] = new Label();
					grids[i, j].Width = _blockSize;
					grids[i, j].Height = _blockSize;
					grids[i, j].BackColor = Color.Black;
					grids[i, j].Left = 640 + _blockSize * j;
					grids[i, j].Top = 550 + i * _blockSize;
					grids[i, j].Visible = true;
					form.Controls.Add(grids[i, j]);
				}
			}
		}
		public void UpdateScore(int score)
		{
			txtScore.Text = score.ToString();
		}
	}
}
