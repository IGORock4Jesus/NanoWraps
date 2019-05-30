using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoWraps.MainMenu
{
	class MainMenuFrame : GameStackItem
	{
		private LevelParser parser;

		public override bool Initialize()
		{
			parser = new LevelParser();
			parser.Open();


			foreach (var level in parser.Levels)
			{
				Scene.Add(new LevelView(level));
			}

			return true;
		}
	}
}
