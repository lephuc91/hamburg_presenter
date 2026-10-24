using Pro.Common.ErrorReporting;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Merged.Factory;
using Pro.Text.Fills;
using ProPresenter.DO.Media;

namespace ProPresenter.DO.DependencyInjection;

public interface IProPresenterDOFactoryProvider
{
	IMediaFactory MediaFactory { get; }

	ITextDocumentFactory TextDocumentFactory { get; }

	IEntityFactory EntityFactory { get; }

	IMergedEntityFactory MergedEntityFactory { get; }

	IDocumentFactory DocumentFactory { get; }

	ITextFillMediaFactory TextFillMediaFactory { get; }

	IEntityDocumentSyncerFactory EntityDocumentSyncerFactory { get; }

	IErrorReporter ErrorReporter { get; }
}
