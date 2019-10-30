using System;
namespace TetrisVideoGame
{
	public class CollisionDetector
	{

		public bool CheckCollision(Tetromino _tetromino, PlayFieldBoard _playboard, int left_right, int down)
		{
			for (int i = 0; i < _tetromino.Height; ++i)
			{
				for (int j = 0; j < _tetromino.Width; ++j)
				{
					if (_tetromino.TetromoniShape[i, j] != 0) //check a block of the tetromino is whether exist.
					{
						//check the block is whether over the width of the playfield (left side)
						if (j + (_tetromino.PositionX + left_right) < 0)
						{
							return true;
						}
						//check the block is whether over the width of the playfield (right side)
						if (j + (_tetromino.PositionX + left_right) > 9)
						{
							return true;
						}
						//check the block is whether over the height of the playfield (top)
						if (i + (_tetromino.PositionY + down) > 19)
						{
							return true;
						}
						//check the block is whether collide the landed blocks.
						if (_playboard.GridSigns[i + (_tetromino.PositionY + down), j + (_tetromino.PositionX + left_right)] != 0)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		public int GetCollisionHeight(Tetromino _tetromino, PlayFieldBoard _playboard)
		{
			int down = 0;
			for (int a = 1; a <= 20-_tetromino.Height-_tetromino.PositionY; ++a)
			{
				bool flag = false;
				for (int i = 0; i < _tetromino.Height; ++i)
				{
					for (int j = 0; j < _tetromino.Width; ++j)
					{
						if (_tetromino.TetromoniShape[i, j] != 0) //check a block of the tetromino is whether exist.
						{
							if (_playboard.GridSigns[i + (_tetromino.PositionY + a), j + _tetromino.PositionX] != 0)
							{
								flag = true;
							}
						}
					}
				}
				if (flag)
					break;
				down = a;
			}

 			return down;
		}

		public bool CheckRotationCollision(Tetromino _tetromino, PlayFieldBoard _playboard)
		{
			for (int i = 0; i < _tetromino.Height; ++i)
			{
				for (int j = 0; j < _tetromino.Width; ++j)
				{
					if (_tetromino.TetromoniShape[i, j] != 0)
					{
						if (_playboard.GridSigns[i + _tetromino.PositionY, j + _tetromino.PositionX] != 0)
						{
							return true;
						}
					}
				}
			}
			return false;
		}
	}
}
