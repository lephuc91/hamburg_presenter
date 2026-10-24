using System;
using System.Collections.Generic;
using System.Windows.Input;
using Pro.UI.Components;
using Pro.UI.InputActions;

namespace Pro.UI.Commands;

public static class CommonApplicationCommands
{
	private static bool _initialized;

	public static ICommand NavigateUpCommand { get; private set; }

	public static ICommand SelectPreviousCommand { get; private set; }

	public static ICommand NavigateDownCommand { get; private set; }

	public static ICommand SelectNextCommand { get; private set; }

	public static ICommand CutCommand { get; private set; }

	public static ICommand PrintCommand { get; private set; }

	public static ICommand OpenCommand { get; private set; }

	public static ICommand SelectAllCommand { get; private set; }

	public static ICommand FindCommand { get; private set; }

	public static ICommand PasteAndMatchStyle { get; private set; }

	public static ICommand Duplicate { get; private set; }

	public static ICommand DeselectAll { get; private set; }

	public static ICommand Rename { get; private set; }

	public static ICommand SubmitCommand { get; private set; }

	public static ICommand UndoCommand { get; private set; }

	public static ICommand RedoCommand { get; private set; }

	public static ICommand Delete { get; private set; }

	public static ICommand Paste { get; private set; }

	public static ICommand Copy { get; private set; }

	public static ICommand ChangeOutputDestination { get; private set; }

	static CommonApplicationCommands()
	{
		ChangeOutputDestination = (Copy = (Paste = (Delete = (RedoCommand = (UndoCommand = (SubmitCommand = (Rename = (DeselectAll = (Duplicate = (PasteAndMatchStyle = (FindCommand = (SelectAllCommand = (OpenCommand = (PrintCommand = (CutCommand = (SelectNextCommand = (NavigateDownCommand = (SelectPreviousCommand = (NavigateUpCommand = new RelayCommand(delegate
		{
		}))))))))))))))))))));
	}

	public static InputGestureCollection AsCollection(this InputGesture gesture)
	{
		return new InputGestureCollection(new List<InputGesture> { gesture });
	}

	public static void InitializeCommands(CommonInputActionGroup group)
	{
		if (_initialized || group == null)
		{
			throw new InvalidOperationException();
		}
		_initialized = true;
		NavigateUpCommand = group.NavigateUp.BindCommand;
		SelectPreviousCommand = group.SelectPreviousCommand.BindCommand;
		NavigateDownCommand = group.NavigateDown.BindCommand;
		SelectNextCommand = group.SelectNextCommand.BindCommand;
		CutCommand = group.Cut.BindCommand;
		PrintCommand = group.Print.BindCommand;
		OpenCommand = group.Open.BindCommand;
		SelectAllCommand = group.SelectAll.BindCommand;
		FindCommand = group.Find.BindCommand;
		PasteAndMatchStyle = group.PasteAndMatchStyle.BindCommand;
		Duplicate = group.Duplicate.BindCommand;
		DeselectAll = group.DeselectAll.BindCommand;
		Rename = group.Rename.BindCommand;
		SubmitCommand = group.Submit.BindCommand;
		UndoCommand = group.Undo.BindCommand;
		RedoCommand = group.Redo.BindCommand;
		Delete = group.Delete.BindCommand;
		Paste = group.Paste.BindCommand;
		Copy = group.Copy.BindCommand;
		ChangeOutputDestination = group.ChangeOutputDestination.BindCommand;
	}
}
