using System;
using System.ComponentModel;
using System.Windows.Media.Imaging;
using Pro.Common.Components;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;
using Pro.ssAPI;

namespace Pro.Text;

public interface ITextFillMedia : INotifyPropertyChanged, ICloneable<ITextFillMedia>, IEquatable<ITextFillMedia>, IHasMediaContainerId, ICanReceiveMediaContainerIdUpdates
{
	BitmapSource? PreviewImage { get; }

	BitmapSource? FullSizeImage { get; }

	ScaleBehavior ScaleBehavior { get; }

	bool IsValid { get; }

	event Action<ITextFillMedia> TextFillDataModified;

	Media Serialize();

	void Deserialize(Media media);

	void UpdateValidity();

	void StartObservingSourceFile();

	void StopObservingSourceFile();

	void SerializeToEntity(IEntityFactory entityFactory, IMedia value);

	void DeserializeEntity(IMedia value);
}
