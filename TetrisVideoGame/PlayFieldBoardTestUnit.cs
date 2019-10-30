using System;
using System.Collections.Generic;
using System.Drawing;
using NUnit.Framework;
using System.Windows.Forms;

namespace TetrisVideoGame
{
	[TestFixture]
	public class PlayFieldBoardTestUnit
	{
		[Test]
		public void TestSaveIntoGrid()
		{
			Dictionary<int, Color> ColorDictionary = new Dictionary<int, Color>();
			ColorDictionary.Add(1, Color.FromArgb(44, 209, 255)); // cyan
			ColorDictionary.Add(2, Color.FromArgb(255, 156, 35)); // orange
			ColorDictionary.Add(3, Color.FromArgb(255, 67, 92)); // red
			ColorDictionary.Add(4, Color.FromArgb(232, 76, 201)); //purple
			ColorDictionary.Add(5, Color.FromArgb(134, 234, 51)); //green
			ColorDictionary.Add(6, Color.FromArgb(255, 217, 59)); //yellow
			ColorDictionary.Add(7, Color.FromArgb(68, 124, 255)); //blue

			Form myform = new Form();

			Tetromino _tetromino = new Tetromino(ShapeType.O_Shape); //default x is 4 and y is 0;

			PlayFieldBoard myboard = new PlayFieldBoard(myform,30,10,20,ColorDictionary);
			myboard.SaveIntoGrids(_tetromino); // save the tetromino to the myboard.

			//expected grid signs value (6 is the shape of the O Shape with its position X and Y)
			int[,] expectedGrids = new int[20, 10]{{ 0,0,0,0,6,6,0,0,0,0 },
												   { 0,0,0,0,6,6,0,0,0,0 },
			              						   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 }};
			for (int i = 0; i < 20; ++i)
			{
				for (int j = 0; j < 10; ++j)
				{
					Assert.AreEqual(expectedGrids[i, j], myboard.GridSigns[i,j]); // check each block as one by one .
				}
			}

			int[,]expectedGrids2 = new int[20, 10]{{ 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 6,6,0,0,0,0,0,0,0,0 },
												   { 6,6,0,0,0,0,0,0,0,0 }};


			_tetromino.PositionX = 0; //change the tetromino postion X
			_tetromino.PositionY = 18; // change the tetromino position Y
			myboard.ResetGridSign(); // reset the previous value saved in the grid signs
			myboard.SaveIntoGrids(_tetromino); // save the tetromino to the myboard.

			for (int i = 0; i < 20; ++i)
			{
				for (int j = 0; j < 10; ++j)
				{
					Assert.AreEqual(expectedGrids2[i, j], myboard.GridSigns[i, j]); // check each block as one by one .
				}
			}

		}

		[Test]
		public void TestResetGridSigns()
		{
			Dictionary<int, Color> ColorDictionary = new Dictionary<int, Color>();
			ColorDictionary.Add(1, Color.FromArgb(44, 209, 255)); // cyan
			ColorDictionary.Add(2, Color.FromArgb(255, 156, 35)); // orange
			ColorDictionary.Add(3, Color.FromArgb(255, 67, 92)); // red
			ColorDictionary.Add(4, Color.FromArgb(232, 76, 201)); //purple
			ColorDictionary.Add(5, Color.FromArgb(134, 234, 51)); //green
			ColorDictionary.Add(6, Color.FromArgb(255, 217, 59)); //yellow
			ColorDictionary.Add(7, Color.FromArgb(68, 124, 255)); //blue

			Form myform = new Form();

			Tetromino _tetromino = new Tetromino(ShapeType.O_Shape); //default x is 4 and y is 0;

			PlayFieldBoard myboard = new PlayFieldBoard(myform, 30, 10, 20, ColorDictionary);
			myboard.SaveIntoGrids(_tetromino); // save the tetromino to the myboard.

			//expected grid signs value (6 is the shape of the O Shape with its position X and Y)
			int[,] expectedGrids = new int[20, 10]{{ 0,0,0,0,6,6,0,0,0,0 },
												   { 0,0,0,0,6,6,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 },
												   { 0,0,0,0,0,0,0,0,0,0 }};
			for (int i = 0; i < 20; ++i)
			{
				for (int j = 0; j < 10; ++j)
				{
					Assert.AreEqual(expectedGrids[i, j], myboard.GridSigns[i, j]); // check each block as one by one .
				}
			}

			myboard.ResetGridSign(); // reset all the gird sign and the value will become 0.
			for (int i = 0; i < 20; ++i)
			{
				for (int j = 0; j < 10; ++j)
				{
					Assert.AreEqual(0, myboard.GridSigns[i, j]); // check each block as one by one .
				}
			}

		}
	}
}
