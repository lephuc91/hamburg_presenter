using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Utility;
using ProPresenter.DO.Looks;
using ProPresenter.DO.Masks;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Themes;

namespace ProPresenter.UI.ViewModels.LooksDialog;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class LiveAudienceLookVM : ObservableObject, IDisposable
{
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("HasChanges", "HasChanges")]
	private readonly LiveAudienceLook _liveLook;

	private readonly IDisposable _lookSubscription;

	[ObservableProperty]
	private AudienceLookVM _audienceLook;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public bool HasChanges => _liveLook.HasChanges;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public AudienceLookVM AudienceLook
	{
		get
		{
			return _audienceLook;
		}
		[MemberNotNull("_audienceLook")]
		set
		{
			if (!EqualityComparer<AudienceLookVM>.Default.Equals(_audienceLook, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.AudienceLook);
				_audienceLook = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.AudienceLook);
			}
		}
	}

	public LiveAudienceLookVM(IThemeCollection themes, IMaskCollection masks, AudienceScreenArrangementCollection audienceScreens, LiveAudienceLook liveLook)
	{
		LiveAudienceLookVM liveAudienceLookVM = this;
		_liveLook = liveLook;
		_audienceLook = new AudienceLookVM(themes, masks, audienceScreens, liveLook.Live);
		_lookSubscription = _liveLook.WhenPropertyChanges("Live").Subscribe(delegate
		{
			liveAudienceLookVM._audienceLook.Dispose();
			liveAudienceLookVM.AudienceLook = new AudienceLookVM(themes, masks, audienceScreens, liveLook.Live);
		});
		AddPropertyLinks();
	}

	public bool IsLive(AudienceLookVM look)
	{
		return _liveLook.IsLive(look.BackingAudienceLook);
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
		_lookSubscription.Dispose();
		_audienceLook.Dispose();
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void _liveLook_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "HasChanges")
		{
			OnPropertyChanged("HasChanges");
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void AddPropertyLinks()
	{
		_liveLook.PropertyChanged += _liveLook_PropertyChanged;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void RemovePropertyLinks()
	{
		_liveLook.PropertyChanged -= _liveLook_PropertyChanged;
	}
}
