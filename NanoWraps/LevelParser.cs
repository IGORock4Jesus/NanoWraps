using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoWraps
{
	class LevelParser
	{
		public List<Level> Levels { get; private set; }

		public void Open()
		{
			string path = @"Levels";
			var files = Directory.EnumerateFiles(path, "*.json");
			List<Level> levels = new List<Level>();

			foreach (var file in files)
			{
				levels.Add(JsonConvert.DeserializeObject<Level>(File.ReadAllText(file)));
			}

			this.Levels = levels;
		}
	}
}
