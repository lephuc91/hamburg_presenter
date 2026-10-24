using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;
using Pro.Common.Collections;
using Pro.Common.Logging;
using Pro.Common.Win32;
using Pro.UI.Commands;
using Pro.UI.Controls.Windowing;
using Pro.UI.DependencyInjection;
using Pro.UI.DragDropHelper;
using Pro.UI.InputActions;
using Pro.UI.Utility;
using ProPresenter.DO.InputActionMap;
using ProPresenter.UI.ViewModels.QuickSearch;

namespace ProPresenter.UI.Search;

public partial class QuickSearchWindow : ChromedWindow, IComponentConnector
{
	private IQuickSearchPageVM? _lastActivePage;

	public QuickSearchWindow()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		IInputActions service = UIServiceProvider.GetService<IInputActions>();
		InitializeComponent();
		base.DataContextChanged += new DependencyPropertyChangedEventHandler(QuickSearchWindow_DataContextChanged);
		DragSource.DragCompleted += delegate
		{
			if (base.IsVisible)
			{
				Focus();
				(base.DataContext as IQuickSearchVM)?.ActivePage?.DragCompleted();
			}
		};
		CommonInputActionGroup commonInputActions = service.CommonInputActions;
		CommandManager.RegisterClassInputBinding(typeof(TextBox), new InputBinding(commonInputActions.NavigateUp.BindCommand, (commonInputActions.NavigateUp.BindCommand as RoutedCommand)?.InputGestures.OfType<KeyGesture>().FirstOrDefault()));
		CommandManager.RegisterClassInputBinding(typeof(TextBox), new InputBinding(commonInputActions.NavigateDown.BindCommand, (commonInputActions.NavigateDown.BindCommand as RoutedCommand)?.InputGestures.OfType<KeyGesture>().FirstOrDefault()));
	}

	protected override void OnSourceInitialized(EventArgs e)
	{
		base.OnSourceInitialized(e);
		WindowsFunctions.SetWindowLong(base.Handle, GWL.STYLE, (nint)(uint)((int)WindowsFunctions.GetWindowLong(base.Handle, GWL.STYLE) & -196609));
	}

	protected override void OnActivated(EventArgs e)
	{
		base.OnActivated(e);
		SearchBox.Focus();
		SearchBox.SelectAll();
	}

	protected override void OnDeactivated(EventArgs e)
	{
		base.OnDeactivated(e);
		CheckToCloseAsync();
	}

	private void OnLyricPreviewClosed(object? sender, EventArgs e)
	{
		CheckToCloseAsync();
	}

	private void OnLyricPreviewPopupDeactivated(object? sender, EventArgs e)
	{
		CheckToCloseAsync();
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)e.Key == 13)
		{
			CloseWindow();
		}
	}

	private void QuickSearchWindow_DataContextChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		if (((DependencyPropertyChangedEventArgs)(ref e)).OldValue is IQuickSearchVM quickSearchVM)
		{
			quickSearchVM.PropertyChanged -= OnQuickSearchPropertyChanged;
			quickSearchVM.CloseSearch -= CloseWindow;
			quickSearchVM.SelectAllText -= SearchBox.SelectAll;
			SetupCommandBindings(null);
		}
		object newValue = ((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		IQuickSearchVM newQuickSearchVM = newValue as IQuickSearchVM;
		if (newQuickSearchVM != null)
		{
			newQuickSearchVM.PropertyChanged += OnQuickSearchPropertyChanged;
			newQuickSearchVM.CloseSearch += CloseWindow;
			newQuickSearchVM.SelectAllText += SearchBox.SelectAll;
			base.CommandBindings.Add(CommonApplicationCommands.NavigateUpCommand, delegate
			{
				newQuickSearchVM.ActivePage?.Navigate(isForward: false);
			});
			base.CommandBindings.Add(CommonApplicationCommands.NavigateDownCommand, delegate
			{
				newQuickSearchVM.ActivePage?.Navigate(isForward: true);
			});
			SetupCommandBindings(newQuickSearchVM.ActivePage);
		}
	}

	private void OnQuickSearchPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (sender is IQuickSearchVM quickSearchVM && e.PropertyName == "ActivePage")
		{
			SetupCommandBindings(quickSearchVM.ActivePage);
		}
	}

	private void SetupCommandBindings(IQuickSearchPageVM? page)
	{
		ISearchCommandVM[] commandVMs;
		if (_lastActivePage != null)
		{
			commandVMs = _lastActivePage.PreviewVM.CommandVMs;
			foreach (ISearchCommandVM commandVM in commandVMs)
			{
				commandVM.PropertyChanged -= OnCommandPropertyChanged;
				base.CommandBindings.RemoveIf((object? c) => c is CommandBinding commandBinding && commandBinding.Command == commandVM.BindCommand);
			}
		}
		_lastActivePage = page;
		if (page == null)
		{
			return;
		}
		commandVMs = page.PreviewVM.CommandVMs;
		foreach (ISearchCommandVM searchCommandVM in commandVMs)
		{
			searchCommandVM.PropertyChanged += OnCommandPropertyChanged;
			if (searchCommandVM.IsVisible)
			{
				base.CommandBindings.Add(searchCommandVM.BindCommand, searchCommandVM.ExecuteCommand);
			}
		}
	}

	private void OnCommandPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		ISearchCommandVM commandVM = sender as ISearchCommandVM;
		if (commandVM == null || !(e.PropertyName == "IsVisible"))
		{
			return;
		}
		if (!commandVM.IsVisible)
		{
			base.CommandBindings.RemoveIf((object? c) => c is CommandBinding commandBinding && commandBinding.Command == commandVM.BindCommand);
		}
		else
		{
			base.CommandBindings.Add(commandVM.BindCommand, commandVM.ExecuteCommand);
		}
	}

	private void CloseWindow()
	{
		Hide();
		((DispatcherObject)this).Dispatcher.InvokeAsync<bool>((Func<bool>)Application.Current.MainWindow.Focus);
	}

	private void CheckToCloseAsync()
	{
		((DispatcherObject)this).Dispatcher.InvokeAsync((Action)delegate
		{
			try
			{
				if (!base.IsActive && !base.IsResizing && !((DependencyObject)(object)this).FindVisualChildren<ItemListBox>().Any((ItemListBox l) => l.IsDragging) && !base.OwnedWindows.AnyOf((Window w) => w.IsActive))
				{
					CloseWindow();
				}
			}
			catch (Exception arg)
			{
				Log.Debug($"Exception occured when closing QuickSearchWindow: {arg}");
			}
		});
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
