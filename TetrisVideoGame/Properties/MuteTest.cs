using System;
using NUnit.Framework;
namespace TetrisVideoGame
{
	[TestFixture()]
	public class MuteTest
	{
		[Test()]
		public void MutingTest()
		{
			Assert.AreEqual(false, GlobalVariable.mute);
			SettingWindow.mute();
		}
	}
}
