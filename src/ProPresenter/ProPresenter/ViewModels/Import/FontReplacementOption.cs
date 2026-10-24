using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Text;
using ProPresenter.DO.Import;

namespace ProPresenter.ViewModels.Import;

public class FontReplacementOption : ObservableObject, IFontReplacementOption, INotifyPropertyChanged
{
	[ObservableProperty]
	private string _displayName = string.Empty;

	[ObservableProperty]
	private FontInfo? _fontInfo;

	[ObservableProperty]
	private bool _isDefault;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string DisplayName
	{
		get
		{
			return _displayName;
		}
		[MemberNotNull("_displayName")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_displayName, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.DisplayName);
				_displayName = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.DisplayName);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public FontInfo? FontInfo
	{
		get
		{
			return _fontInfo;
		}
		set
		{
			if (!EqualityComparer<Pro.Text.FontInfo?>.Default.Equals(_fontInfo, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.FontInfo);
				_fontInfo = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.FontInfo);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsDefault
	{
		get
		{
			return _isDefault;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isDefault, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsDefault);
				_isDefault = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsDefault);
			}
		}
	}

	public override string ToString()
	{
		return DisplayName;
	}
}
