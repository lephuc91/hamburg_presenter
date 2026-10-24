using System;

namespace Pro.UI.DialogService;

public record ButtonDescriptor(string Content, bool IsDefault = false, bool IsCancel = false, Action? Action = null);
