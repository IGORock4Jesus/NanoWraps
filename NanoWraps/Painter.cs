using SharpDX;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NanoWraps
{
	public class Painter
	{
		private Renderer renderer;

		internal Painter(Renderer renderer)
		{
			this.renderer = renderer;
		}

		[Serializable]
		struct ColorVertex2
		{
			public float x, y, z, w;
			public uint color;
			public const VertexFormat FORMAT = VertexFormat.PositionRhw | VertexFormat.Diffuse;
			public static readonly int SIZE = Marshal.SizeOf(typeof(ColorVertex2));

			public ColorVertex2(float x, float y, float z, float w, uint color)
			{
				this.x = x;
				this.y = y;
				this.z = z;
				this.w = w;
				this.color = color;
			}
		};

		[Serializable]
		struct TextureVertex2

		{
			public float x, y, z, w;
			public float u, v;
			public const VertexFormat FORMAT = VertexFormat.PositionRhw | VertexFormat.Texture1;
			public static readonly int SIZE = Marshal.SizeOf(typeof(TextureVertex2));

			public TextureVertex2(float x, float y, float z, float w, float u, float v)
			{
				this.x = x;
				this.y = y;
				this.z = z;
				this.w = w;
				this.u = u;
				this.v = v;
			}
		};

		public void DrawRectangle(float x, float y, float w, float h, uint argb)
		{
			ColorVertex2[] vs = new[]{
				new ColorVertex2(x, y, 0, 1, argb),
				new ColorVertex2( x + w, y, 0, 1, argb),
				new ColorVertex2(x + w, y + h, 0, 1, argb),
				new ColorVertex2(x, y + h, 0, 1, argb)
			};
			renderer.Device.VertexFormat = ColorVertex2.FORMAT;
			renderer.Device.DrawUserPrimitives(PrimitiveType.TriangleFan, 0, 2, vs);
		}

		public void DrawRectangle(float x, float y, float w, float h, Texture texture, float xScale = 1.0f, float yScale = 1.0f)
		{
			TextureVertex2[] vs = new[]{
				new TextureVertex2(x, y, 0, 1, 0, 0),
				new TextureVertex2( x + w, y, 0, 1, 1, 0),
				new TextureVertex2(x + w, y + h, 0, 1, 1, 1),
				new TextureVertex2(x, y + h, 0, 1, 0, 1)
			};
			renderer.Device.VertexFormat = TextureVertex2.FORMAT;
			renderer.Device.SetTexture(0, texture);
			renderer.Device.DrawUserPrimitives(PrimitiveType.TriangleFan, 0, 2, vs);
		}

		public void DrawString(float x, float y, float w, float h, int fontSize, string text, string fontName, FontDrawFlags format = FontDrawFlags.Left | FontDrawFlags.Top)
		{
			using (Font font = new Font(renderer.Device, -fontSize, 0, FontWeight.Regular, 0, false, FontCharacterSet.Default, FontPrecision.TrueType, FontQuality.ClearType, FontPitchAndFamily.Default, fontName))
				font.DrawText(null, text, new RectangleF(x, y, w, h), format, Color.White);
		}
	}
}
