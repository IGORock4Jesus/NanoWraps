using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using SharpDX.Direct3D9;

namespace NanoWraps.MainMenu
{
	class LevelView : GameObject
	{
		public Vector2 Size { get; set; } = new Vector2(350, 75);
		public Level Level { get; private set; }


		public LevelView(Level level)
		{
			Level = level;
			Position = new Vector2(100, 100 * Level.Index);
		}

		public override void Render(Device device, Painter painter)
		{
			painter.DrawRectangle(Position.X, Position.Y, Size.X, Size.Y, 0xffff3030);

			if(Level != null)
			{
				painter.DrawString(Position.X, Position.Y, Size.X, Size.Y, 32, Level.Title, "Arial", FontDrawFlags.Center | FontDrawFlags.VerticalCenter);
			}
		}
	}
}
