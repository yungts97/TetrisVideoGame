using System;
using System.Collections.Generic;
using System.Drawing;

namespace TetrisVideoGame
{
	public class Player
	{
		private string _name;
		private int _level;
		private int _clearedLines;
		private int _score;
		private readonly ColourBomb _myColourBombs;
		private readonly HorizontalBomb _myHorizontalBombs;
		private readonly LargeBomb _myLargeBombs;

		public Player(string name)
		{
			_name = name;
			_level = 1;
			_clearedLines = 0;
			_score = 0;
			_myColourBombs = new ColourBomb(0);
			_myHorizontalBombs = new HorizontalBomb(0);
			_myLargeBombs = new LargeBomb(0);

		}

		public string Name
		{
			set { _name = value;}
			get { return _name;}
		}

		public int Level
		{
			set { _level = value;}
			get { return _level;}
		}

		public int ClearedLines
		{
			set { _clearedLines = value; }
			get { return _clearedLines;}
		}

		public int Score
		{
			set { _score = value;}
			get { return _score;}
		}

		public ColourBomb ColourBombs
		{
			get { return _myColourBombs;}
		}
		public HorizontalBomb HorizontalBombs
		{
			get { return _myHorizontalBombs; }
		}
		public LargeBomb LargeBombs
		{
			get { return _myLargeBombs; }
		}
	}
}
