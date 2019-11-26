using System;
using System.Windows.Forms;
using System.Drawing;

namespace TetrisVideoGame
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			MainWindows windows = new MainWindows();
			windows.StartPosition = FormStartPosition.CenterScreen;
			windows.FormBorderStyle = FormBorderStyle.None;
			windows.Text = "Main Screen";
			windows.Name = "MainScreen";
            windows.BackgroundImage = Image.FromFile("bg.png");
            windows.BackgroundImageLayout = ImageLayout.Stretch;
            windows.Visible = true;
			Application.Run(windows);
		}

	}
}
