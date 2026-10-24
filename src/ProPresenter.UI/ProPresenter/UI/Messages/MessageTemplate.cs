using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.DO.Messages;

namespace ProPresenter.UI.Messages;

public partial class MessageTemplate : UserControl, IComponentConnector
{
	public static readonly DependencyProperty ActiveMessagesProperty = DependencyProperty.Register("ActiveMessages", typeof(IEnumerable<Message>), typeof(MessageTemplate), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnActiveMessagePropertyChanged)));

	private static readonly DependencyProperty IsActiveProperty = DependencyProperty.Register("IsActive", typeof(bool), typeof(MessageTemplate), new PropertyMetadata((object)false));

	public IEnumerable<Message>? ActiveMessages
	{
		get
		{
			return (IEnumerable<Message>)((DependencyObject)this).GetValue(ActiveMessagesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActiveMessagesProperty, (object)value);
		}
	}

	private bool IsActive
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsActiveProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsActiveProperty, (object)value);
		}
	}

	private static void OnActiveMessagePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((MessageTemplate)(object)d).ActiveMessagesChanged(((DependencyPropertyChangedEventArgs)(ref e)).NewValue as IEnumerable<Message>);
	}

	public MessageTemplate()
	{
		InitializeComponent();
	}

	private void ActiveMessagesChanged(IEnumerable<Message>? activeMessages)
	{
		((DependencyObject)this).SetCurrentValue(IsActiveProperty, (object)(activeMessages?.Any((Message m) => base.DataContext is Message message && m.ID == message.ID) ?? false));
	}
}
