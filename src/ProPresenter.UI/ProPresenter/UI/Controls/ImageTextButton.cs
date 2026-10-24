using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.FileSystem;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.DO.Cues;
using ProPresenter.UI.AudioLibrary;

namespace ProPresenter.UI.Controls;

public partial class ImageTextButton : UserControl, IComponentConnector
{
	private static readonly SolidColorBrush _defaultTextForeground = (SolidColorBrush)new BrushConverter().ConvertFromString("#A0A0A0");

	private static readonly SolidColorBrush _defaultButtonBackground = (SolidColorBrush)new BrushConverter().ConvertFromString("#80505050");

	public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(ImageTextButton));

	public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register("CommandParameter", typeof(object), typeof(ImageTextButton));

	public static readonly DependencyProperty CommandTargetProperty = DependencyProperty.Register("CommandTarget", typeof(IInputElement), typeof(ImageTextButton));

	public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(ImageTextButton));

	public static readonly DependencyProperty TextSizeProperty = DependencyProperty.Register("TextSize", typeof(int), typeof(ImageTextButton), new PropertyMetadata((object)14));

	public static readonly DependencyProperty TextForegroundProperty = DependencyProperty.Register("TextForeground", typeof(Brush), typeof(ImageTextButton), new PropertyMetadata((object)_defaultTextForeground));

	public static readonly DependencyProperty ButtonWidthProperty = DependencyProperty.Register("ButtonWidth", typeof(int), typeof(ImageTextButton), new PropertyMetadata((object)100));

	public static readonly DependencyProperty ButtonHeightProperty = DependencyProperty.Register("ButtonHeight", typeof(int), typeof(ImageTextButton), new PropertyMetadata((object)100));

	public static readonly DependencyProperty ImageWidthProperty = DependencyProperty.Register("ImageWidth", typeof(int), typeof(ImageTextButton), new PropertyMetadata((object)32));

	public static readonly DependencyProperty ImageHeightProperty = DependencyProperty.Register("ImageHeight", typeof(int), typeof(ImageTextButton), new PropertyMetadata((object)32));

	public static readonly DependencyProperty ButtonBackgroundProperty = DependencyProperty.Register("ButtonBackground", typeof(Brush), typeof(ImageTextButton), new PropertyMetadata((object)_defaultButtonBackground));

	public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(ImageTextButton));

	public static readonly DependencyProperty DragDropSourceProperty = DependencyProperty.Register("DragDropSource", typeof(IDragDropCollection<MediaCue>), typeof(ImageTextButton));

	public static readonly DependencyProperty DropAudioFilesCommandProperty = DependencyProperty.Register("DropAudioFilesCommand", typeof(ICommand<DropAudioFilesCommandParameter>), typeof(ImageTextButton));

	public ICommand? Command
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(CommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CommandProperty, (object)value);
		}
	}

	public object? CommandParameter
	{
		get
		{
			return ((DependencyObject)this).GetValue(CommandParameterProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CommandParameterProperty, value);
		}
	}

	public IInputElement? CommandTarget
	{
		get
		{
			return (IInputElement)((DependencyObject)this).GetValue(CommandTargetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CommandTargetProperty, (object)value);
		}
	}

	public string? Text
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(TextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TextProperty, (object)value);
		}
	}

	public int ButtonWidth
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(ButtonWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ButtonWidthProperty, (object)value);
		}
	}

	public int ButtonHeight
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(ButtonHeightProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ButtonHeightProperty, (object)value);
		}
	}

	public int ImageWidth
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(ImageWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ImageWidthProperty, (object)value);
		}
	}

	public int ImageHeight
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(ImageHeightProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ImageHeightProperty, (object)value);
		}
	}

	public int TextSize
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(TextSizeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TextSizeProperty, (object)value);
		}
	}

	public Brush TextForeground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(TextForegroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TextForegroundProperty, (object)value);
		}
	}

	public Brush ButtonBackground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(ButtonBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ButtonBackgroundProperty, (object)value);
		}
	}

	public ImageSource? ImageSource
	{
		get
		{
			return (ImageSource)((DependencyObject)this).GetValue(ImageSourceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ImageSourceProperty, (object)value);
		}
	}

	public IDragDropCollection<MediaCue> DragDropSource
	{
		get
		{
			return (IDragDropCollection<MediaCue>)((DependencyObject)this).GetValue(DragDropSourceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DragDropSourceProperty, (object)value);
		}
	}

	public ICommand<DropAudioFilesCommandParameter> DropAudioFilesCommand
	{
		get
		{
			return (ICommand<DropAudioFilesCommandParameter>)((DependencyObject)this).GetValue(DropAudioFilesCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropAudioFilesCommandProperty, (object)value);
		}
	}

	public ImageTextButton()
	{
		InitializeComponent();
	}

	private void ImageTextButtonOnDragEnter(object sender, DragEventArgs e)
	{
		e.Effects = (e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None);
	}

	private void ImageTextButtonOnDragOver(object sender, DragEventArgs e)
	{
		e.Effects = ((e.Data.GetDataPresent(DataFormats.FileDrop) && ContainsOnlyAudioFiles((string[])e.Data.GetData(DataFormats.FileDrop))) ? DragDropEffects.Copy : DragDropEffects.None);
		e.Handled = true;
	}

	private void ImageTextButtonOnDrop(object sender, DragEventArgs e)
	{
		if (e.Data.GetDataPresent(DataFormats.FileDrop))
		{
			string[] filenames = ((string[])e.Data.GetData(DataFormats.FileDrop)) ?? Array.Empty<string>();
			DropAudioFilesCommand?.Invoke(new DropAudioFilesCommandParameter(filenames, null, 0));
		}
	}

	private static bool ContainsOnlyAudioFiles(string[] files)
	{
		return Array.TrueForAll(files, (string file) => file.IsAudioFile());
	}
}
