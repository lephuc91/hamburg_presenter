using System;
using System.Collections.Generic;
using System.Windows;

namespace Pro.UI.DialogService;

public interface IMessageDialogService
{
	void ShowAlert(string message);

	void ShowAlert(string heading, string message);

	bool ShowDialog(string? header, DependencyObject content, IEnumerable<ButtonDescriptor> buttons, DialogIcon dialogIcon, double? dialogWidth = null);

	bool ShowDialog(string? header, string message, IEnumerable<ButtonDescriptor> buttons, DialogIcon dialogIcon);

	bool ShowDialog(string? header, string heading, string message, IEnumerable<ButtonDescriptor> buttons, DialogIcon dialogIcon);

	bool ShowDialog(string? header, DependencyObject content, IEnumerable<ButtonDescriptor> buttons, DialogIcon? dialogIcon = null, double? dialogWidth = null, bool canClose = true);

	T? ShowDialog<T>(string? header, DependencyObject content, T buttons, T defaultButton, DialogIcon dialogIcon, T[]? orderedButtons = null, Dictionary<T, string[]>? placeholderContent = null) where T : struct, Enum;

	T? ShowDialog<T>(string? header, string heading, string message, T buttons, T defaultButton, T[]? orderedButtons = null, Dictionary<T, string[]>? placeholderContent = null) where T : struct, Enum;

	T? ShowDialog<T>(string? header, string message, T buttons, T defaultButton, T[]? orderedButtons = null, Dictionary<T, string[]>? placeholderContent = null) where T : struct, Enum;

	T? ShowDialogNoClose<T>(string? header, string message, T buttons, T defaultButton, T[]? orderedButtons = null, Dictionary<T, string[]>? placeholderContent = null) where T : struct, Enum;

	Window ShowDialogNonBlocking(string? header, DependencyObject content, IEnumerable<ButtonDescriptor> buttons);

	Window ShowDialogNonBlocking(string? header, string message, IEnumerable<ButtonDescriptor> buttons);

	Window ShowDialogNonBlocking<T>(string? header, DependencyObject content, T buttons, T defaultButton, Action<T?> callBack, T[]? orderedButtons = null) where T : struct, Enum;

	void ShowDialogNonBlocking<T>(string? header, string message, T buttons, T defaultButton, Action<T?> callBack, T[]? orderedButtons = null) where T : struct, Enum;

	bool ShowSimpleContent(string? header, DependencyObject content, bool canCancel = true);

	bool ShowSimpleContent(string? header, string message, bool canCancel = true);
}
