using System;
using System.Windows.Forms;
using System.Drawing;

namespace TetrisVideoGame
{
	public class ColourBombBoard: Board
	{
		private Label txtTitle;
		private Label txtQty;
		private Color _currentColor;
		private PictureBox picBomb;

		public ColourBombBoard(Form myform, int blocksize, int col, int row):base(blocksize,col,row)
		{
			_currentColor = Color.Black;
			initialize(myform);
		}
		public override void initialize(Form form)
		{
			/*txtTitle = new Label();
			txtTitle.Text = "Colour Bomb";
			txtTitle.ForeColor = Color.Black;
			txtTitle.Font = new Font("Arial", 11, FontStyle.Bold);
			txtTitle.AutoSize = true;
			txtTitle.Left = 80;
			txtTitle.Top = 330;
			form.Controls.Add(txtTitle);*/

			txtQty = new Label();
			txtQty.Text = "x 0";
			txtQty.ForeColor = Color.White;
			txtQty.BackColor = Color.Transparent;
			txtQty.Font = new Font("Arial", 12, FontStyle.Bold);
			txtQty.AutoSize = true;
			txtQty.Left = 236;
			txtQty.Top = 529;
			form.Controls.Add(txtQty);

			/*for (int i = 0; i < _rows; ++i)
			{
				for (int j = 0; j < _columns; ++j)
				{
					grids[i, j] = new Label();
					grids[i, j].Width = _blockSize;
					grids[i, j].Height = _blockSize;
					grids[i, j].BackColor = Color.Black;
					grids[i, j].Left = 80 + _blockSize * j;
					grids[i, j].Top = 360 + i * _blockSize;
					grids[i, j].Visible = true;
					form.Controls.Add(grids[i, j]);
				}
			}*/

			picBomb = new PictureBox();
			picBomb.Size = new Size(32, 32);
			picBomb.SizeMode = PictureBoxSizeMode.StretchImage;
			picBomb.BackColor = Color.Transparent;
			picBomb.Image = Image.FromFile("bomb.png");
			picBomb.Top = 522;
			picBomb.Left = 160;
			form.Controls.Add(picBomb);
			picBomb.BringToFront();
		}
		public Color currentColor
		{
			get { return _currentColor;}
		}
		public void updateQuantity(int qty)
		{
			txtQty.Text = "x " + qty.ToString();
		}
		public void updateBombPicture(Color c)
		{
			_currentColor = c;
	
			if (c == Color.FromArgb(44, 209, 255))
			{
				picBomb.Image = Image.FromFile("bomb(cyan).png");
			}
			else if (c == Color.FromArgb(255, 156, 35))
			{
				picBomb.Image = Image.FromFile("bomb(orange).png");
			}
			else if (c == Color.FromArgb(134, 234, 51))
			{
				picBomb.Image = Image.FromFile("bomb(green).png");
			}
			else if (c == Color.FromArgb(255, 217, 59))
			{
				picBomb.Image = Image.FromFile("bomb(yellow).png");
			}
			else if (c == Color.FromArgb(68, 124, 255))
			{
				picBomb.Image = Image.FromFile("bomb(blue).png");
			}
			else if (c == Color.FromArgb(255, 67, 92))
			{
				picBomb.Image = Image.FromFile("bomb(red).png");
			}
			else if (c == Color.FromArgb(232, 76, 201))
			{
				picBomb.Image = Image.FromFile("bomb(purple).png");
			}
			else
			{
				picBomb.Image = Image.FromFile("bomb.png");
			}
		}
	}
}
