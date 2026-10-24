using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Localization;
using Pro.UI.Controls.Windowing;
using Pro.UI.Utility;
using ProPresenter.UI.ViewModels.Workspaces;
using ProPresenter.UI.Workspaces;

namespace ProPresenter.UI.CloudWorkspaces;

public partial class ManageCloudWorkspacesWindow : ChromedWindow, IComponentConnector
{
	private ContextMenu _emptySpaceContextMenu;

	public ManageCloudWorkspacesWindow()
	{
		InitializeComponent();
		_emptySpaceContextMenu = new ContextMenu();
	}

	private void ManageCloudWorkspacesWindow_Loaded(object sender, RoutedEventArgs e)
	{
		if (base.DataContext is IWorkspacesVM workspacesVM)
		{
			_emptySpaceContextMenu.Items.Add(new MenuItem
			{
				Header = LocalizedStrings.Get("LOCALWORKSPACE_CREATE_NEW_WORKSPACE_MENU_ITEM_NO_ELLIPSIS_title"),
				Command = workspacesVM.CreateWorkspaceCommand
			});
			_emptySpaceContextMenu.Items.Add(new MenuItem
			{
				Header = LocalizedStrings.Get("LOCALWORKSPACE_IMPORT_LEGACY_FOLDER_MENU_ITEM_title"),
				Command = workspacesVM.ImportSelectedLegacyFolderToWorkspaceCommand
			});
		}
		WorkspacesListBox.AddHandler(UIElement.PreviewMouseRightButtonDownEvent, new MouseButtonEventHandler(WorkspacesListBox_OnMouseRightButtonDown), handledEventsToo: true);
		WorkspacesListBox.Focus();
	}

	private void WorkspacesListBox_OnMouseRightButtonDown(object sender, MouseButtonEventArgs e)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		if (sender is WorkspacesListBox workspacesListBox)
		{
			Point position = e.GetPosition(workspacesListBox);
			if (DependencyObjectExtensions.FindVisualParent<ListBoxItem>((DependencyObject)workspacesListBox.InputHitTest(position)) == null)
			{
				_emptySpaceContextMenu.PlacementTarget = workspacesListBox;
				_emptySpaceContextMenu.Placement = PlacementMode.MousePoint;
				_emptySpaceContextMenu.IsOpen = true;
				e.Handled = true;
			}
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
