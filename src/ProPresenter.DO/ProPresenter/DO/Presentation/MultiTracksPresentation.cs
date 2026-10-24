using System;
using System.Reactive;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Time;
using Pro.Common.Time.Timer;
using Pro.Common.Utility;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using Pro.UI.DialogService;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.MultiTracks;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Themes;

namespace ProPresenter.DO.Presentation;

public class MultiTracksPresentation : CustomPresentation
{
	private long _songID = -1L;

	private string _customerID = string.Empty;

	private DateTime _authorizationExpirationDate = DateTime.MinValue;

	private DateTime _authorizationLicenseExpiration = DateTime.MinValue;

	private MultiTracksSubscriptionLevel _subscriptionLevel = MultiTracksSubscriptionLevel.ChartPro;

	private bool _isCheckingAccountStatus;

	public override PresentationType PresentationType => PresentationType.MultiTracks;

	public long SongID
	{
		get
		{
			EnsureLoaded();
			return _songID;
		}
		private set
		{
			SetValue("SongID", ref _songID, value, base.OnDataModified);
		}
	}

	public string CustomerID
	{
		get
		{
			EnsureLoaded();
			return _customerID;
		}
		private set
		{
			SetValue("CustomerID", ref _customerID, value, base.OnDataModified);
		}
	}

	public DateTime AuthorizationTetherExpiration
	{
		get
		{
			EnsureLoaded();
			return _authorizationExpirationDate;
		}
		private set
		{
			SetValue("AuthorizationTetherExpiration", ref _authorizationExpirationDate, value, base.OnDataModified);
		}
	}

	public DateTime AuthorizationLicenseExpiration
	{
		get
		{
			EnsureLoaded();
			return _authorizationLicenseExpiration;
		}
		private set
		{
			SetValue("AuthorizationLicenseExpiration", ref _authorizationLicenseExpiration, value, base.OnDataModified);
		}
	}

	public MultiTracksSubscriptionLevel SubscriptionLevel
	{
		get
		{
			EnsureLoaded();
			return _subscriptionLevel;
		}
		private set
		{
			SetValue("SubscriptionLevel", ref _subscriptionLevel, value, base.OnDataModified);
		}
	}

	public bool OwnedByCurrentCustomer => base.App.MultiTracksCustomerID == CustomerID;

	public bool IsTetherExpired => AuthorizationTetherExpiration.Date < DateTime.Today;

	public bool IsLicenseExpired => AuthorizationLicenseExpiration.Date < DateTime.Today;

	public override bool IsAvailable
	{
		get
		{
			if ((base.App.MultiTracksSubscriptionLevel == MultiTracksSubscriptionLevel.ChartPro || base.App.MultiTracksSubscriptionLevel == MultiTracksSubscriptionLevel.SlidePro) && !IsTetherExpired)
			{
				return OwnedByCurrentCustomer;
			}
			return false;
		}
	}

	public bool IsCheckingAccountStatus
	{
		get
		{
			return _isCheckingAccountStatus;
		}
		set
		{
			SetValue("IsCheckingAccountStatus", ref _isCheckingAccountStatus, value);
		}
	}

	public override bool SupportsChords
	{
		get
		{
			if (base.BaseKey != null)
			{
				return base.TargetKey != null;
			}
			return false;
		}
	}

	public override ICopyPresentationIdentifier CopyIdentifier => new MultiTracksCopyPresentationIdentifier(SongID);

	public override ObjectBinder<PresentationBase, Pro.Entity.IPresentation> Bind(IUiScheduler scheduler, IProPresenterDOFactoryProvider factoryProvider, IActionBinderFactory actionBinderFactory, Pro.Entity.IPresentation entityDoc)
	{
		ObjectBinder<PresentationBase, Pro.Entity.IPresentation> objectBinder = base.Bind(scheduler, factoryProvider, actionBinderFactory, entityDoc);
		objectBinder.Bind<Unit, Unit>(null, (Pro.Entity.IPresentation r) => r.MultiTracksLicensing.WhenValueChanges.ToUnit(), delegate(PresentationBase l, Pro.Entity.IPresentation r)
		{
			if (l is MultiTracksPresentation mt)
			{
				Pro.Entity.IPresentation.Types.IMultiTracksLicensing multiTracksLicensing = factoryProvider.EntityFactory.Create<Pro.Entity.IPresentation.Types.IMultiTracksLicensing>();
				r.MultiTracksLicensing.Set(multiTracksLicensing);
				ObjectBinder<MultiTracksPresentation, Pro.Entity.IPresentation.Types.IMultiTracksLicensing> objectBinder2 = CreateLicensingBinder(mt, multiTracksLicensing);
				objectBinder2.InitializeRightFromLeft();
				multiTracksLicensing.RegisterLinkedDisposable(objectBinder2);
			}
		}, delegate(Pro.Entity.IPresentation r, PresentationBase l)
		{
			if (l is MultiTracksPresentation multiTracksPresentation)
			{
				if (r.MultiTracksLicensing.Value != null)
				{
					ObjectBinder<MultiTracksPresentation, Pro.Entity.IPresentation.Types.IMultiTracksLicensing> objectBinder3 = CreateLicensingBinder((MultiTracksPresentation)l, r.MultiTracksLicensing.Value);
					objectBinder3.InitializeLeftFromRight();
					r.MultiTracksLicensing.Value.RegisterLinkedDisposable(objectBinder3);
				}
				else
				{
					multiTracksPresentation.SongID = 0L;
					multiTracksPresentation.CustomerID = string.Empty;
					multiTracksPresentation.AuthorizationTetherExpiration = DateTime.MinValue;
					multiTracksPresentation.AuthorizationLicenseExpiration = DateTime.MinValue;
					multiTracksPresentation.SubscriptionLevel = MultiTracksSubscriptionLevel.Unknown;
				}
			}
		});
		return objectBinder;
	}

	private static ObjectBinder<MultiTracksPresentation, Pro.Entity.IPresentation.Types.IMultiTracksLicensing> CreateLicensingBinder(MultiTracksPresentation mt, Pro.Entity.IPresentation.Types.IMultiTracksLicensing mtEntity)
	{
		ObjectBinder<MultiTracksPresentation, Pro.Entity.IPresentation.Types.IMultiTracksLicensing> objectBinder = new ObjectBinder<MultiTracksPresentation, Pro.Entity.IPresentation.Types.IMultiTracksLicensing>(mt, mtEntity);
		objectBinder.Bind((MultiTracksPresentation l) => l.WhenPropertyChanges("SongID"), (Pro.Entity.IPresentation.Types.IMultiTracksLicensing r) => r.SongIdentifier.WhenValueChanges, delegate(MultiTracksPresentation l, Pro.Entity.IPresentation.Types.IMultiTracksLicensing r)
		{
			r.SongIdentifier.Set(l.SongID);
		}, delegate(Pro.Entity.IPresentation.Types.IMultiTracksLicensing r, MultiTracksPresentation l)
		{
			l.SongID = r.SongIdentifier.Value;
			l.CheckAuthorization();
		}).Bind((MultiTracksPresentation l) => l.WhenPropertyChanges("CustomerID"), (Pro.Entity.IPresentation.Types.IMultiTracksLicensing r) => r.CustomerIdentifier.WhenValueChanges, delegate(MultiTracksPresentation l, Pro.Entity.IPresentation.Types.IMultiTracksLicensing r)
		{
			r.CustomerIdentifier.Set(l.CustomerID);
		}, delegate(Pro.Entity.IPresentation.Types.IMultiTracksLicensing r, MultiTracksPresentation l)
		{
			l.CustomerID = r.CustomerIdentifier.Value;
			l.CheckAuthorization();
		}).Bind((MultiTracksPresentation l) => l.WhenPropertyChanges("AuthorizationTetherExpiration"), (Pro.Entity.IPresentation.Types.IMultiTracksLicensing r) => r.ExpirationDate.WhenValueChanges, delegate(MultiTracksPresentation l, Pro.Entity.IPresentation.Types.IMultiTracksLicensing r)
		{
			r.ExpirationDate.Set(new Pro.Entity.Timestamp(l.AuthorizationTetherExpiration.ToUnixTimestamp(), 0));
		}, delegate(Pro.Entity.IPresentation.Types.IMultiTracksLicensing r, MultiTracksPresentation l)
		{
			l.AuthorizationTetherExpiration = ((!l.App.MultiTracksSimulateExpired) ? r.ExpirationDate.Value.Seconds.FromUnixTimestamp() : DateTime.MinValue);
			l.CheckAuthorization();
		})
			.Bind((MultiTracksPresentation l) => l.WhenPropertyChanges("AuthorizationLicenseExpiration"), (Pro.Entity.IPresentation.Types.IMultiTracksLicensing r) => r.LicenseExpiration.WhenValueChanges, delegate(MultiTracksPresentation l, Pro.Entity.IPresentation.Types.IMultiTracksLicensing r)
			{
				r.LicenseExpiration.Set(new Pro.Entity.Timestamp(l.AuthorizationLicenseExpiration.ToUnixTimestamp(), 0));
			}, delegate(Pro.Entity.IPresentation.Types.IMultiTracksLicensing r, MultiTracksPresentation l)
			{
				l.AuthorizationLicenseExpiration = ((!l.App.MultiTracksSimulateExpired) ? r.LicenseExpiration.Value.Seconds.FromUnixTimestamp() : DateTime.MinValue);
				l.CheckAuthorization();
			})
			.Bind((MultiTracksPresentation l) => l.WhenPropertyChanges("SubscriptionLevel"), (Pro.Entity.IPresentation.Types.IMultiTracksLicensing r) => r.Subscription.WhenValueChanges, delegate(MultiTracksPresentation l, Pro.Entity.IPresentation.Types.IMultiTracksLicensing r)
			{
				r.Subscription.Set(l.SubscriptionLevel.ToEntitySubscription());
			}, delegate(Pro.Entity.IPresentation.Types.IMultiTracksLicensing r, MultiTracksPresentation l)
			{
				l.SubscriptionLevel = r.Subscription.Value.ToMultiTracksSubscriptionLevel();
				l.CheckAuthorization();
			});
		return objectBinder;
	}

	public MultiTracksPresentation(IApp app, ITimerFactory timerFactory, IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions, IMessageDialogService messageDialogService, ICurrentTime currentTime, TemplateSlide? template = null)
		: base(app, timerFactory, factoryProvider, transitionDescriptions, messageDialogService, currentTime, template)
	{
	}

	public MultiTracksPresentation(long songID, string customerID, DateTime expirationDate, DateTime licenseExpiration, MultiTracksSubscriptionLevel subscriptionLevel, IApp app, ITimerFactory timerFactory, IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions, IMessageDialogService messageDialogService, ICurrentTime currentTime, TemplateSlide? template = null)
		: this(app, timerFactory, factoryProvider, transitionDescriptions, messageDialogService, currentTime, template)
	{
		SongID = songID;
		CustomerID = customerID;
		AuthorizationTetherExpiration = expirationDate;
		AuthorizationLicenseExpiration = licenseExpiration;
		SubscriptionLevel = subscriptionLevel;
	}

	public override PresentationBase Clone()
	{
		return CopyProperties(new MultiTracksPresentation(base.App, base.TimerFactory, base.FactoryProvider, base.TransitionDescriptions, base.MessageDialogService, base.CurrentTime, base.ActiveTemplate)
		{
			SongID = SongID,
			CustomerID = CustomerID,
			AuthorizationTetherExpiration = AuthorizationTetherExpiration,
			AuthorizationLicenseExpiration = AuthorizationLicenseExpiration,
			SubscriptionLevel = SubscriptionLevel
		});
	}

	protected override Pro.SerializationInterop.RVProtoData.Presentation.Types.MultiTracksLicensing SerializeMultiTracksLicensing()
	{
		return new Pro.SerializationInterop.RVProtoData.Presentation.Types.MultiTracksLicensing
		{
			SongIdentifier = SongID,
			CustomerIdentifier = CustomerID,
			ExpirationDate = AuthorizationTetherExpiration.ToTimeStamp(),
			LicenseExpiration = AuthorizationLicenseExpiration.ToTimeStamp(),
			Subscription = SubscriptionLevel.ToProtoSubcription()
		};
	}

	protected override void DeserializeMultiTracksLicensing(Pro.SerializationInterop.RVProtoData.Presentation.Types.MultiTracksLicensing multiTracksLicensing)
	{
		if (multiTracksLicensing != null)
		{
			SongID = multiTracksLicensing.SongIdentifier;
			CustomerID = ((!base.App.MultiTracksSimulateNonOwned) ? multiTracksLicensing.CustomerIdentifier : string.Empty);
			AuthorizationTetherExpiration = ((!base.App.MultiTracksSimulateExpired) ? multiTracksLicensing.ExpirationDate.ToDateTime() : DateTime.MinValue);
			AuthorizationLicenseExpiration = (base.App.MultiTracksSimulateExpired ? DateTime.MinValue : (multiTracksLicensing.LicenseExpiration?.ToDateTime() ?? DateTime.MinValue));
			SubscriptionLevel = multiTracksLicensing.Subscription.ToMultiTracksSubscriptionLevel();
			CheckAuthorization();
		}
	}

	internal void RefreshAuthorization(string customerID, DateTime tetherExpiration, DateTime licenseExpiration)
	{
		CustomerID = customerID;
		AuthorizationTetherExpiration = tetherExpiration;
		AuthorizationLicenseExpiration = licenseExpiration;
		CheckAuthorization();
	}

	public void CheckAuthorization()
	{
		OnPropertyChanged("IsAvailable");
	}
}
