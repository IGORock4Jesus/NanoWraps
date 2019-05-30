using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NanoWraps.MainMenu;
using SharpDX.Direct3D9;

namespace NanoWraps
{
	public class Scene
	{
		private readonly List<GameObject> objects = new List<GameObject>();

		internal void Render(Device device, Painter painter)
		{
			foreach (var @object in objects)
			{
				@object.Render(device, painter);
			}
		}

		internal void Add(GameObject gameObject)
		{
			objects.Add(gameObject);
		}
	}
}
