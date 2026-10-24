using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using ProPresenter.DO.Import;

namespace ProPresenter.ViewModels.Import;

public class MissingFontItemVM : ObservableObject, IMissingFontItemVM, INotifyPropertyChanged
{
	[ObservableProperty]
	private IFontReplacementOption? _selectedReplacement;

	public IReadOnlyList<MissingFontInfo> MissingFontInfo { get; }

	public string FontName { get; }

	public int UsageCount { get; }

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IFontReplacementOption? SelectedReplacement
	{
		get
		{
			return _selectedReplacement;
		}
		set
		{
			if (!EqualityComparer<IFontReplacementOption>.Default.Equals(_selectedReplacement, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SelectedReplacement);
				_selectedReplacement = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SelectedReplacement);
			}
		}
	}

	public MissingFontItemVM(string familyName, IReadOnlyList<MissingFontInfo> missingFontInfo)
	{
		MissingFontInfo = missingFontInfo;
		FontName = familyName;
		UsageCount = MissingFontInfo.Sum((MissingFontInfo mf) => mf.UsageCount);
	}
}
