using System.Windows;
using System.Windows.Input;
using Pro.UI.Commands;
using ProPresenter.DO.PanelSourcing;

namespace ProPresenter.UI.Thumbnails;

public abstract class CutPasteThumbnailPanel<T> : ThumbnailPanel<T> where T : class, IThumbnailSource
{
	public static readonly DependencyProperty CopyCommandProperty = DependencyProperty.Register("CopyCommand", typeof(ICommand), typeof(CutPasteThumbnailPanel<T>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((CutPasteThumbnailPanel<T>)(object)s).CommandBindings.Add(CommonApplicationCommands.Copy, (ICommand)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}));

	public static readonly DependencyProperty CutCommandProperty = DependencyProperty.Register("CutCommand", typeof(ICommand), typeof(CutPasteThumbnailPanel<T>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((CutPasteThumbnailPanel<T>)(object)s).CommandBindings.Add(CommonApplicationCommands.CutCommand, (ICommand)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}));

	public static readonly DependencyProperty PasteCommandProperty = DependencyProperty.Register("PasteCommand", typeof(ICommand), typeof(CutPasteThumbnailPanel<T>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((CutPasteThumbnailPanel<T>)(object)s).CommandBindings.Add(CommonApplicationCommands.Paste, (ICommand)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}));

	public static readonly DependencyProperty DeleteCommandProperty = DependencyProperty.Register("DeleteCommand", typeof(ICommand), typeof(CutPasteThumbnailPanel<T>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((CutPasteThumbnailPanel<T>)(object)s).CommandBindings.Add(CommonApplicationCommands.Delete, (ICommand)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}));

	public static readonly DependencyProperty DuplicateCommandProperty = DependencyProperty.Register("DuplicateCommand", typeof(ICommand), typeof(CutPasteThumbnailPanel<T>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((CutPasteThumbnailPanel<T>)(object)s).CommandBindings.Add(CommonApplicationCommands.Duplicate, (ICommand)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}));

	public ICommand? CopyCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(CopyCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CopyCommandProperty, (object)value);
		}
	}

	public ICommand? CutCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(CutCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CutCommandProperty, (object)value);
		}
	}

	public ICommand? PasteCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(PasteCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PasteCommandProperty, (object)value);
		}
	}

	public ICommand? DeleteCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(DeleteCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DeleteCommandProperty, (object)value);
		}
	}

	public ICommand? DuplicateCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(DuplicateCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DuplicateCommandProperty, (object)value);
		}
	}
}
