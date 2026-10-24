using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.DO.Transitions;
using Pro.Localization;
using Pro.Text;
using Pro.UI.Components;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO;
using ProPresenter.DO.Slide;
using ProPresenter.DO.Slide.Builds;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.UI.ViewModels.Editor;

namespace ProPresenter.ViewModels.Editor;

public class BuildInspectorVM : NotifyPropertyChangedBase, IBuildInspectorVM
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003C_003Ec__DisplayClass100_0
	{
		public bool isBuildIn;

		public BuildInspectorVM _003C_003E4__this;
	}

	[CompilerGenerated]
	private sealed class _003CAddBuild_003Ed__100 : IEnumerable<Build>, IEnumerable, IEnumerator<Build>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private Build _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private bool isBuildIn;

		public bool _003C_003E3__isBuildIn;

		public BuildInspectorVM _003C_003E4__this;

		private _003C_003Ec__DisplayClass100_0 _003C_003E8__1;

		private TransitionParameters transition;

		public TransitionParameters _003C_003E3__transition;

		private IEnumerator<SlideElementBase> _003C_003E7__wrap1;

		Build IEnumerator<Build>.Current
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
		public _003CAddBuild_003Ed__100(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003C_003E8__1 = default(_003C_003Ec__DisplayClass100_0);
			_003C_003E7__wrap1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			try
			{
				int num = _003C_003E1__state;
				BuildInspectorVM buildInspectorVM = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E8__1.isBuildIn = isBuildIn;
					_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
					if (buildInspectorVM.Builds == null)
					{
						return false;
					}
					buildInspectorVM.UndoStack?.BeginCommit((_003C_003E8__1.isBuildIn ? UndoActionTypes.AddBuildIn : UndoActionTypes.AddBuildOut).ToAction());
					_003C_003E7__wrap1 = buildInspectorVM.SelectedElements.GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					break;
				}
				while (_003C_003E7__wrap1.MoveNext())
				{
					SlideElementBase current = _003C_003E7__wrap1.Current;
					if ((_003C_003E8__1.isBuildIn ? current.BuildIn : current.BuildOut) == null)
					{
						_003C_003E2__current = buildInspectorVM._003CAddBuild_003Eg__addAction_007C100_0(ref _003C_003E8__1)(current, transition);
						_003C_003E1__state = 1;
						return true;
					}
					Build build = (_003C_003E8__1.isBuildIn ? current.BuildIn : current.BuildOut);
					if (build != null)
					{
						build.SelectedTransition = transition;
					}
				}
				_003C_003Em__Finally1();
				_003C_003E7__wrap1 = null;
				buildInspectorVM.UndoStack?.EndCommit(null, null, autoFinalize: true);
				return false;
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

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<Build> IEnumerable<Build>.GetEnumerator()
		{
			_003CAddBuild_003Ed__100 _003CAddBuild_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CAddBuild_003Ed__ = this;
			}
			else
			{
				_003CAddBuild_003Ed__ = new _003CAddBuild_003Ed__100(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			_003CAddBuild_003Ed__.transition = _003C_003E3__transition;
			_003CAddBuild_003Ed__.isBuildIn = _003C_003E3__isBuildIn;
			return _003CAddBuild_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Build>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	private sealed class _003Cget_AvailableStartMode_003Ed__59 : IEnumerable<StartMode>, IEnumerable, IEnumerator<StartMode>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private StartMode _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public BuildInspectorVM _003C_003E4__this;

		StartMode IEnumerator<StartMode>.Current
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
		public _003Cget_AvailableStartMode_003Ed__59(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			BuildInspectorVM CS_0024_003C_003E8__locals8 = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				if (CS_0024_003C_003E8__locals8.Builds == null || CS_0024_003C_003E8__locals8.Builds.Empty() || CS_0024_003C_003E8__locals8.SelectedBuilds.Empty())
				{
					return false;
				}
				if (CS_0024_003C_003E8__locals8.EditMode == EditMode.Presentation)
				{
					_003C_003E2__current = StartMode.OnClick;
					_003C_003E1__state = 1;
					return true;
				}
				goto IL_0074;
			case 1:
				_003C_003E1__state = -1;
				goto IL_0074;
			case 2:
				_003C_003E1__state = -1;
				goto IL_009e;
			case 3:
				_003C_003E1__state = -1;
				if (CS_0024_003C_003E8__locals8.SelectedBuilds.All((IBuild b) => b is Build { IsBuildIn: not false } build && build == CS_0024_003C_003E8__locals8.Builds.First()))
				{
					_003C_003E2__current = StartMode.WithSlide;
					_003C_003E1__state = 4;
					return true;
				}
				break;
			case 4:
				{
					_003C_003E1__state = -1;
					break;
				}
				IL_009e:
				_003C_003E2__current = StartMode.AfterPrevious;
				_003C_003E1__state = 3;
				return true;
				IL_0074:
				if (CS_0024_003C_003E8__locals8.SelectedBuild != CS_0024_003C_003E8__locals8.Builds.First())
				{
					_003C_003E2__current = StartMode.WithPrevious;
					_003C_003E1__state = 2;
					return true;
				}
				goto IL_009e;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<StartMode> IEnumerable<StartMode>.GetEnumerator()
		{
			_003Cget_AvailableStartMode_003Ed__59 result;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				result = this;
			}
			else
			{
				result = new _003Cget_AvailableStartMode_003Ed__59(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			return result;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<StartMode>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	private sealed class _003Cget_BuildFromPoints_003Ed__29 : IEnumerable<IBuild>, IEnumerable, IEnumerator<IBuild>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private IBuild _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public BuildInspectorVM _003C_003E4__this;

		private IEnumerator<ChildBuild> _003C_003E7__wrap1;

		IBuild IEnumerator<IBuild>.Current
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
		public _003Cget_BuildFromPoints_003Ed__29(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if (num == -3 || num == 2)
			{
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003C_003E7__wrap1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			try
			{
				int num = _003C_003E1__state;
				BuildInspectorVM buildInspectorVM = _003C_003E4__this;
				IEnumerable<ChildBuild> enumerable;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					if (!buildInspectorVM.ShowBuildFrom)
					{
						return false;
					}
					if (buildInspectorVM.SelectedElement?.BuildIn != null)
					{
						_003C_003E2__current = buildInspectorVM.SelectedElement.BuildIn;
						_003C_003E1__state = 1;
						return true;
					}
					goto IL_0077;
				case 1:
					_003C_003E1__state = -1;
					goto IL_0077;
				case 2:
					{
						_003C_003E1__state = -3;
						break;
					}
					IL_0077:
					enumerable = (buildInspectorVM.SelectedElement as ClosedBezierPath)?.ChildBuilds;
					_003C_003E7__wrap1 = (enumerable ?? Enumerable.Empty<ChildBuild>()).GetEnumerator();
					_003C_003E1__state = -3;
					break;
				}
				if (_003C_003E7__wrap1.MoveNext())
				{
					ChildBuild current = _003C_003E7__wrap1.Current;
					_003C_003E2__current = current;
					_003C_003E1__state = 2;
					return true;
				}
				_003C_003Em__Finally1();
				_003C_003E7__wrap1 = null;
				return false;
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

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<IBuild> IEnumerable<IBuild>.GetEnumerator()
		{
			_003Cget_BuildFromPoints_003Ed__29 result;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				result = this;
			}
			else
			{
				result = new _003Cget_BuildFromPoints_003Ed__29(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			return result;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<IBuild>)this).GetEnumerator();
		}
	}

	private readonly IBuildInspectorPrompt _prompt;

	private CustomSlide? _selectedSlide;

	private BuildCollection? _builds;

	private bool _ignoreSelectionChanges;

	private EditMode _editMode;

	private UndoStack? UndoStack => Builds?.UndoStack;

	private IBuild? SelectedBuild => SelectedBuilds.FirstOrDefault();

	public SlideElementBase? SelectedElement => SelectedElements.FirstOrDefault();

	public CustomSlide? SelectedSlide
	{
		get
		{
			return _selectedSlide;
		}
		set
		{
			SetValue<CustomSlide>("SelectedSlide", ref _selectedSlide, value, delegate(CustomSlide o, CustomSlide n)
			{
				SlideTransitionHandler.ActivateTransition(n?.SelectedTransition);
			});
		}
	}

	public BuildCollection? Builds
	{
		get
		{
			return _builds;
		}
		set
		{
			SetValue<BuildCollection>("Builds", ref _builds, value, delegate(BuildCollection o, BuildCollection n)
			{
				if (o != null)
				{
					o.BuildPropertyChanged -= OnBuildChanged;
					o.CollectionChanged -= Builds_CollectionChanged;
				}
				if (n != null)
				{
					n.BuildPropertyChanged += OnBuildChanged;
					n.CollectionChanged += Builds_CollectionChanged;
					UpdateBuildGroups();
					RebuildIndexMap();
				}
			});
		}
	}

	public ObservableCollection<SlideElementBase> SelectedElements { get; }

	public ObservableCollection<ObservableCollection<IBuild>> BuildGroups { get; } = new ObservableCollection<ObservableCollection<IBuild>>();

	public ObservableCollection<IBuild> SelectedBuilds { get; } = new ObservableCollection<IBuild>();

	public bool ShowBuildFrom
	{
		get
		{
			if (EditMode != EditMode.Template)
			{
				if (SelectedElement is ClosedBezierPath closedBezierPath)
				{
					return closedBezierPath.ChildBuilds.Any();
				}
				return false;
			}
			return Delivery == RevealType.Underline;
		}
	}

	public IEnumerable<IBuild> BuildFromPoints
	{
		[IteratorStateMachine(typeof(_003Cget_BuildFromPoints_003Ed__29))]
		get
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003Cget_BuildFromPoints_003Ed__29(-2)
			{
				_003C_003E4__this = this
			};
		}
	}

	public IBuild? SelectedBuildFromPoint
	{
		get
		{
			if (!(SelectedElement is ClosedBezierPath closedBezierPath))
			{
				return null;
			}
			IBuild build = closedBezierPath.ChildBuilds.ElementAtOrDefault(closedBezierPath.RevealFromIndex - 1);
			return build ?? closedBezierPath.BuildIn;
		}
		private set
		{
			if (SelectedElement is ClosedBezierPath closedBezierPath)
			{
				closedBezierPath.RevealFromIndex = closedBezierPath.ChildBuilds.IndexOf(value) + 1;
				OnPropertyChanged("SelectedBuildFromPoint");
			}
		}
	}

	public bool AnySelectedBuilds => SelectedBuilds.Any();

	public ssAPIOutput OutputController { get; }

	public TransitionHandler BuildInTransitionHandler { get; } = new TransitionHandler(DataVault.Transitions);

	public TransitionHandler BuildOutTransitionHandler { get; } = new TransitionHandler(DataVault.Transitions);

	public TransitionHandler SlideTransitionHandler { get; } = new TransitionHandler(DataVault.Transitions);

	public TransitionParameters? BuildInTransition
	{
		get
		{
			TransitionParameters transitionParameters = SelectedElement?.BuildIn?.SelectedTransition;
			BuildInTransitionHandler.ActivateTransition(transitionParameters);
			return transitionParameters;
		}
		set
		{
			if (!(SelectedElement?.BuildIn?.SelectedTransition == value))
			{
				if (value == null)
				{
					RemoveBuild(isBuildIn: true);
				}
				else
				{
					SelectBuilds(AddBuild(value, isBuildIn: true).ToArray());
				}
				UpdateStartMode();
				NotifyPropertyChanges();
			}
		}
	}

	public TransitionParameters? BuildOutTransition
	{
		get
		{
			TransitionParameters transitionParameters = SelectedElement?.BuildOut?.SelectedTransition;
			BuildOutTransitionHandler.ActivateTransition(transitionParameters);
			return transitionParameters;
		}
		set
		{
			if (!(SelectedElement?.BuildOut?.SelectedTransition == value))
			{
				if (value == null)
				{
					RemoveBuild(isBuildIn: false);
				}
				else
				{
					SelectBuilds(AddBuild(value, isBuildIn: false).ToArray());
				}
				UpdateStartMode();
				NotifyPropertyChanges();
			}
		}
	}

	public RevealType Delivery
	{
		get
		{
			return SelectedElement?.RevealType ?? RevealType.None;
		}
		private set
		{
			bool flag = false;
			bool flag2 = false;
			if (value != 0)
			{
				if (SelectedElements.AnyOf((ClosedBezierPath e) => e.TextScroller.ShouldScrollText))
				{
					flag = true;
					if (!_prompt.ConfirmRemoveTextScrolling())
					{
						return;
					}
				}
				if (SelectedElements.OfType<ClosedBezierPath>().Any((ClosedBezierPath e) => e.Text.Any((Paragraph p) => p.Any(checkTextFillIncompatible))))
				{
					flag2 = true;
					if (!_prompt.ConfirmRemoveTextFill())
					{
						return;
					}
				}
			}
			UndoStack?.BeginCommit(UndoActionTypes.ElementRevealType.ToAction());
			List<Build> list = new List<Build>();
			foreach (SlideElementBase selectedElement in SelectedElements)
			{
				if (Builds != null && selectedElement.BuildIn == null)
				{
					list.Add(Builds.AddBuildIn(selectedElement, BuildInTransitionHandler.Set.CutTransition?.Preset.Parameters));
				}
				selectedElement.RevealType = value;
				if (!(selectedElement is ClosedBezierPath closedBezierPath))
				{
					continue;
				}
				if (flag)
				{
					closedBezierPath.TextScroller.ShouldScrollText = false;
				}
				if (!flag2)
				{
					continue;
				}
				closedBezierPath.Text.IterateRuns(Pro.Text.Range.All, splitRuns: true, delegate(RunBase r)
				{
					if (checkTextFillIncompatible(r))
					{
						r.Settings.Fill = new SolidTextFill();
					}
				});
			}
			SelectedBuilds.AddRange(list);
			UpdateStartMode();
			UndoStack?.EndCommit(null, null, autoFinalize: true);
			OnPropertyChanged("Delivery");
			OnPropertyChanged("SelectedBuildFromPoint");
			OnPropertyChanged("ShowBuildFrom");
			static bool checkTextFillIncompatible(RunBase run)
			{
				return run.Settings.Fill.TextFillType.IsAnyOf(TextFillType.CutOut);
			}
		}
	}

	public bool ShowDelivery => SelectedElement?.BuildIn != null;

	public IEnumerable<StartMode> AvailableStartMode
	{
		[IteratorStateMachine(typeof(_003Cget_AvailableStartMode_003Ed__59))]
		get
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003Cget_AvailableStartMode_003Ed__59(-2)
			{
				_003C_003E4__this = this
			};
		}
	}

	public StartMode Start
	{
		get
		{
			return SelectedBuild?.Start ?? StartMode.OnClick;
		}
		set
		{
			UndoStack?.BeginCommit(UndoActionTypes.BuildStartMode.ToAction());
			SelectedBuilds.ForEach(delegate(IBuild b)
			{
				b.Start = value;
			});
			if (Builds != null && value == StartMode.WithSlide)
			{
				Builds.ArrangeBuildOrder(Builds.Where((IBuild b) => b.Start == StartMode.WithSlide).ToArray(), 0, isInside: true, isHead: false, isTheSameGroup: true);
			}
			UndoStack?.EndCommit(null, null, autoFinalize: true);
			OnPropertyChanged("Start");
		}
	}

	public TimeSlice Delay
	{
		get
		{
			return SelectedBuild?.Delay ?? TimeSlice.Zero;
		}
		set
		{
			UndoStack?.BeginCommit(UndoActionTypes.BuildDelay.ToAction());
			SelectedBuilds.ForEach(delegate(IBuild b)
			{
				b.Delay = value;
			});
			UndoStack?.EndCommit(null, delegate
			{
				OnPropertyChanged("Delay");
			});
			OnPropertyChanged("Delay");
		}
	}

	public Dictionary<IBuild, int> BuildIndexMap { get; } = new Dictionary<IBuild, int>();

	public bool IsBuild => SelectedElements.Any();

	public EditMode EditMode
	{
		get
		{
			return _editMode;
		}
		set
		{
			SetValue("EditMode", ref _editMode, value, null, false, "AvailableStartMode");
		}
	}

	public IBuild? FirstChildBuild => (SelectedElement as ClosedBezierPath)?.ChildBuilds.FirstOrDefault();

	public string SelectedTemplateBuildName => (from i in RevealFromIndexMenuItems
		where i.IsChecked
		select i.Header).FirstOrDefault() ?? string.Empty;

	public IEnumerable<RevealFromIndexMenuItemVM> RevealFromIndexMenuItems { get; private set; }

	public ICommand<IBuild> SelectBuildsCommand => new RelayCommand<IBuild>(OnSelectBuildsCommand);

	public ICommand<StartMode> SelectStartModeCommand => new RelayCommand<StartMode>(delegate(StartMode s)
	{
		Start = s;
	});

	public ICommand<IBuild> ChangeRevealFromIndexCommand => new RelayCommand<IBuild>(delegate(IBuild b)
	{
		SelectedBuildFromPoint = b;
	}, (IBuild b) => SelectedElement is ClosedBezierPath);

	public ICommand<RevealType> ChangeDeliveryCommand => new RelayCommand<RevealType>(delegate(RevealType r)
	{
		Delivery = r;
	});

	public ICommand DeleteBuildsCommand => new RelayCommand(OnDeleteBuildsCommand, ((IEnumerable)SelectedBuilds).AnyOf<Build>);

	public ICommand ChangeThemeRevealFromIndexCommand => new RelayCommand<int>(OnChangeThemeRevealFromIndexCommand);

	public BuildInspectorVM(ObservableCollection<SlideElementBase> selectedElements, ssAPIOutput outputController, IBuildInspectorPrompt? prompt = null)
	{
		_prompt = prompt ?? new BuildInspectorPrompt();
		SelectedElements = selectedElements;
		OutputController = outputController;
		SelectedElements.CollectionChanged += OnSelectedElementsChanged;
		BuildInTransitionHandler.TransitionFinalized += delegate(TransitionParameters? t)
		{
			BuildInTransition = t;
		};
		BuildOutTransitionHandler.TransitionFinalized += delegate(TransitionParameters? t)
		{
			BuildOutTransition = t;
		};
		SlideTransitionHandler.TransitionFinalized += delegate(TransitionParameters? t)
		{
			if (SelectedSlide != null)
			{
				SelectedSlide.SelectedTransition = t;
			}
		};
		InitializeThemeRevealFromIndexMenu();
	}

	public void SelectBuilds(IEnumerable<IBuild> builds)
	{
		if (builds != null && !builds.Empty())
		{
			SelectedBuilds.Clear();
			SelectedBuilds.AddRange(builds);
			NotifyPropertyChanges();
		}
	}

	[MemberNotNull("RevealFromIndexMenuItems")]
	private void InitializeThemeRevealFromIndexMenu()
	{
		RevealFromIndexMenuItems = new List<RevealFromIndexMenuItemVM>
		{
			new RevealFromIndexMenuItemVM
			{
				Command = ChangeThemeRevealFromIndexCommand,
				Header = LocalizedStrings.Get("TRANSITIONS_BUILD_FROM_NON_UNDERLINED_MENU_ITEM_title"),
				Index = 0
			},
			new RevealFromIndexMenuItemVM
			{
				Command = ChangeThemeRevealFromIndexCommand,
				Header = LocalizedStrings.Get("TRANSITIONS_BUILD_FROM_FIRST_UNDERLINE_MENU_ITEM_title"),
				Index = 1
			}
		};
	}

	private void OnSelectedElementsChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (_ignoreSelectionChanges)
		{
			return;
		}
		switch (e.Action)
		{
		case NotifyCollectionChangedAction.Add:
			e.NewItems?.OfType<SlideElementBase>().ForEach(delegate(SlideElementBase s)
			{
				SelectedBuilds.AddRange(s.AllBuilds);
			});
			break;
		case NotifyCollectionChangedAction.Remove:
			e.OldItems?.OfType<SlideElementBase>().ForEach(delegate(SlideElementBase s)
			{
				SelectedBuilds.RemoveRange(s.AllBuilds);
			});
			break;
		case NotifyCollectionChangedAction.Reset:
			SelectedBuilds.Clear();
			break;
		}
		NotifyPropertyChanges();
	}

	private void OnSelectBuildsCommand(IBuild build)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		_ignoreSelectionChanges = true;
		IBuild[] array = ((Builds == null) ? Array.Empty<IBuild>() : SelectionHelper<IBuild>.FindSelectedItems(Builds, SelectedBuilds, build, Keyboard.Modifiers).ToArray());
		SelectedElements.Clear();
		SelectedElements.AddRange(array.Select((IBuild b) => b.Element).Distinct());
		SelectBuilds(array);
		_ignoreSelectionChanges = false;
	}

	private void OnDeleteBuildsCommand()
	{
		if (Builds != null)
		{
			UndoStack?.BeginCommit(UndoActionTypes.RemoveBuild.ToAction());
			SelectedBuilds.OfType<Build>().ToArray().ForEach(delegate(Build b)
			{
				GetRemoveBuildAction(b.IsBuildIn)(b.Element);
			});
			UndoStack?.EndCommit(null, null, autoFinalize: true);
			SelectedBuilds.Clear();
			NotifyPropertyChanges();
		}
		Action<SlideElementBase> GetRemoveBuildAction(bool isBuildIn)
		{
			if (!isBuildIn)
			{
				return Builds.RemoveBuildOut;
			}
			return Builds.RemoveBuildIn;
		}
	}

	[IteratorStateMachine(typeof(_003CAddBuild_003Ed__100))]
	private IEnumerable<Build> AddBuild(TransitionParameters transition, bool isBuildIn)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CAddBuild_003Ed__100(-2)
		{
			_003C_003E4__this = this,
			_003C_003E3__transition = transition,
			_003C_003E3__isBuildIn = isBuildIn
		};
	}

	private void RemoveBuild(bool isBuildIn)
	{
		if (Builds != null)
		{
			UndoStack?.BeginCommit((isBuildIn ? UndoActionTypes.RemoveBuildIn : UndoActionTypes.RemoveBuildOut).ToAction());
			SelectedElements.ForEach(GetRemoveBuildAction(isBuildIn));
			SelectedBuilds.RemoveIf((object? b) => !Builds.Contains(b));
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
		Action<SlideElementBase> GetRemoveBuildAction(bool isBuildIn)
		{
			if (!isBuildIn)
			{
				return Builds.RemoveBuildOut;
			}
			return Builds.RemoveBuildIn;
		}
	}

	private void NotifyPropertyChanges()
	{
		OnPropertyChanged("AvailableStartMode");
		OnPropertyChanged("SelectedBuilds");
		OnPropertyChanged("AnySelectedBuilds");
		OnPropertyChanged("BuildInTransition");
		OnPropertyChanged("BuildOutTransition");
		OnPropertyChanged("Start");
		OnPropertyChanged("Delay");
		OnPropertyChanged("Delivery");
		OnPropertyChanged("ShowDelivery");
		OnPropertyChanged("BuildFromPoints");
		OnPropertyChanged("SelectedBuildFromPoint");
		OnPropertyChanged("ShowBuildFrom");
		OnPropertyChanged("IsBuild");
		OnPropertyChanged("SelectedElement");
		OnPropertyChanged("FirstChildBuild");
		UpdateThemeRevealFromIndexMenu();
	}

	private void UpdateThemeRevealFromIndexMenu()
	{
		RevealFromIndexMenuItems.ForEach(delegate(RevealFromIndexMenuItemVM i)
		{
			i.IsChecked = false;
		});
		int num = (SelectedElement as ClosedBezierPath)?.RevealFromIndex ?? 0;
		if (num > 1)
		{
			num = 0;
		}
		RevealFromIndexMenuItems.ElementAt(num).IsChecked = true;
		OnPropertyChanged("SelectedTemplateBuildName");
	}

	private void OnBuildChanged()
	{
		UpdateBuildGroups();
		RebuildIndexMap();
		NotifyPropertyChanges();
	}

	private void Builds_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<IBuild>().ForEach(delegate(IBuild b)
		{
			SelectedBuilds.Remove(b);
		});
		e.NewItems?.OfType<IBuild>().ForEach(delegate(IBuild b)
		{
			SelectedBuilds.Add(b);
		});
		OnBuildChanged();
	}

	private void UpdateBuildGroups()
	{
		BuildGroups.Clear();
		ObservableCollection<IBuild> observableCollection = null;
		IEnumerable<IBuild> builds = Builds;
		foreach (IBuild item in builds ?? Enumerable.Empty<IBuild>())
		{
			if (observableCollection == null || item.Start == StartMode.OnClick)
			{
				observableCollection = new ObservableCollection<IBuild>();
				BuildGroups.Add(observableCollection);
			}
			observableCollection.Add(item);
		}
	}

	private void RebuildIndexMap()
	{
		BuildIndexMap.Clear();
		int num = 0;
		IEnumerable<IBuild> builds = Builds;
		foreach (IBuild item in builds ?? Enumerable.Empty<IBuild>())
		{
			BuildIndexMap.Add(item, ++num);
		}
		OnPropertyChanged("BuildIndexMap");
	}

	private void UpdateStartMode()
	{
		SelectedBuilds.Where((IBuild b) => b.Start == StartMode.OnClick && (EditMode == EditMode.CCLITemplate || EditMode == EditMode.Prop)).ForEach(delegate(IBuild b)
		{
			b.Start = StartMode.AfterPrevious;
		});
	}

	private void OnChangeThemeRevealFromIndexCommand(int index)
	{
		if (SelectedElement is ClosedBezierPath closedBezierPath)
		{
			closedBezierPath.RevealFromIndex = index;
			UpdateThemeRevealFromIndexMenu();
		}
	}

	[CompilerGenerated]
	private Func<SlideElementBase, TransitionParameters, Build> _003CAddBuild_003Eg__addAction_007C100_0(ref _003C_003Ec__DisplayClass100_0 P_0)
	{
		if (!P_0.isBuildIn)
		{
			return Builds.AddBuildOut;
		}
		return Builds.AddBuildIn;
	}
}
