using System;
using System.Drawing;
using System.Windows.Forms;

namespace TetrisVideoGame
{
	public class HoldShapeBoard:Board
	{
		private Label HoldShapeLabel;
		public HoldShapeBoard(Form myboard, int blocksize, int col, int row):base(blocksize,col,row)
		{
			initialize(myboard);
		}
		public override void initialize(Form form)
		{
			HoldShapeLabel = new Label();
			HoldShapeLabel.Text = "Hold Shape";
			HoldShapeLabel.Font = new Font("Arial", 13, FontStyle.Bold);
			HoldShapeLabel.AutoSize = true;
			HoldShapeLabel.Left = 80;
			HoldShapeLabel.Top = 120;
			form.Controls.Add(HoldShapeLabel);

			for (int i = 0; i < _rows; ++i)
			{
				for (int j = 0; j < _columns; ++j)
				{
					grids[i, j] = new Label();
					grids[i, j].Width = 30;
					grids[i, j].Height = 30;
					grids[i, j].BorderStyle = BorderStyle.FixedSingle;
					grids[i, j].BackColor = Color.Black;
					grids[i, j].Left = 80 + 30 * j;
					grids[i, j].Top = 150 + i * 30;
					grids[i, j].Visible = true;
					form.Controls.Add(grids[i, j]);
				}
			}
		}

		public void DrawHopeShape(int[,] shape, Color shapeColor)
		{
			for (int i = 0; i < _rows; ++i)
			{
				for (int j = 0; j < _columns; ++j)
				{
					grids[i, j].BackColor = Color.Black;
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
