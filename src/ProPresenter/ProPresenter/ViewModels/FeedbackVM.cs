using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Documents;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using FluentValidation.Results;
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
using ProPresenter.UI.Feedback;
using ProPresenter.UI.UserAttachments;
using ProPresenter.UI.ViewModels.FeedbackCrash;
using ProPresenter.UI.ViewModels.UserAttachments;
using ProPresenter.ViewModels.FeedbackCrash;

namespace ProPresenter.ViewModels;

public class FeedbackVM : ObservableObject, IFeedbackVM, IDataErrorInfo
{
	private readonly ILogger _logger;

	private readonly IUserFeedbackConsumer _apiConsumer;

	private readonly IRegistrationStateProvider _registrationStateProvider;

	private readonly IUserAttachmentVMFactory _userAttachmentVMFactory;

	private readonly IInternetAccessCheck _internetAccessCheck;

	private readonly FeedbackFieldsValidator _validator;

	private ValidationResult? _validationResult;

	private readonly IAttachmentsUploader _attachmentsUploader;

	private readonly IAttachmentUploadJobFactory _attachmentUploadJobFactory;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly IMessageDialogService _messageDialogService;

	[ObservableProperty]
	private string _email = string.Empty;

	[ObservableProperty]
	private string _name = string.Empty;

	[ObservableProperty]
	private FeedbackRequestType _requestType;

	[ObservableProperty]
	private string _subject = string.Empty;

	[ObservableProperty]
	private string _ticketId = string.Empty;

	[ObservableProperty]
	private string _description = string.Empty;

	[ObservableProperty]
	private IUserAttachmentCollectionVM? _attachments;

	[ObservableProperty]
	private IUserAttachmentsVM? _attachmentsVM;

	[ObservableProperty]
	private bool _previousTicketSelected;

	[ObservableProperty]
	private bool _isInternal;

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
				return LocalizedStrings.Get("USER_FEEDBACK_NOT_SUBMITTED_label");
			}
			return string.Empty;
		}
	}

	public string this[string columnName] => _validationResult?.Errors.FirstOrDefault((ValidationFailure r) => r.PropertyName == columnName)?.ErrorMessage ?? string.Empty;

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
	public FeedbackRequestType RequestType
	{
		get
		{
			return _requestType;
		}
		set
		{
			if (!EqualityComparer<FeedbackRequestType>.Default.Equals(_requestType, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.RequestType);
				_requestType = value;
				OnRequestTypeChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.RequestType);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Subject
	{
		get
		{
			return _subject;
		}
		[MemberNotNull("_subject")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_subject, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Subject);
				_subject = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Subject);
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
	public bool PreviousTicketSelected
	{
		get
		{
			return _previousTicketSelected;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_previousTicketSelected, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.PreviousTicketSelected);
				_previousTicketSelected = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.PreviousTicketSelected);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsInternal
	{
		get
		{
			return _isInternal;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isInternal, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsInternal);
				_isInternal = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsInternal);
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

	public FeedbackVM(ILogger logger, IUserFeedbackConsumer apiConsumer, IRegistrationStateProvider registrationStateProvider, IUserAttachmentVMFactory userAttachmentVMFactory, IInternetAccessCheck internetAccessCheck, IAttachmentsUploader attachmentsUploader, IAttachmentUploadJobFactory attachmentUploadJobFactory, IHyperlinkService hyperlinkService, IMessageDialogService messageDialogService)
	{
		_logger = logger ?? throw new ArgumentNullException("logger");
		_apiConsumer = apiConsumer ?? throw new ArgumentNullException("apiConsumer");
		_registrationStateProvider = registrationStateProvider;
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
		_validator = new FeedbackFieldsValidator();
	}

	private async Task<UserAttachSettings> GetSettingsAsync()
	{
		return new UserAttachSettings((await _apiConsumer.GetFeedbackAttachmentSettingsAsync() is SuccessResult<AttachmentSettings> successResult) ? successResult.Data : AttachmentSettings.RestrictiveDefault);
	}

	private async Task ResetDataAsync()
	{
		Email = string.Empty;
		Name = string.Empty;
		RequestType = FeedbackRequestType.None;
		Subject = string.Empty;
		TicketId = string.Empty;
		Description = string.Empty;
		PreviousTicketSelected = false;
		IsInternal = false;
		UserAttachSettings userAttachSettings = await GetSettingsAsync();
		Attachments = _userAttachmentVMFactory.CreateUserAttachmentCollectionVM(userAttachSettings);
		AttachmentsVM = _userAttachmentVMFactory.CreateUserAttachmentsVM(Attachments);
		AttachmentsVM?.AttachSystemInformationCommand.Invoke();
	}

	public async Task<bool> ResetDataAsync(bool isReportingIssue)
	{
		return await ResetDataAsync(isReportingIssue, isInternal: false);
	}

	public async Task<bool> ResetDataAsync(bool isReportingIssue, bool isInternal)
	{
		await ResetDataAsync();
		RequestType = (isReportingIssue ? FeedbackRequestType.TechnicalIssue : FeedbackRequestType.None);
		IsInternal = isInternal;
		if (AttachmentsVM == null || !AttachmentsVM.IsValid)
		{
			_logger.Warning("Could not get Feedback Settings");
			return false;
		}
		if (isInternal)
		{
			AttachmentsVM.AttachCloudDocumentsCommand.Invoke();
		}
		return true;
	}

	public void Cleanup()
	{
		AttachmentsVM?.AttachSystemDiagnosticsCommand.Cancel();
		AttachmentsVM?.CleanupWorkspaceAttachment();
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
			FeedbackReport report = new FeedbackReport(Email, HardwareId, ActivationKey, Description, Attachments.ToFileAttachments(), RequestType.ToString(), Subject, Name, TicketId, IsInternal);
			if ((await _apiConsumer.PostFeedbackAsync(report)) is SuccessResult<bool>)
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
				closeable?.Close();
			}
			else
			{
				_messageDialogService.ShowAlert(LocalizedStrings.Get("USER_FEEDBACK_FORM_COULD_NOT_SEND_message"));
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

	[RelayCommand]
	private void Cancel(ICloseable closeable)
	{
		AttachmentsVM?.CleanupWorkspaceAttachment();
		closeable?.Close();
	}

	private void NotifyPropertyChangeForRequiredFields()
	{
		OnPropertyChanged("Email");
		OnPropertyChanged("Name");
		OnPropertyChanged("RequestType");
		OnPropertyChanged("Subject");
		OnPropertyChanged("Description");
		OnPropertyChanged("TicketId");
		OnPropertyChanged("IsInternal");
		OnPropertyChanged("Error");
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnRequestTypeChanged(FeedbackRequestType value)
	{
		if (value != FeedbackRequestType.TechnicalIssue)
		{
			PreviousTicketSelected = false;
			TicketId = string.Empty;
		}
		else
		{
			AttachmentsVM?.AttachSystemDiagnosticsCommand.Invoke();
			AttachmentsVM?.AttachProgramFileLogCommand.Invoke();
		}
	}
}
