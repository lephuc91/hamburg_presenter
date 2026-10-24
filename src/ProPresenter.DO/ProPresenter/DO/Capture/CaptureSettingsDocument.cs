using System;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Capture;

public class CaptureSettingsDocument : NotifyPropertyChangedBase, ICaptureSettingsDocument, INotifyPropertyChanged
{
	private ICapturePreset? _activePreset;

	private readonly IStreamFactory _streamFactory;

	public IStreamCollection Streams { get; }

	public ICapturePresetCollection Presets { get; }

	public IStream? DefaultStream
	{
		get
		{
			if (!Streams.Any())
			{
				Streams.AddStream(_streamFactory.CreateStream());
			}
			return Streams.FirstOrDefault();
		}
	}

	public ICapturePreset? ActivePreset
	{
		get
		{
			return _activePreset;
		}
		set
		{
			SetValue<ICapturePreset>("ActivePreset", ref _activePreset, value, delegate(ICapturePreset o, ICapturePreset n)
			{
				if (o != null)
				{
					o.DataModified -= OnDataModified;
				}
				if (n != null)
				{
					n.DataModified += OnDataModified;
				}
				OnDataModified();
				Streams.Clear();
				n?.Streams.ForEach(delegate(IStream s)
				{
					Streams.AddStream(s.Clone());
				});
			});
		}
	}

	public UndoStack UndoStack { get; } = new UndoStack();

	public event System.Action? DataModified;

	public static ObjectBinder<ICaptureSettingsDocument, IRecording.Types.ISettingsDocument> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, ICaptureSettingsDocument left, IRecording.Types.ISettingsDocument right)
	{
		IReadOnlyObjectBinder<ICapturePresetCollection, IComplexCollection<IRecording.Types.IPreset>> presetsBinder = left.Presets.CreateBinder(scheduler, entityFactory, right.Presets);
		ObjectBinder<ICaptureSettingsDocument, IRecording.Types.ISettingsDocument> objectBinder = new ObjectBinder<ICaptureSettingsDocument, IRecording.Types.ISettingsDocument>(left, right);
		objectBinder.Bind((ICaptureSettingsDocument l) => l.WhenPropertyChanges("ActivePreset"), (IRecording.Types.ISettingsDocument r) => r.ActivePreset.WhenValueChanges, delegate(ICaptureSettingsDocument l, IRecording.Types.ISettingsDocument r)
		{
			if (l.ActivePreset != null)
			{
				IRecording.Types.IPreset preset = entityFactory.Create<IRecording.Types.IPreset>();
				r.ActivePreset.Set(preset);
				ObjectBinder<ICapturePreset, IRecording.Types.IPreset> objectBinder2 = CapturePreset.CreateBinder(scheduler, entityFactory, l.ActivePreset, preset);
				objectBinder2.InitializeRightFromLeft();
				preset.RegisterLinkedDisposable(objectBinder2);
			}
			else
			{
				r.ActivePreset.Set(null);
			}
		}, delegate(IRecording.Types.ISettingsDocument r, ICaptureSettingsDocument l)
		{
			if (r.ActivePreset.Value != null)
			{
				ICapturePreset capturePreset = l.Presets.FirstOrDefaultBy((ICapturePreset p) => p.ID == r.ActivePreset.Value.Id.Value, (ICapturePreset p) => p.Name == r.ActivePreset.Value.Name.Value);
				if (capturePreset != null)
				{
					l.ActivePreset = capturePreset;
					ObjectBinder<ICapturePreset, IRecording.Types.IPreset> objectBinder3 = CapturePreset.CreateBinder(scheduler, entityFactory, l.ActivePreset, r.ActivePreset.Value);
					objectBinder3.InitializeLeftFromRight();
					r.ActivePreset.Value.RegisterLinkedDisposable(objectBinder3);
				}
				else
				{
					l.ActivePreset = null;
				}
			}
			else
			{
				l.ActivePreset = null;
			}
		}).DoOnInitializeLeftFromRight(presetsBinder.InitializeLeftFromRight).DoOnInitializeRightFromLeft(presetsBinder.InitializeRightFromLeft)
			.RegisterChildDisposable(() => new global::_003C_003Ez__ReadOnlySingleElementList<IDisposable>(presetsBinder));
		return objectBinder;
	}

	public CaptureSettingsDocument(IStreamFactory streamFactory)
	{
		_streamFactory = streamFactory;
		Streams = new StreamCollection(streamFactory);
		Presets = new CapturePresetCollection(new CapturePresetFactory(streamFactory))
		{
			UndoStack = UndoStack
		};
		Presets.DataModified += OnDataModified;
		ActivePreset = Presets.Create();
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	public Recording.Types.SettingsDocument Serialize()
	{
		Recording.Types.SettingsDocument settingsDocument = new Recording.Types.SettingsDocument
		{
			ActivePreset = ActivePreset?.Serialize()
		};
		settingsDocument.Presets.AddRange(Presets.Serialize().NonNull());
		if (ActivePreset?.Streams != null)
		{
			settingsDocument.Streams.AddRange(ActivePreset.Streams.Serialize().NonNull());
		}
		return settingsDocument;
	}

	public void Deserialize(Recording.Types.SettingsDocument settingsDocument)
	{
		Presets.DataModified -= OnDataModified;
		Streams.DataModified -= OnDataModified;
		if (ActivePreset != null)
		{
			ActivePreset.DataModified -= OnDataModified;
		}
		if (settingsDocument != null)
		{
			Streams.Deserialize(settingsDocument.Streams);
			Presets.Deserialize(settingsDocument.Presets);
			if (settingsDocument.ActivePreset != null)
			{
				ICapturePreset capturePreset = Presets.FirstOrDefaultBy((ICapturePreset p) => p.ID == settingsDocument.ActivePreset.Id.ToGuid(), (ICapturePreset p) => p.Name == settingsDocument.ActivePreset.Name);
				if (capturePreset != null)
				{
					ActivePreset = capturePreset;
				}
				else
				{
					ActivePreset?.Deserialize(settingsDocument.ActivePreset);
				}
			}
		}
		if (!Streams.Any())
		{
			Streams.Reset();
		}
		if (settingsDocument != null && settingsDocument.ActivePreset == null && ActivePreset != null)
		{
			ActivePreset.Streams.Clear();
			Streams.Select((IStream s) => s.Clone()).ForEach(ActivePreset.Streams.AddStream);
		}
		if (ActivePreset != null)
		{
			ActivePreset.DataModified += OnDataModified;
		}
		Streams.DataModified += OnDataModified;
		Presets.DataModified += OnDataModified;
	}
}
