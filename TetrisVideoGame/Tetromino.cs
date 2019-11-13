using System;
using System.Drawing;
using System.Windows.Forms;

namespace TetrisVideoGame
{
	public class Tetromino
	{
		private int _posX;
		private int _posY;
		private Color _color;
		private ShapeType _type;
		private int _rotation;
		private int[,] _shape;
		private int _width;
		private int _height;
		private bool _isHold;

		public Tetromino()
		{
			_posX = 4;
			_posY = 0;
			_rotation = 0;
			_isHold = false;
		}
		public Tetromino(ShapeType t)
		{
			_posX = 4;
			_posY = 0;
			_type = t;
			_rotation = 0;
			_isHold = false;
			if (_type == ShapeType.I_Shape)
			{
				_shape = new int[4, 1] { {1},  // *
										 {1},  // *
										 {1},  // *
										 {1}}; // *
				_width = 1;
				_height = 4;
				_color = Color.FromArgb(44, 209, 255); // cyan
			}
			else if (_type == ShapeType.J_Shape)
			{
				_shape = new int[3, 2] { {0,1},  //  *
										{0,1},   //  *
										{1,1}};  // **
				_width = 2;
				_height = 3;
				_color = Color.FromArgb(68, 124, 255); // blue
			}
			else if (_type == ShapeType.L_Shape)
			{
				_shape = new int[3, 2] { {1,0},  // *
										 {1,0},  // *
										 {1,1}}; // **
				_width = 2;
				_height = 3;
				_color = Color.FromArgb(255, 156, 35); // orange
			}
			else if (_type == ShapeType.O_Shape)
			{
				_shape = new int[2, 2] { {1,1},   // **
										 {1,1}};  // **
				_width = 2;
				_height = 2;
				_color = Color.FromArgb(255, 217, 59); //yellow
			}
			else if (_type == ShapeType.S_Shape)
			{
				_shape = new int[3, 2] { {1,0},  // *
										{1,1},   // **
										{0,1}};  //  *
				_width = 2;
				_height = 3;
				_color = Color.FromArgb(134, 234, 51); // green
			}
			else if (_type == ShapeType.T_Shape)
			{
				_shape = new int[2, 3] { {1,1,1},  // ***
										 {0,1,0}}; //  *
				_width = 3;
				_height = 2;
				_color = Color.FromArgb(232, 76, 201); // purple
			}
			else if (_type == ShapeType.Z_Shape)
			{
				_shape = new int[2, 3] { {1,1,0},  // **
										 {0,1,1}}; //  **
				_width = 3;
				_height = 2;
				_color = Color.FromArgb(255, 67, 92); // red
			}
		}

		public int PositionX
		{
			get { return _posX;}
			set { _posX = value;}
		}
		public int PositionY
		{
			get { return _posY; }
			set { _posY = value; }
		}
		public Color ShapeColor
		{
			get { return _color;}
			set { _color = value;}
		}
		public ShapeType Type
		{
			get { return _type; }
			set { _type = value; }
		}
		public int Rotation
		{
			get { return _rotation; }
			set { _rotation = value; }
		}
		public bool Hold
		{
			get { return _isHold;}
			set { _isHold = value;}
		}
		public int[,] TetromoniShape
		{
			get { return _shape;}
		}
		public int Width
		{
			get { return _width; }
		}
		public int Height
		{
			get { return _height;}
		}
		public void MoveLeft()
		{
			if (_posX > 0)
			{
				_posX -= 1;
			}
		}
		public void MoveRight()
		{
			if (_posX >= 0 && _posX < 9)
			{
				//Console.WriteLine(_posX);
				_posX += 1;

			}
		}
		public void leftRotation()
		{
			_rotation += 90;
			if (_rotation == 360)
				_rotation = 0;
			_shape = setRotation(_type, _rotation);

			//for rotation collision 
			if (_posX + _width > 10)
				_posX = 10 - _width;
			if (_posY + _height > 20)
				_posY = 20 - _height;
		}
		public void rightRotation()
		{
			_rotation -= 90;
			if (_rotation == 360)
				_rotation = 0;
			if (_rotation == -90)
			{
				_rotation = 270;
			}
			_shape = setRotation(_type, _rotation);

			//for rotation collision 
			if (_posX + _width > 10)
				_posX = 10 - _width;
			if (_posY + _height > 20)
				_posY = 20 - _height;
		}
		public void resetRotation()
		{
			_rotation = 0;
			_shape = setRotation(_type, _rotation);
		}
		public void changeBackRotation(int x, int y)
		{
			if (_rotation != 0)
				_rotation -= 90;
			else
				_rotation = 270;
			_posX = x;
			_posY = y;
			_shape = setRotation(_type, _rotation);
			if (_posX + _width > 10)
				_posX = 10 - _width;
			if (_posY + _height > 20)
				_posY = 20 - _height;
		}
		public int[,] setRotation(ShapeType t, int rot)
		{
			int[,] newShape = new int[0, 0];
			switch ((int)t)
			{
				case 1: // I
					switch (rot)
					{
						case 0: 
							newShape = new int[4, 1] { {1},
														{1},
														{1},
														{1}};
							_width = 1;
							_height = 4;
							break;
						case 90:
							newShape = new int[1, 4] { { 1, 1, 1, 1 } };
							_width = 4;
							_height = 1;
							break;
						case 180:
							newShape = new int[4, 1] { {1},
														{1},
														{1},
														{1}};
							_width = 1;
							_height = 4;
							break;
						case 270:
							newShape = new int[1, 4] { { 1, 1, 1, 1 } };
							_width = 4;
							_height = 1;
							break;	
					}
					break;
				case 2: // L
					switch (rot) 
					{
						case 0:
							newShape = new int[3, 2] { {1,0},
														{1,0},
														{1,1}};
							_width = 2;
							_height = 3;
							break;
						case 90:
							newShape = new int[2, 3] { {1,1,1},
														{1,0,0}};
							_width = 3;
							_height = 2;
							break;
						case 180:
							newShape = new int[3, 2] { {1,1},
														{0,1},
														{0,1}};
							_width = 2;
							_height = 3;
							break;
						case 270:
							newShape = new int[2, 3] { { 0,0,1},
														{1,1,1}};
							_width = 3;
							_height = 2;
							break;
					}
					break;
				case 3: // Z
					switch (rot)
					{
						case 0:
							newShape = new int[2, 3] { {1,1,0},
														{0,1,1}};
							_width = 3;
							_height = 2;
							break;
						case 90:
							newShape = new int[3, 2] { { 0,1},
														{1,1},
														{1,0}};
							_width = 2;
							_height = 3;
							break;
						case 180:
							newShape = new int[2, 3] { {1,1,0},
														{0,1,1}};
							_width = 3;
							_height = 2;
							break;
						case 270:
							newShape = new int[3, 2] { { 0,1},
														{1,1},
														{1,0}};
							_width = 2;
							_height = 3;
							break;
					}
					break;
				case 4: // T
					switch (rot)
					{
						case 0:
							newShape = new int[2, 3] { {1,1,1},
														{0,1,0}};
							_width = 3;
							_height = 2;
							break;
						case 90:
							newShape = new int[3, 2] { { 0,1},
														{1,1},
														{0,1}};
							_width = 2;
							_height = 3;
							break;
						case 180:
							newShape = new int[2, 3] { {0,1,0},
														{1,1,1}};
							_width = 3;
							_height = 2;
							break;
						case 270:
							newShape = new int[3, 2] { { 1,0},
														{1,1},
														{1,0}};
							_width = 2;
							_height = 3;
							break;
					}
					break;
				case 5: // S
					switch (rot)
					{
						case 0:
							newShape = new int[3, 2] { { 1,0},
														{1,1},
														{0,1}};
							_width = 2;
							_height = 3;
							break;
						case 90:
							newShape = new int[2, 3] { {0,1,1},
														{1,1,0}};
							_width = 3;
							_height = 2;
							break;
						case 180:
							newShape = new int[3, 2] { { 1,0},
														{1,1},
														{0,1}};
							_width = 2;
							_height = 3;
							break;
						case 270:
							newShape = new int[2, 3] { {0,1,1},
														{1,1,0}};
							_width = 3;
							_height = 2;
							break;
					}
					break;
				case 6: // O
					switch (rot)
					{
						case 0:
							newShape = new int[2, 2] { { 1,1},
														{1,1}};
							_width = 2;
							_height = 2;
							break;
						case 90:
							newShape = new int[2, 2] { { 1,1},
														{1,1}};
							_width = 2;
							_height = 2;
							break;
						case 180:
							newShape = new int[2, 2] { { 1,1},
														{1,1}};
							_width = 2;
							_height = 2;
							break;
						case 270:
							newShape = new int[2, 2] { { 1,1},
														{1,1}};
							_width = 2;
							_height = 2;
							break;
					}
					break;	
				case 7: // J
					switch (rot)
					{
						case 0:
							newShape = new int[3, 2] { {0,1},
														{0,1},
														{1,1}};
							_width = 2;
							_height = 3;
							break;
						case 90:
							newShape = new int[2, 3] { {1,0,0},
														{1,1,1}};
							_width = 3;
							_height = 2;
							break;
						case 180:
							newShape = new int[3, 2] { {1,1},
														{1,0},
														{1,0}};
							_width = 2;
							_height = 3;
							break;
						case 270:
							newShape = new int[2, 3] { { 1,1,1},
														{0,0,1}};
							_width = 3;
							_height = 2;
							break;
					}
					break;
			}
			return newShape;
		}
	}
}
