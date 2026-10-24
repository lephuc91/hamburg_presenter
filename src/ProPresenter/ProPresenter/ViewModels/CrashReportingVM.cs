using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO.Abstractions;
using System.Threading.Tasks;
using System.Windows.Documents;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using FluentValidation.Results;
using Pro.Common.Collections;
using Pro.Common.HTTP;
using Pro.Common.HTTP.Results;
using Pro.Common.Internet;
using Pro.Common.Logging;
using Pro.Localization;
using Pro.Reporting.UserFeedback;
using Pro.Reporting.UserFeedback.AttachmentUpload;
using Pro.Reporting.UserFeedback.AttachmentUpload.Model;
using Pro.UI.Controls.Windowing;
using Pro.UI.DialogService;
using Pro.UI.Utility;
using ProPresenter.DO.Registration.State;
using ProPresenter.DO.Registration.State.ProPresenter;
using ProPresenter.DO.Settings;
using ProPresenter.UI.UserAttachments;
using ProPresenter.UI.ViewModels.FeedbackCrash;
using ProPresenter.UI.ViewModels.UserAttachments;
using ProPresenter.ViewModels.FeedbackCrash;

namespace ProPresenter.ViewModels;

public class CrashReportingVM : ObservableObject, ICrashReportingVM, IDataErrorInfo
{
	private readonly ILogger _logger;

	private readonly IUserFeedbackConsumer _apiConsumer;

	private readonly IRegistrationStateProvider _registrationStateProvider;

	private readonly string _crashOutputFolder;

	private readonly IFileSystem _fileSystem;

	private readonly IInternetAccessCheck _internetAccessCheck;

	private readonly IAttachmentsUploader _attachmentsUploader;

	private readonly IAttachmentUploadJobFactory _attachmentUploadJobFactory;

	private readonly IUserAttachmentVMFactory _userAttachmentVMFactory;

	private ValidationResult? _validationResult;

	private readonly CrashReportFieldsValidator _validator;

	private readonly IGeneral _general;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly IMessageDialogService _messageDialogService;

	private const string DefaultEmail = "support+crash-report@renewedvision.com";

	private const string DefaultName = "DO NOT REPLY";

	[ObservableProperty]
	private string _email = string.Empty;

	[ObservableProperty]
	private string _name = string.Empty;

	[ObservableProperty]
	private string _ticketId = string.Empty;

	[ObservableProperty]
	private string _description = string.Empty;

	[ObservableProperty]
	private IUserAttachmentCollectionVM? _attachments;

	[ObservableProperty]
	private IUserAttachmentsVM? _attachmentsVM;

	[ObservableProperty]
	private bool _supportFollowupSelected;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<ICloseable>? submitCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<object>? hyperlink_RequestNavigateCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<ICloseable>? cancelCommand;

	public string HardwareId => _registrationStateProvider.HardwareInformation.HardwareIdentifier;

	public string ActivationKey => (_registrationStateProvider.Registration.ProPresenter as IRegisteredState)?.ActivationKey ?? string.Empty;

	public bool NetworkAvailable => _internetAccessCheck.Available();

	public string Error
	{
		get
		{
			if (_validationResult == null)
			{
				return string.Empty;
			}
			if (!_validationResult.IsValid)
			{
				return LocalizedStrings.Get("CRASH_REPORT_NOT_SUBMITTED_label");
			}
			return string.Empty;
		}
	}

	public string this[string columnName] => _validationResult?.Errors.Find((ValidationFailure r) => r.PropertyName == columnName)?.ErrorMessage ?? string.Empty;

	public bool IsEnableCrashReporting => _general.EnableCrashReporting;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Email
	{
		get
		{
			return _email;
		}
		[MemberNotNull("_email")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_email, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Email);
				_email = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Email);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Name
	{
		get
		{
			return _name;
		}
		[MemberNotNull("_name")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_name, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Name);
				_name = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Name);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string TicketId
	{
		get
		{
			return _ticketId;
		}
		[MemberNotNull("_ticketId")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_ticketId, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.TicketId);
				_ticketId = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.TicketId);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Description
	{
		get
		{
			return _description;
		}
		[MemberNotNull("_description")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_description, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Description);
				_description = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Description);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IUserAttachmentCollectionVM? Attachments
	{
		get
		{
			return _attachments;
		}
		set
		{
			if (!EqualityComparer<IUserAttachmentCollectionVM>.Default.Equals(_attachments, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Attachments);
				_attachments = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Attachments);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IUserAttachmentsVM? AttachmentsVM
	{
		get
		{
			return _attachmentsVM;
		}
		set
		{
			if (!EqualityComparer<IUserAttachmentsVM>.Default.Equals(_attachmentsVM, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.AttachmentsVM);
				_attachmentsVM = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.AttachmentsVM);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool SupportFollowupSelected
	{
		get
		{
			return _supportFollowupSelected;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_supportFollowupSelected, value))
			{
				bool supportFollowupSelected = _supportFollowupSelected;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SupportFollowupSelected);
				_supportFollowupSelected = value;
				OnSupportFollowupSelectedChanged(supportFollowupSelected, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SupportFollowupSelected);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<ICloseable> SubmitCommand => submitCommand ?? (submitCommand = new AsyncRelayCommand<ICloseable>(Submit, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<object> Hyperlink_RequestNavigateCommand => hyperlink_RequestNavigateCommand ?? (hyperlink_RequestNavigateCommand = new RelayCommand<object>(Hyperlink_RequestNavigate));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<ICloseable> CancelCommand => cancelCommand ?? (cancelCommand = new RelayCommand<ICloseable>(Cancel));

	public CrashReportingVM(ILogger logger, IUserFeedbackConsumer apiConsumer, IRegistrationStateProvider registrationStateProvider, string crashOutputFolder, IFileSystem fileSystem, IUserAttachmentVMFactory userAttachmentVMFactory, IInternetAccessCheck internetAccessCheck, IAttachmentsUploader attachmentsUploader, IAttachmentUploadJobFactory attachmentUploadJobFactory, IGeneral general, IHyperlinkService hyperlinkService, IMessageDialogService messageDialogService)
	{
		_logger = logger ?? throw new ArgumentNullException("logger");
		_apiConsumer = apiConsumer ?? throw new ArgumentNullException("apiConsumer");
		_registrationStateProvider = registrationStateProvider;
		_crashOutputFolder = crashOutputFolder;
		_fileSystem = fileSystem;
		_userAttachmentVMFactory = userAttachmentVMFactory;
		_internetAccessCheck = internetAccessCheck;
		_attachmentsUploader = attachmentsUploader;
		_attachmentUploadJobFactory = attachmentUploadJobFactory;
		_hyperlinkService = hyperlinkService;
		_messageDialogService = messageDialogService;
		_internetAccessCheck.WhenIsAvailableChanged.Subscribe(delegate
		{
			OnPropertyChanged("NetworkAvailable");
		});
		_validator = new CrashReportFieldsValidator();
		_general = general;
	}

	private async Task<IUserAttachSettings> GetSettingsAsync()
	{
		return new UserAttachSettings((await _apiConsumer.GetCrashReportAttachmentSettingsAsync() is SuccessResult<AttachmentSettings> successResult) ? successResult.Data : AttachmentSettings.RestrictiveDefault);
	}

	private async Task ResetDataAsync()
	{
		Email = string.Empty;
		Name = string.Empty;
		TicketId = string.Empty;
		Description = string.Empty;
		SupportFollowupSelected = false;
		IUserAttachSettings userAttachSettings = await GetSettingsAsync();
		Attachments = _userAttachmentVMFactory.CreateUserAttachmentCollectionVM(userAttachSettings);
		AttachmentsVM = _userAttachmentVMFactory.CreateUserAttachmentsVM(Attachments);
		AttachmentsVM?.AttachSystemInformationCommand.Invoke();
	}

	public async Task<bool> ResetDataAsync(bool hasCrashed)
	{
		await ResetDataAsync();
		if (Attachments == null || AttachmentsVM == null || !AttachmentsVM.IsValid)
		{
			_logger.Warning("Could not get Crash Report Settings");
			return false;
		}
		if (hasCrashed)
		{
			await HandleCrashState(AttachmentsVM, Attachments);
		}
		return true;
	}

	public void Cleanup()
	{
		if (!string.IsNullOrEmpty(_crashOutputFolder) && _fileSystem.Directory.Exists(_crashOutputFolder))
		{
			_fileSystem.Directory.Delete(_crashOutputFolder, recursive: true);
		}
		AttachmentsVM?.AttachSystemDiagnosticsCommand.Cancel();
	}

	private async Task HandleCrashState(IUserAttachmentsVM attachmentsVM, IUserAttachmentCollectionVM attachments)
	{
		if (!string.IsNullOrEmpty(_crashOutputFolder) && _fileSystem.Directory.Exists(_crashOutputFolder))
		{
			string[] files = _fileSystem.Directory.GetFiles(_crashOutputFolder);
			if (files.None((string f) => f.EndsWith(".systeminfo")))
			{
				attachmentsVM.AttachSystemDiagnosticsCommand.Invoke();
			}
			await attachments.AddAsync(files);
		}
		else
		{
			attachmentsVM.AttachSystemDiagnosticsCommand.Invoke();
		}
	}

	[RelayCommand(FlowExceptionsToTaskScheduler = true)]
	private async Task Submit(ICloseable closeable)
	{
		if (!CanSubmit() || !NetworkAvailable)
		{
			return;
		}
		bool success = false;
		try
		{
			await AttachmentsVM.PrepareAttachmentUploads();
			if (string.IsNullOrEmpty(Email))
			{
				Email = "support+crash-report@renewedvision.com";
			}
			if (string.IsNullOrEmpty(Name))
			{
				Name = "DO NOT REPLY";
			}
			CrashReport report = new CrashReport(Email, HardwareId, ActivationKey, TicketId, Description, Attachments.ToFileAttachments(), Name);
			if ((await _apiConsumer.PostCrashReportAsync(report)) is SuccessResult<bool>)
			{
				success = true;
			}
		}
		catch (Exception ex)
		{
			_logger.Error(ex);
		}
		finally
		{
			if (success)
			{
				Attachments?.Upload(_attachmentsUploader, _attachmentUploadJobFactory);
				AttachmentsVM?.CleanupWorkspaceAttachment();
				closeable.Close();
			}
			else
			{
				_messageDialogService.ShowAlert(LocalizedStrings.Get("CRASH_REPORT_FORM_COULD_NOT_SEND_message"));
			}
		}
	}

	[RelayCommand]
	public void Hyperlink_RequestNavigate(object sender)
	{
		if (sender is Hyperlink hyperlink)
		{
			_hyperlinkService.Open(hyperlink.NavigateUri);
		}
	}

	[RelayCommand]
	private void Cancel(ICloseable closeable)
	{
		AttachmentsVM?.CleanupWorkspaceAttachment();
		closeable?.Close();
	}

	[MemberNotNullWhen(true, new string[] { "AttachmentsVM", "Attachments" })]
	private bool CanSubmit()
	{
		if (Attachments == null || AttachmentsVM == null || !AttachmentsVM.IsValid)
		{
			return false;
		}
		_validationResult = _validator.Validate(this);
		bool isValid = _validationResult.IsValid;
		NotifyPropertyChangeForRequiredFields();
		_validationResult = null;
		return isValid;
	}

	private void NotifyPropertyChangeForRequiredFields()
	{
		OnPropertyChanged("Email");
		OnPropertyChanged("Name");
		OnPropertyChanged("Error");
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnSupportFollowupSelectedChanged(bool oldValue, bool newValue)
	{
		if (!newValue)
		{
			Email = string.Empty;
			Name = string.Empty;
		}
	}
}
