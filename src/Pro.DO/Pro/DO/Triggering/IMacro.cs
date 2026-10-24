using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.DO.Application;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Triggering;

public interface IMacro : ICloneable<IMacro>, IIdentifiable, INotifyPropertyChanged
{
	new string Name { get; set; }

	System.Windows.Media.Color Color { get; set; }

	bool TriggerOnStartup { get; }

	ActionCollection Actions { get; }

	ImageType ImageType { get; set; }

	BitmapSource? Icon { get; set; }

	UndoStack? UndoStack { get; set; }

	bool IsValid { get; }

	event System.Action DataModified;

	void AddAction(IAction action, bool addMediaReferences = false);

	void AddActions(IEnumerable<IAction> actions, bool addMediaReferences = false);

	void InsertActions(IEnumerable<IAction> actions, int index, bool addMediaReferences = false);

	void RemoveAction(IAction action);

	void RemoveActions(IEnumerable<IAction> actions);

	MacrosDocument.Types.Macro Serialize();

	void Deserialize(MacrosDocument.Types.Macro protoMacro, ApplicationData applicationData);
}
