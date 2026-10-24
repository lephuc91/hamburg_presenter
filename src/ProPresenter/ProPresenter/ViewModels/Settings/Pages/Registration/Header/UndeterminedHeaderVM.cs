using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Pro.Common.SourceGenerator.Attributes;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration.Header;

namespace ProPresenter.ViewModels.Settings.Pages.Registration.Header;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class UndeterminedHeaderVM : ObservableObject, IUndeterminedHeaderVM, IHeaderVM, INotifyPropertyChanged, IDisposable
{
	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
		}
	}
}
