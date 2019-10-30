using System;
namespace TetrisVideoGame
{
	public class LargeBomb:Bomb
	{
		private int _targetRow;
		public LargeBomb(int q):base(q)
		{
			_targetRow = 15;
		}

		public int TargetRow
		{
			get { return _targetRow; }
			set { _targetRow = value; }
		}

		public override void triggerBomb(int[,] gridSigns)
		{
			for (int i = 19; i > 0; --i)
			{
				for (int j = 0; j < 10; ++j)
				{
					if (i - _targetRow >= 0)
					{
						gridSigns[i, j] = 0;
					}
					if(i -5 >= 0)
						gridSigns[i, j] = gridSigns[i - 5, j];
				}
			}
			_quantity -= 1;
		}
	}
}
