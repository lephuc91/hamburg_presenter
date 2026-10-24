using System;

namespace Pro.UI.Components;

public interface IDialogContent
{
	event Action Accept;

	event Action Cancel;
}
