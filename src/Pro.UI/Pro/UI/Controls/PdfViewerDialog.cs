using System;
using Pro.PDF;
using Pro.UI.Components;

namespace Pro.UI.Controls;

public class PdfViewerDialog : PdfViewer, IDialogContent
{
	public event Action? Accept;

	public event Action? Cancel;

	public PdfViewerDialog()
	{
		SetupCommands();
	}

	public PdfViewerDialog(PdfRenderer renderer)
		: base(renderer)
	{
		SetupCommands();
	}

	private void SetupCommands()
	{
		base.AcceptCommand = new RelayCommand(delegate
		{
			this.Accept?.Invoke();
		});
		base.CancelCommand = new RelayCommand(delegate
		{
			this.Cancel?.Invoke();
		});
	}
}
