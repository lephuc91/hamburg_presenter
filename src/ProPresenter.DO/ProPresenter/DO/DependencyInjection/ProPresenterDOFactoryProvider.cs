using Pro.Common.ErrorReporting;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Merged.Factory;
using Pro.Text.Fills;
using ProPresenter.DO.Media;

namespace ProPresenter.DO.DependencyInjection;

public sealed record ProPresenterDOFactoryProvider(IMediaFactory MediaFactory, ITextDocumentFactory TextDocumentFactory, IEntityFactory EntityFactory, IDocumentFactory DocumentFactory, ITextFillMediaFactory TextFillMediaFactory, IEntityDocumentSyncerFactory EntityDocumentSyncerFactory, IErrorReporter ErrorReporter, IMergedEntityFactory MergedEntityFactory) : IProPresenterDOFactoryProvider;
