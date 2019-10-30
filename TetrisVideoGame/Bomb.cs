using System;
using System.Collections.Generic;
using System.Drawing;

namespace TetrisVideoGame
{
	public abstract class Bomb
	{
		protected int _quantity;

		public Bomb() : this(0) { }

		public Bomb(int q)
		{
			_quantity = q;
		}

		public int Quantity
		{
			get { return _quantity; }
			set { _quantity = value; }
		}
		public abstract void triggerBomb(int[,] gridSigns);
	}
}
