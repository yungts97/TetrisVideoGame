using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TetrisVideoGame
{
	public class DataRecorder
	{
		string path = "player.json";

		public void SaveData(Player p)
		{
			List<Player> plyers = new List<Player>();
			plyers.Add(p);
			string JSONresult;
			if (File.Exists(path))
			{
				
				string result;
				using (var tr = new StreamReader(path))
				{
					result = tr.ReadToEnd();
					tr.Close();
				}
				File.Delete(path);
				List<Player> players = JsonConvert.DeserializeObject<List<Player>>(result);
				players.Add(p);
				JSONresult = JsonConvert.SerializeObject(players, Formatting.Indented);
				using (var tw = new StreamWriter(path, true))
				{
					tw.WriteLine(JSONresult);
					tw.Close();
				}
			}
			else
			{
				JSONresult = JsonConvert.SerializeObject(plyers, Formatting.Indented);
				using (var tw = new StreamWriter(path, true))
				{
					tw.WriteLine(JSONresult);
					tw.Close();
				}
			}

		}
		public List<Player> RetrieveData()
		{
			if (File.Exists(path))
			{
				string result;
				using (var tr = new StreamReader(path))
				{
					result = tr.ReadToEnd();
				}
				List<Player> players = JsonConvert.DeserializeObject<List<Player>>(result);
				return players;
			}
			else
			{
				return null;
			}
		}
	}
}
