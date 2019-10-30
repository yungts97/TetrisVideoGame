using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TetrisVideoGame
{
	public class PlayFieldBoard:Board
	{
		private int[,] gridSigns;
		private Label[] shadowBlocks;
		private Panel bg;
		private Dictionary<int, Color> _ColorDictionary;
		private Color shadowColor;
		private bool[,] shadowGrids;

		public PlayFieldBoard(Form myboard, int blocksize, int col, int row, Dictionary<int, Color> ColorDictionary):base(blocksize,col,row)
		{
			shadowGrids = new bool[row, col];
			shadowBlocks = new Label[4];
			for (int i = 0; i < row; ++i)
			{
				for (int j = 0; j < col; ++j)
				{
					shadowGrids[i, j] = false;
				}
			}
			_ColorDictionary = ColorDictionary;
			gridSigns = new int[row, col];
			ResetGridSign();

			initialize(myboard);
		}
		public override void initialize(Form form)
		{
			form.FormBorderStyle = FormBorderStyle.None;

			for (int i = 0; i < _rows; ++i)
			{
				for (int j = 0; j < _columns; ++j)
				{
					grids[i, j] = new Label();
					grids[i, j].Width = _blockSize;
					grids[i, j].Height = _blockSize;
					grids[i, j].BorderStyle = BorderStyle.FixedSingle;
					grids[i, j].BackColor = Color.Black;
					grids[i, j].Left = 270 + _blockSize * j;
					grids[i, j].Top = 130 + i * _blockSize;
					grids[i, j].Visible = true;
					//grids[i, j].Paint += new PaintEventHandler(grids_Paint);
					form.Controls.Add(grids[i, j]);
				}
			}

			bg = new Panel();
			bg.BackColor = Color.FromArgb(72,72,72);
			bg.Width = 360;
			bg.Height = 660;
			bg.Left = 240;
			bg.Top = 100;
			bg.Visible = true;
			form.Controls.Add(bg);

		}

		public void DrawLandedBlocks() // to redraw the landed blocks in the playfield
		{
			for (int i = 0; i < _rows; ++i)   // clean the previous blocks
			{
				for (int j = 0; j < _columns; ++j)
				{
					grids[i, j].BackColor = Color.Black;

				}
			}
			for (int i = 0; i < _rows; ++i)  // draw the current landed blocks
			{
				for (int j = 0; j < _columns; ++j)
				{
					if (gridSigns[i, j] != 0)
					{
						grids[i, j].BackColor = _ColorDictionary[gridSigns[i, j]];
					}
				}
			}
		}
		public void SaveIntoGrids(Tetromino _tetromino) // to record the blocks those has been landed in the playfield
		{
			for (int i = 0; i < _tetromino.Height; ++i)
			{
				for (int j = 0; j < _tetromino.Width; ++j)
				{
					if (_tetromino.TetromoniShape[i, j] != 0)
					{
						gridSigns[i + _tetromino.PositionY, j + _tetromino.PositionX] = (int)_tetromino.Type;
					}
				}
			}
		}
		public void DrawShape(Tetromino _tetromino) // draw a new tetromino (any changes of the tetromino will call this function)
		{
			for (int i = 0; i < _tetromino.Height; ++i)
			{
				for (int j = 0; j < _tetromino.Width; ++j)
				{
					if (_tetromino.TetromoniShape[i, j] != 0)
					{
						grids[(_tetromino.PositionY + i), (_tetromino.PositionX + j)].BackColor = _tetromino.ShapeColor;
					}
				}
			}
		}
		public void RemoveShape(Tetromino _tetromino) // remove the old tetromino (any changes of the tetromino will call this function)
		{
			for (int i = 0; i < _tetromino.Height; ++i)
			{
				for (int j = 0; j < _tetromino.Width; ++j)
				{
					if (_tetromino.TetromoniShape[i, j] != 0)
					{
						grids[(_tetromino.PositionY + i), (_tetromino.PositionX + j)].BackColor = Color.Black;
					}
				}
			}
		}

		private void grids_Paint(object sender, PaintEventArgs e) // this is for the tetromino shadow  
		{
			
			ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, shadowColor, ButtonBorderStyle.Solid);
		}

		public void DrawShadowGrids(Form form,Tetromino _tetromino) // this is draw the tetromino shadow
		{
			shadowColor = _tetromino.ShapeColor;

			for (int i = 0; i < 20; ++i)
			{
				for (int j = 0; j < 10; ++j)
				{
					shadowGrids[i, j] = false;
				}
			}
			for (int i = 0; i < 4; ++i)
			{
				form.Controls.Remove(shadowBlocks[i]);
			}

			CollisionDetector collisionDetector = new CollisionDetector();
			int collidedY = 1;
			int tempPosY = _tetromino.PositionY;
			while (!collisionDetector.CheckCollision(_tetromino,this,0, collidedY))
			{
				++collidedY;
			}
			collidedY = collidedY + _tetromino.PositionY -1;

			for (int i = 0; i < _tetromino.Height; ++i)
			{
				for (int j = 0; j < _tetromino.Width; ++j)
				{
					if (_tetromino.TetromoniShape[i, j] != 0)
					{
						shadowGrids[(collidedY + i), (_tetromino.PositionX + j)] = true;
					}
				}
			}

			int c = 0;
			for (int a = 0; a < 20; ++a)
			{
				for (int b = 0; b < 10; ++b)
				{
					if (shadowGrids[a, b])
					{
						
						//Console.Write("1 ");
						shadowBlocks[c] = new Label();
						shadowBlocks[c].Width = _blockSize;
						shadowBlocks[c].Height = _blockSize;
						shadowBlocks[c].BorderStyle = BorderStyle.FixedSingle;
						shadowBlocks[c].BackColor = Color.Black;
						shadowBlocks[c].Left = 270 + _blockSize * b;
						shadowBlocks[c].Top = 130 + a * _blockSize;
						shadowBlocks[c].Paint += new PaintEventHandler(grids_Paint);
						form.Controls.Add(shadowBlocks[c]);
						if ((_tetromino.PositionY+_tetromino.Height-1) < a)
							shadowBlocks[c].BringToFront();
						/*else
							Console.WriteLine("tocuhed " + a + " Y:" + _tetromino.PositionY);*/
						++c;
					}
					/*if (b == 9)
						Console.WriteLine();*/
				}
			}

		}


		public int[,] GridSigns
		{
			get { return gridSigns; }
		}

		public void ResetGridSign() // clean the all grid signs
		{
			Array.Clear(gridSigns, 0, gridSigns.Length);
		}
	}
}
