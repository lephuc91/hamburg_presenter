using System;
using Pro.Entity.Properties;

namespace Pro.Entity;

public interface IAlignmentGuide : IEntity, IDisposable
{
	public class Types
	{
		public enum GuidelineOrientation
		{
			Horizontal,
			Vertical
		}
	}

	IObservableProperty<Guid> Uuid { get; }

	IObservableProperty<Types.GuidelineOrientation> Orientation { get; }

	IObservableProperty<double> Location { get; }
}
