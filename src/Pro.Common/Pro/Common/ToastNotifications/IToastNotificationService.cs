using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Pro.Common.ToastNotifications;

public interface IToastNotificationService
{
	bool CanSendToasts { get; }

	void ShowToast(string title, string message, bool showLong, Action? onToastActivated, Action? onToastDismissed, [ParamCollection] IReadOnlyList<ToastButton> buttons);
}
