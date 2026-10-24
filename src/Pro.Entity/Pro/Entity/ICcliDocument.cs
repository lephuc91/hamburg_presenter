using System;
using Pro.Entity.Properties;

namespace Pro.Entity;

public interface ICcliDocument : IEntity, IDisposable
{
	public class Types
	{
		public enum DisplayType
		{
			FirstSlide,
			LastSlide,
			FirstAndLastSlide,
			AllSlides
		}
	}

	IObservableProperty<bool> EnableCcliDisplay { get; }

	IObservableProperty<string> CcliLicense { get; }

	IObservableProperty<Types.DisplayType> DisplayType { get; }

	IComplexObservableProperty<ITemplate.Types.ISlide> Template { get; }

	IComplexObservableProperty<ICopyrightLayout> Layout { get; }
}
