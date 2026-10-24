using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Pro.Common.Collections;
using Pro.Common.Operations;
using Pro.Localization;
using Pro.UI.Utility;

namespace Pro.UI.DialogService;

public static class MessageDialogService
{
	public static bool ShowDialog(string? header, DependencyObject content, IEnumerable<ButtonDescriptor> buttons, DialogIcon? dialogIcon = null, double? dialogWidth = null, bool canClose = true)
	{
		WindowHelper.MainWindow()?.Activate();
		if ((object)dialogIcon == null)
		{
			dialogIcon = DialogIcon.Default;
		}
		DialogTemplate customMessageDialog = GenerateTemplate(content, header, dialogIcon);
		buttons.Select((ButtonDescriptor b) => GenerateButton(b, customMessageDialog)).ForEach(delegate(Button b)
		{
			customMessageDialog.ButtonsPanel.Children.Add(b);
		});
		if (dialogWidth.HasValue)
		{
			customMessageDialog.MaxWidth = dialogWidth.Value;
		}
		customMessageDialog.CanClose = canClose;
		if (customMessageDialog.IsClosing)
		{
			return false;
		}
		customMessageDialog.ShowDialog();
		return !customMessageDialog.IsCancel;
	}

	public static bool ShowDialog(string? header, string message, IEnumerable<ButtonDescriptor> buttons, DialogIcon dialogIcon)
	{
		return ShowDialog(header, (DependencyObject)(object)GenerateMessageContent(message), buttons, dialogIcon, null);
	}

	public static bool ShowDialog(string? header, string heading, string message, IEnumerable<ButtonDescriptor> buttons, DialogIcon? dialogIcon = null)
	{
		return ShowDialog(header, (DependencyObject)(object)GenerateMessageContent(message, heading), buttons, dialogIcon, null);
	}

	public static T? ShowDialog<T>(string? header, DependencyObject content, T buttons, T defaultButton, DialogIcon? dialogIcon = null, T[]? orderedButtons = null, Dictionary<T, string[]>? placeholderContent = null, bool canClose = true) where T : struct, Enum
	{
		WindowHelper.MainWindow()?.Activate();
		T? result = null;
		IEnumerable<ButtonDescriptor> buttons2 = from b in GetButtonValues(buttons, orderedButtons)
			select GenerateButtonDescriptor(b, defaultButton, delegate
			{
				result = b;
			}, placeholderContent);
		if ((object)dialogIcon == null)
		{
			dialogIcon = DialogIcon.Default;
		}
		DialogIcon? dialogIcon2 = dialogIcon;
		bool canClose2 = canClose;
		if (!ShowDialog(header, content, buttons2, dialogIcon2, null, canClose2))
		{
			result = null;
		}
		return result;
	}

	public static T? ShowDialog<T>(string? header, string message, T buttons, T defaultButton, T[]? orderedButtons = null, Dictionary<T, string[]>? placeholderContent = null) where T : struct, Enum
	{
		return ShowDialog(header, (DependencyObject)(object)GenerateMessageContent(message), buttons, defaultButton, DialogIcon.Default, orderedButtons, placeholderContent);
	}

	public static T? ShowDialogNoClose<T>(string? header, string message, T buttons, T defaultButton, T[]? orderedButtons = null, Dictionary<T, string[]>? placeholderContent = null) where T : struct, Enum
	{
		return ShowDialog(header, (DependencyObject)(object)GenerateMessageContent(message), buttons, defaultButton, DialogIcon.Default, orderedButtons, placeholderContent, canClose: false);
	}

	public static T? ShowDialog<T>(string? header, string heading, string message, T buttons, T defaultButton, T[]? orderedButtons = null, Dictionary<T, string[]>? placeholderContent = null) where T : struct, Enum
	{
		return ShowDialog(header, (DependencyObject)(object)GenerateMessageContent(message, heading), buttons, defaultButton, DialogIcon.Default, orderedButtons, placeholderContent);
	}

	public static Window ShowDialogNonBlocking(string? header, DependencyObject content, IEnumerable<ButtonDescriptor> buttons)
	{
		WindowHelper.MainWindow()?.Activate();
		DialogTemplate customMessageDialog = GenerateTemplate(content, header, DialogIcon.Default);
		buttons.Select((ButtonDescriptor b) => GenerateButton(b, customMessageDialog)).ForEach(delegate(Button b)
		{
			customMessageDialog.ButtonsPanel.Children.Add(b);
		});
		customMessageDialog.Show();
		return customMessageDialog;
	}

	public static Window ShowDialogNonBlocking<T>(string? header, DependencyObject content, T buttons, T defaultButton, Action<T?>? callBack, T[]? orderedButtons = null) where T : struct, Enum
	{
		WindowHelper.MainWindow()?.Activate();
		T? result = null;
		DialogTemplate dialogTemplate = GenerateTemplate(content, header, DialogIcon.Default);
		IEnumerable<ButtonDescriptor> buttons2 = from b in GetButtonValues(buttons, orderedButtons)
			select GenerateButtonDescriptor(b, defaultButton, delegate
			{
				result = b;
			});
		Window result2 = ShowDialogNonBlocking(header, content, buttons2);
		dialogTemplate.Closed += delegate
		{
			callBack?.Invoke(result);
		};
		return result2;
	}

	public static Window ShowDialogNonBlocking(string? header, string message, IEnumerable<ButtonDescriptor> buttons)
	{
		return ShowDialogNonBlocking(header, (DependencyObject)(object)GenerateMessageContent(message), buttons);
	}

	public static void ShowDialogNonBlocking<T>(string? header, string message, T buttons, T defaultButton, Action<T?> callBack, T[]? orderedButtons = null) where T : struct, Enum
	{
		ShowDialogNonBlocking(header, (DependencyObject)(object)GenerateMessageContent(message), buttons, defaultButton, callBack, orderedButtons);
	}

	public static bool ShowSimpleContent(string? header, DependencyObject content, bool canCancel = true)
	{
		DefaultButtons buttons = (canCancel ? (DefaultButtons.OK | DefaultButtons.CANCEL) : DefaultButtons.OK);
		return ShowDialog(header, content, buttons, DefaultButtons.OK, DialogIcon.Default) == DefaultButtons.OK;
	}

	public static bool ShowSimpleContent(string? header, string message, bool canCancel = true)
	{
		DefaultButtons buttons = (canCancel ? (DefaultButtons.OK | DefaultButtons.CANCEL) : DefaultButtons.OK);
		return ShowDialog(header, (DependencyObject)(object)GenerateMessageContent(message), buttons, DefaultButtons.OK, DialogIcon.Default) == DefaultButtons.OK;
	}

	public static void ShowAlert(string message)
	{
		ShowDialog(string.Empty, message, DefaultButtons.OK, DefaultButtons.OK);
	}

	public static void ShowAlert(string heading, string message)
	{
		ShowDialog(string.Empty, heading, message, DefaultButtons.OK, DefaultButtons.OK);
	}

	private static IEnumerable<T> GetButtonValues<T>(T buttons, T[]? orderedButtons = null) where T : struct, Enum
	{
		IEnumerable<T> enumerable = from b in Enum.GetValues<T>()
			where (b.Cast<int, T>() & buttons.Cast<int, T>()) != 0
			select b;
		if (orderedButtons == null)
		{
			return enumerable;
		}
		return enumerable.OrderBy((T v) => orderedButtons.IndexOf(v));
	}

	private static ButtonDescriptor GenerateButtonDescriptor<T>(T value, T defaultButton, Action? buttonAction, Dictionary<T, string[]>? placeholderContent = null) where T : Enum
	{
		string text = LocalizedStrings.Get(value);
		if (placeholderContent != null && placeholderContent.TryGetValue(value, out string[] value2))
		{
			string format = text;
			object[] args = value2;
			text = string.Format(format, args);
		}
		return new ButtonDescriptor(text, value.Equal(defaultButton), IsCancel: false, buttonAction);
	}

	public static Button GenerateButton(ButtonDescriptor descriptor, Window dialog)
	{
		Button button = new Button();
		button.Content = descriptor.Content;
		button.Height = 22.0;
		button.MinWidth = 80.0;
		button.Padding = new Thickness(4.0, 0.0, 4.0, 0.0);
		button.Margin = new Thickness(10.0, 0.0, 0.0, 0.0);
		button.IsDefault = descriptor.IsDefault;
		button.IsCancel = descriptor.IsCancel;
		button.Click += delegate
		{
			descriptor.Action?.Invoke();
			dialog.Close();
		};
		return button;
	}

	private static DialogTemplate GenerateTemplate(DependencyObject content, string? header, DialogIcon dialogIcon)
	{
		return new DialogTemplate(content)
		{
			Title = (string.IsNullOrEmpty(header) ? "DIALOG" : header),
			ShowInTaskbar = false,
			ShowTitle = !string.IsNullOrEmpty(header),
			DialogIcon = dialogIcon.Icon,
			HideIcon = dialogIcon.HideIcon
		};
	}

	private static MessageContent GenerateMessageContent(string message, string? heading = null)
	{
		return new MessageContent
		{
			Message = message,
			Heading = heading
		};
	}
}
