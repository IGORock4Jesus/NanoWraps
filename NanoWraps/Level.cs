using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoWraps
{
	public class Level
	{
		public int Index { get; set; }
		public string Title { get; set; }
		public bool Locked { get; set; }

		public override string ToString()
		{
			return Title;
		}
	}
}
