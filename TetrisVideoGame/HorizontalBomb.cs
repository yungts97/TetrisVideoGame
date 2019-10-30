using System;
namespace TetrisVideoGame
{
	public class HorizontalBomb:Bomb
	{
		private int _targetRow;
		public HorizontalBomb(int q):base(q)
		{
			_targetRow = 19;
		}

		public int TargetRow
		{
			get { return _targetRow;}
			set { _targetRow = value;}
		}

		public override void triggerBomb(int[,] gridSigns)
		{
			for (int i = 20; i > 0; --i)
			{
				for (int j = 0; j < 10; ++j)
				{
					if (_targetRow >= i)
					{
						gridSigns[i,j] = gridSigns[i-1,j];
					}
				}
			}
			/*for (int a = 0; a < 20; ++a)
			{
				for (int b = 0; b < 10; ++b)
				{
					Console.Write(gridSigns[a, b] + " ");
					if (b == 9)
						Console.WriteLine();
				}
			}*/
			_quantity -= 1;
		}

	}
}
