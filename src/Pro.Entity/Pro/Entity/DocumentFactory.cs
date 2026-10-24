using Pro.Entity.Document;
using Pro.Entity.Extensions;
using Pro.Entity.Factory;

namespace Pro.Entity;

public class DocumentFactory : IDocumentFactory, IDocFactory<ICcliDocumentDoc>, IDocFactory, IDocFactory<ICalendarDoc>, IDocFactory<IClearGroupsDocumentDoc>, IDocFactory<IEffect.Types.IPresetDoc>, IDocFactory<IKeyMappingDocumentDoc>, IDocFactory<ILibraryDoc>, IDocFactory<IMacrosDocumentDoc>, IDocFactory<IMessageDocumentDoc>, IDocFactory<IMessageLocalDocumentDoc>, IDocFactory<IPlaylistDocumentDoc>, IDocFactory<IPlaylistTemplateDoc>, IDocFactory<IPresentationDoc>, IDocFactory<IProGroupsDocumentDoc>, IDocFactory<IProLabelsDocumentDoc>, IDocFactory<IProPresenterCommunicationsDoc>, IDocFactory<IProPresenterLocalCommunicationsDoc>, IDocFactory<IProPresenterLocalWorkspaceDoc>, IDocFactory<IProPresenterWorkspaceDoc>, IDocFactory<IPropDocumentDoc>, IDocFactory<IStage.Types.IDocumentDoc>, IDocFactory<ITemplate.Types.IDocumentDoc>, IDocFactory<ITestPatternDocumentDoc>, IDocFactory<ITimersDocumentDoc>, IDocFactory<ITimersLocalDocumentDoc>, IDocFactory<ITransition.Types.IPresetDoc>
{
	ICcliDocumentDoc IDocFactory<ICcliDocumentDoc>.CreateInstance(ulong peerId)
	{
		return new CcliDocumentDoc(peerId);
	}

	ICcliDocumentDoc IDocFactory<ICcliDocumentDoc>.CreateInstance(byte[] document, ulong peerId)
	{
		return new CcliDocumentDoc(document.ToLoroDoc(), peerId);
	}

	ICalendarDoc IDocFactory<ICalendarDoc>.CreateInstance(ulong peerId)
	{
		return new CalendarDoc(peerId);
	}

	ICalendarDoc IDocFactory<ICalendarDoc>.CreateInstance(byte[] document, ulong peerId)
	{
		return new CalendarDoc(document.ToLoroDoc(), peerId);
	}

	IClearGroupsDocumentDoc IDocFactory<IClearGroupsDocumentDoc>.CreateInstance(ulong peerId)
	{
		return new ClearGroupsDocumentDoc(peerId);
	}

	IClearGroupsDocumentDoc IDocFactory<IClearGroupsDocumentDoc>.CreateInstance(byte[] document, ulong peerId)
	{
		return new ClearGroupsDocumentDoc(document.ToLoroDoc(), peerId);
	}

	IEffect.Types.IPresetDoc IDocFactory<IEffect.Types.IPresetDoc>.CreateInstance(ulong peerId)
	{
		return new IEffect.Types.PresetDoc(peerId);
	}

	IEffect.Types.IPresetDoc IDocFactory<IEffect.Types.IPresetDoc>.CreateInstance(byte[] document, ulong peerId)
	{
		return new IEffect.Types.PresetDoc(document.ToLoroDoc(), peerId);
	}

	IKeyMappingDocumentDoc IDocFactory<IKeyMappingDocumentDoc>.CreateInstance(ulong peerId)
	{
		return new KeyMappingDocumentDoc(peerId);
	}

	IKeyMappingDocumentDoc IDocFactory<IKeyMappingDocumentDoc>.CreateInstance(byte[] document, ulong peerId)
	{
		return new KeyMappingDocumentDoc(document.ToLoroDoc(), peerId);
	}

	ILibraryDoc IDocFactory<ILibraryDoc>.CreateInstance(ulong peerId)
	{
		return new LibraryDoc(peerId);
	}

	ILibraryDoc IDocFactory<ILibraryDoc>.CreateInstance(byte[] document, ulong peerId)
	{
		return new LibraryDoc(document.ToLoroDoc(), peerId);
	}

	IMacrosDocumentDoc IDocFactory<IMacrosDocumentDoc>.CreateInstance(ulong peerId)
	{
		return new MacrosDocumentDoc(peerId);
	}

	IMacrosDocumentDoc IDocFactory<IMacrosDocumentDoc>.CreateInstance(byte[] document, ulong peerId)
	{
		return new MacrosDocumentDoc(document.ToLoroDoc(), peerId);
	}

	IMessageDocumentDoc IDocFactory<IMessageDocumentDoc>.CreateInstance(ulong peerId)
	{
		return new MessageDocumentDoc(peerId);
	}

	IMessageDocumentDoc IDocFactory<IMessageDocumentDoc>.CreateInstance(byte[] document, ulong peerId)
	{
		return new MessageDocumentDoc(document.ToLoroDoc(), peerId);
	}

	IMessageLocalDocumentDoc IDocFactory<IMessageLocalDocumentDoc>.CreateInstance(ulong peerId)
	{
		return new MessageLocalDocumentDoc(peerId);
	}

	IMessageLocalDocumentDoc IDocFactory<IMessageLocalDocumentDoc>.CreateInstance(byte[] document, ulong peerId)
	{
		return new MessageLocalDocumentDoc(document.ToLoroDoc(), peerId);
	}

	IPlaylistDocumentDoc IDocFactory<IPlaylistDocumentDoc>.CreateInstance(ulong peerId)
	{
		return new PlaylistDocumentDoc(peerId);
	}

	IPlaylistDocumentDoc IDocFactory<IPlaylistDocumentDoc>.CreateInstance(byte[] document, ulong peerId)
	{
		return new PlaylistDocumentDoc(document.ToLoroDoc(), peerId);
	}

	IPlaylistTemplateDoc IDocFactory<IPlaylistTemplateDoc>.CreateInstance(ulong peerId)
	{
		return new PlaylistTemplateDoc(peerId);
	}

	IPlaylistTemplateDoc IDocFactory<IPlaylistTemplateDoc>.CreateInstance(byte[] document, ulong peerId)
	{
		return new PlaylistTemplateDoc(document.ToLoroDoc(), peerId);
	}

	IPresentationDoc IDocFactory<IPresentationDoc>.CreateInstance(ulong peerId)
	{
		return new PresentationDoc(peerId);
	}

	IPresentationDoc IDocFactory<IPresentationDoc>.CreateInstance(byte[] document, ulong peerId)
	{
		return new PresentationDoc(document.ToLoroDoc(), peerId);
	}

	IProGroupsDocumentDoc IDocFactory<IProGroupsDocumentDoc>.CreateInstance(ulong peerId)
	{
		return new ProGroupsDocumentDoc(peerId);
	}

	IProGroupsDocumentDoc IDocFactory<IProGroupsDocumentDoc>.CreateInstance(byte[] document, ulong peerId)
	{
		return new ProGroupsDocumentDoc(document.ToLoroDoc(), peerId);
	}

	IProLabelsDocumentDoc IDocFactory<IProLabelsDocumentDoc>.CreateInstance(ulong peerId)
	{
		return new ProLabelsDocumentDoc(peerId);
	}

	IProLabelsDocumentDoc IDocFactory<IProLabelsDocumentDoc>.CreateInstance(byte[] document, ulong peerId)
	{
		return new ProLabelsDocumentDoc(document.ToLoroDoc(), peerId);
	}

	IProPresenterCommunicationsDoc IDocFactory<IProPresenterCommunicationsDoc>.CreateInstance(ulong peerId)
	{
		return new ProPresenterCommunicationsDoc(peerId);
	}

	IProPresenterCommunicationsDoc IDocFactory<IProPresenterCommunicationsDoc>.CreateInstance(byte[] document, ulong peerId)
	{
		return new ProPresenterCommunicationsDoc(document.ToLoroDoc(), peerId);
	}

	IProPresenterLocalCommunicationsDoc IDocFactory<IProPresenterLocalCommunicationsDoc>.CreateInstance(ulong peerId)
	{
		return new ProPresenterLocalCommunicationsDoc(peerId);
	}

	IProPresenterLocalCommunicationsDoc IDocFactory<IProPresenterLocalCommunicationsDoc>.CreateInstance(byte[] document, ulong peerId)
	{
		return new ProPresenterLocalCommunicationsDoc(document.ToLoroDoc(), peerId);
	}

	IProPresenterLocalWorkspaceDoc IDocFactory<IProPresenterLocalWorkspaceDoc>.CreateInstance(ulong peerId)
	{
		return new ProPresenterLocalWorkspaceDoc(peerId);
	}

	IProPresenterLocalWorkspaceDoc IDocFactory<IProPresenterLocalWorkspaceDoc>.CreateInstance(byte[] document, ulong peerId)
	{
		return new ProPresenterLocalWorkspaceDoc(document.ToLoroDoc(), peerId);
	}

	IProPresenterWorkspaceDoc IDocFactory<IProPresenterWorkspaceDoc>.CreateInstance(ulong peerId)
	{
		return new ProPresenterWorkspaceDoc(peerId);
	}

	IProPresenterWorkspaceDoc IDocFactory<IProPresenterWorkspaceDoc>.CreateInstance(byte[] document, ulong peerId)
	{
		return new ProPresenterWorkspaceDoc(document.ToLoroDoc(), peerId);
	}

	IPropDocumentDoc IDocFactory<IPropDocumentDoc>.CreateInstance(ulong peerId)
	{
		return new PropDocumentDoc(peerId);
	}

	IPropDocumentDoc IDocFactory<IPropDocumentDoc>.CreateInstance(byte[] document, ulong peerId)
	{
		return new PropDocumentDoc(document.ToLoroDoc(), peerId);
	}

	IStage.Types.IDocumentDoc IDocFactory<IStage.Types.IDocumentDoc>.CreateInstance(ulong peerId)
	{
		return new IStage.Types.DocumentDoc(peerId);
	}

	IStage.Types.IDocumentDoc IDocFactory<IStage.Types.IDocumentDoc>.CreateInstance(byte[] document, ulong peerId)
	{
		return new IStage.Types.DocumentDoc(document.ToLoroDoc(), peerId);
	}

	ITemplate.Types.IDocumentDoc IDocFactory<ITemplate.Types.IDocumentDoc>.CreateInstance(ulong peerId)
	{
		return new ITemplate.Types.DocumentDoc(peerId);
	}

	ITemplate.Types.IDocumentDoc IDocFactory<ITemplate.Types.IDocumentDoc>.CreateInstance(byte[] document, ulong peerId)
	{
		return new ITemplate.Types.DocumentDoc(document.ToLoroDoc(), peerId);
	}

	ITestPatternDocumentDoc IDocFactory<ITestPatternDocumentDoc>.CreateInstance(ulong peerId)
	{
		return new TestPatternDocumentDoc(peerId);
	}

	ITestPatternDocumentDoc IDocFactory<ITestPatternDocumentDoc>.CreateInstance(byte[] document, ulong peerId)
	{
		return new TestPatternDocumentDoc(document.ToLoroDoc(), peerId);
	}

	ITimersDocumentDoc IDocFactory<ITimersDocumentDoc>.CreateInstance(ulong peerId)
	{
		return new TimersDocumentDoc(peerId);
	}

	ITimersDocumentDoc IDocFactory<ITimersDocumentDoc>.CreateInstance(byte[] document, ulong peerId)
	{
		return new TimersDocumentDoc(document.ToLoroDoc(), peerId);
	}

	ITimersLocalDocumentDoc IDocFactory<ITimersLocalDocumentDoc>.CreateInstance(ulong peerId)
	{
		return new TimersLocalDocumentDoc(peerId);
	}

	ITimersLocalDocumentDoc IDocFactory<ITimersLocalDocumentDoc>.CreateInstance(byte[] document, ulong peerId)
	{
		return new TimersLocalDocumentDoc(document.ToLoroDoc(), peerId);
	}

	ITransition.Types.IPresetDoc IDocFactory<ITransition.Types.IPresetDoc>.CreateInstance(ulong peerId)
	{
		return new ITransition.Types.PresetDoc(peerId);
	}

	ITransition.Types.IPresetDoc IDocFactory<ITransition.Types.IPresetDoc>.CreateInstance(byte[] document, ulong peerId)
	{
		return new ITransition.Types.PresetDoc(document.ToLoroDoc(), peerId);
	}

	public IDocument CreateDocument(byte[] document, ulong peerId)
	{
		return new Pro.Entity.Document.Document(document.ToLoroDoc(), peerId);
	}
}
