using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using Pro.Common.SourceGenerator.Attributes;
using Pro.DO;
using Pro.DO.Effects.Descriptions;
using Pro.Serialization.DataManagement;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.CommonPathsWrapper;

namespace ProPresenter.DO.Media;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_syncedData" })]
public sealed class EffectsProtoSyncer : IDataSyncer<EffectsCollection>, IDisposable
{
	private readonly IProtoSyncedFileData<Effect.Types.Preset, EffectsCollection> _syncedData;

	private readonly IReadOnlyList<EffectDescription> _availableEffects;

	private readonly Action<EffectsCollection> _onAdd;

	private readonly Action<EffectsCollection> _onRemove;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public EffectsProtoSyncer(ISyncDataFactory syncDataFactory, IReadOnlyList<EffectDescription> availableEffects, ICommonPathsWrapper commonPathsWrapper, Action<EffectsCollection> onAdd, Action<EffectsCollection> onRemove)
	{
		_availableEffects = availableEffects;
		_onAdd = onAdd;
		_onRemove = onRemove;
		_syncedData = syncDataFactory.GetSyncedFileData<Effect.Types.Preset, EffectsCollection>(".effectPreset", commonPathsWrapper.EffectsPresets, SyncedFileParse, SyncedFileLoaded, SyncedFileDeleted, SyncedFileRenamed, SyncedFileUpdated);
	}

	public void Add(EffectsCollection model)
	{
		model.DataModified += OnDataModified;
		model.FilenameModified += Preset_FilenameModified;
		_syncedData.AddSyncedFile(model.Name, model.SerializePreset(), model);
	}

	public void Remove(EffectsCollection model)
	{
		model.DataModified -= OnDataModified;
		model.FilenameModified -= Preset_FilenameModified;
		_syncedData.DeleteSyncedFile(model);
	}

	private EffectsCollection SyncedFileParse(ProtoSyncedFileData<Effect.Types.Preset, EffectsCollection> sender, string filename, Effect.Types.Preset data)
	{
		EffectsCollection effectsCollection = new EffectsCollection(filename);
		effectsCollection.DeserializePreset(filename, data, _availableEffects);
		return effectsCollection;
	}

	private void SyncedFileLoaded(ProtoSyncedFileData<Effect.Types.Preset, EffectsCollection> sender, EffectsCollection model)
	{
		model.DataModified += OnDataModified;
		model.FilenameModified += Preset_FilenameModified;
		_onAdd(model);
	}

	private void SyncedFileDeleted(ProtoSyncedFileData<Effect.Types.Preset, EffectsCollection> sender, string filename, EffectsCollection model)
	{
		model.DataModified -= OnDataModified;
		model.FilenameModified -= Preset_FilenameModified;
		_onRemove(model);
	}

	private static void SyncedFileRenamed(ProtoSyncedFileData<Effect.Types.Preset, EffectsCollection> sender, string oldFilename, string newFilename, EffectsCollection model)
	{
		model.Name = newFilename;
	}

	private void SyncedFileUpdated(ProtoSyncedFileData<Effect.Types.Preset, EffectsCollection> sender, string filename, Effect.Types.Preset data, EffectsCollection model)
	{
		model.DeserializePreset(Path.GetFileNameWithoutExtension(filename), data, _availableEffects);
	}

	private void OnDataModified(EffectsCollection preset)
	{
		_syncedData.UpdateSyncedFile(preset.SerializePreset(), preset);
	}

	private void Preset_FilenameModified(EffectsCollection preset, string newFilename)
	{
		_syncedData?.RenameSyncedFile(preset, newFilename);
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
