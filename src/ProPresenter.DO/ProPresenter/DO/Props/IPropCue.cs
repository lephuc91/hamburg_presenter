using System;
using System.ComponentModel;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.DO.Application;
using Pro.DO.Triggering;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.DependencyInjection;

namespace ProPresenter.DO.Props;

public interface IPropCue : INotifyPropertyChanged, ICloneable<IPropCue>, ITriggerable, IIdentifiable
{
	Guid ParentCollectionID { get; set; }

	string ParentCollectionName { get; set; }

	ActionCollection Actions { get; }

	PropSlideAction? SlideAction { get; }

	UndoStack? UndoStack { get; set; }

	event Action<Pro.DO.Triggering.Cue>? DataModified;

	void ChangeSize(Vector2<double> size);

	Pro.SerializationInterop.RVProtoData.Cue Serialize();

	void Deserialize(Pro.SerializationInterop.RVProtoData.Cue cue, ApplicationData? applicationData, string containerId);

	IReadOnlyObjectBinder<IPropCue, ICue> Bind(IUiScheduler scheduler, IProPresenterDOFactoryProvider factoryProvider, ICue entity);
}
