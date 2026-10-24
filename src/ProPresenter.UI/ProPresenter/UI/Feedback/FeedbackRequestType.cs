using Pro.Localization;

namespace ProPresenter.UI.Feedback;

public enum FeedbackRequestType
{
	[LocalizedString("USER_FEEDBACK_FORM_REQUEST_TYPE_NO_SELECTION_title")]
	None,
	[LocalizedString("USER_FEEDBACK_FORM_REQUEST_TYPE_TECHNICAL_ISSUE_title")]
	TechnicalIssue,
	[LocalizedString("USER_FEEDBACK_FORM_REQUEST_TYPE_FEATURE_REQUEST_title")]
	FeatureRequest,
	[LocalizedString("USER_FEEDBACK_FORM_REQUEST_TYPE_QUESTION_BEFORE_PURCHASING_title")]
	QuestionBeforePurchasing,
	[LocalizedString("USER_FEEDBACK_FORM_REQUEST_TYPE_QUESTION_ABOUT_ORDER_title")]
	QuestionAboutRecentOrder,
	[LocalizedString("USER_FEEDBACK_FORM_REQUEST_TYPE_QUESTION_ABOUT_LICENSE_title")]
	QuestionAboutExistingLicence,
	[LocalizedString("USER_FEEDBACK_FORM_REQUEST_TYPE_OTHER_QUESTION_title")]
	DifferentQuestionOrOtherFeedback
}
