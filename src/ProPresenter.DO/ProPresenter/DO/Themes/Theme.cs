using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.FeatureFlag;
using Pro.Common.FileSystem;
using Pro.Common.ObjectBinding;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Strings;
using Pro.Common.Utility;
using Pro.DO;
using Pro.DO.Application;
using Pro.DO.Storage;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Localization;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Media;
using ProPresenter.DO.Slide.Custom;

namespace ProPresenter.DO.Themes;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class Theme : ImmutableObservableCollection<TemplateSlide>, ICutPasteCollection<TemplateSlide>, ICutCollection<TemplateSlide>, IIdentifiable, IDisposable
{
	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private string _name = string.Empty;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	protected ITransitionDescriptionCollection TransitionDescriptions { get; }

	protected IFlagService FlagService { get; }

	public Guid ID { get; }

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			SetValue("Name", ref _name, value, OnRenamed);
		}
	}

	public string Path { get; private set; }

	public UndoStack UndoStack { get; } = new UndoStack();

	protected virtual bool UseDefaultTemplateName => true;

	public bool HasThemeDetailsBeenAcknowledgedByUser { get; set; }

	public virtual string ContainerId => MediaContainerIds.Theme(Name);

	public event Action<string, Theme, TemplateSlide?>? DataModified;

	public event Action<Theme>? Renamed;

	public ObjectBinder<Theme, ITemplate.Types.IDocument> Bind(IUiScheduler scheduler, IProPresenterDOFactoryProvider factoryProvider, IActionBinderFactory actionBinderFactory, IFlagService flagService, ITemplate.Types.IDocument document)
	{
		IEntityFactory entityFactory = factoryProvider.EntityFactory;
		ObjectBinder<Theme, ITemplate.Types.IDocument> objectBinder = new ObjectBinder<Theme, ITemplate.Types.IDocument>(this, document);
		objectBinder.Bind((Theme l) => l.WhenCollectionChanges(), (ITemplate.Types.IDocument r) => r.Slides.WhenCollectionChanges, delegate(Theme l, ITemplate.Types.IDocument r)
		{
			r.Slides.SynchronizeFrom(l, (TemplateSlide m, ITemplate.Types.ISlide e) => m.Slide.ID == e.BaseSlide.Value.Uuid.Value, delegate(TemplateSlide m)
			{
				ITemplate.Types.ISlide slide = entityFactory.Create<ITemplate.Types.ISlide>();
				ObjectBinder<TemplateSlide, ITemplate.Types.ISlide> objectBinder2 = TemplateSlide.CreateBinder(scheduler, actionBinderFactory, m, slide);
				objectBinder2.InitializeRightFromLeft();
				slide.RegisterLinkedDisposable(objectBinder2);
				return slide;
			});
		}, delegate(ITemplate.Types.IDocument r, Theme l)
		{
			r.Slides.Items.SynchronizeTo(l, (ITemplate.Types.ISlide e, TemplateSlide m) => m.Slide.ID == e.BaseSlide.Value.Uuid.Value, delegate(ITemplate.Types.ISlide e, int i)
			{
				TemplateSlide templateSlide = new TemplateSlide(factoryProvider, l.TransitionDescriptions, flagService);
				templateSlide.UpdateContainerId(l.ContainerId);
				ObjectBinder<TemplateSlide, ITemplate.Types.ISlide> objectBinder3 = TemplateSlide.CreateBinder(scheduler, actionBinderFactory, templateSlide, e);
				objectBinder3.InitializeLeftFromRight();
				e.RegisterLinkedDisposable(objectBinder3);
				l.Insert(i, templateSlide);
			}, l.Collection.Move, delegate(int i)
			{
				TemplateSlide templateSlide2 = l.ElementAtOrDefault(i);
				if (templateSlide2 != null)
				{
					l.Remove(templateSlide2);
				}
			});
		}, null, scheduler.Scheduler);
		return objectBinder;
	}

	public Theme(IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions, IFlagService flagService)
		: this(factoryProvider, transitionDescriptions, flagService, string.Empty, string.Empty, null)
	{
	}

	public Theme(IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions, IFlagService flagService, string name, string path, Guid? id = null)
	{
		_factoryProvider = factoryProvider;
		TransitionDescriptions = transitionDescriptions;
		FlagService = flagService;
		Name = name;
		Path = path;
		ID = id ?? Guid.NewGuid();
		if (!string.IsNullOrEmpty(path))
		{
			Directory.CreateDirectory(this.GetAssetPath());
		}
	}

	protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
	{
		if (!string.IsNullOrEmpty(ContainerId))
		{
			e.NewItems?.OfType<TemplateSlide>().ForEach(delegate(TemplateSlide templateSlide)
			{
				templateSlide.UpdateContainerId(ContainerId);
			});
		}
		OnDataModified("Items", null);
	}

	public void Insert(int index, TemplateSlide slide)
	{
		Insert(index, new global::_003C_003Ez__ReadOnlySingleElementList<TemplateSlide>(slide));
	}

	public void Insert(int index, IEnumerable<TemplateSlide> slides)
	{
		OnInsert(index, slides);
		UndoStack.Commit(UndoActionTypes.AddTemplate.ToAction(), delegate
		{
			Remove(slides);
		}, delegate
		{
			Insert(index, slides);
		}, null, null, autoFinalize: true);
	}

	public void Add(TemplateSlide slide)
	{
		Insert(base.Collection.Count, slide);
	}

	public void Add(CustomSlide slide)
	{
		Add(new TemplateSlide(_factoryProvider, slide, FlagService));
	}

	public void Add(IEnumerable<TemplateSlide> slides)
	{
		slides.ForEach(Add);
	}

	public void Add(IEnumerable<CustomSlide> slides)
	{
		slides.ForEach(Add);
	}

	public void Add()
	{
		Add(new TemplateSlide(_factoryProvider, TransitionDescriptions, FlagService, addDefaultShape: true));
	}

	private void OnInsert(int index, IEnumerable<TemplateSlide> slides)
	{
		slides.ForEach(delegate(TemplateSlide s)
		{
			s.ParentTheme = this;
			s.DataModified += OnDataModified;
			s.UndoStack = UndoStack;
			s.Name = ((UseDefaultTemplateName && string.IsNullOrWhiteSpace(s.Name)) ? LocalizedStrings.Get("THEMES_SLIDE_DEFAULT_NAME_name") : s.Name).DuplicateName(this, (TemplateSlide t) => t.Name);
		});
		base.Collection.InsertRange(index, slides);
	}

	public void Remove(TemplateSlide slide)
	{
		Remove(new global::_003C_003Ez__ReadOnlySingleElementList<TemplateSlide>(slide));
	}

	public void Remove(IEnumerable<TemplateSlide> slides)
	{
		Dictionary<int, TemplateSlide> originalValues = slides.ToDictionary(IndexOf, (TemplateSlide m) => m);
		OnRemove(slides);
		UndoStack.Commit(UndoActionTypes.RemoveTemplate.ToAction(), delegate
		{
			originalValues.ForEach(delegate(KeyValuePair<int, TemplateSlide> kv)
			{
				Insert(kv.Key, kv.Value);
			});
		}, delegate
		{
			OnRemove(slides);
		}, null, null, autoFinalize: true);
	}

	private void OnRemove(IEnumerable<TemplateSlide> slides)
	{
		slides.ForEach(delegate(TemplateSlide s)
		{
			s.DataModified -= OnDataModified;
		});
		base.Collection.RemoveRange(slides);
	}

	public void Clear()
	{
		Remove(base.Collection.ToArray());
	}

	protected void OnDataModified(string propName, TemplateSlide? slide)
	{
		this.DataModified?.Invoke(propName, this, slide);
	}

	private void OnRenamed()
	{
		using (IEnumerator<TemplateSlide> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current.UpdateContainerId(ContainerId);
			}
		}
		this.Renamed?.Invoke(this);
		OnDataModified("Name", null);
	}

	public Template.Types.Document Serialize()
	{
		Template.Types.Document document = new Template.Types.Document
		{
			ApplicationInfo = new ApplicationData(ApplicationType.ProPresenter).Serialize()
		};
		using (RelativePath.SetCurrentResourceRoot(System.IO.Path.Combine(CommonPaths.Themes, Path)))
		{
			document.Slides.AddRange(this.Select((TemplateSlide t) => t.Serialize()));
			return document;
		}
	}

	public void Deserialize(Template.Types.Document data, bool removeExisting = true)
	{
		ApplicationData applicationData = ApplicationData.Deserialize(data.ApplicationInfo);
		UndoStack.StartIgnoring();
		using (RelativePath.SetCurrentResourceRoot(System.IO.Path.Combine(CommonPaths.Themes, Path)))
		{
			base.Collection.DeserializeCollection(data.Slides, (TemplateSlide g, Template.Types.Slide p) => g.Name == p.Name, (Template.Types.Slide p) => new TemplateSlide(_factoryProvider, TransitionDescriptions, FlagService), Add, delegate(TemplateSlide g)
			{
				if (removeExisting)
				{
					Remove(g);
				}
			}, delegate(TemplateSlide t, Template.Types.Slide p)
			{
				FixMediaProto(p);
				t.DataModified -= OnDataModified;
				t.Deserialize(p, applicationData, MediaContainerIds.Theme(Name));
				t.DataModified += OnDataModified;
			});
		}
		UndoStack.StopIgnoring();
	}

	private void FixMediaProto(Template.Types.Slide p)
	{
		foreach (Pro.SerializationInterop.RVProtoData.Media item in p.Actions.Select((Pro.SerializationInterop.RVProtoData.Action a) => a.Media.Element).Concat(p.BaseSlide.Elements.GetProtoMediaFills()))
		{
			if (item.Url != null)
			{
				item.Url = fixUrl(item.Url);
			}
			switch (item.TypePropertiesCase)
			{
			case Pro.SerializationInterop.RVProtoData.Media.TypePropertiesOneofCase.Image:
				if (item.Image.File != null)
				{
					item.Image.File.LocalUrl = fixUrl(item.Image.File.LocalUrl);
				}
				break;
			case Pro.SerializationInterop.RVProtoData.Media.TypePropertiesOneofCase.Video:
				if (item.Video.File != null)
				{
					item.Video.File.LocalUrl = fixUrl(item.Video.File.LocalUrl);
				}
				break;
			}
		}
		URL fixUrl(URL url)
		{
			if (url.Platform == URL.Types.Platform.Macos && url.RelativeFilePathCase == URL.RelativeFilePathOneofCase.None && url.StorageCase == URL.StorageOneofCase.AbsoluteString)
			{
				URL uRL = url.Clone();
				string path = Uri.UnescapeDataString(uRL.AbsoluteString).NormalizePath(isDirectory: false);
				string assetPath = this.GetAssetPath();
				string fileName = System.IO.Path.GetFileName(path);
				uRL.Local = new URL.Types.LocalRelativePath
				{
					Path = System.IO.Path.Combine(assetPath, fileName),
					Root = URL.Types.LocalRelativePath.Types.Root.CurrentResource
				};
				return uRL;
			}
			return url;
		}
	}

	public void CutFrom(IEnumerable<TemplateSlide> items)
	{
		Remove(items);
	}

	public void PasteInto(IEnumerable<TemplateSlide> items, int index)
	{
		Insert(index, items);
	}

	public void MoveTo(IEnumerable<TemplateSlide> items, int index)
	{
		UndoStack.BeginCommit(UndoActionTypes.MoveTemplates.ToAction());
		base.Collection.MoveTo(items, index, UndoStack);
		UndoStack.EndCommit(null, null, autoFinalize: true);
	}

	public void UpdatePath(string newPath)
	{
		Path = newPath;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
		}
	}
}
