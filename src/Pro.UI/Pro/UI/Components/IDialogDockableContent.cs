using System;

namespace Pro.UI.Components;

public interface IDialogDockableContent : IDialogContent
{
	event Action ToggleDock;
}
