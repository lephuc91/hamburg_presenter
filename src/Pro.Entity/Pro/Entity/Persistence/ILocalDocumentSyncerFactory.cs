namespace Pro.Entity.Persistence;

public interface ILocalDocumentSyncerFactory
{
	ILocalDocumentSyncer<ITimersLocalDocumentDoc> CreateTimer();

	ILocalDocumentSyncer<IProPresenterLocalWorkspaceDoc> CreateWorkspace();

	ILocalDocumentSyncer<IMessageLocalDocumentDoc> CreateMessages();
}
