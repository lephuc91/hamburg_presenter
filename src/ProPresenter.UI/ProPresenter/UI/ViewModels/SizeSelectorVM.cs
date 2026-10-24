using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Pro.Common.Components;
using Pro.Common.Mathematics;
using Pro.UI.Components;
using Pro.UI.DependencyInjection;
using Pro.UI.DialogService;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.UI.ViewModels;

public class SizeSelectorVM : LinkedNotifyPropertyChangedBase, ISizeSelectorVM, INotifyPropertyChanged
{
	private static readonly Vector2<double>[] DefaultCommonSizes = new Vector2<double>[4]
	{
		new Vector2<double>(1920.0, 1080.0),
		new Vector2<double>(1280.0, 720.0),
		new Vector2<double>(1024.0, 768.0),
		new Vector2<double>(800.0, 600.0)
	};

	private Vector2<double>? _customSize;

	private Vector2<double> _selectedSize;

	private ISizeableTarget? _target;

	private bool _setTargetToDefaultSize;

	private ScreenTargetType _screenTargetType;

	private readonly IOutputService _outputService;

	public ISizeableTarget? Target
	{
		get
		{
			return _target;
		}
		set
		{
			SetValue<ISizeableTarget>("Target", ref _target, value, delegate(ISizeableTarget o, ISizeableTarget n)
			{
				if (o != null)
				{
					o.PropertyChanged -= base.RaiseLinkedValues;
				}
				if (n != null)
				{
					n.PropertyChanged += base.RaiseLinkedValues;
				}
				if (SetTargetToDefaultSize)
				{
					SetDefaultSize();
				}
				ValidateSelectedSize();
				OnPropertyChanged("SelectedSize");
				OnPropertyChanged("SizeIsConfigured");
			});
		}
	}

	public Vector2<double> SelectedSize => Target?.Size ?? _selectedSize;

	public bool SizeIsConfigured
	{
		get
		{
			if (TargetScreens.Any())
			{
				return ScreenSizes.Contains(SelectedSize);
			}
			return true;
		}
	}

	public ScreenArrangementCollectionBase TargetScreens => ScreenTargetType switch
	{
		ScreenTargetType.Audience => _outputService.OutputRepository.AudienceScreenArrangementCollection, 
		ScreenTargetType.Stage => _outputService.OutputRepository.StageScreenArrangementCollection, 
		_ => throw new NotSupportedException(), 
	};

	private IEnumerable<Vector2<double>> ScreenSizes => TargetScreens.Select((ScreenArrangementBase s) => s.TotalSize);

	public IEnumerable<Vector2<double>> CommonSizes => DefaultCommonSizes;

	public Vector2<double>? CustomSize
	{
		get
		{
			return _customSize;
		}
		set
		{
			SetValue("CustomSize", ref _customSize, value);
		}
	}

	public bool SetTargetToDefaultSize
	{
		get
		{
			return _setTargetToDefaultSize;
		}
		set
		{
			SetValue("SetTargetToDefaultSize", ref _setTargetToDefaultSize, value, SetDefaultSize);
		}
	}

	public ICommand<Vector2<double>> SelectSizeCommand => new RelayCommand<Vector2<double>>(SelectSize);

	public ICommand CustomSizeCommand => new RelayCommand(OnCustomSizeCommand);

	public ICommand ResizeToScreenCommand => new RelayCommand(OnResizeToScreenCommand);

	public Func<Vector2<double>, bool>? ConfirmResize { get; set; }

	public ScreenTargetType ScreenTargetType
	{
		get
		{
			return _screenTargetType;
		}
		set
		{
			SetValue("ScreenTargetType", ref _screenTargetType, value, (Action)delegate
			{
				OnPropertyChanged("TargetScreens");
			}, (Predicate<ScreenTargetType>?)null, referenceComparison: false);
		}
	}

	public SizeSelectorVM()
		: this(UIServiceProvider.GetService<IOutputService>())
	{
	}

	public SizeSelectorVM(IOutputService outputService)
	{
		_outputService = outputService;
		_outputService.OutputRepository.AudienceScreenArrangementCollection.CollectionModified += Screens_CollectionModified;
		_outputService.OutputRepository.StageScreenArrangementCollection.CollectionModified += Screens_CollectionModified;
		LinkAction("Size", delegate
		{
			ValidateSelectedSize();
			OnPropertyChanged("SelectedSize");
			OnPropertyChanged("SizeIsConfigured");
		});
	}

	private void Screens_CollectionModified(ScreenArrangementCollectionBase screens)
	{
		ValidateSelectedSize();
		OnPropertyChanged("SizeIsConfigured");
	}

	private void SetDefaultSize()
	{
		SelectSize(ScreenSizes.Union(CommonSizes).First());
	}

	private void SelectSize(Vector2<double> size)
	{
		Func<Vector2<double>, bool>? confirmResize = ConfirmResize;
		if (confirmResize == null || confirmResize(size))
		{
			if (Target != null)
			{
				Target.ChangeSize(size);
			}
			else
			{
				_selectedSize = size;
				OnPropertyChanged("SelectedSize");
				OnPropertyChanged("SizeIsConfigured");
			}
			ValidateSelectedSize();
		}
	}

	private void OnCustomSizeCommand()
	{
		CustomSizeDialog customSizeDialog = new CustomSizeDialog(SelectedSize.X, SelectedSize.Y);
		if (MessageDialogService.ShowSimpleContent(string.Empty, (DependencyObject)(object)customSizeDialog))
		{
			SelectSize(new Vector2<double>(customSizeDialog.X, customSizeDialog.Y));
		}
	}

	private void OnResizeToScreenCommand()
	{
		if (TargetScreens.Count == 1)
		{
			SelectSize(TargetScreens[0].TotalSize);
			return;
		}
		ResizeToScreenDialog resizeToScreenDialog = new ResizeToScreenDialog(TargetScreens);
		if (MessageDialogService.ShowSimpleContent(string.Empty, (DependencyObject)(object)resizeToScreenDialog))
		{
			SelectSize(resizeToScreenDialog.SelectedScreen.TotalSize);
		}
	}

	private void ValidateSelectedSize()
	{
		CustomSize = (ScreenSizes.Union(CommonSizes).Contains(SelectedSize) ? ((Vector2<double>?)null) : new Vector2<double>?(SelectedSize));
	}
}
