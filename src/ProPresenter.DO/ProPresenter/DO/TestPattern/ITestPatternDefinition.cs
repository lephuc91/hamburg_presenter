using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media.Imaging;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.TestPattern.Properties;

namespace ProPresenter.DO.TestPattern;

public interface ITestPatternDefinition : INotifyPropertyChanged
{
	Guid ID { get; }

	string Name { get; }

	IEnumerable<ITestPatternProperty> Properties { get; }

	bool ShowDelaySettings { get; set; }

	BitmapSource? Thumbnail { get; set; }

	event System.Action DataModified;

	void Deserialize(Pro.SerializationInterop.RVProtoData.TestPatternDefinition protoTestPatternDefinition);

	Pro.SerializationInterop.RVProtoData.TestPatternDefinition Serialize();
}
