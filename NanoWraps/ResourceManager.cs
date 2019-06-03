using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoWraps
{
	public class ResourceManager : IDisposable
	{
		private readonly Device device;
		private readonly string texturePath;
		private Dictionary<string, Texture> textures = new Dictionary<string, Texture>();

		public ResourceManager(Device device, string texturePath)
		{
			this.device = device;
			this.texturePath = texturePath;
		}

		public void LoadTexture(string name, string filename)
		{
			string fn = Path.Combine(texturePath, filename);
			if (!File.Exists(fn))
				throw new ArgumentException($"Файл текстуры не найден: {fn}");
			var texture = Texture.FromFile(device, fn);
			textures[name] = texture;
		}

		public Texture GetTexture(string name)
		{
			return textures[name];
		}

		public void Dispose()
		{
			foreach (var texture in textures)
			{
				texture.Value.Dispose();
			}
		}
	}
}
