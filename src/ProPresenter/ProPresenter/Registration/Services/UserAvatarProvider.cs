using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.IO;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Pro.Common.SourceGenerator.Attributes;
using Pro.UI.Themes;
using ProPresenter.DO.Organization;
using ProPresenter.DO.Organization.Avatar.Model;
using ProPresenter.DO.Registration.State;
using ProPresenter.DO.Registration.State.Subscription;

namespace ProPresenter.Registration.Services;

public sealed class UserAvatarProvider : IUserAvatarProvider, IObservable<ImageSource?>, IAsyncDisposable
{
	[Pro.Common.SourceGenerator.Attributes.ActionLink("Registration", "OnRegistrationChanged")]
	private readonly IRegistrationStateProvider _registrationStateProvider;

	private readonly IOrganizationConsumer _organizationConsumer;

	private readonly BehaviorSubject<ImageSource?> _avatarSubject = new BehaviorSubject<ImageSource>(Icons.GetIcon(Icons.SettingsRegistrationSignedIn));

	private readonly Lock _lock = new Lock();

	private readonly CancellationTokenSource _cts = new CancellationTokenSource();

	private Task? _loadTask;

	private DateTimeOffset _avatarTimestamp = DateTimeOffset.MinValue;

	public UserAvatarProvider(IRegistrationStateProvider registrationStateProvider, IOrganizationConsumer organizationConsumer)
	{
		_registrationStateProvider = registrationStateProvider;
		_organizationConsumer = organizationConsumer;
		AddPropertyLinks();
		OnRegistrationChanged();
	}

	public IDisposable Subscribe(IObserver<ImageSource?> observer)
	{
		return _avatarSubject.Subscribe(observer);
	}

	private void OnRegistrationChanged()
	{
		if (_registrationStateProvider.Registration.SubscriptionState is SubscribedState)
		{
			TriggerAvatarReload();
			return;
		}
		_avatarTimestamp = DateTimeOffset.MinValue;
		BehaviorSubject<ImageSource?> avatarSubject = _avatarSubject;
		ImageSource value = ((!(_registrationStateProvider.Registration.SubscriptionState is UnsubscribedState)) ? Icons.GetIcon(Icons.SettingsRegistrationSignedIn) : Icons.GetIcon(Icons.SettingsRegistrationSignedOut));
		avatarSubject.OnNext(value);
	}

	private void TriggerAvatarReload()
	{
		using (_lock.EnterScope())
		{
			if (_loadTask == null)
			{
				_loadTask = LoadAvatarAsync(_cts.Token);
			}
		}
	}

	private async Task LoadAvatarAsync(CancellationToken token)
	{
		_ = 3;
		try
		{
			IAvatarResult avatarResult = await _organizationConsumer.GetAvatarAsync(_avatarTimestamp, token).ConfigureAwait(continueOnCapturedContext: false);
			Stream imageData;
			DateTimeOffset avatarTimestamp;
			if (!avatarResult.AvatarExists)
			{
				_avatarTimestamp = DateTimeOffset.MinValue;
				_avatarSubject.OnNext(Icons.GetIcon(Icons.SettingsRegistrationSignedIn));
			}
			else if (avatarResult.TryGetAvatarData(out imageData, out avatarTimestamp))
			{
				await using (imageData)
				{
					await using MemoryStream ms = new MemoryStream();
					await imageData.CopyToAsync(ms, token).ConfigureAwait(continueOnCapturedContext: false);
					ms.Seek(0L, SeekOrigin.Begin);
					BitmapImage bitmapImage = new BitmapImage();
					bitmapImage.BeginInit();
					bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
					bitmapImage.StreamSource = ms;
					bitmapImage.EndInit();
					((Freezable)bitmapImage).Freeze();
					_avatarTimestamp = avatarTimestamp;
					_avatarSubject.OnNext(bitmapImage);
				}
			}
		}
		catch
		{
		}
		using (_lock.EnterScope())
		{
			_loadTask = null;
		}
	}

	public async ValueTask DisposeAsync()
	{
		await _cts.CancelAsync().ConfigureAwait(continueOnCapturedContext: false);
		Task task = null;
		using (_lock.EnterScope())
		{
			task = _loadTask;
			_loadTask = null;
		}
		if (task != null)
		{
			await task;
		}
		RemovePropertyLinks();
		_cts.Dispose();
		_avatarSubject.Dispose();
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void _registrationStateProvider_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Registration")
		{
			OnRegistrationChanged();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void AddPropertyLinks()
	{
		_registrationStateProvider.PropertyChanged += _registrationStateProvider_PropertyChanged;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void RemovePropertyLinks()
	{
		_registrationStateProvider.PropertyChanged -= _registrationStateProvider_PropertyChanged;
	}
}
