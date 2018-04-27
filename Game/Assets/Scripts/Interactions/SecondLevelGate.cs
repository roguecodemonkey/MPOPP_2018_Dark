using System;
using System.Collections.Generic;

namespace Interactions
{
	public class SecondLevelGate : Button
	{
		public override void StartInteracting()
		{
			if (GlobalSettings.GotFirstLevelKey)
				base.StartInteracting();
		}
	}
}
