using System.Windows;
using System.Windows.Controls;
using ProPresenter.UI.ViewModels.CloudOnboarding;

namespace ProPresenter.UI.CloudOnboarding;

public sealed class CloudOnboardingTemplateSelector : DataTemplateSelector
{
	public DataTemplate? EligibilityTemplate { get; set; }

	public DataTemplate? PricingTemplate { get; set; }

	public DataTemplate? LocalWorkspacesTemplate { get; set; }

	public DataTemplate? ManageMediaTemplate { get; set; }

	public DataTemplate? DoneTemplate { get; set; }

	public override DataTemplate? SelectTemplate(object item, DependencyObject container)
	{
		if (item is OnboardingStep)
		{
			switch ((OnboardingStep)item)
			{
			case OnboardingStep.Eligibility:
				return EligibilityTemplate;
			case OnboardingStep.Pricing:
				return PricingTemplate;
			case OnboardingStep.LocalWorkspaces:
				return LocalWorkspacesTemplate;
			case OnboardingStep.ManageMedia:
				return ManageMediaTemplate;
			case OnboardingStep.Done:
				return DoneTemplate;
			}
		}
		return base.SelectTemplate(item, container);
	}
}
