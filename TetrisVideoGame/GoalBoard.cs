using System;
using System.Windows.Forms;
using System.Drawing;

namespace TetrisVideoGame
{
	public class GoalBoard:Board
	{
		private Label txtGoal;
		private Label txtTitle;

		public GoalBoard(Form myboard, int blocksize, int col, int row):base(blocksize,col,row)
		{
			initialize(myboard);
		}
		public override void initialize(Form form)
		{
			txtTitle = new Label();
			txtTitle.Text = "Goal";
			txtTitle.ForeColor = Color.Black;
			txtTitle.Font = new Font("Arial", 13, FontStyle.Bold);
			txtTitle.AutoSize = true;
			txtTitle.Left = 640;
			txtTitle.Top = 320;
			form.Controls.Add(txtTitle);

			txtGoal = new Label();
			txtGoal.Text = "0";
			txtGoal.BackColor = Color.Black;
			txtGoal.ForeColor = Color.White;
			txtGoal.Font = new Font("Arial", 15, FontStyle.Bold);
			txtGoal.AutoSize = true;
			txtGoal.BringToFront();
			txtGoal.Left = 660;
			txtGoal.Top = 360;
			form.Controls.Add(txtGoal);

			for (int i = 0; i < _rows; ++i)
			{
				for (int j = 0; j < _columns; ++j)
				{
					grids[i, j] = new Label();
					grids[i, j].Width = _blockSize;
					grids[i, j].Height = _blockSize;
					grids[i, j].BackColor = Color.Black;
					grids[i, j].Left = 640 + _blockSize * j;
					grids[i, j].Top = 350 + i * _blockSize;
					grids[i, j].Visible = true;
					form.Controls.Add(grids[i, j]);
				}
			}
		}
		public void UpdateGoal(int goal)
		{
			txtGoal.Text = goal.ToString();
		}

	}
}
