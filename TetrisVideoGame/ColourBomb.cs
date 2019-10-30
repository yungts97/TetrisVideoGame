using System;
using System.Collections.Generic;
using System.Drawing;

namespace TetrisVideoGame
{
	public class ColourBomb:Bomb
	{
		private readonly List<Color> _bombColor;
		private Dictionary<int, Color> _ColorDictionary;

		public ColourBomb(int q):base(q)
		{
			_bombColor = new List<Color>();
			_ColorDictionary = new Dictionary<int, Color>();
			_ColorDictionary.Add(1, Color.FromArgb(44, 209, 255)); // cyan
			_ColorDictionary.Add(2, Color.FromArgb(255, 156, 35)); // orange
			_ColorDictionary.Add(3, Color.FromArgb(255, 67, 92)); // red
			_ColorDictionary.Add(4, Color.FromArgb(232, 76, 201)); //purple
			_ColorDictionary.Add(5, Color.FromArgb(134, 234, 51)); //green
			_ColorDictionary.Add(6, Color.FromArgb(255, 217, 59)); //yellow
			_ColorDictionary.Add(7, Color.FromArgb(68, 124, 255)); //blue
		}

		public void AddBombColor(Color c)
		{
			_bombColor.Add(c);
		}
		public List<Color> Colors
		{
			get { return _bombColor;}
		}
		public override void triggerBomb(int[,] gridSigns)
		{
			int indexColor = 0;
			for (int x = 1; x <= _ColorDictionary.Count; ++x)
			{
				if (_ColorDictionary[x] == _bombColor[0])
				{
					indexColor = x;
				}
			}
			for (int i = 0; i < 10; ++i)
			{
				for (int j = 0; j < 20; ++j)
				{
					if (gridSigns[j, i] != 0 && gridSigns[j, i] == indexColor)
					{
						int[] tempGrid = new int[j];
						for (int x = 0; x < j; ++x)
						{
							tempGrid[x] = gridSigns[x, i];
							//MessageBox.Show(gridSigns[x, i].ToString());
						}
						gridSigns[j, i] = 0;
						for (int z = j; z > 0; --z)
						{
							gridSigns[z, i] = tempGrid[z - 1];
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
					}
				}
			}
			_quantity -= 1;
			_bombColor.RemoveAt(0);

		}

	}
}
