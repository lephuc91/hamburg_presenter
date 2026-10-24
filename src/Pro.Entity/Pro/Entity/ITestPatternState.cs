using System;

namespace Pro.Entity;

public interface ITestPatternState : IEntity, IDisposable
{
	public class Types
	{
		public enum DisplayLocation
		{
			AllScreens,
			AudienceScreens,
			StageScreens,
			SpecificScreen
		}
	}
}
