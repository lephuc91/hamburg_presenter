using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.ToastNotifications;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace ProPresenter.ToastNotifications;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class ToastNotificationService : IToastNotificationService, IDisposable
{
	private sealed record ToastNotificationInteractions(Action? OnActivate, Action? OnDismiss, IReadOnlyList<ToastButton> Buttons)
	{
		public Guid Id { get; } = Guid.NewGuid();
	}

	private const string _actionArgumentPrefix = "action=";

	private const string _toastGroup = "ProPresenter";

	private readonly ConcurrentDictionary<Guid, ToastNotificationInteractions> _activeNotifications = new ConcurrentDictionary<Guid, ToastNotificationInteractions>();

	private ToastNotifier? _toastNotifier;

	[Pro.Common.SourceGenerator.Attributes.Aumid("AUMID.ini")]
	private static string _amuid;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	[MemberNotNullWhen(true, "_toastNotifier")]
	public bool CanSendToasts
	{
		[MemberNotNullWhen(true, "_toastNotifier")]
		get
		{
			return _toastNotifier != null;
		}
	}

	public ToastNotificationService()
	{
		try
		{
			_toastNotifier = ToastNotificationManager.CreateToastNotifier(_amuid);
		}
		catch
		{
			_toastNotifier = null;
		}
	}

	public void ShowToast(string title, string message, bool showLong, Action? onToastActivated, Action? onToastDismissed, [ParamCollection] IReadOnlyList<ToastButton> buttons)
	{
		ToastNotificationInteractions interactions = new ToastNotificationInteractions(onToastActivated, onToastDismissed, buttons);
		string value = EscapeXml(title);
		string value2 = EscapeXml(message);
		string xml = $"\r\n                <toast duration=\"{GetShowDuration(showLong)}\">\r\n                    <visual>\r\n                        <binding template=\"ToastGeneric\">\r\n                            <text>{value}</text>\r\n                            <text>{value2}</text>\r\n                        </binding>\r\n                    </visual>\r\n                    {GenerateActionsXml(interactions.Buttons)}\r\n                </toast>";
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(xml);
		ToastNotification toastNotification = new ToastNotification(xmlDocument);
		toastNotification.Group = "ProPresenter";
		toastNotification.Tag = interactions.Id.ToString();
		_activeNotifications[interactions.Id] = interactions;
		toastNotification.Activated += Toast_Activated;
		toastNotification.Dismissed += Toast_Dismissed;
		toastNotification.Failed += delegate
		{
			CleanupCallbacks(interactions.Id);
		};
		try
		{
			_toastNotifier?.Show(toastNotification);
		}
		catch
		{
			_activeNotifications.Clear();
			_toastNotifier = null;
		}
	}

	private static string GenerateActionsXml(IReadOnlyList<ToastButton> buttons)
	{
		if (buttons.Count < 1)
		{
			return string.Empty;
		}
		string text = string.Join(Environment.NewLine, buttons.Select((ToastButton b, int id) => $"<action content=\"{EscapeXml(b.Content)}\" arguments=\"{EscapeXml($"{"action="}{id}")}\" />"));
		return "<actions>" + text + "</actions>";
	}

	private static string EscapeXml(string value)
	{
		return SecurityElement.Escape(value);
	}

	private static string GetShowDuration(bool showLong)
	{
		if (!showLong)
		{
			return "short";
		}
		return "long";
	}

	private void Toast_Activated(ToastNotification sender, object args)
	{
		try
		{
			if (Guid.TryParse(sender.Tag, out var result) && _activeNotifications.TryRemove(result, out ToastNotificationInteractions value))
			{
				if (args is ToastActivatedEventArgs { Arguments: var arguments } && arguments.StartsWith("action=") && int.TryParse(arguments.Substring("action=".Length), out var result2) && result2 >= 0 && result2 < value.Buttons.Count)
				{
					value.Buttons[result2].Callback();
				}
				else
				{
					value.OnActivate?.Invoke();
				}
			}
		}
		finally
		{
			if (!string.IsNullOrEmpty(sender.Tag))
			{
				ToastNotificationManager.History.Remove(sender.Tag, sender.Group, _amuid);
			}
		}
	}

	private void Toast_Dismissed(ToastNotification sender, object args)
	{
		if (TryGetInteractions(sender, out ToastNotificationInteractions interactions))
		{
			interactions.OnDismiss?.Invoke();
		}
		if (!string.IsNullOrEmpty(sender.Tag))
		{
			ToastNotificationManager.History.Remove(sender.Tag, sender.Group, _amuid);
		}
	}

	private void CleanupCallbacks(Guid id)
	{
		_activeNotifications.TryRemove(id, out ToastNotificationInteractions _);
	}

	private bool TryGetInteractions(ToastNotification sender, [NotNullWhen(true)] out ToastNotificationInteractions? interactions)
	{
		if (Guid.TryParse(sender.Tag, out var result) && _activeNotifications.TryRemove(result, out interactions))
		{
			return true;
		}
		interactions = null;
		return false;
	}

	static ToastNotificationService()
	{
		_amuid = "RenewedVision.ProPresenter";
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		_activeNotifications.Clear();
		try
		{
			if ((object)_toastNotifier != null)
			{
				ToastNotificationManager.History.RemoveGroup("ProPresenter", _amuid);
			}
		}
		catch
		{
		}
	}
}
