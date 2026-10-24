using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using Pro.Common.Logging;
using Pro.Common.SourceGenerator.Attributes;
using Pro.CoreApplication.Registration.Interaction;
using Pro.SerializationInterop.RVProtoData.Registration;
using ProPresenter.DO.Notifications;

namespace ProPresenter.Registration.CallbackHandlers.Notifications;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_whenNotificationsChanged" })]
public class NotificationCallbackHandler : IRegistrationCallbackHandler, INotificationCallbackHandler, IDisposable
{
	[CompilerGenerated]
	private sealed class _003CConvert_003Ed__4 : IEnumerable<ProPresenter.DO.Notifications.Notification>, IEnumerable, IEnumerator<ProPresenter.DO.Notifications.Notification>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private ProPresenter.DO.Notifications.Notification _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IEnumerable<Pro.SerializationInterop.RVProtoData.Registration.Notification> protoNotifications;

		public IEnumerable<Pro.SerializationInterop.RVProtoData.Registration.Notification> _003C_003E3__protoNotifications;

		private IEnumerator<Pro.SerializationInterop.RVProtoData.Registration.Notification> _003C_003E7__wrap1;

		ProPresenter.DO.Notifications.Notification IEnumerator<ProPresenter.DO.Notifications.Notification>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CConvert_003Ed__4(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003C_003E7__wrap1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			try
			{
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E7__wrap1 = protoNotifications.GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					break;
				}
				while (_003C_003E7__wrap1.MoveNext())
				{
					Pro.SerializationInterop.RVProtoData.Registration.Notification current = _003C_003E7__wrap1.Current;
					if (!Guid.TryParse(current.Id, out var result))
					{
						Pro.Common.Logging.Log.Warning("[{0}]: Malformed notification ID received - {1}", "NotificationCallbackHandler", current.Id);
						continue;
					}
					_003C_003E2__current = new ProPresenter.DO.Notifications.Notification(result, current.Header, current.Body, current.Url, current.UrlDisplayText, DateTimeOffset.FromUnixTimeSeconds((long)current.CreatedAt), DateTimeOffset.FromUnixTimeSeconds((long)current.ExpiresAt), current.IsRead);
					_003C_003E1__state = 1;
					return true;
				}
				_003C_003Em__Finally1();
				_003C_003E7__wrap1 = null;
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			_003C_003E1__state = -1;
			if (_003C_003E7__wrap1 != null)
			{
				_003C_003E7__wrap1.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<ProPresenter.DO.Notifications.Notification> IEnumerable<ProPresenter.DO.Notifications.Notification>.GetEnumerator()
		{
			_003CConvert_003Ed__4 _003CConvert_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CConvert_003Ed__ = this;
			}
			else
			{
				_003CConvert_003Ed__ = new _003CConvert_003Ed__4(0);
			}
			_003CConvert_003Ed__.protoNotifications = _003C_003E3__protoNotifications;
			return _003CConvert_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<ProPresenter.DO.Notifications.Notification>)this).GetEnumerator();
		}
	}

	private readonly BehaviorSubject<IReadOnlyList<ProPresenter.DO.Notifications.Notification>> _whenNotificationsChanged = new BehaviorSubject<IReadOnlyList<ProPresenter.DO.Notifications.Notification>>(Array.Empty<ProPresenter.DO.Notifications.Notification>());

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public IObservable<IReadOnlyList<ProPresenter.DO.Notifications.Notification>> WhenNotificationsChanged => _whenNotificationsChanged;

	public bool HandleResponse(Callback responseCallback, IRegistrationRequestSender requestSender)
	{
		if (responseCallback.CallbackCase == Callback.CallbackOneofCase.NotificationCallback)
		{
			_whenNotificationsChanged.OnNext(Convert(responseCallback.NotificationCallback.Notifications).ToArray());
			return true;
		}
		return false;
	}

	[IteratorStateMachine(typeof(_003CConvert_003Ed__4))]
	private static IEnumerable<ProPresenter.DO.Notifications.Notification> Convert(IEnumerable<Pro.SerializationInterop.RVProtoData.Registration.Notification> protoNotifications)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CConvert_003Ed__4(-2)
		{
			_003C_003E3__protoNotifications = protoNotifications
		};
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
			_whenNotificationsChanged.Dispose();
		}
	}
}
