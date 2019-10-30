using System;
using System.Windows.Forms;
using System.Drawing;

namespace TetrisVideoGame
{
	public class LineClearedBoard:Board
	{
		private Label txtLineCleared;
		private Label txtTitle;
		public LineClearedBoard(Form myboard, int blocksize, int col, int row) : base(blocksize, col, row)
		{
			initialize(myboard);
		}
		public override void initialize(Form form)
		{
			txtTitle = new Label();
			txtTitle.Text = "Line Cleared";
			txtTitle.ForeColor = Color.Black;
			txtTitle.Font = new Font("Arial", 13, FontStyle.Bold);
			txtTitle.AutoSize = true;
			txtTitle.Left = 640;
			txtTitle.Top = 620;
			form.Controls.Add(txtTitle);

			txtLineCleared = new Label();
			txtLineCleared.Text = "0";
			txtLineCleared.BackColor = Color.Black;
			txtLineCleared.ForeColor = Color.White;
			txtLineCleared.Font = new Font("Arial", 15, FontStyle.Bold);
			txtLineCleared.AutoSize = true;
			txtLineCleared.BringToFront();
			txtLineCleared.Left = 660;
			txtLineCleared.Top = 660;
			form.Controls.Add(txtLineCleared);

			for (int i = 0; i < _rows; ++i)
			{
				for (int j = 0; j < _columns; ++j)
				{
					grids[i, j] = new Label();
					grids[i, j].Width = _blockSize;
					grids[i, j].Height = _blockSize;
					grids[i, j].BackColor = Color.Black;
					grids[i, j].Left = 640 + _blockSize * j;
					grids[i, j].Top = 650 + i * _blockSize;
					grids[i, j].Visible = true;
					form.Controls.Add(grids[i, j]);
				}
			}
		}
		public void UpdateLineCleared(int line)
		{
			txtLineCleared.Text = line.ToString();
		}
	}
}
