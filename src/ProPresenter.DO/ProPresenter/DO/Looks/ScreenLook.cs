using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.Components;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Storage;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Themes;

namespace ProPresenter.DO.Looks;

public sealed class ScreenLook : ObservableObject, ICloneable<ScreenLook>, IEquatable<ScreenLook?>
{
	[ObservableProperty]
	private bool _propsEnabled = true;

	[ObservableProperty]
	private bool _messagesEnabled = true;

	[ObservableProperty]
	private bool _announcementEnabled = true;

	[ObservableProperty]
	private bool _foregroundEnabled = true;

	[ObservableProperty]
	private bool _backgroundEnabled = true;

	[ObservableProperty]
	private bool _liveVideoEnabled = true;

	private Guid? _templateId;

	private RelativePath? _templatePath;

	[ObservableProperty]
	private Guid? _maskId;

	private int? _hashCode;

	[ObservableProperty]
	private Guid? _screenId;

	public Guid? TemplateId
	{
		get
		{
			return _templateId;
		}
		private set
		{
			SetProperty(ref _templateId, value, "TemplateId");
		}
	}

	public RelativePath? TemplatePath
	{
		get
		{
			return _templatePath;
		}
		set
		{
			SetProperty(ref _templatePath, value, "TemplatePath");
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool PropsEnabled
	{
		get
		{
			return _propsEnabled;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_propsEnabled, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.PropsEnabled);
				_propsEnabled = value;
				OnPropsEnabledChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.PropsEnabled);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool MessagesEnabled
	{
		get
		{
			return _messagesEnabled;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_messagesEnabled, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.MessagesEnabled);
				_messagesEnabled = value;
				OnMessagesEnabledChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.MessagesEnabled);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool AnnouncementEnabled
	{
		get
		{
			return _announcementEnabled;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_announcementEnabled, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.AnnouncementEnabled);
				_announcementEnabled = value;
				OnAnnouncementEnabledChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.AnnouncementEnabled);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ForegroundEnabled
	{
		get
		{
			return _foregroundEnabled;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_foregroundEnabled, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ForegroundEnabled);
				_foregroundEnabled = value;
				OnForegroundEnabledChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ForegroundEnabled);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool BackgroundEnabled
	{
		get
		{
			return _backgroundEnabled;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_backgroundEnabled, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.BackgroundEnabled);
				_backgroundEnabled = value;
				OnBackgroundEnabledChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.BackgroundEnabled);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool LiveVideoEnabled
	{
		get
		{
			return _liveVideoEnabled;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_liveVideoEnabled, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.LiveVideoEnabled);
				_liveVideoEnabled = value;
				OnLiveVideoEnabledChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.LiveVideoEnabled);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public Guid? MaskId
	{
		get
		{
			return _maskId;
		}
		set
		{
			if (!EqualityComparer<Guid?>.Default.Equals(_maskId, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.MaskId);
				_maskId = value;
				OnMaskIdChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.MaskId);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public Guid? ScreenId
	{
		get
		{
			return _screenId;
		}
		set
		{
			if (!EqualityComparer<Guid?>.Default.Equals(_screenId, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ScreenId);
				_screenId = value;
				OnScreenIdChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ScreenId);
			}
		}
	}

	public event System.Action? DataModified;

	public static ObjectBinder<ScreenLook, IProAudienceLook.Types.IProScreenLook> CreateBinder(IUiScheduler scheduler, ScreenLook left, IProAudienceLook.Types.IProScreenLook right)
	{
		ObjectBinder<ScreenLook, IProAudienceLook.Types.IProScreenLook> objectBinder = new ObjectBinder<ScreenLook, IProAudienceLook.Types.IProScreenLook>(left, right);
		objectBinder.Bind((ScreenLook l) => l.WhenPropertyChanges("ScreenId"), (IProAudienceLook.Types.IProScreenLook r) => r.ProScreenUuid.WhenValueChanges, delegate(ScreenLook l, IProAudienceLook.Types.IProScreenLook r)
		{
			r.ProScreenUuid.Set(l.ScreenId ?? Guid.Empty);
		}, delegate(IProAudienceLook.Types.IProScreenLook r, ScreenLook l)
		{
			l.ScreenId = r.ProScreenUuid.Value;
		}).Bind((ScreenLook l) => l.WhenPropertyChanges("PropsEnabled"), (IProAudienceLook.Types.IProScreenLook r) => r.PropsLayerEnabled.WhenValueChanges, delegate(ScreenLook l, IProAudienceLook.Types.IProScreenLook r)
		{
			r.PropsLayerEnabled.Set(l.PropsEnabled);
		}, delegate(IProAudienceLook.Types.IProScreenLook r, ScreenLook l)
		{
			l.PropsEnabled = r.PropsLayerEnabled.Value;
		}).Bind((ScreenLook l) => l.WhenPropertyChanges("MessagesEnabled"), (IProAudienceLook.Types.IProScreenLook r) => r.MessagesLayerEnabled.WhenValueChanges, delegate(ScreenLook l, IProAudienceLook.Types.IProScreenLook r)
		{
			r.MessagesLayerEnabled.Set(l.MessagesEnabled);
		}, delegate(IProAudienceLook.Types.IProScreenLook r, ScreenLook l)
		{
			l.MessagesEnabled = r.MessagesLayerEnabled.Value;
		})
			.Bind((ScreenLook l) => l.WhenPropertyChanges("AnnouncementEnabled"), (IProAudienceLook.Types.IProScreenLook r) => r.AnnouncementsEnabled.WhenValueChanges, delegate(ScreenLook l, IProAudienceLook.Types.IProScreenLook r)
			{
				r.AnnouncementsEnabled.Set(l.AnnouncementEnabled);
			}, delegate(IProAudienceLook.Types.IProScreenLook r, ScreenLook l)
			{
				l.AnnouncementEnabled = r.AnnouncementsEnabled.Value;
			})
			.Bind((ScreenLook l) => l.WhenPropertyChanges("ForegroundEnabled"), (IProAudienceLook.Types.IProScreenLook r) => r.PresentationForegroundEnabled.WhenValueChanges, delegate(ScreenLook l, IProAudienceLook.Types.IProScreenLook r)
			{
				r.PresentationForegroundEnabled.Set(l.ForegroundEnabled);
			}, delegate(IProAudienceLook.Types.IProScreenLook r, ScreenLook l)
			{
				l.ForegroundEnabled = r.PresentationForegroundEnabled.Value;
			})
			.Bind((ScreenLook l) => l.WhenPropertyChanges("BackgroundEnabled"), (IProAudienceLook.Types.IProScreenLook r) => r.PresentationBackgroundEnabled.WhenValueChanges, delegate(ScreenLook l, IProAudienceLook.Types.IProScreenLook r)
			{
				r.PresentationBackgroundEnabled.Set(l.BackgroundEnabled);
			}, delegate(IProAudienceLook.Types.IProScreenLook r, ScreenLook l)
			{
				l.BackgroundEnabled = r.PresentationBackgroundEnabled.Value;
			})
			.Bind((ScreenLook l) => l.WhenPropertyChanges("LiveVideoEnabled"), (IProAudienceLook.Types.IProScreenLook r) => r.LiveVideoEnabled.WhenValueChanges, delegate(ScreenLook l, IProAudienceLook.Types.IProScreenLook r)
			{
				r.LiveVideoEnabled.Set(l.LiveVideoEnabled);
			}, delegate(IProAudienceLook.Types.IProScreenLook r, ScreenLook l)
			{
				l.LiveVideoEnabled = r.LiveVideoEnabled.Value;
			})
			.Bind((ScreenLook l) => l.WhenPropertyChanges("TemplateId"), (IProAudienceLook.Types.IProScreenLook r) => r.TemplateSlideUuid.WhenValueChanges, delegate(ScreenLook l, IProAudienceLook.Types.IProScreenLook r)
			{
				r.TemplateSlideUuid.Set(l.TemplateId);
			}, delegate(IProAudienceLook.Types.IProScreenLook r, ScreenLook l)
			{
				l.TemplateId = r.TemplateSlideUuid.Value;
			})
			.Bind((ScreenLook l) => l.WhenPropertyChanges("MaskId"), (IProAudienceLook.Types.IProScreenLook r) => r.MaskUuid.WhenValueChanges, delegate(ScreenLook l, IProAudienceLook.Types.IProScreenLook r)
			{
				r.MaskUuid.Set(l.MaskId);
			}, delegate(IProAudienceLook.Types.IProScreenLook r, ScreenLook l)
			{
				l.MaskId = r.MaskUuid.Value;
			});
		return objectBinder;
	}

	public ScreenLook(Guid? screenId)
	{
		_screenId = screenId;
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	public void UpdateTemplate(TemplateSlide? theme)
	{
		TemplateId = theme?.ID;
		TemplatePath = ((theme?.ParentTheme == null) ? RelativePath.Empty() : new RelativePath(Path.Combine(CommonPaths.Themes, theme.ParentTheme.Path, "Theme")));
		OnDataModified();
	}

	public ProAudienceLook.Types.ProScreenLook Serialize()
	{
		return new ProAudienceLook.Types.ProScreenLook
		{
			PropsEnabled = (PropsEnabled && MessagesEnabled),
			ProScreenUuid = ScreenId?.ToUUID(),
			PropsLayerEnabled = PropsEnabled,
			MessagesLayerEnabled = MessagesEnabled,
			AnnouncementsEnabled = AnnouncementEnabled,
			PresentationForegroundEnabled = ForegroundEnabled,
			PresentationBackgroundEnabled = BackgroundEnabled,
			LiveVideoEnabled = LiveVideoEnabled,
			TemplateSlideUuid = TemplateId?.ToUUID(),
			TemplateDocumentFilePath = (((object)_templatePath == null) ? RelativePath.Empty().Serialize() : _templatePath.Serialize()),
			MaskUuid = MaskId?.ToUUID()
		};
	}

	public void Deserialize(ProAudienceLook.Types.ProScreenLook look)
	{
		if (look.PropsEnabled)
		{
			PropsEnabled = true;
			MessagesEnabled = true;
		}
		else
		{
			PropsEnabled = look.PropsLayerEnabled;
			MessagesEnabled = look.MessagesLayerEnabled;
		}
		AnnouncementEnabled = look.AnnouncementsEnabled;
		ForegroundEnabled = look.PresentationForegroundEnabled;
		BackgroundEnabled = look.PresentationBackgroundEnabled;
		LiveVideoEnabled = look.LiveVideoEnabled;
		TemplateId = look.TemplateSlideUuid?.ToGuid();
		RelativePath relativePath = new RelativePath(look.TemplateDocumentFilePath);
		if (relativePath != RelativePath.Empty())
		{
			_templatePath = relativePath;
		}
		else
		{
			_templatePath = null;
		}
		MaskId = look.MaskUuid?.ToGuid();
	}

	public ScreenLook Clone()
	{
		return new ScreenLook(ScreenId)
		{
			PropsEnabled = PropsEnabled,
			MessagesEnabled = MessagesEnabled,
			AnnouncementEnabled = AnnouncementEnabled,
			ForegroundEnabled = ForegroundEnabled,
			BackgroundEnabled = BackgroundEnabled,
			LiveVideoEnabled = LiveVideoEnabled,
			TemplateId = TemplateId,
			_templatePath = _templatePath,
			MaskId = MaskId
		};
	}

	public override int GetHashCode()
	{
		if (!_hashCode.HasValue)
		{
			_hashCode = HashCodeHelper.GenerateHashCode(ScreenId, PropsEnabled, MessagesEnabled, AnnouncementEnabled, ForegroundEnabled, BackgroundEnabled, LiveVideoEnabled, TemplateId, TemplatePath, MaskId);
		}
		return _hashCode.Value;
	}

	public override bool Equals(object? obj)
	{
		if (obj is ScreenLook other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(ScreenLook? other)
	{
		if ((object)other == null)
		{
			return false;
		}
		Guid? screenId = ScreenId;
		Guid? screenId2 = other.ScreenId;
		if (screenId.HasValue == screenId2.HasValue && (!screenId.HasValue || screenId.GetValueOrDefault() == screenId2.GetValueOrDefault()) && PropsEnabled == other.PropsEnabled && MessagesEnabled == other.MessagesEnabled && AnnouncementEnabled == other.AnnouncementEnabled && ForegroundEnabled == other.ForegroundEnabled && BackgroundEnabled == other.BackgroundEnabled && LiveVideoEnabled == other.LiveVideoEnabled && MaskId == other.MaskId)
		{
			screenId = TemplateId;
			screenId2 = other.TemplateId;
			if (screenId.HasValue != screenId2.HasValue)
			{
				return false;
			}
			if (!screenId.HasValue)
			{
				return true;
			}
			return screenId.GetValueOrDefault() == screenId2.GetValueOrDefault();
		}
		return false;
	}

	public static bool operator ==(ScreenLook? lhs, ScreenLook? rhs)
	{
		return lhs.NullableEquals(rhs);
	}

	public static bool operator !=(ScreenLook lhs, ScreenLook rhs)
	{
		return !lhs.NullableEquals<ScreenLook>(rhs);
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnPropsEnabledChanged(bool value)
	{
		OnDataModified();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnMessagesEnabledChanged(bool value)
	{
		OnDataModified();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnAnnouncementEnabledChanged(bool value)
	{
		OnDataModified();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnForegroundEnabledChanged(bool value)
	{
		OnDataModified();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnBackgroundEnabledChanged(bool value)
	{
		OnDataModified();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnLiveVideoEnabledChanged(bool value)
	{
		OnDataModified();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnMaskIdChanged(Guid? value)
	{
		OnDataModified();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnScreenIdChanged(Guid? value)
	{
		OnDataModified();
	}
}
