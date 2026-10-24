using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Common.Nullability;
using Pro.Localization;

namespace ProPresenter.UI.Registration.PopUpAlerts;

[ContentProperty("TextTranslationKeysElements")]
public partial class ActivationPopUpContent : UserControl, IComponentConnector
{
	public static readonly DependencyProperty TitleTranslationKeyProperty = DependencyProperty.Register("TitleTranslationKey", typeof(string), typeof(ActivationPopUpContent));

	public static readonly DependencyProperty OrganizationNameProperty = DependencyProperty.Register("OrganizationName", typeof(string), typeof(ActivationPopUpContent), new PropertyMetadata
	{
		PropertyChangedCallback = new PropertyChangedCallback(UpdateFormattedOrganization_DependencyCallback)
	});

	public static readonly DependencyProperty OrganizationFormattingKeyProperty = DependencyProperty.Register("OrganizationFormattingKey", typeof(string), typeof(ActivationPopUpContent), new PropertyMetadata
	{
		PropertyChangedCallback = new PropertyChangedCallback(UpdateFormattedOrganization_DependencyCallback)
	});

	private static readonly DependencyProperty FormattedOrganizationProperty = DependencyProperty.Register("FormattedOrganization", typeof(string), typeof(ActivationPopUpContent));

	public static readonly DependencyProperty TextTranslationKeysElementsProperty = DependencyProperty.Register("TextTranslationKeysElements", typeof(Collection<string>), typeof(ActivationPopUpContent));

	public static readonly DependencyProperty ConfirmationButtonTitleProperty = DependencyProperty.Register("ConfirmationButtonTitleKey", typeof(string), typeof(ActivationPopUpContent));

	public static readonly DependencyProperty CloseCommandProperty = DependencyProperty.Register("CloseCommand", typeof(ICommand), typeof(ActivationPopUpContent));

	public string? TitleTranslationKey
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(TitleTranslationKeyProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TitleTranslationKeyProperty, (object)value);
		}
	}

	public string? OrganizationName
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(OrganizationNameProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OrganizationNameProperty, (object)value);
		}
	}

	private string? FormattedOrganization
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(FormattedOrganizationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FormattedOrganizationProperty, (object)value);
		}
	}

	public string? OrganizationFormattingKey
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(OrganizationFormattingKeyProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OrganizationFormattingKeyProperty, (object)value);
		}
	}

	public Collection<string> TextTranslationKeysElements
	{
		get
		{
			return (Collection<string>)((DependencyObject)this).GetValue(TextTranslationKeysElementsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TextTranslationKeysElementsProperty, (object)value);
		}
	}

	public string? ConfirmationButtonTitleKey
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(ConfirmationButtonTitleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ConfirmationButtonTitleProperty, (object)value);
		}
	}

	public ICommand? CloseCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(CloseCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CloseCommandProperty, (object)value);
		}
	}

	public ActivationPopUpContent()
	{
		InitializeComponent();
		TextTranslationKeysElements = new ObservableCollection<string>();
	}

	private static void UpdateFormattedOrganization_DependencyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is ActivationPopUpContent activationPopUpContent && !activationPopUpContent.OrganizationFormattingKey.NullableIsNullOrEmpty())
		{
			activationPopUpContent.FormattedOrganization = LocalizedStrings.Get(activationPopUpContent.OrganizationFormattingKey, new object[1] { activationPopUpContent.OrganizationName });
		}
	}
}
