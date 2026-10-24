using System;
using Pro.Entity.Collections;
using Pro.Entity.Document;
using Pro.Entity.Extensions;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class ProPresenterWorkspaceDoc : EntityDocumentBase, IProPresenterWorkspaceDoc, IEntityDocument, IEntity, IDisposable, IDocument, ICanExportSnapshot, IProPresenterWorkspace
{
	private readonly ProPresenterWorkspace _entity;

	public IComplexCollection<IProAudienceLook> AudienceLooks => _entity.AudienceLooks;

	public IComplexCollection<IProMask> Masks => _entity.Masks;

	public IComplexObservableProperty<IAudio.Types.ISettingsDocument> AudioSettings => _entity.AudioSettings;

	public IObservableProperty<string> SelectedLibraryName => _entity.SelectedLibraryName;

	public IComplexObservableProperty<IRecording.Types.ISettingsDocument?> RecordSettings => _entity.RecordSettings;

	public IObservableProperty<double> AudioInputTransitionTime => _entity.AudioInputTransitionTime;

	public IComplexCollection<ICloudProPresenterScreen> CloudOutputScreens => _entity.CloudOutputScreens;

	public IComplexCollection<ICloudVideoInput> CloudVideoInputs => _entity.CloudVideoInputs;

	public IComplexCollection<ICloudAudioInput> CloudAudioInputs => _entity.CloudAudioInputs;

	public IObservableProperty<uint> AudioChannelCount => _entity.AudioChannelCount;

	public ProPresenterWorkspaceDoc(LoroDoc doc, ulong peerId)
		: base(doc, peerId)
	{
		_entity = new ProPresenterWorkspace(base.Doc.GetMap("root".ToLoroContainerIdLike()));
	}

	public ProPresenterWorkspaceDoc(ulong peerId)
		: this(new LoroDoc(), peerId)
	{
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
		if (disposing)
		{
			_entity.Dispose();
		}
	}

	public override void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		_entity.OnDiff(path, diff);
	}

	public override void RegisterLinkedDisposable(IDisposable disposable)
	{
		_entity.RegisterLinkedDisposable(disposable);
	}
}
