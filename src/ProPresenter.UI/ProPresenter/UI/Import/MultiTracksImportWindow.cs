using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows.Markup;
using Pro.Localization;
using Pro.UI.Controls.Windowing;

namespace ProPresenter.UI.Import;

public partial class MultiTracksImportWindow : ChromedWindow, IComponentConnector
{
	public string HelpToolTipText => LocalizedStrings.Get("PRESENTATION_QUICK_SEARCH_MULTITRACKS_CHORDS_AND_AUTOMATION_tooltip", new object[1] { "https://MultiTracks.com" });

	public MultiTracksImportWindow()
	{
		InitializeComponent();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
