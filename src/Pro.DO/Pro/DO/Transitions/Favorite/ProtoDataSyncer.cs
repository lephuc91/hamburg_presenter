using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Serialization.DataManagement;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Transitions.Favorite;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_syncedData" })]
public sealed class ProtoDataSyncer : IDataSyncer<FavoriteTransition>, IDisposable
{
	private readonly IProtoSyncedFileData<Transition.Types.Preset, TransitionPreset> _syncedData;

	private readonly ITransitionDescriptionCollection _descriptions;

	private readonly Action<TransitionPreset> _onAdd;

	private readonly Action<TransitionPreset> _onRemove;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public ProtoDataSyncer(ISyncDataFactory syncDataFactory, string containingFolder, ITransitionDescriptionCollection transitionDescriptions, Action<TransitionPreset> onAdd, Action<TransitionPreset> onRemove)
	{
		_onAdd = onAdd;
		_onRemove = onRemove;
		_descriptions = transitionDescriptions;
		_syncedData = syncDataFactory.GetSyncedFileData<Transition.Types.Preset, TransitionPreset>(".transitionPreset", containingFolder, SyncedFileParse, SyncedFileLoaded, SyncedFileDeleted, SyncedFileRenamed, SyncedFileUpdated);
	}

	public void Add(FavoriteTransition model)
	{
		model.Preset.PropertyChanged += OnPresetChanged;
		_syncedData.AddSyncedFile(model.Preset.Name, model.Preset.Serialize(), model.Preset);
	}

	public void Remove(FavoriteTransition model)
	{
		model.Preset.PropertyChanged -= OnPresetChanged;
		_syncedData.DeleteSyncedFile(model.Preset);
	}

	private TransitionPreset SyncedFileParse(ProtoSyncedFileData<Transition.Types.Preset, TransitionPreset> sender, string filename, Transition.Types.Preset data)
	{
		return new TransitionPreset(_descriptions, data, canRename: true);
	}

	private void SyncedFileLoaded(ProtoSyncedFileData<Transition.Types.Preset, TransitionPreset> sender, TransitionPreset model)
	{
		model.PropertyChanged += OnPresetChanged;
		_onAdd(model);
	}

	private void SyncedFileDeleted(ProtoSyncedFileData<Transition.Types.Preset, TransitionPreset> sender, string filename, TransitionPreset model)
	{
		model.PropertyChanged -= OnPresetChanged;
		_onRemove(model);
	}

	private static void SyncedFileRenamed(ProtoSyncedFileData<Transition.Types.Preset, TransitionPreset> sender, string oldFilename, string newFilename, TransitionPreset model)
	{
		model.Name = newFilename;
	}

	private void SyncedFileUpdated(ProtoSyncedFileData<Transition.Types.Preset, TransitionPreset> sender, string filename, Transition.Types.Preset data, TransitionPreset model)
	{
		model.UpdateParameters(new TransitionParameters(_descriptions, data.Transition));
	}

	private void OnPresetChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (sender is TransitionPreset transitionPreset)
		{
			if (e.PropertyName == "Name")
			{
				_syncedData?.RenameSyncedFile(transitionPreset, transitionPreset.Name);
			}
			_syncedData?.UpdateSyncedFile(transitionPreset.Serialize(), transitionPreset);
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			_syncedData.Dispose();
		}
	}
}
