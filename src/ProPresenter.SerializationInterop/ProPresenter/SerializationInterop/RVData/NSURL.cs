using System;
using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class NSURL
{
	[Text]
	public Uri URL { get; set; }
}
