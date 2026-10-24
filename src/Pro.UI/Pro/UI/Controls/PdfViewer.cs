using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Common.SourceGenerator.Attributes;
using Pro.PDF;
using Pro.UI.Components;

namespace Pro.UI.Controls;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_renderer" })]
public partial class PdfViewer : UserControl, IComponentConnector, IDisposable
{
	private sealed class PdfPage
	{
		public int PageNumber { get; set; }

		public PdfRenderer? Renderer { get; set; }
	}

	private PdfRenderer? _renderer;

	public static readonly DependencyProperty FilenameProperty = DependencyProperty.Register("Filename", typeof(string), typeof(PdfViewer), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(FilenamePropertyChanged)));

	public static readonly DependencyProperty SelectedPageNumberProperty = DependencyProperty.Register("SelectedPageNumber", typeof(int), typeof(PdfViewer), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)(-1), new PropertyChangedCallback(SelectedPageNumberChanged)));

	public static readonly DependencyProperty AcceptCommandProperty = DependencyProperty.Register("AcceptCommand", typeof(ICommand), typeof(PdfViewer));

	public static readonly DependencyProperty CancelCommandProperty = DependencyProperty.Register("CancelCommand", typeof(ICommand), typeof(PdfViewer));

	private static readonly DependencyProperty PagesProperty = DependencyProperty.Register("Pages", typeof(PdfPage[]), typeof(PdfViewer));

	private static readonly DependencyProperty SelectedPageProperty = DependencyProperty.Register("SelectedPage", typeof(PdfPage), typeof(PdfViewer), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(SelectedPageChanged)));

	private static readonly DependencyProperty PreviousPageCommandProperty = DependencyProperty.Register("PreviousPageCommand", typeof(ICommand), typeof(PdfViewer));

	private static readonly DependencyProperty NextPageCommandProperty = DependencyProperty.Register("NextPageCommand", typeof(ICommand), typeof(PdfViewer));

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public string Filename
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(FilenameProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FilenameProperty, (object)value);
		}
	}

	public int SelectedPageNumber
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(SelectedPageNumberProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedPageNumberProperty, (object)value);
		}
	}

	public ICommand AcceptCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(AcceptCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AcceptCommandProperty, (object)value);
		}
	}

	public ICommand CancelCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(CancelCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CancelCommandProperty, (object)value);
		}
	}

	private PdfPage[]? Pages
	{
		get
		{
			return (PdfPage[])((DependencyObject)this).GetValue(PagesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PagesProperty, (object)value);
		}
	}

	private PdfPage? SelectedPage
	{
		get
		{
			return (PdfPage)((DependencyObject)this).GetValue(SelectedPageProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedPageProperty, (object)value);
		}
	}

	private ICommand PreviousPageCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(PreviousPageCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PreviousPageCommandProperty, (object)value);
		}
	}

	private ICommand NextPageCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(NextPageCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(NextPageCommandProperty, (object)value);
		}
	}

	private static void FilenamePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((PdfViewer)(object)d).OnFilenamePropertyChanged((string)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void SelectedPageNumberChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((PdfViewer)(object)d).OnSelectedPageNumberChanged((int)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void SelectedPageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((PdfViewer)(object)d).OnSelectedPageChanged((PdfPage)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	public PdfViewer()
	{
		InitializeComponent();
		PreviousPageCommand = new RelayCommand(delegate
		{
			SelectedPageNumber--;
			PagesListBox.ScrollIntoView(SelectedPage);
		}, () => SelectedPageNumber > 1);
		NextPageCommand = new RelayCommand(delegate
		{
			SelectedPageNumber++;
			PagesListBox.ScrollIntoView(SelectedPage);
		}, delegate
		{
			int selectedPageNumber = SelectedPageNumber;
			PdfPage[]? pages = Pages;
			return selectedPageNumber < ((pages != null) ? pages.Length : 0);
		});
	}

	public PdfViewer(PdfRenderer renderer)
		: this()
	{
		_renderer = renderer;
		LoadPages();
	}

	private void OnFilenamePropertyChanged(string filename)
	{
		_renderer?.Dispose();
		_renderer = new PdfRenderer(filename);
		LoadPages();
	}

	private void LoadPages()
	{
		PdfPage[] array = new PdfPage[_renderer?.PageCount ?? 0];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new PdfPage
			{
				PageNumber = i + 1,
				Renderer = _renderer
			};
		}
		Pages = array;
		SelectedPage = array.FirstOrDefault();
	}

	private void OnSelectedPageNumberChanged(int pageNumber)
	{
		((DependencyObject)this).SetCurrentValue(SelectedPageProperty, (object)Pages?.FirstOrDefault((PdfPage p) => p.PageNumber == pageNumber));
	}

	private void OnSelectedPageChanged(PdfPage page)
	{
		((DependencyObject)this).SetCurrentValue(SelectedPageNumberProperty, (object)(page?.PageNumber ?? (-1)));
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}

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
			_renderer?.Dispose();
		}
	}
}
