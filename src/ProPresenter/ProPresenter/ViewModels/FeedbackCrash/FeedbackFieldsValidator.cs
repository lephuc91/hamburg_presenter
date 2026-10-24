using FluentValidation;
using Pro.Common.Strings;
using Pro.Localization;
using ProPresenter.UI.Feedback;

namespace ProPresenter.ViewModels.FeedbackCrash;

public class FeedbackFieldsValidator : AbstractValidator<FeedbackVM>
{
	public FeedbackFieldsValidator()
	{
		RuleFor((FeedbackVM vm) => vm.Email).Must((string e) => e.IsValidEmail()).WithMessage<FeedbackVM, string>((FeedbackVM vm) => LocalizedStrings.Get("USER_FEEDBACK_EMAIL_INVALID_tooltip"));
		RuleFor((FeedbackVM vm) => vm.Name).NotEmpty().WithMessage<FeedbackVM, string>((FeedbackVM vm) => LocalizedStrings.Get("USER_FEEDBACK_FIELD_REQUIRED_tooltip"));
		RuleFor((FeedbackVM vm) => vm.RequestType).Must((FeedbackRequestType e) => e != FeedbackRequestType.None).WithMessage<FeedbackVM, FeedbackRequestType>((FeedbackVM vm) => LocalizedStrings.Get("USER_FEEDBACK_FIELD_REQUIRED_tooltip"));
		RuleFor((FeedbackVM vm) => vm.Description).NotEmpty().WithMessage<FeedbackVM, string>((FeedbackVM vm) => LocalizedStrings.Get("USER_FEEDBACK_FIELD_REQUIRED_tooltip"));
		RuleFor((FeedbackVM vm) => vm.Subject).NotEmpty().WithMessage<FeedbackVM, string>((FeedbackVM vm) => LocalizedStrings.Get("USER_FEEDBACK_FIELD_REQUIRED_tooltip"));
		RuleFor((FeedbackVM vm) => vm.TicketId).Must<FeedbackVM, string>((FeedbackVM vm, string i) => vm.RequestType != FeedbackRequestType.TechnicalIssue || !vm.PreviousTicketSelected || !string.IsNullOrEmpty(i)).WithMessage((FeedbackVM vm) => LocalizedStrings.Get("USER_FEEDBACK_FIELD_REQUIRED_tooltip"));
	}
}
