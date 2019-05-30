using SharpDX;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NanoWraps
{
	class Renderer : IDisposable
	{
		Direct3D direct;
		public Device Device { get; }
		public Renderer(Control control)
		{
			direct = new Direct3D();
			Device = new Device(direct, 0, DeviceType.Hardware, control.Handle,
				CreateFlags.HardwareVertexProcessing | CreateFlags.Multithreaded,
				new PresentParameters
				{
					AutoDepthStencilFormat = Format.D24S8,
					BackBufferCount = 1,
					BackBufferFormat = Format.X8R8G8B8,
					BackBufferHeight = control.Height,
					BackBufferWidth = control.Width,
					DeviceWindowHandle = control.Handle,
					EnableAutoDepthStencil = true,
					FullScreenRefreshRateInHz = 0,
					MultiSampleQuality = 0,
					MultiSampleType = MultisampleType.None,
					PresentationInterval = PresentInterval.Default,
					PresentFlags = PresentFlags.None,
					SwapEffect = SwapEffect.Discard,
					Windowed = true
				});
		}

		internal bool Begin()
		{
			Device.Clear(ClearFlags.All, Color.DarkGray, 1.0f, 0);
			Device.BeginScene();
			return true;
		}
		internal void End()
		{
			Device.EndScene();
			Device.Present();
		}

		public void Dispose()
		{
			if (Device != null) Device.Dispose();
			if (direct != null) direct.Dispose();
		}

	}
}
