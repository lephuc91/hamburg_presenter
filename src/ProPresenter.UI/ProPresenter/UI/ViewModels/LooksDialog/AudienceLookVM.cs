using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Time;
using ProPresenter.Controller;
using ProPresenter.DO.Looks;
using ProPresenter.DO.Masks;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Themes;

namespace ProPresenter.UI.ViewModels.LooksDialog;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class AudienceLookVM : ObservableObject, ICloneable<AudienceLookVM>, IDisposable
{
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("Name", "Name")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("TransitionDuration", "TransitionDuration")]
	private readonly AudienceLook _audienceLook;

	private readonly IThemeCollection _themes;

	private readonly IMaskCollection _masks;

	private readonly AudienceScreenArrangementCollection _audienceScreens;

	private PairedCollection<ScreenLook, ScreenLookVM> _screenLooks;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public string Name
	{
		get
		{
			return _audienceLook.Name;
		}
		set
		{
			_audienceLook.Name = value;
		}
	}

	public TimeSlice MaximumTransitionDuration => AudienceLook.MaximumTransitionDuration;

	public TimeSlice MinimumTransitionDuration => AudienceLook.MinimumTransitionDuration;

	public TimeSlice TransitionDuration
	{
		get
		{
			return _audienceLook.TransitionDuration;
		}
		set
		{
			_audienceLook.TransitionDuration = value;
		}
	}

	public IReadOnlyCollection<ScreenLookVM> ScreenLooks => _screenLooks;

	internal AudienceLook BackingAudienceLook => _audienceLook;

	public AudienceLookVM(IThemeCollection themes, IMaskCollection masks, AudienceScreenArrangementCollection audienceScreens, AudienceLook audienceLook)
	{
		AudienceLookVM audienceLookVM = this;
		_themes = themes;
		_masks = masks;
		_audienceScreens = audienceScreens;
		_audienceLook = audienceLook;
		_screenLooks = new PairedCollection<ScreenLook, ScreenLookVM>(_audienceLook.ScreenLooks, (ScreenLook s) => new ScreenLookVM(themes, masks, audienceLookVM._audienceScreens, s), delegate(ScreenLookVM t)
		{
			t.Dispose();
		});
		AddPropertyLinks();
	}

	public void Trigger(ITriggering triggering)
	{
		triggering.TriggerAudienceLook(_audienceLook);
	}

	public AudienceLookVM Clone()
	{
		return new AudienceLookVM(_themes, _masks, _audienceScreens, _audienceLook.Clone());
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
		RemovePropertyLinks();
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void _audienceLook_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (!(propertyName == "Name"))
		{
			if (propertyName == "TransitionDuration")
			{
				OnPropertyChanged("TransitionDuration");
			}
		}
		else
		{
			OnPropertyChanged("Name");
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void AddPropertyLinks()
	{
		_audienceLook.PropertyChanged += _audienceLook_PropertyChanged;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void RemovePropertyLinks()
	{
		_audienceLook.PropertyChanged -= _audienceLook_PropertyChanged;
	}
}
