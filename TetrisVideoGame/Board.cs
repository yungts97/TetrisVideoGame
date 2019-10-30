using System;
using System.Windows.Forms;
using System.Drawing;

namespace TetrisVideoGame
{
	public abstract class Board
	{
		protected Label[,] grids;
		protected int _blockSize;
		protected int _columns;
		protected int _rows;
		 
		public Board(int blockSize, int col, int row)
		{
			_blockSize = blockSize;
			_columns = col;
			_rows = row;
			grids = new Label[row, col];
		}

		public abstract void initialize(Form form);

		public Label[,] Grids
		{
			get { return grids;}
		}


	}
}
