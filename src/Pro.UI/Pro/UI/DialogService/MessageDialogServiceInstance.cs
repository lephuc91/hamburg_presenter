using System;
using System.Collections.Generic;
using System.Windows;

namespace Pro.UI.DialogService;

public class MessageDialogServiceInstance : IMessageDialogService
{
	public bool ShowDialog(string? header, DependencyObject content, IEnumerable<ButtonDescriptor> buttons, DialogIcon dialogIcon, double? dialogWidth = null)
	{
		return MessageDialogService.ShowDialog(header, content, buttons, dialogIcon, dialogWidth);
	}

	public bool ShowDialog(string? header, string message, IEnumerable<ButtonDescriptor> buttons, DialogIcon dialogIcon)
	{
		return MessageDialogService.ShowDialog(header, message, buttons, dialogIcon);
	}

	public bool ShowDialog(string? header, string heading, string message, IEnumerable<ButtonDescriptor> buttons, DialogIcon dialogIcon)
	{
		return MessageDialogService.ShowDialog(header, heading, message, buttons, dialogIcon);
	}

	public T? ShowDialog<T>(string? header, DependencyObject content, T buttons, T defaultButton, DialogIcon dialogIcon, T[]? orderedButtons = null, Dictionary<T, string[]>? placeholderContent = null) where T : struct, Enum
	{
		return MessageDialogService.ShowDialog(header, content, buttons, defaultButton, dialogIcon, orderedButtons, placeholderContent);
	}

	public T? ShowDialog<T>(string? header, string message, T buttons, T defaultButton, T[]? orderedButtons = null, Dictionary<T, string[]>? placeholderContent = null) where T : struct, Enum
	{
		return MessageDialogService.ShowDialog(header, message, buttons, defaultButton, orderedButtons, placeholderContent);
	}

	public T? ShowDialog<T>(string? header, string heading, string message, T buttons, T defaultButton, T[]? orderedButtons = null, Dictionary<T, string[]>? placeholderContent = null) where T : struct, Enum
	{
		return MessageDialogService.ShowDialog(header, heading, message, buttons, defaultButton, orderedButtons, placeholderContent);
	}

	public T? ShowDialogNoClose<T>(string? header, string message, T buttons, T defaultButton, T[]? orderedButtons = null, Dictionary<T, string[]>? placeholderContent = null) where T : struct, Enum
	{
		return MessageDialogService.ShowDialogNoClose(header, message, buttons, defaultButton, orderedButtons, placeholderContent);
	}

	public Window ShowDialogNonBlocking(string? header, DependencyObject content, IEnumerable<ButtonDescriptor> buttons)
	{
		return MessageDialogService.ShowDialogNonBlocking(header, content, buttons);
	}

	public Window ShowDialogNonBlocking<T>(string? header, DependencyObject content, T buttons, T defaultButton, Action<T?> callBack, T[]? orderedButtons = null) where T : struct, Enum
	{
		return MessageDialogService.ShowDialogNonBlocking(header, content, buttons, defaultButton, callBack, orderedButtons);
	}

	public Window ShowDialogNonBlocking(string? header, string message, IEnumerable<ButtonDescriptor> buttons)
	{
		return MessageDialogService.ShowDialogNonBlocking(header, message, buttons);
	}

	public void ShowDialogNonBlocking<T>(string? header, string message, T buttons, T defaultButton, Action<T?> callBack, T[]? orderedButtons = null) where T : struct, Enum
	{
		MessageDialogService.ShowDialogNonBlocking(header, message, buttons, defaultButton, callBack, orderedButtons);
	}

	public bool ShowSimpleContent(string? header, DependencyObject content, bool canCancel = true)
	{
		return MessageDialogService.ShowSimpleContent(header, content, canCancel);
	}

	public bool ShowSimpleContent(string? header, string message, bool canCancel = true)
	{
		return MessageDialogService.ShowSimpleContent(header, message, canCancel);
	}

	public void ShowAlert(string message)
	{
		MessageDialogService.ShowAlert(message);
	}

	public void ShowAlert(string heading, string message)
	{
		MessageDialogService.ShowAlert(heading, message);
	}

	public bool ShowDialog(string? header, DependencyObject content, IEnumerable<ButtonDescriptor> buttons, DialogIcon? dialogIcon = null, double? dialogWidth = null, bool canClose = true)
	{
		return MessageDialogService.ShowDialog(header, content, buttons, dialogIcon, dialogWidth, canClose);
	}
}
