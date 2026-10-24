using System.ComponentModel;
using System.Windows.Input;
using Pro.Common.Components;
using Pro.UI.Components;
using ProPresenter.Controller;
using ProPresenter.DO.Looks;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels;

public class ToolBarVM : NotifyPropertyChangedBase, IToolBarVM, INotifyPropertyChanged
{
	private readonly ICoreManager _coreManager;

	private readonly ITriggering _triggerService;

	private ICaptureVM _captureVM;

	private bool _isAudienceEnabled;

	private bool _isStageEnabled;

	public ICaptureVM CaptureVM
	{
		get
		{
			return _captureVM;
		}
		private set
		{
			SetValue("CaptureVM", ref _captureVM, value);
		}
	}

	public bool IsAudienceEnabled
	{
		get
		{
			return _isAudienceEnabled;
		}
		private set
		{
			SetValue("IsAudienceEnabled", ref _isAudienceEnabled, value);
		}
	}

	public bool IsStageEnabled
	{
		get
		{
			return _isStageEnabled;
		}
		private set
		{
			SetValue("IsStageEnabled", ref _isStageEnabled, value);
		}
	}

	public LiveAudienceLook LiveLook => _coreManager.OutputConfiguration.LiveLook;

	public IAudienceLookCollection Looks => _coreManager.OutputConfiguration.AudienceLooks;

	public ICommand TriggerLookCommand { get; }

	public ToolBarVM(ICoreManager coreManager, ICaptureVM captureVM, ITriggeringFactory triggeringFactory)
	{
		_coreManager = coreManager;
		_coreManager.PropertyChanged += OnCoreManagerPropertyChanged;
		_coreManager.OutputConfiguration.PropertyChanged += OutputConfigurationOnPropertyChanged;
		_captureVM = captureVM;
		Initialize();
		_triggerService = triggeringFactory.Create();
		TriggerLookCommand = new RelayCommand<AudienceLook>(TriggerLook);
	}

	protected void OnCoreManagerPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (!(propertyName == "AudienceEnable"))
		{
			if (propertyName == "StageEnable")
			{
				IsStageEnabled = _coreManager.StageEnable;
			}
		}
		else
		{
			IsAudienceEnabled = _coreManager.AudienceEnable;
		}
	}

	private void Initialize()
	{
		IsStageEnabled = _coreManager.StageEnable;
		IsAudienceEnabled = _coreManager.AudienceEnable;
	}

	private void OutputConfigurationOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "LiveLook")
		{
			OnPropertyChanged("LiveLook");
		}
	}

	private void TriggerLook(AudienceLook look)
	{
		_triggerService.TriggerAudienceLook(look);
	}
}
