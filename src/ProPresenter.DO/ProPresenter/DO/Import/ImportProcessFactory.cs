using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using Pro.Common.Background;
using Pro.Common.Dispatcher;
using Pro.Common.FeatureFlag;
using Pro.Common.Logging;
using Pro.Common.MessageService;
using Pro.Common.Utility.Zip;
using Pro.CoreApplication.Media;
using Pro.CoreApplication.Media.V2;
using Pro.CoreApplication.PowerPoint;
using Pro.Entity;
using Pro.Entity.Persistence;
using Pro.Localization.Services;
using Pro.Serialization.Utility;
using ProPresenter.DO.Analytics.Events.PowerPoint;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Import.Handlers;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Import.Results;
using ProPresenter.DO.Masks;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Settings;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Import;

public class ImportProcessFactory : IImportProcessFactory
{
	private readonly IRequestHandler[] _handlers;

	private readonly IProCoreInstance _proCoreInstance;

	private readonly IUiDispatcher _uiDispatcher;

	private readonly IEntityFactory _entityFactory;

	private readonly IMissingFontService _missingFontService;

	private readonly IMissingFontWindowProvider _missingFontWindowProvider;

	public ImportProcessFactory(IProPresenterResourceService resources, IThemeService themeService, IZipService zipService, IFileSystem fileSystem, IMessageService messageService, IFileService fileService, ILogger logger, ILocalization localization, IAdvanced advanced, IProtoService protoService, IPresentationFactory presentationFactory, IProCoreInstance proCoreInstance, IUiDispatcher uiDispatcher, IProPresenterDOFactoryProvider factoryProvider, IPowerPointImageLoader powerPointImageLoader, IEntityFactory entityFactory, IPowerPointEvents powerPointEvents, IMissingFontService missingFontService, IProPresenterCueFactory cueFactory, IMissingFontWindowProvider missingFontWindowProvider, IPowerPointImportService powerPointImportService, IFlagService featureFlagService, IImportHelperServices importHelpers, IImportLocationSelectionDialogService importLocationSelectionDialogService, IManageMediaAutoMaticallyProvider manageMediaAutomatically, IMediaService mediaService, IFileCreator fileCreator, IOutputConfiguration outputConfiguration, IMaskCollection maskCollection, ICollectionStorage collectionStorage)
	{
		IRequestHandler[] obj = new IRequestHandler[32]
		{
			new BundleHandler(),
			new ZipHandler(zipService, fileSystem, logger, localization),
			new PdfHandler(fileCreator, collectionStorage),
			new PowerPointHandler(presentationFactory, powerPointImageLoader, powerPointEvents, powerPointImportService, fileSystem, localization, importLocationSelectionDialogService),
			new Pro4DocumentHandler(),
			new Pro5DocumentHandler(),
			new Pro6MaskHandler(),
			new Pro6PropsHandler(),
			new Pro6DocumentHandler(),
			new PlainTextHandler(),
			new RTFHandler(),
			new WordXmlHandler(),
			new ImportOptionsHandler(messageService, presentationFactory),
			new Pro6TemplateBundleHandler(),
			new Pro6TemplateHandler(),
			new BundledThemeHandler(fileSystem, fileService, zipService),
			new ThemeHandler(themeService, fileSystem, fileService, featureFlagService, advanced, factoryProvider.MediaFactory, logger, importHelpers, collectionStorage),
			new Pro6PlaylistHandler(),
			new ProPresentationMediaHandler(featureFlagService.IsFlagEnabled(Flag.Cloud)),
			new ProPropsMediaHandler(featureFlagService.IsFlagEnabled(Flag.Cloud)),
			new ProMaskMediaHandler(featureFlagService.IsFlagEnabled(Flag.Cloud)),
			new ProPlaylistMediaHandler(featureFlagService.IsFlagEnabled(Flag.Cloud)),
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null
		};
		IRequestHandler requestHandler2;
		if (!(mediaService is IMediaServiceV2 mediaService2))
		{
			IRequestHandler requestHandler = new LegacyMediaImportHandler(fileCreator, collectionStorage);
			requestHandler2 = requestHandler;
		}
		else
		{
			IRequestHandler requestHandler = new CoreMediaImportHandler(factoryProvider.MediaFactory, mediaService2, uiDispatcher, fileSystem, fileCreator);
			requestHandler2 = requestHandler;
		}
		obj[22] = requestHandler2;
		obj[23] = new ProPresentationHandler(importLocationSelectionDialogService, fileCreator, collectionStorage);
		obj[24] = new ProPlaylistHandler(advanced, fileSystem, resources, protoService, logger, this, factoryProvider.MediaFactory, cueFactory);
		obj[25] = new ProPropsHandler(fileCreator, collectionStorage);
		obj[26] = new ProMaskHandler(factoryProvider, maskCollection);
		obj[27] = new Pro6StageLayoutsHandler(fileCreator, collectionStorage);
		obj[28] = new Pro6TimersHandler(fileCreator, collectionStorage);
		obj[29] = new Pro6MessagesHandler(fileCreator, collectionStorage);
		obj[30] = new Pro6CCLITemplateHandler(fileCreator, collectionStorage);
		obj[31] = new GeneratedPresentationHandler();
		_handlers = obj;
		_proCoreInstance = proCoreInstance;
		_uiDispatcher = uiDispatcher;
		_entityFactory = entityFactory;
		_missingFontService = missingFontService;
		_missingFontWindowProvider = missingFontWindowProvider;
	}

	public IImportProcess Create(IEnumerable<string> files)
	{
		return Create(files.Select((string f) => new FileImportRequest(f)));
	}

	public IImportProcess Create(IImportRequest request)
	{
		return Create(new global::_003C_003Ez__ReadOnlySingleElementList<IImportRequest>(request));
	}

	public IImportProcess Create(IEnumerable<IImportRequest> requests, IFileChangedLibrary? fileChangedLibrary = null, bool allowSelectPlaylist = true)
	{
		ImportProcess importProcess = new ImportProcess(requests, _handlers, _proCoreInstance, _uiDispatcher, _entityFactory, _missingFontService, SharedWorkerPool.Queue, fileChangedLibrary, allowSelectPlaylist);
		_missingFontWindowProvider.HandleImportProcess(importProcess);
		return importProcess;
	}
}
