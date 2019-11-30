using System;
using System.Windows.Forms;
using System.Drawing;

namespace TetrisVideoGame
{
	public class LargeBombBoard:Board
	{
		private Label txtTitle;
		private Label txtQty;
		private PictureBox picBomb;

		public LargeBombBoard(Form myform, int blocksize, int col, int row) : base(blocksize, col, row)
		{
			initialize(myform);
		}

		public override void initialize(Form form)
		{
			/*txtTitle = new Label();
			txtTitle.Text = "Large Bomb";
			txtTitle.ForeColor = Color.Black;
			txtTitle.Font = new Font("Arial", 11, FontStyle.Bold);
			txtTitle.AutoSize = true;
			txtTitle.Left = 80;
			txtTitle.Top = 610;
			form.Controls.Add(txtTitle);*/

			txtQty = new Label();
			txtQty.Text = "x 0";
			txtQty.ForeColor = Color.White;
			txtQty.BackColor = Color.Transparent;
			txtQty.Font = new Font("Arial", 12, FontStyle.Bold);
			txtQty.AutoSize = true;
			txtQty.Left = 236;
			txtQty.Top = 737;
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
					grids[i, j].Top = 640 + i * _blockSize;
					grids[i, j].Visible = true;
					form.Controls.Add(grids[i, j]);
				}
			}*/

			/*picBomb = new PictureBox();
			picBomb.Size = new Size(40, 40);
			picBomb.SizeMode = PictureBoxSizeMode.StretchImage;
			picBomb.BackColor = Color.Black;
			picBomb.Image = Image.FromFile("largeBomb.png");
			picBomb.Top = 660;
			picBomb.Left = 120;
			form.Controls.Add(picBomb);
			picBomb.BringToFront();*/
		}

		public void updateQuantity(int qty)
		{
			txtQty.Text = "x " + qty.ToString();
		}

	}
}
