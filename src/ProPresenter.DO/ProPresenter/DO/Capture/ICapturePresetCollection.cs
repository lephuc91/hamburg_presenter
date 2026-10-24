using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Google.Protobuf.Collections;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Capture;

public interface ICapturePresetCollection : INotifyEnumerableChanged<ICapturePreset>, IEnumerable<ICapturePreset>, IEnumerable, INotifyCollectionChanged, IReadOnlyCollection<ICapturePreset>
{
	UndoStack? UndoStack { get; set; }

	ICapturePresetFactory Factory { get; }

	event System.Action DataModified;

	event Action<ICapturePreset> PresetRenamed;

	void Clear();

	void AddPreset(ICapturePreset preset);

	void InsertPreset(ICapturePreset preset, int index);

	void RemovePreset(ICapturePreset preset);

	void Deserialize(RepeatedField<Recording.Types.Preset> protoPresets);

	IEnumerable<Recording.Types.Preset> Serialize();

	ICapturePreset Create();

	IReadOnlyObjectBinder<ICapturePresetCollection, IComplexCollection<IRecording.Types.IPreset>> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, IComplexCollection<IRecording.Types.IPreset> right);
}
