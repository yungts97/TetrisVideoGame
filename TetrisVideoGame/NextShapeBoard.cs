using System;
using System.Windows.Forms;
using System.Drawing;

namespace TetrisVideoGame
{
	public class NextShapeBoard:Board
	{
		private Label NextShapeLabel;
		public NextShapeBoard(Form myboard, int blocksize, int col, int row) : base(blocksize, col, row)
		{
			initialize(myboard);
		}

		public override void initialize(Form form)
		{
			/*NextShapeLabel = new Label();
			NextShapeLabel.Text = "Next Shape";
			NextShapeLabel.Font = new Font("Arial", 13, FontStyle.Bold);
			NextShapeLabel.AutoSize = true;
			NextShapeLabel.Left = 640;
			NextShapeLabel.Top = 120;
			form.Controls.Add(NextShapeLabel);*/

			for (int i = 0; i < _rows; ++i)
			{
				for (int j = 0; j < _columns; ++j)
				{
					grids[i, j] = new Label();
					grids[i, j].Width = 30;
					grids[i, j].Height = 30;
					grids[i, j].BorderStyle = BorderStyle.FixedSingle;
					grids[i, j].BackColor = Color.FromArgb(51, 50, 50);
                    grids[i, j].Left = 661 + 30 * j;
					grids[i, j].Top = 267 + i * 30;
					grids[i, j].Visible = true;
					form.Controls.Add(grids[i, j]);
				}
			}
		}

		public void DrawNextShape(int[,] shape, Color shapeColor)
		{
			for (int i = 0; i < _rows; ++i)
			{
				for (int j = 0; j < _columns; ++j)
				{
					grids[i, j].BackColor = Color.FromArgb(51, 50, 50);
                }
			}
			for (int i = 0; i < shape.GetLength(0); ++i)
			{
				for (int j = 0; j < shape.GetLength(1); ++j)
				{
					if (shape[i, j] != 0)
					{
						grids[(1 + i), (1 + j)].BackColor = shapeColor;
						//Console.WriteLine((_nextTetromino.PositionY + i) + " " + (_nextTetromino.PositionX + j));
					}
				}
			}
		}
	}
}
