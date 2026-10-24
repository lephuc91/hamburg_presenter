using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using CommunityToolkit.Mvvm.Input;
using Pro.UI.Controls.Markdown.Renderer;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration.Footer;

namespace ProPresenter.UI.Settings.PageTemplates.Registration.Footer;

public partial class SignedOutFooter : UserControl, IHyperlinkCommandProvider, IComponentConnector
{
	public const string ENTER_CONFIRMATION_CODE_COMMAND_KEY = "ENTER_CONFIRMATION_CODE_COMMAND_KEY";

	public SignedOutFooter()
	{
		InitializeComponent();
	}

	private void ShowConfirmationKeyPopUp()
	{
		if (base.DataContext is ISignedOutFooterVM signedOutFooterVM)
		{
			signedOutFooterVM.EnterConfirmationCodeVM.IsVisible = true;
		}
	}

	public ICommand? Get(string? key)
	{
		if (key == "ENTER_CONFIRMATION_CODE_COMMAND_KEY")
		{
			return new RelayCommand(ShowConfirmationKeyPopUp);
		}
		return null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
