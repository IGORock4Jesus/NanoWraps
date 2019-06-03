using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NanoWraps
{
	public class GameStack
	{
		readonly Stack<GameStackItem> items = new Stack<GameStackItem>();
		readonly Queue<GameStackItem> added = new Queue<GameStackItem>();
		private int pops;
		private bool enable;
		Thread thread;
		Scene scene;
		private ResourceManager resourceManager;
		Form1 form;

		public GameStack(Scene scene, ResourceManager resourceManager, Form1 form)
		{
			this.scene = scene;
			this.resourceManager = resourceManager;
			this.form = form;
		}

		public void Push(GameStackItem item)
		{
			added.Enqueue(item);
		}

		public void Pop()
		{
			pops++;
		}

		public bool Enable
		{
			get => enable;
			set
			{
				if (enable == value) return;

				if (enable = value)
				{
					thread = new Thread(Start);
					thread.Start();
				}
				else
				{
					if (thread.IsAlive)
						thread.Join();
				}
			}
		}

		public int Count => items.Count;

		private void Start()
		{
			var oldTime = Environment.TickCount;

			while (enable)
			{
				var newTime = Environment.TickCount;
				float deltaTime = (newTime - oldTime) * 0.001f;
				oldTime = newTime;

				if (added.Count != 0)
				{
					var item = added.Dequeue();

					if (items.Count != 0)
					{
						items.Peek().Suspend();
					}

					item.SetInterfaces(scene, resourceManager, form);
					if (item.Initialize())
					{
						items.Push(item);
					}
					else
						items.Peek().Resume();
				}
				else if (pops != 0)
				{
					if (items.Count != 0)
					{
						items.Pop().Release();

						if (items.Count != 0)
						{
							items.Peek().Resume();
						}
					}
				}

				if (items.Count != 0)
				{
					items.Peek().Update(deltaTime);
				}

				Thread.Sleep(1);
			}
		}
	}
}
