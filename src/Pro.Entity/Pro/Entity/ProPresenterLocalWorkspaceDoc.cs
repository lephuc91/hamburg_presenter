using System;
using Pro.Entity.Collections;
using Pro.Entity.Document;
using Pro.Entity.Extensions;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class ProPresenterLocalWorkspaceDoc : EntityDocumentBase, IProPresenterLocalWorkspaceDoc, IEntityDocument, IEntity, IDisposable, IDocument, ICanExportSnapshot, IProPresenterLocalWorkspace
{
	private readonly ProPresenterLocalWorkspace _entity;

	public IComplexObservableProperty<IDigitalAudio.Types.ISetup?> DigitalAudioSetup => _entity.DigitalAudioSetup;

	public IComplexCollection<IProPresenterScreen> ProScreens => _entity.ProScreens;

	public IComplexCollection<IVideoInput> VideoInputs => _entity.VideoInputs;

	public IComplexCollection<IAudioInput> AudioInputs => _entity.AudioInputs;

	public IComplexObservableProperty<IProAudienceLook> LiveAudienceLook => _entity.LiveAudienceLook;

	public IComplexCollection<IStage.Types.IScreenAssignment> StageLayoutMappings => _entity.StageLayoutMappings;

	public ProPresenterLocalWorkspaceDoc(LoroDoc doc, ulong peerId)
		: base(doc, peerId)
	{
		_entity = new ProPresenterLocalWorkspace(base.Doc.GetMap("root".ToLoroContainerIdLike()));
	}

	public ProPresenterLocalWorkspaceDoc(ulong peerId)
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
