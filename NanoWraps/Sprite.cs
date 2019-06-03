using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using SharpDX.Direct3D9;

namespace NanoWraps
{
	class Sprite : GameObject
	{
		public Size2 Size { get; set; } = new Size2(100, 100);
		public Texture Texture { get; set; }
		public Size2 TextureSize { get; set; }
		public LayoutMethod LayoutMethod { get; set; }

		public override void Render(Device device, Painter painter)
		{
			switch (LayoutMethod)
			{
				case LayoutMethod.Stretch:
					painter.DrawRectangle(Position.X, Position.Y, Size.Width, Size.Height, Texture);
					break;
				case LayoutMethod.Repeat:
					for (int y = 0; y < Size.Height; y += TextureSize.Height)
					{
						for (int x = 0; x < Size.Width; x += TextureSize.Width)
						{
							painter.DrawRectangle(Position.X, Position.Y, Size.Width, Size.Height, Texture);
						}
					}
					break;
				case LayoutMethod.Mirror:
					break;
				default:
					break;
			}
		}
	}

	enum LayoutMethod
	{
		Stretch,
		Repeat,
		Mirror
	}
}
