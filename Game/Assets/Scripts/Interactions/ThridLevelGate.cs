using System;
using System.Collections.Generic;

namespace Interactions
{
	public class ThirdLevelGate : Switch
	{
		public override void StartInteracting()
		{
			if (GlobalSettings.GotThirdLevelKey)
				base.StartInteracting();
		}
	}
}
