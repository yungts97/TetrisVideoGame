﻿using System;
using NUnit.Framework;

namespace TetrisVideoGame
{
	[TestFixture]
	public class HorizontalBombUnitTest
	{
		[Test]
		public void TestHorizontalBombTrigger()
		{
			HorizontalBomb myBomb = new HorizontalBomb(1);
			int[,] Gridsigns = new int[20, 10]{{ 0,0,0,0,0,0,0,0,0,0 },
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
												   { 4,0,5,0,0,0,0,0,0,0 },
												   { 4,4,5,1,1,3,3,0,0,0 },
												   { 4,4,5,1,1,1,3,7,7,0 }};

			int[,] expectedGrids = new int[20, 10]{{ 0,0,0,0,0,0,0,0,0,0 },
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
												   { 4,0,5,0,0,0,0,0,0,0 },
												   { 4,4,5,1,1,3,3,0,0,0 }};
			
			myBomb.triggerBomb(Gridsigns);
			for (int i = 0; i < 20; ++i)
			{
				for (int j = 0; j < 10; ++j)
				{
					Assert.AreEqual(expectedGrids[i, j], Gridsigns[i, j]);
				}
			}
		}
	}
}
