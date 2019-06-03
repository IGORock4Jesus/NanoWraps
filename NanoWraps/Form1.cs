using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NanoWraps
{
	public partial class Form1 : Form
	{
		private Renderer renderer;
		Painter painter;
		private ResourceManager resourceManager;
		private Thread thread;
		Scene scene;
		private bool enabled;
		GameStack gameStack;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			scene = new Scene();

			renderer = new Renderer(this);
			painter = new Painter(renderer);

			resourceManager = new ResourceManager(renderer.Device, @"..\..\Textures");

			gameStack = new GameStack(scene, resourceManager, this);
			gameStack.Push(new MainMenu.MainMenuFrame());

			enabled = true;
			thread = new Thread(StartUpdate);
			thread.Start();
		}

		private void StartUpdate()
		{
			gameStack.Enable = true;

			while (enabled)
			{
				if (renderer.Begin())
				{
					scene.Render(renderer.Device, painter);

					renderer.End();
				}
			}

			gameStack.Enable = false;
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			enabled = false;
			if (thread.IsAlive)
				thread.Join();

			resourceManager.Dispose();
			renderer.Dispose();
		}
	}
}
