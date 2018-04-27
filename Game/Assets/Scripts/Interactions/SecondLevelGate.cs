using System;
using System.Collections.Generic;

namespace Interactions
{
	public class SecondLevelGate : Switch
	{
		public override void StartInteracting()
		{
			if (GlobalSettings.GotFirstLevelKey)
				base.StartInteracting();
		}
	}
}
