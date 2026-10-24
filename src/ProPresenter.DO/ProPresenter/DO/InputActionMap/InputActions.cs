using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Google.Protobuf;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.FeatureFlag;
using Pro.Common.ObjectBinding;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Versioning;
using Pro.CoreApplication.Document;
using Pro.CoreApplication.Document.Intrinsic;
using Pro.DO;
using Pro.DO.Application;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Persistence;
using Pro.Localization;
using Pro.Serialization.DataManagement;
using Pro.SerializationInterop.RVProtoData;
using Pro.UI.Commands;
using Pro.UI.InputActions;
using ProPresenter.DO.ChangeDirectory;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Extensions;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.DO.InputActionMap;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_syncedData", "_syncer" })]
public class InputActions : InputActionGroupCollectionBase, IInputActions, IReadOnlyCollection<InputActionGroupBase>, IEnumerable<InputActionGroupBase>, IEnumerable, INotifyEnumerableChanged<InputActionGroupBase>, INotifyCollectionChanged, IDocumentProvider, IDisposable
{
	[CompilerGenerated]
	private sealed class _003CGetAllInputActions_003Ed__1 : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private InputAction _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public InputActions _003C_003E4__this;

		private IEnumerator<InputActionGroupBase> _003C_003E7__wrap1;

		private IEnumerator<InputAction> _003C_003E7__wrap2;

		InputAction IEnumerator<InputAction>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CGetAllInputActions_003Ed__1(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if ((uint)(num - -6) <= 3u || (uint)(num - 1) <= 2u)
			{
				try
				{
					switch (num)
					{
					case -4:
					case 1:
						try
						{
						}
						finally
						{
							_003C_003Em__Finally2();
						}
						break;
					case -5:
					case 2:
						try
						{
						}
						finally
						{
							_003C_003Em__Finally3();
						}
						break;
					case -6:
					case 3:
						try
						{
						}
						finally
						{
							_003C_003Em__Finally4();
						}
						break;
					case -3:
					case -2:
					case -1:
					case 0:
						break;
					}
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003C_003E7__wrap1 = null;
			_003C_003E7__wrap2 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			try
			{
				int num = _003C_003E1__state;
				InputActions inputActions = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E7__wrap1 = inputActions.Collection.GetEnumerator();
					_003C_003E1__state = -3;
					goto IL_0203;
				case 1:
					_003C_003E1__state = -4;
					goto IL_00e6;
				case 2:
					_003C_003E1__state = -5;
					goto IL_018f;
				case 3:
					{
						_003C_003E1__state = -6;
						goto IL_01e9;
					}
					IL_0203:
					if (_003C_003E7__wrap1.MoveNext())
					{
						InputActionGroupBase current = _003C_003E7__wrap1.Current;
						if (current is PropsGroupsGroup propsGroupsGroup)
						{
							_003C_003E7__wrap2 = (propsGroupsGroup.Children?.SelectMany((InputActionGroupBase g) => g) ?? Array.Empty<InputAction>()).GetEnumerator();
							_003C_003E1__state = -4;
							goto IL_00e6;
						}
						if (current is MacroGroupsGroup macroGroupsGroup)
						{
							_003C_003E7__wrap2 = (macroGroupsGroup.Children?.SelectMany((InputActionGroupBase g) => g) ?? Array.Empty<InputAction>()).GetEnumerator();
							_003C_003E1__state = -5;
							goto IL_018f;
						}
						_003C_003E7__wrap2 = current.GetEnumerator();
						_003C_003E1__state = -6;
						goto IL_01e9;
					}
					_003C_003Em__Finally1();
					_003C_003E7__wrap1 = null;
					return false;
					IL_00e6:
					if (_003C_003E7__wrap2.MoveNext())
					{
						InputAction current2 = _003C_003E7__wrap2.Current;
						_003C_003E2__current = current2;
						_003C_003E1__state = 1;
						return true;
					}
					_003C_003Em__Finally2();
					_003C_003E7__wrap2 = null;
					goto IL_0203;
					IL_01e9:
					if (_003C_003E7__wrap2.MoveNext())
					{
						InputAction current3 = _003C_003E7__wrap2.Current;
						_003C_003E2__current = current3;
						_003C_003E1__state = 3;
						return true;
					}
					_003C_003Em__Finally4();
					_003C_003E7__wrap2 = null;
					goto IL_0203;
					IL_018f:
					if (_003C_003E7__wrap2.MoveNext())
					{
						InputAction current4 = _003C_003E7__wrap2.Current;
						_003C_003E2__current = current4;
						_003C_003E1__state = 2;
						return true;
					}
					_003C_003Em__Finally3();
					_003C_003E7__wrap2 = null;
					goto IL_0203;
				}
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			_003C_003E1__state = -1;
			if (_003C_003E7__wrap1 != null)
			{
				_003C_003E7__wrap1.Dispose();
			}
		}

		private void _003C_003Em__Finally2()
		{
			_003C_003E1__state = -3;
			if (_003C_003E7__wrap2 != null)
			{
				_003C_003E7__wrap2.Dispose();
			}
		}

		private void _003C_003Em__Finally3()
		{
			_003C_003E1__state = -3;
			if (_003C_003E7__wrap2 != null)
			{
				_003C_003E7__wrap2.Dispose();
			}
		}

		private void _003C_003Em__Finally4()
		{
			_003C_003E1__state = -3;
			if (_003C_003E7__wrap2 != null)
			{
				_003C_003E7__wrap2.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
		{
			_003CGetAllInputActions_003Ed__1 result;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				result = this;
			}
			else
			{
				result = new _003CGetAllInputActions_003Ed__1(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			return result;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<InputAction>)this).GetEnumerator();
		}
	}

	private IProtoSyncedData<KeyMappingDocument>? _syncedData;

	private bool _ignoreChanges;

	private IEntityDocumentSyncer<IKeyMappingDocumentDoc>? _syncer;

	private readonly IFlagService _flagService;

	private readonly ISyncDataFactory _syncDataFactory;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly bool _loadLegacy;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public CommonInputActionGroup CommonInputActions { get; }

	public ProPresenterGroup ProCommon { get; }

	public ProMenuGroup ProMenu { get; }

	public FileMenuGroup FileMenu { get; }

	public EditMenuGroup EditMenu { get; }

	public PresentationMenuGroup PresentationMenu { get; }

	public EditorMenuGroup EditorMenu { get; }

	public ReflowMenuGroup ReflowMenu { get; }

	public ScreensMenuGroup ScreensMenu { get; }

	public CalendarMenuGroup CalendarMenu { get; }

	public ViewMenuGroup ViewMenu { get; }

	public WindowMenuGroup WindowMenu { get; }

	public HelpMenuGroup HelpMenu { get; }

	public ClearGroupGroup ClearGroups { get; }

	public GroupLabelGroup GroupLabels { get; }

	public MacroGroup Macros { get; }

	public MacroGroupsGroup MacroGroups { get; }

	public PropGroup Props { get; }

	public PropsGroupsGroup PropGroups { get; }

	public UndoStack UndoStack { get; } = new UndoStack();

	public Guid DocumentId => _syncer?.Id ?? Guid.Empty;

	private IReadOnlyObjectBinder<InputActions, Pro.Entity.Collections.ICollection<IKeyMapping>> Bind(IEntityFactory entityFactory, IKeyMappingDocument document)
	{
		return new ObjectBinder<InputActions, Pro.Entity.Collections.ICollection<IKeyMapping>>(this, document.Keymappings);
	}

	[IteratorStateMachine(typeof(_003CGetAllInputActions_003Ed__1))]
	private IEnumerable<InputAction> GetAllInputActions()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGetAllInputActions_003Ed__1(-2)
		{
			_003C_003E4__this = this
		};
	}

	public InputActions(IFlagService flagService, ISyncDataFactory syncDataFactory, IProPresenterDOFactoryProvider factoryProvider, IVersionInfoProvider versionInfoProvider, bool loadLegacy)
	{
		CommonInputActions = new CommonInputActionGroup(string.Empty, this);
		CommonApplicationCommands.InitializeCommands(CommonInputActions);
		ProCommon = new ProPresenterGroup(string.Empty, this);
		ProMenu = new ProMenuGroup(LocalizedStrings.Get("KEYMAPPING_PREFERENCES_SECTION_HEADER_MENU_SUFFIX_title", new object[1] { LocalizedStrings.Get("MAIN_MENU_APPLICATION_title") }), this, flagService);
		AddGroup(ProMenu);
		FileMenu = new FileMenuGroup(LocalizedStrings.Get("KEYMAPPING_PREFERENCES_SECTION_HEADER_MENU_SUFFIX_title", new object[1] { LocalizedStrings.Get("MAIN_MENU_FILE_MENU_title") }), this);
		AddGroup(FileMenu);
		EditMenu = new EditMenuGroup(LocalizedStrings.Get("KEYMAPPING_PREFERENCES_SECTION_HEADER_MENU_SUFFIX_title", new object[1] { LocalizedStrings.Get("MAIN_MENU_EDIT_MENU_title") }), this);
		AddGroup(EditMenu);
		PresentationMenu = new PresentationMenuGroup(LocalizedStrings.Get("KEYMAPPING_PREFERENCES_SECTION_HEADER_MENU_SUFFIX_title", new object[1] { LocalizedStrings.Get("MAIN_MENU_PRESENTATION_MENU_title") }), this);
		AddGroup(PresentationMenu);
		ReflowMenu = new ReflowMenuGroup(LocalizedStrings.Get("KEYMAPPING_PREFERENCES_SECTION_HEADER_MENU_SUFFIX_title", new object[1] { LocalizedStrings.Get("MAIN_TOOLBAR_REFLOW_BUTTON_label") }), this);
		AddGroup(ReflowMenu);
		EditorMenu = new EditorMenuGroup(LocalizedStrings.Get("KEYMAPPING_PREFERENCES_SECTION_HEADER_MENU_SUFFIX_title", new object[1] { LocalizedStrings.Get("MAIN_MENU_EDITOR_MENU_title") }), this);
		AddGroup(EditorMenu);
		ScreensMenu = new ScreensMenuGroup(LocalizedStrings.Get("KEYMAPPING_PREFERENCES_SECTION_HEADER_MENU_SUFFIX_title", new object[1] { LocalizedStrings.Get("MAIN_MENU_SCREEN_MENU_title") }), this);
		AddGroup(ScreensMenu);
		CalendarMenu = new CalendarMenuGroup(LocalizedStrings.Get("KEYMAPPING_PREFERENCES_SECTION_HEADER_MENU_SUFFIX_title", new object[1] { LocalizedStrings.Get("MAIN_MENU_CALENDAR_MENU_title") }), this);
		AddGroup(CalendarMenu);
		ViewMenu = new ViewMenuGroup(LocalizedStrings.Get("KEYMAPPING_PREFERENCES_SECTION_HEADER_MENU_SUFFIX_title", new object[1] { LocalizedStrings.Get("MAIN_MENU_VIEW_MENU_title") }), this);
		AddGroup(ViewMenu);
		WindowMenu = new WindowMenuGroup(LocalizedStrings.Get("KEYMAPPING_PREFERENCES_SECTION_HEADER_MENU_SUFFIX_title", new object[1] { LocalizedStrings.Get("MAIN_MENU_WINDOW_MENU_title") }), this);
		AddGroup(WindowMenu);
		HelpMenu = new HelpMenuGroup(LocalizedStrings.Get("KEYMAPPING_PREFERENCES_SECTION_HEADER_MENU_SUFFIX_title", new object[1] { LocalizedStrings.Get("MAIN_MENU_HELP_MENU_title") }), this, flagService, versionInfoProvider);
		AddGroup(HelpMenu);
		ClearGroups = new ClearGroupGroup(LocalizedStrings.Get("MAIN_MENU_PRESENTATION_CLEAR_GROUPS_title"), this);
		AddGroup(ClearGroups);
		GroupLabels = new GroupLabelGroup(LocalizedStrings.Get("PRESENTATION_HEADER_ARRANGEMENTS_GROUPS_label"), this);
		AddGroup(GroupLabels);
		Macros = new MacroGroup(LocalizedStrings.Get("MAIN_MENU_VIEW_MACROS_title"), this);
		MacroGroups = new MacroGroupsGroup(LocalizedStrings.Get("MAIN_MENU_VIEW_MACROS_title"), this);
		AddGroup(MacroGroups);
		Props = new PropGroup(LocalizedStrings.Get("MAIN_MENU_VIEW_PROPS_title"), this);
		PropGroups = new PropsGroupsGroup(LocalizedStrings.Get("MAIN_MENU_VIEW_PROPS_title"), this);
		AddGroup(PropGroups);
		_flagService = flagService;
		_syncDataFactory = syncDataFactory;
		_factoryProvider = factoryProvider;
		_loadLegacy = loadLegacy;
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
			_syncer = _factoryProvider.EntityDocumentSyncerFactory.CreateConfigurationSyncer("KeyMappings", (IKeyMappingDocumentDoc doc) => Bind(_factoryProvider.EntityFactory, doc), () => Serialize().ToByteArray(), Deserialize, LoadDefaults, loadLegacy);
		}
		else
		{
			_syncedData = _syncDataFactory.GetSyncedData<KeyMappingDocument>(CommonPaths.Configuration, "KeyMappings", Deserialize, SyncedDataCleared);
		}
	}

	private void LoadDefaults()
	{
		SyncedDataCleared(DataClearSource.FileRemoved);
	}

	private KeyMappingDocument Serialize()
	{
		KeyMappingDocument keyMappingDocument = new KeyMappingDocument
		{
			ApplicationInfo = new ApplicationData(ApplicationType.ProPresenter).Serialize()
		};
		keyMappingDocument.Keymappings.AddRange(ProMenu.Serialize());
		keyMappingDocument.Keymappings.AddRange(FileMenu.Serialize());
		keyMappingDocument.Keymappings.AddRange(EditMenu.Serialize());
		keyMappingDocument.Keymappings.AddRange(PresentationMenu.Serialize());
		keyMappingDocument.Keymappings.AddRange(ReflowMenu.Serialize());
		keyMappingDocument.Keymappings.AddRange(EditorMenu.Serialize());
		keyMappingDocument.Keymappings.AddRange(ScreensMenu.Serialize());
		keyMappingDocument.Keymappings.AddRange(CalendarMenu.Serialize());
		keyMappingDocument.Keymappings.AddRange(ViewMenu.Serialize());
		keyMappingDocument.Keymappings.AddRange(WindowMenu.Serialize());
		keyMappingDocument.Keymappings.AddRange(HelpMenu.Serialize());
		keyMappingDocument.Keymappings.AddRange(ClearGroups.Serialize());
		keyMappingDocument.Keymappings.AddRange(GroupLabels.Serialize());
		if (base.Collection.Contains(Macros))
		{
			keyMappingDocument.Keymappings.AddRange(Macros.Serialize());
		}
		else
		{
			keyMappingDocument.Keymappings.AddRange(MacroGroups.SerializeGroups().NonNull());
		}
		if (base.Collection.Contains(Props))
		{
			keyMappingDocument.Keymappings.AddRange(Props.Serialize());
		}
		else
		{
			keyMappingDocument.Keymappings.AddRange(PropGroups.SerializeGroups().NonNull());
		}
		return keyMappingDocument;
	}

	private void Deserialize(byte[] data)
	{
		KeyMappingDocument document = KeyMappingDocument.Parser.ParseFrom(data);
		Deserialize(document);
	}

	public void Deserialize(KeyMappingDocument document)
	{
		KeyMapping[] protoKeyMappings = document.Keymappings.Where((KeyMapping k) => k.MenuItem != null).ToArray();
		ProMenu.DeserializeMenu(protoKeyMappings);
		FileMenu.DeserializeMenu(protoKeyMappings);
		EditMenu.DeserializeMenu(protoKeyMappings);
		PresentationMenu.DeserializeMenu(protoKeyMappings);
		ReflowMenu.DeserializeMenu(protoKeyMappings);
		EditorMenu.DeserializeMenu(protoKeyMappings);
		ScreensMenu.DeserializeMenu(protoKeyMappings);
		CalendarMenu.DeserializeMenu(protoKeyMappings);
		ViewMenu.DeserializeMenu(protoKeyMappings);
		WindowMenu.Deserialize(protoKeyMappings);
		HelpMenu.DeserializeMenu(protoKeyMappings);
		ClearGroups.Deserialize(document.Keymappings.Where((KeyMapping k) => k.ClearGroupIdentifier != null));
		GroupLabels.Deserialize(document.Keymappings.Where((KeyMapping k) => k.GroupIdentifier != null));
		if (base.Collection.Contains(Macros))
		{
			Macros.Deserialize(document.Keymappings.Where((KeyMapping k) => k.MacroIdentifier != null));
		}
		else
		{
			MacroGroups.Deserialize(document.Keymappings.Where((KeyMapping k) => k.MacroIdentifier != null));
		}
		if (base.Collection.Contains(Props))
		{
			Props.Deserialize(document.Keymappings.Where((KeyMapping k) => k.PropIdentifier != null));
		}
		else
		{
			PropGroups.Deserialize(document.Keymappings.Where((KeyMapping k) => k.PropIdentifier != null));
		}
	}

	private void SyncedDataCleared(DataClearSource dataClearSource)
	{
		if (dataClearSource == DataClearSource.FileRemoved)
		{
			_ignoreChanges = true;
			ResetAll();
			_ignoreChanges = false;
		}
	}

	public void ResetAll()
	{
		UndoStack.StartIgnoring();
		ProMenu.Reset();
		FileMenu.Reset();
		EditMenu.Reset();
		PresentationMenu.Reset();
		ReflowMenu.Reset();
		EditorMenu.Reset();
		ScreensMenu.Reset();
		CalendarMenu.Reset();
		ViewMenu.Reset();
		WindowMenu.Reset();
		HelpMenu.Reset();
		ClearGroups.Reset();
		GroupLabels.Reset();
		Macros.Reset();
		MacroGroups.Reset();
		Props.Reset();
		PropGroups.Reset();
		UndoStack.StopIgnoring();
	}

	private void AddGroup(InputActionGroupBase group)
	{
		AddInputActionGroup(group);
		group.DataModified += OnDataModified;
	}

	private void OnDataModified()
	{
		if (!_ignoreChanges)
		{
			_syncedData?.UpdateData(Serialize());
		}
	}

	public void InitializeShowGroups()
	{
		_ignoreChanges = true;
		ClearGroups.Initialize(DataVault.ClearGroups);
		GroupLabels.Initialize(DataVault.GroupLabels);
		Macros.Initialize(DataVault.MacroSource);
		MacroGroups.Initilalize(DataVault.MacroGroups);
		Props.Initialize(DataVault.PropCueCollection);
		PropGroups.Initilalize(DataVault.PropGroupCollection);
		WindowMenu.InitializeWindowedOutput(OutputVault.AudienceScreenArrangementCollection, OutputVault.StageScreenArrangementCollection);
		SetupDocumentSyncer(_loadLegacy);
		ChangeDirectoryPrompt.RegisterDelegate(new ChangeDirectoryListener(TeardownDocumentSyncer, SetupDocumentSyncer));
		_ignoreChanges = false;
	}

	public Pro.CoreApplication.Document.IDocument? GetDocument()
	{
		if (_syncer == null)
		{
			return null;
		}
		return new KeyMappingsDocument(_syncer.Document.ExportFullSnapshot(), _syncer.Id);
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
			OnDispose();
			_syncedData?.Dispose();
			_syncer?.Dispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		ChangeDirectoryPrompt.UnregisterDelegate(new ChangeDirectoryListener(TeardownDocumentSyncer, SetupDocumentSyncer));
	}
}
