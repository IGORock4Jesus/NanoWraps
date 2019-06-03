using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoWraps
{
	public class GameStackItem
	{
		public Scene Scene { get; private set; }
		public ResourceManager ResourceManager { get; private set; }
		public Form1 Form { get; private set; }



		public virtual bool Initialize() { return true; }
		public virtual void Release() { }
		public virtual void Suspend() { }
		public virtual void Resume() { }
		public virtual void Update(float deltaTime) { }

		internal void SetInterfaces(Scene scene, ResourceManager resourceManager, Form1 form)
		{
			Scene = scene;
			ResourceManager = resourceManager;
			Form = form;
		}
	}
}
