using SharpDX;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoWraps
{
	class GameObject
	{
		public string Name { get; set; }
		public Vector2 Position { get; set; }

		public virtual void Render(Device device, Painter painter)
		{

		}
	}
}
