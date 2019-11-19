using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Media;
using System.Linq;

namespace TetrisVideoGame
{
	public class TetrisGame : Form
	{
		private PlayFieldBoard _playboard;
		private NextShapeBoard _nextshapeboard;
		private GoalBoard _goalboard;
		private LevelBoard _levelboard;
		private ScoreBoard _scoreboard;
		private LineClearedBoard _lineboard;
		private PlayerBoard _playerboard;
		private HoldShapeBoard _holdshapeboard;
		private ColourBombBoard _colourbombboard;
		private HorizontalBombBoard _horizontalbombboard;
		private LargeBombBoard _largebombboard;
		private CollisionDetector _collisionDetector;
		private Player _player;
		private DataRecorder _recorder;
		private Random rander;
		private List<int> randomShapeNumber; 
		private Tetromino _tetromino;
		private Tetromino _nextTetromino;
		private Tetromino _holdTetromino;
		private int goal;
		private Timer GameTimer;
		private Timer BombMsgTimer;
		private const int time_interval = 1010;
		private Dictionary<int, Color> ColorDictionary;
		private GameOverWindows myGameOverForm;
		private PauseMenuWindows myPauseForm;
		private ConfirmationWindows myConfirmForm;
		private HelpWindows myHelpForm;
		private SoundPlayer BGMplayer;
		private BombMessageBox _myBombMsgBox;

		public TetrisGame(int blockSize, int columns, int rows, string playername)
		{
			this.MaximumSize = new Size(850, 850);
			ColorDictionary = new Dictionary<int, Color>();
			ColorDictionary.Add(1, Color.FromArgb(44, 209, 255)); // cyan
			ColorDictionary.Add(2, Color.FromArgb(255, 156, 35)); // orange
			ColorDictionary.Add(3, Color.FromArgb(255, 67, 92)); // red
			ColorDictionary.Add(4, Color.FromArgb(232, 76, 201)); //purple
			ColorDictionary.Add(5, Color.FromArgb(134, 234, 51)); //green
			ColorDictionary.Add(6, Color.FromArgb(255, 217, 59)); //yellow
			ColorDictionary.Add(7, Color.FromArgb(68, 124, 255)); //blue

			_playboard = new PlayFieldBoard(this, blockSize, columns, rows, ColorDictionary);
			_nextshapeboard = new NextShapeBoard(this, 30, 4, 5);
			_goalboard = new GoalBoard(this, 20, 6, 2);
			_levelboard = new LevelBoard(this, 20, 6, 2);
			_scoreboard = new ScoreBoard(this, 20, 6, 2);
			_lineboard = new LineClearedBoard(this, 20, 6, 2);
			_holdshapeboard = new HoldShapeBoard(this, 30, 4, 5);
			_colourbombboard = new ColourBombBoard(this, 20, 6, 4);
			_horizontalbombboard = new HorizontalBombBoard(this, 20, 6, 4);
			_largebombboard = new LargeBombBoard(this, 20, 6, 4);
			_playerboard = new PlayerBoard(this, 20, 0, 0);
			_player = new Player(playername);
			_playerboard.UpdatePlayerName(playername);
			_collisionDetector = new CollisionDetector();

			_recorder = new DataRecorder();

		    _myBombMsgBox = new BombMessageBox();
			_myBombMsgBox.ShowInTaskbar = false;
			_myBombMsgBox.BackColor = Color.FromArgb(240, 240, 240);
			_myBombMsgBox.Location = new Point(800, 430);
			_myBombMsgBox.StartPosition = FormStartPosition.Manual;
			_myBombMsgBox.FormBorderStyle = FormBorderStyle.None;
			_myBombMsgBox.Width = 300;
			_myBombMsgBox.Height = 60;
			_myBombMsgBox.Opacity = 0;
			_myBombMsgBox.Show();
			_myBombMsgBox.TopMost = true;


			init();
			_tetromino = NextShape();
			_nextTetromino = NextShape();
			_playboard.DrawShape(_tetromino);
			_playboard.DrawShadowGrids(this,_tetromino); // Shadow
			_nextshapeboard.DrawNextShape(_nextTetromino.TetromoniShape, _nextTetromino.ShapeColor);
			_holdTetromino = new Tetromino();

		}

		public void init()
		{
			Label message = new Label();
			message.Text = "Press ESC key to pause the game.";
			message.ForeColor = Color.Red;
			message.Font = new Font("Arial", 8, FontStyle.Bold);
			message.AutoSize = true;
			message.Left = 240;
			message.Top = 770;
			this.Controls.Add(message);

			BGMplayer = new SoundPlayer("bgm.wav");
			BGMplayer.PlayLooping();
			this.KeyDown += new KeyEventHandler(this.Form_KeyDown);
			this.KeyUp += new KeyEventHandler(this.Form_KeyUp);

			goal = _player.Level * 120 * _player.Level;
			_goalboard.UpdateGoal(goal);

			rander = new Random(System.DateTime.Now.Millisecond);
			randomShapeNumber = new List<int>();

			GameTimer = new Timer();
			GameTimer.Tick += new EventHandler(this.GameTimer_Tick);
			//time_interval = 1010; //speed of the block drop
			GameTimer.Interval = time_interval - (_player.Level * 70);
			GameTimer.Enabled = true;

			BombMsgTimer = new Timer();
			BombMsgTimer.Tick += new EventHandler(this.BombMsgTimer2_Tick);
			BombMsgTimer.Interval = 200;
		}



		private void Shuffle(List<int> list)
		{
			int n = list.Count;
			while (n > 1)
			{
				n--;
				int k = rander.Next(n+1);
				int value = list[k];
				list[k] = list[n];
				list[n] = value;
			}
		}


		private void GameTimer_Tick(object sender, EventArgs e)
		{
			
			if (!_collisionDetector.CheckCollision(_tetromino, _playboard, 0, 1))
			{
				_playboard.RemoveShape(_tetromino);
				_tetromino.PositionY += 1;
				_playboard.DrawShape(_tetromino);
				_playboard.DrawShadowGrids(this,_tetromino); // Shadow
			}
			else
			{
				if (CheckGameOver())
				{
					BGMplayer.Stop();
					GameTimer.Enabled = false;
					myGameOverForm = new GameOverWindows();
					myGameOverForm.BackColor = Color.FromArgb(240, 240, 240);
					myGameOverForm.StartPosition = FormStartPosition.CenterScreen;
					myGameOverForm.FormBorderStyle = FormBorderStyle.None;
					myGameOverForm.Text = "Game Over";
					myGameOverForm.Width = 450;
					myGameOverForm.Height = 180;
					_recorder.SaveData(_player);
					_recorder.RetrieveData();
 					if (myGameOverForm.ShowDialog() == DialogResult.OK)
					{
						RestartGame();
						myGameOverForm.Dispose();
					}
					else
					{
						var forms = Application.OpenForms.Cast<Form>().Where(x => x.Name == "MainScreen").FirstOrDefault();
						if (forms != null)
						{
							forms.Show();
							this.Dispose();
						}
					}

				}
				else 
				{
					_playboard.RemoveShape(_tetromino);
					_playboard.SaveIntoGrids(_tetromino);
					CheckClearLine();
					_playboard.DrawLandedBlocks();
					_tetromino = _nextTetromino;
					_nextTetromino = NextShape();
					_nextshapeboard.DrawNextShape(_nextTetromino.TetromoniShape, _nextTetromino.ShapeColor);
					_holdTetromino.Hold = false;
					_playboard.DrawShape(_tetromino);

				}
			}
		}

		private void BombMsgTimer2_Tick(object sender, EventArgs e)
		{
			_myBombMsgBox.Opacity -= 0.10;
			if (_myBombMsgBox.Opacity <= 0)
				BombMsgTimer.Enabled = false;
		}

		public void AddScore(int num)
		{
			_player.Score += (20 * num);
			_scoreboard.UpdateScore(_player.Score);

			if (_player.Score >= goal)
			{
				_player.Level += 1;
				_levelboard.UpdateLevel(_player.Level);

				goal = _player.Level * 120 * _player.Level;
				_goalboard.UpdateGoal(goal);

				if (_player.Level * 70 >= 900)
					GameTimer.Interval = 100;
				else
					GameTimer.Interval = time_interval - (_player.Level * 70);
				Console.WriteLine(GameTimer.Interval);
			}
		}
		public void CheckClearLine()
		{
			for (int i = 0; i < 20; ++i)
			{
				int sum = 0;
				for (int j = 0; j < 10; ++j)
				{
					if (_playboard.GridSigns[i,j] != 0)
					{
						sum += 1;
					}
				}
				if (sum == 10)
				{
					/*
					if (_playboard.Grids[i, 0].Text == "X")
					{
						for (int j = 0; j < 10; ++j)
						{
							_playboard.Grids[i, j].Text = "";
						}
					}*/
					for (int j = 0; j < 10; ++j)
					{
						_playboard.GridSigns[i, j] = 0;
					}
					for (int y = i; y > 0; --y)
					{
						for (int j = 0; j < 10; ++j)
						{
							_playboard.GridSigns[y, j] = _playboard.GridSigns[y - 1, j];
						}
					}
					_player.ClearedLines += 1;
					_lineboard.UpdateLineCleared(_player.ClearedLines);
					AddScore(1);
					GetBomb();
				}
			}
		}

		private void GetBomb()
		{

			int rand = rander.Next(1, 11);
			if (rand == 1)
			{
				int rand2 = rander.Next(1, 4);
				if (rand2 == 1)
				{
					int rand3 = rander.Next(1, 8);
					string color = "";
					if (rand3 == 1)
						color = "Cyan";
					else if (rand3 == 2)
						color = "Orange";
					else if (rand3 == 3)
						color = "Red";
					else if (rand3 == 4)
						color = "Purple";
					else if (rand3 == 5)
						color = "Green";
					else if (rand3 == 6)
						color = "Yellow";
					else if (rand3 == 7)
						color = "Blue";
					
					Color c = ColorDictionary[rand3];
					_player.ColourBombs.Quantity += 1;
					_player.ColourBombs.AddBombColor(c);
					_myBombMsgBox.UpdateMessage("You are obtain 1 "+color + " Bomb!");
					_myBombMsgBox.Opacity = 1;
					BombMsgTimer.Enabled = true;
					_colourbombboard.updateQuantity(_player.ColourBombs.Quantity);
					if(_colourbombboard.currentColor == Color.Black)
						_colourbombboard.updateBombPicture(c);
				}
				else if (rand2 == 2)
				{
					_player.HorizontalBombs.Quantity += 1;
					_myBombMsgBox.UpdateMessage("You are obtain 1 Horizontal Bomb!");
					_myBombMsgBox.Opacity = 1;
					BombMsgTimer.Enabled = true;
					_horizontalbombboard.updateQuantity(_player.HorizontalBombs.Quantity);
				}
				else if (rand2 == 3)
				{
					_player.LargeBombs.Quantity += 1;
					_myBombMsgBox.UpdateMessage("You are obtain 1 Large Bomb!");
					_myBombMsgBox.Opacity = 1;
					BombMsgTimer.Enabled = true;
					_largebombboard.updateQuantity(_player.LargeBombs.Quantity);
				}
			}
		}

		private void Form_KeyDown(object sender, KeyEventArgs e)
		{
			if (GameTimer.Enabled == true)
			{
				if (e.KeyCode == Keys.Left)
				{

					if (!_collisionDetector.CheckCollision(_tetromino, _playboard, -1, 0))
					{
						_playboard.RemoveShape(_tetromino); // remove the previous shape
						_tetromino.MoveLeft();
						_playboard.DrawShape(_tetromino); // draw a new shape
						_playboard.DrawShadowGrids(this, _tetromino); // Shadow
					}
				}
				else if (e.KeyCode == Keys.Right)
				{
					if (!_collisionDetector.CheckCollision(_tetromino, _playboard, 1, 0))
					{
						_playboard.RemoveShape(_tetromino);
						_tetromino.MoveRight();
						_playboard.DrawShape(_tetromino);
						_playboard.DrawShadowGrids(this, _tetromino); // Shadow
					}
				}
				else if (e.KeyCode == Keys.X)
				{
					_playboard.RemoveShape(_tetromino);
					int x = _tetromino.PositionX;
					int y = _tetromino.PositionY;
					_tetromino.leftRotation();
					if (_collisionDetector.CheckRotationCollision(_tetromino, _playboard))
					{
						_tetromino.changeBackRotation(x, y);
					}
					_playboard.DrawShape(_tetromino);
					_playboard.DrawShadowGrids(this, _tetromino); // Shadow

				}
				else if (e.KeyCode == Keys.Z)
				{
					_playboard.RemoveShape(_tetromino);
					int x = _tetromino.PositionX;
					int y = _tetromino.PositionY;
					_tetromino.rightRotation();
					if (_collisionDetector.CheckRotationCollision(_tetromino, _playboard))
					{
						_tetromino.changeBackRotation(x, y);
					}
					_playboard.DrawShape(_tetromino);
					_playboard.DrawShadowGrids(this, _tetromino); // Shadow

				}
				else if (e.KeyCode == Keys.Down)
				{
					if (_player.Level * 4 >= 45) // maximum drop speed
						GameTimer.Interval = 15;
					else
						GameTimer.Interval = 60 - (_player.Level * 4);
				}
				else if (e.KeyCode == Keys.ShiftKey)
				{
					if (!_holdTetromino.Hold)
					{
						if (_holdTetromino.ShapeColor.IsEmpty) // this means the shape holder no holds any shape.
						{
							_holdTetromino = _tetromino;
							_holdTetromino.Hold = true;

							//reset the attributes of holded shape
							_holdTetromino.PositionX = 4;
							_holdTetromino.PositionY = 0;
							_holdTetromino.resetRotation();
							_holdshapeboard.DrawHopeShape(_holdTetromino.TetromoniShape, _holdTetromino.ShapeColor);

							//assign current shape to next shape, next shape assign to new next shape

							_tetromino = _nextTetromino;
							_nextTetromino = NextShape();
							_playboard.DrawLandedBlocks();
							_nextshapeboard.DrawNextShape(_nextTetromino.TetromoniShape, _nextTetromino.ShapeColor);
						}
						else
						{
							Tetromino temp = _holdTetromino;
							_holdTetromino = _tetromino;
							_tetromino = temp;

							_holdTetromino.Hold = true;

							//reset the attributes of holded shape
							_holdTetromino.PositionX = 4;
							_holdTetromino.PositionY = 0;
							_holdTetromino.resetRotation();
							_holdshapeboard.DrawHopeShape(_holdTetromino.TetromoniShape, _holdTetromino.ShapeColor);

							//assign current shape to next shape, next shape assign to new next shape

							_playboard.DrawLandedBlocks();
						}
					}

				}
				else if (e.KeyCode == Keys.D1)
				{
					if (_player.ColourBombs.Quantity >= 1)
					{
						_player.ColourBombs.triggerBomb(_playboard.GridSigns); // check here
						AddScore(2);
						_playboard.DrawLandedBlocks();
						if (_player.ColourBombs.Quantity == 0)
						{
							_colourbombboard.updateBombPicture(Color.Black);
						}
						else
						{
							_colourbombboard.updateBombPicture(_player.ColourBombs.Colors[0]);
						}
						_colourbombboard.updateQuantity(_player.ColourBombs.Quantity);

					}
					else
					{
						_myBombMsgBox.UpdateMessage("You don't have any Colour Bomb!");
						_myBombMsgBox.Opacity = 1;
						BombMsgTimer.Enabled = true;
					}
				}
				else if (e.KeyCode == Keys.D2)
				{
					if (_player.HorizontalBombs.Quantity >= 1)
					{
						AddScore(1);
						_player.HorizontalBombs.triggerBomb(_playboard.GridSigns); // check here
						_playboard.DrawLandedBlocks();
						_horizontalbombboard.updateQuantity(_player.HorizontalBombs.Quantity);
					}
					else
					{
						_myBombMsgBox.UpdateMessage("You don't have any Horizontal Bomb!");
						_myBombMsgBox.Opacity = 1;
						BombMsgTimer.Enabled = true;
					}
				}
				else if (e.KeyCode == Keys.D3)
				{
					if (_player.LargeBombs.Quantity >= 1)
					{
						AddScore(5);
						_player.LargeBombs.triggerBomb(_playboard.GridSigns); // check here
						_playboard.DrawLandedBlocks();
						_largebombboard.updateQuantity(_player.LargeBombs.Quantity);
					}
					else
					{
						_myBombMsgBox.UpdateMessage("You don't have any Large Bomb!");
						_myBombMsgBox.Opacity = 1;
						BombMsgTimer.Enabled = true;
					}
				}
				else if (e.KeyCode == Keys.Space)
				{
					//_playboard.RemoveShape(_tetromino);
					_tetromino.PositionY += _collisionDetector.GetCollisionHeight(_tetromino, _playboard);
					_playboard.RemoveShape(_tetromino);
					_playboard.SaveIntoGrids(_tetromino);
					CheckClearLine();
					_playboard.DrawLandedBlocks();
					_tetromino = _nextTetromino;
					_nextTetromino = NextShape();
					_nextshapeboard.DrawNextShape(_nextTetromino.TetromoniShape, _nextTetromino.ShapeColor);
					_holdTetromino.Hold = false;
					_playboard.DrawShape(_tetromino);
					_playboard.DrawShadowGrids(this,_tetromino); // Shadow
				}
				else if (e.KeyCode == Keys.Escape)
				{
					GameTimer.Enabled = false;
					while (true)
					{
						myPauseForm = new PauseMenuWindows();
						myPauseForm.ShowInTaskbar = false;
						myPauseForm.BackColor = Color.FromArgb(240, 240, 240);
						myPauseForm.StartPosition = FormStartPosition.CenterScreen;
						myPauseForm.FormBorderStyle = FormBorderStyle.None;
						myPauseForm.Width = 300;
						myPauseForm.Height = 270;
						if (myPauseForm.ShowDialog() == DialogResult.OK)
						{
							GameTimer.Enabled = true;
							myPauseForm.Dispose();
							break;
						}
						else if (myPauseForm.DialogResult == DialogResult.No)
						{
							myHelpForm = new HelpWindows();
							myHelpForm.BackColor = Color.FromArgb(240, 240, 240);
							myHelpForm.StartPosition = FormStartPosition.CenterScreen;
							myHelpForm.FormBorderStyle = FormBorderStyle.None;
							myHelpForm.Name = "HelpDialog";
							myHelpForm.Width = 830;
							myHelpForm.Height = 600;
							if (myHelpForm.ShowDialog() == DialogResult.OK)
							{
								myHelpForm.Dispose();
							}
						}
						else
						{
							myConfirmForm = new ConfirmationWindows();
							myConfirmForm.ShowInTaskbar = false;
							myConfirmForm.BackColor = Color.FromArgb(240, 240, 240);
							myConfirmForm.StartPosition = FormStartPosition.CenterScreen;
							myConfirmForm.FormBorderStyle = FormBorderStyle.None;
							myConfirmForm.Width = 350;
							myConfirmForm.Height = 130;
							if (myConfirmForm.ShowDialog() == DialogResult.OK)
							{
								BGMplayer.Stop();
								var forms = Application.OpenForms.Cast<Form>().Where(x => x.Name == "MainScreen").FirstOrDefault();
								if (forms != null)
								{
									forms.Show();
									myPauseForm.Dispose();
									myConfirmForm.Dispose();
									this.Dispose();
									break;
								}
							}
							else
							{
								myConfirmForm.Dispose();
							}
						}
				
					}

				}
			}
		}

		private void Form_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				if (_player.Level * 70 >= 900) // maximum speed
					GameTimer.Interval = 100;
				else
					GameTimer.Interval = time_interval - (_player.Level * 70);// change the speed of block drop
			}
		}

		public Tetromino NextShape()
		{
			ShapeType type;
			if (randomShapeNumber.Count == 0)
			{
				for (int i = 1; i < 8; ++i)
				{
					randomShapeNumber.Add(i);
				}
				Shuffle(randomShapeNumber);
			}
			//type = (ShapeType)rander.Next(7)+1;
			type = (ShapeType)randomShapeNumber[0];
			randomShapeNumber.RemoveAt(0);

			return new Tetromino(type);
		}
		public bool CheckGameOver()
		{
			
			if (_collisionDetector.CheckCollision(_tetromino, _playboard, 0, 1) && _tetromino.PositionY == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public void RestartGame()
		{
			BGMplayer.PlayLooping();
			_playboard.ResetGridSign();
			_player.Score = 0;
			_scoreboard.UpdateScore(_player.Score);

			_player.Level = 1;
			_levelboard.UpdateLevel(_player.Level);

			_player.ClearedLines = 0;
			_lineboard.UpdateLineCleared(_player.ClearedLines);

			goal = _player.Level * 120 * _player.Level;
			_goalboard.UpdateGoal(goal);

			_playboard.DrawLandedBlocks();
			_tetromino = NextShape();
			_nextTetromino = NextShape();
			_playboard.DrawShape(_tetromino);
			_nextshapeboard.DrawNextShape(_nextTetromino.TetromoniShape, _nextTetromino.ShapeColor);
			GameTimer.Interval = time_interval - (_player.Level * 70);
			GameTimer.Enabled = true;
		}



		#region windows shadow effect
		private const int WM_NCHITTEST = 0x84;
		private const int HTCLIENT = 0x1;
		private const int HTCAPTION = 0x2;

		private bool m_aeroEnabled;

		private const int CS_DROPSHADOW = 0x00020000;
		private const int WM_NCPAINT = 0x0085;
		private const int WM_ACTIVATEAPP = 0x001C;

		[System.Runtime.InteropServices.DllImport("dwmapi.dll")]
		public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);
		[System.Runtime.InteropServices.DllImport("dwmapi.dll")]
		public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
		[System.Runtime.InteropServices.DllImport("dwmapi.dll")]

		public static extern int DwmIsCompositionEnabled(ref int pfEnabled);
		[System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
		private static extern IntPtr CreateRoundRectRgn(
			int nLeftRect,
			int nTopRect,
			int nRightRect,
			int nBottomRect,
			int nWidthEllipse,
			int nHeightEllipse
			);

		public struct MARGINS
		{
			public int leftWidth;
			public int rightWidth;
			public int topHeight;
			public int bottomHeight;
		}
		protected override CreateParams CreateParams
		{
			get
			{
				m_aeroEnabled = CheckAeroEnabled();
				CreateParams cp = base.CreateParams;
				if (!m_aeroEnabled)
					cp.ClassStyle |= CS_DROPSHADOW; return cp;
			}
		}
		private bool CheckAeroEnabled()
		{
			if (Environment.OSVersion.Version.Major >= 6)
			{
				int enabled = 0; DwmIsCompositionEnabled(ref enabled);
				return (enabled == 1) ? true : false;
			}
			return false;
		}
		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
				case WM_NCPAINT:
					if (m_aeroEnabled)
					{
						var v = 2;
						DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
						MARGINS margins = new MARGINS()
						{
							bottomHeight = 1,
							leftWidth = 0,
							rightWidth = 0,
							topHeight = 0
						}; DwmExtendFrameIntoClientArea(this.Handle, ref margins);
					}
					break;
				default: break;
			}
			base.WndProc(ref m);
			if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT) m.Result = (IntPtr)HTCAPTION;
		}
		#endregion

	}
}
