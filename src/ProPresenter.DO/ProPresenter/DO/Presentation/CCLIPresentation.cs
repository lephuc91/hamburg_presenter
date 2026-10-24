using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Google.Protobuf;
using Pro.Common.Collections;
using Pro.Common.Dispatcher;
using Pro.Common.FeatureFlag;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.CoreApplication.Document;
using Pro.CoreApplication.Document.Intrinsic;
using Pro.DO;
using Pro.DO.Application;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Entity.Persistence;
using Pro.Serialization.DataManagement;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.CCLI;
using ProPresenter.DO.ChangeDirectory;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Extensions;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Custom.Elements.Shapes;
using ProPresenter.DO.Slide.Links;
using ProPresenter.DO.Themes;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.DO.Presentation;

public class CCLIPresentation : Theme, ICCLIPresentation, INotifyPropertyChanged, INotifyEnumerableChanged<TemplateSlide>, IEnumerable<TemplateSlide>, IEnumerable, INotifyCollectionChanged, IDocumentProvider
{
	private IProtoSyncedData<Pro.SerializationInterop.RVProtoData.CCLIDocument>? _syncedData;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly ISyncDataFactory _syncDataFactory;

	private readonly IFlagService _flagService;

	private readonly IUiScheduler _uiScheduler;

	private readonly IActionBinderFactory _actionBinderFactory;

	private string _license = string.Empty;

	private CCLIDisplayType _displayType;

	private bool _display = true;

	private IEntityDocumentSyncer<ICcliDocumentDoc>? _syncer;

	public string License
	{
		get
		{
			return _license;
		}
		set
		{
			SetValue("License", ref _license, value, (System.Action)delegate
			{
				OnDataModified("License", null);
			});
		}
	}

	public CCLIDisplayType DisplayType
	{
		get
		{
			return _displayType;
		}
		set
		{
			SetValue("DisplayType", ref _displayType, value, (System.Action)delegate
			{
				OnDataModified("DisplayType", null);
			});
		}
	}

	public bool Display
	{
		get
		{
			return _display;
		}
		set
		{
			SetValue("Display", ref _display, value, (System.Action)delegate
			{
				OnDataModified("Display", null);
			});
		}
	}

	public ICCLILayoutData Layout { get; }

	public override string ContainerId => "CCLI";

	public Guid DocumentId => _syncer?.Id ?? Guid.Empty;

	public static ObjectBinder<CCLIPresentation, ICcliDocument> Bind(IUiScheduler scheduler, IProPresenterDOFactoryProvider factoryProvider, IActionBinderFactory actionBinderFactory, CCLIPresentation left, ICcliDocument document)
	{
		IEntityFactory entityFactory = factoryProvider.EntityFactory;
		ObjectBinder<CCLIPresentation, ICcliDocument> objectBinder = new ObjectBinder<CCLIPresentation, ICcliDocument>(left, document);
		objectBinder.Bind((CCLIPresentation l) => l.WhenPropertyChanges("Display"), (ICcliDocument r) => r.EnableCcliDisplay.WhenValueChanges, delegate(CCLIPresentation l, ICcliDocument r)
		{
			r.EnableCcliDisplay.Set(l.Display);
		}, delegate(ICcliDocument r, CCLIPresentation l)
		{
			l.Display = r.EnableCcliDisplay.Value;
		}).Bind((CCLIPresentation l) => l.WhenPropertyChanges("License"), (ICcliDocument r) => r.CcliLicense.WhenValueChanges, delegate(CCLIPresentation l, ICcliDocument r)
		{
			r.CcliLicense.Set(l.License);
		}, delegate(ICcliDocument r, CCLIPresentation l)
		{
			l.License = r.CcliLicense.Value;
		}).Bind((CCLIPresentation l) => l.WhenPropertyChanges("DisplayType"), (ICcliDocument r) => r.DisplayType.WhenValueChanges, delegate(CCLIPresentation l, ICcliDocument r)
		{
			r.DisplayType.Set(ToEntityDisplayType(l.DisplayType));
		}, delegate(ICcliDocument r, CCLIPresentation l)
		{
			l.DisplayType = ToDisplayType(r.DisplayType.Value);
		})
			.Bind((CCLIPresentation l) => l.WhenCollectionChanges(), (ICcliDocument r) => r.Template.WhenValueChanges, delegate(CCLIPresentation l, ICcliDocument r)
			{
				if (l.Count >= 1)
				{
					ITemplate.Types.ISlide slide = entityFactory.Create<ITemplate.Types.ISlide>();
					r.Template.Set(slide);
					ObjectBinder<TemplateSlide, ITemplate.Types.ISlide> objectBinder2 = TemplateSlide.CreateBinder(scheduler, actionBinderFactory, l[0], slide);
					objectBinder2.InitializeRightFromLeft();
					slide.RegisterLinkedDisposable(objectBinder2);
				}
			}, delegate(ICcliDocument r, CCLIPresentation l)
			{
				if (l.Count >= 1)
				{
					ObjectBinder<TemplateSlide, ITemplate.Types.ISlide> objectBinder3 = TemplateSlide.CreateBinder(scheduler, actionBinderFactory, l[0], r.Template.Value);
					objectBinder3.InitializeLeftFromRight();
					r.Template.Value.RegisterLinkedDisposable(objectBinder3);
				}
			}, scheduler.Scheduler, scheduler.Scheduler)
			.Bind((CCLIPresentation l) => l.WhenPropertyChanges("Layout"), (ICcliDocument r) => r.Layout.WhenValueChanges, delegate(CCLIPresentation l, ICcliDocument r)
			{
				ICopyrightLayout copyrightLayout = factoryProvider.EntityFactory.Create<ICopyrightLayout>();
				r.Layout.Set(copyrightLayout);
				ObjectBinder<ICCLILayoutData, ICopyrightLayout> objectBinder4 = l.Layout.Bind(copyrightLayout, scheduler);
				objectBinder4.InitializeRightFromLeft();
				copyrightLayout.RegisterLinkedDisposable(objectBinder4);
			}, delegate(ICcliDocument r, CCLIPresentation l)
			{
				ObjectBinder<ICCLILayoutData, ICopyrightLayout> objectBinder5 = l.Layout.Bind(r.Layout.Value, scheduler);
				objectBinder5.InitializeLeftFromRight();
				r.Layout.Value.RegisterLinkedDisposable(objectBinder5);
			});
		return objectBinder;
	}

	private static CCLIDisplayType ToDisplayType(ICcliDocument.Types.DisplayType value)
	{
		return value switch
		{
			ICcliDocument.Types.DisplayType.FirstSlide => CCLIDisplayType.First, 
			ICcliDocument.Types.DisplayType.LastSlide => CCLIDisplayType.Last, 
			ICcliDocument.Types.DisplayType.FirstAndLastSlide => CCLIDisplayType.FirstAndLast, 
			ICcliDocument.Types.DisplayType.AllSlides => CCLIDisplayType.AllSlides, 
			_ => CCLIDisplayType.First, 
		};
	}

	private static ICcliDocument.Types.DisplayType ToEntityDisplayType(CCLIDisplayType cCLIDisplayType)
	{
		return cCLIDisplayType switch
		{
			CCLIDisplayType.First => ICcliDocument.Types.DisplayType.FirstSlide, 
			CCLIDisplayType.Last => ICcliDocument.Types.DisplayType.LastSlide, 
			CCLIDisplayType.FirstAndLast => ICcliDocument.Types.DisplayType.FirstAndLastSlide, 
			CCLIDisplayType.AllSlides => ICcliDocument.Types.DisplayType.AllSlides, 
			_ => ICcliDocument.Types.DisplayType.FirstSlide, 
		};
	}

	public CCLIPresentation(IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions, ISyncDataFactory syncDataFactory, IFlagService flagService, IUiScheduler uiScheduler, IActionBinderFactory actionBinderFactory, IGeneral general, bool loadLegacy)
		: base(factoryProvider, transitionDescriptions, flagService)
	{
		_factoryProvider = factoryProvider;
		_syncDataFactory = syncDataFactory;
		_flagService = flagService;
		_uiScheduler = uiScheduler;
		_actionBinderFactory = actionBinderFactory;
		base.UndoStack.StartIgnoring();
		ResetLayout(userInitiated: false);
		Layout = general.CCLILayoutData;
		SetupDocumentSyncer(loadLegacy);
		base.DataModified += CCLIPresentation_DataModified;
		base.CollectionChanged += CCLIPresentation_CollectionChanged;
		ChangeDirectoryPrompt.RegisterDelegate(new ChangeDirectoryListener(TeardownDocumentSyncer, SetupDocumentSyncer));
		base.UndoStack.StopIgnoring();
	}

	private void TeardownDocumentSyncer()
	{
		_syncer?.Dispose();
		_syncedData?.Dispose();
		_syncer = null;
		_syncedData = null;
	}

	private void SetupDocumentSyncer(bool loadLegacy)
	{
		if (_flagService.IsFlagEnabled(Flag.Cloud))
		{
			_syncer = _factoryProvider.EntityDocumentSyncerFactory.CreateConfigurationSyncer("CCLI", (ICcliDocumentDoc doc) => Bind(_uiScheduler, _factoryProvider, _actionBinderFactory, this, doc), () => Serialize().ToByteArray(), delegate(byte[] d)
			{
				Deserialize(Pro.SerializationInterop.RVProtoData.CCLIDocument.Parser.ParseFrom(d));
			}, LoadDefaults, loadLegacy);
		}
		else
		{
			_syncedData = _syncDataFactory.GetSyncedData<Pro.SerializationInterop.RVProtoData.CCLIDocument>(CommonPaths.Configuration, "CCLI", Deserialize, SyncDataCleared);
		}
		if (!base.Collection.Any())
		{
			ResetLayout(userInitiated: true);
		}
	}

	private void LoadDefaults()
	{
		SyncDataCleared(DataClearSource.FileRemoved);
	}

	private void ResetLayout(bool userInitiated)
	{
		if (!this.Any())
		{
			TemplateSlide templateSlide = new TemplateSlide(_factoryProvider, base.TransitionDescriptions, _flagService);
			TextShape textShape = new TextShape(_factoryProvider, ContainerId);
			textShape.CenterAndScaleIn(templateSlide.Slide.Size);
			if (textShape.TextLink != null)
			{
				textShape.TextLink.LinkedObject = new CCLITextLinkedObject(General.Settings);
			}
			templateSlide.Slide.AddElement(textShape, userInitiated);
			Add(templateSlide);
		}
	}

	private void SyncDataCleared(DataClearSource dataClearSource)
	{
		if (dataClearSource == DataClearSource.FileRemoved)
		{
			base.UndoStack?.StartIgnoring();
			Clear();
			base.UndoStack?.StopIgnoring();
		}
	}

	private void UpdateSyncedFile()
	{
		_syncedData?.UpdateData(Serialize());
	}

	public new Pro.SerializationInterop.RVProtoData.CCLIDocument Serialize()
	{
		return new Pro.SerializationInterop.RVProtoData.CCLIDocument
		{
			ApplicationInfo = new ApplicationData(ApplicationType.ProPresenter).Serialize(),
			CcliLicense = License,
			DisplayType = DisplayType.ToProtoDisplayType(),
			EnableCcliDisplay = Display,
			Template = this.FirstOrDefault()?.Serialize(),
			Layout = Layout.Serialize()
		};
	}

	private void Deserialize(Pro.SerializationInterop.RVProtoData.CCLIDocument protoCCLI)
	{
		if (protoCCLI != null)
		{
			ApplicationData applicationData = ApplicationData.Deserialize(protoCCLI.ApplicationInfo);
			base.DataModified -= CCLIPresentation_DataModified;
			_license = protoCCLI.CcliLicense;
			_displayType = protoCCLI.DisplayType.ToDisplayType();
			_display = protoCCLI.EnableCcliDisplay;
			TemplateSlide templateSlide = new TemplateSlide(_factoryProvider, base.TransitionDescriptions, _flagService);
			templateSlide.Deserialize(protoCCLI.Template, applicationData, ContainerId);
			Array.ForEach(base.Collection.ToArray(), base.Remove);
			Add(templateSlide);
			if (protoCCLI.Layout != null)
			{
				Layout.Deserialize(protoCCLI.Layout);
			}
			base.DataModified += CCLIPresentation_DataModified;
		}
	}

	private void CCLIPresentation_DataModified(string propName, Theme theme, TemplateSlide? slide)
	{
		UpdateSyncedFile();
	}

	private void CCLIPresentation_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.NewItems?.OfType<TemplateSlide>().ForEach(delegate(TemplateSlide templateSlide)
		{
			templateSlide.UpdateContainerId(ContainerId);
		});
	}

	internal void Save()
	{
		UpdateSyncedFile();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			_syncedData?.Dispose();
			_syncer?.Dispose();
			ChangeDirectoryPrompt.UnregisterDelegate(new ChangeDirectoryListener(TeardownDocumentSyncer, SetupDocumentSyncer));
		}
		base.Dispose(disposing);
	}

	public Pro.CoreApplication.Document.IDocument? GetDocument()
	{
		if (_syncer == null)
		{
			return null;
		}
		return new Pro.CoreApplication.Document.Intrinsic.CCLIDocument(_syncer.Document.ExportFullSnapshot(), _syncer.Id);
	}
}
