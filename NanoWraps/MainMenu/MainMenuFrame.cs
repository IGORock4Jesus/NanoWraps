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
			// создаем фон
			ResourceManager.LoadTexture("background", "menu-back.png");
			Sprite sprite = new Sprite()
			{
				Name = "background",
				Texture = ResourceManager.GetTexture("background"),
				Position = new SharpDX.Vector2(0, 0),
				Size = new SharpDX.Vector2(Form.ClientSize.Width, Form.ClientSize.Height)
			};
			Scene.Add(sprite);

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
