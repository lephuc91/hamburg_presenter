using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.Mathematics;
using ProPresenter.DO;
using ProPresenter.UI.ViewModels.Import;

namespace ProPresenter.ViewModels.Import;

public class ImportPowerpointSelectionVM : ImportSelectionVM, IImportPowerpointSelectionVM, IImportSelectionVM, INotifyPropertyChanged, ISizeableTarget
{
	[ObservableProperty]
	private Vector2<double> _size;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public Vector2<double> Size
	{
		get
		{
			return _size;
		}
		set
		{
			if (!EqualityComparer<Vector2<double>>.Default.Equals(_size, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Size);
				_size = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Size);
			}
		}
	}

	public void ChangeSize(Vector2<double> size)
	{
		Size = size;
	}
}
