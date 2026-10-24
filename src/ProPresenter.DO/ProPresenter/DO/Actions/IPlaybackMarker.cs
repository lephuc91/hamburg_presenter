using System;
using System.ComponentModel;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Time;
using Pro.DO.Application;
using Pro.DO.Triggering;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Actions;

public interface IPlaybackMarker : INotifyPropertyChanged, IActionRepository, ICloneable<IPlaybackMarker>, IHasMediaContainerId, ICanReceiveMediaContainerIdUpdates
{
	Guid ID { get; }

	TimeSlice Timestamp { get; set; }

	TimeSlice VisualTimestamp { get; set; }

	System.Windows.Media.Color Color { get; set; }

	string Name { get; set; }

	UndoStack? UndoStack { get; set; }

	new INotifyEnumerableChanged<Pro.DO.Triggering.IAction> Actions { get; }

	event System.Action? DataModified;

	event System.Action? TimestampChanged;

	IPlaybackMarker CloneRelativeTo(TimeSlice inPoint, bool preserveID = false);

	void Deserialize(Pro.SerializationInterop.RVProtoData.Action.Types.MediaType.Types.PlaybackMarker protoMarker, ApplicationData? applicationData);

	Pro.SerializationInterop.RVProtoData.Action.Types.MediaType.Types.PlaybackMarker Serialize();

	IReadOnlyObjectBinder<IPlaybackMarker, Pro.Entity.IAction.Types.IMediaType.Types.IPlaybackMarker> Bind(IUiScheduler scheduler, IActionBinderFactory actionBinderFactory, IEntityFactory entityFactory, Pro.Entity.IAction.Types.IMediaType.Types.IPlaybackMarker right);
}
