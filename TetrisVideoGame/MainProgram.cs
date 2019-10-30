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
			windows.Width = 420;
			windows.Height = 680;
			windows.Visible = true;
			Application.Run(windows);
		}

	}
}
