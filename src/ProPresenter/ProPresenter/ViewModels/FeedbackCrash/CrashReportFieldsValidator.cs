using FluentValidation;
using Pro.Common.Strings;
using Pro.Localization;

namespace ProPresenter.ViewModels.FeedbackCrash;

public class CrashReportFieldsValidator : AbstractValidator<CrashReportingVM>
{
	public CrashReportFieldsValidator()
	{
		bool emailEmpty = false;
		bool emailValid = false;
		RuleFor((CrashReportingVM vm) => vm.Email).Must<CrashReportingVM, string>(delegate(CrashReportingVM vm, string i)
		{
			if (vm.SupportFollowupSelected)
			{
				emailEmpty = string.IsNullOrWhiteSpace(vm.Email);
				emailValid = i.IsValidEmail();
				return !emailEmpty && emailValid;
			}
			return true;
		}).WithMessage((CrashReportingVM vm) => LocalizedStrings.Get("CRASH_REPORT_FIELD_REQUIRED_tooltip"));
		RuleFor((CrashReportingVM vm) => vm.Name).Must<CrashReportingVM, string>((CrashReportingVM vm, string i) => !vm.SupportFollowupSelected || !string.IsNullOrEmpty(i)).WithMessage((CrashReportingVM vm) => LocalizedStrings.Get("CRASH_REPORT_FIELD_REQUIRED_tooltip"));
	}
}
