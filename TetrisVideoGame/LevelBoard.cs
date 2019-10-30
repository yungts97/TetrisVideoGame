using System;
using System.Windows.Forms;
using System.Drawing;

namespace TetrisVideoGame
{
	public class LevelBoard:Board
	{
		private Label txtLevel;
		private Label txtTitle;

		public LevelBoard(Form myboard, int blocksize, int col, int row):base(blocksize,col,row)
		{
			initialize(myboard);
		}
		public override void initialize(Form form)
		{
			txtTitle = new Label();
			txtTitle.Text = "Level";
			txtTitle.ForeColor = Color.Black;
			txtTitle.Font = new Font("Arial", 13, FontStyle.Bold);
			txtTitle.AutoSize = true;
			txtTitle.Left = 640;
			txtTitle.Top = 420;
			form.Controls.Add(txtTitle);

			txtLevel = new Label();
			txtLevel.Text = "1";
			txtLevel.BackColor = Color.Black;
			txtLevel.ForeColor = Color.White;
			txtLevel.Font = new Font("Arial", 15, FontStyle.Bold);
			txtLevel.AutoSize = true;
			txtLevel.BringToFront();
			txtLevel.Left = 660;
			txtLevel.Top = 460;
			form.Controls.Add(txtLevel);

			for (int i = 0; i < _rows; ++i)
			{
				for (int j = 0; j < _columns; ++j)
				{
					grids[i, j] = new Label();
					grids[i, j].Width = _blockSize;
					grids[i, j].Height = _blockSize;
					grids[i, j].BackColor = Color.Black;
					grids[i, j].Left = 640 + _blockSize * j;
					grids[i, j].Top = 450 + i * _blockSize;
					grids[i, j].Visible = true;
					form.Controls.Add(grids[i, j]);
				}
			}
		}
		public void UpdateLevel(int level)
		{
			txtLevel.Text = level.ToString();
		}
	}
}
