using System;

namespace Pro.Common.ToastNotifications;

public record ToastButton(string Content, Action Callback);
