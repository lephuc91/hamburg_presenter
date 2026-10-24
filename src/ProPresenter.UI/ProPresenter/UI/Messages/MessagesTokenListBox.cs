using System.Windows;
using System.Windows.Controls;
using Pro.UI.Controls.Tokens;
using ProPresenter.DO.Messages;

namespace ProPresenter.UI.Messages;

public class MessagesTokenListBox : TokenListBox<MessageTokenBase>
{
	public static readonly DependencyProperty TokenContextMenuProperty = DependencyProperty.Register("TokenContextMenu", typeof(ContextMenu), typeof(MessagesTokenListBox));

	public ContextMenu? TokenContextMenu
	{
		get
		{
			return (ContextMenu)((DependencyObject)this).GetValue(TokenContextMenuProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TokenContextMenuProperty, (object)value);
		}
	}

	protected override TokenControl OnGenerateToken(MessageTokenBase tokenData)
	{
		TokenControl tokenControl = base.OnGenerateToken(tokenData);
		TextToken obj = tokenData as TextToken;
		if (obj != null && !obj.IsDefaultToken())
		{
			MessageTokenTemplate messageTokenTemplate = new MessageTokenTemplate
			{
				DataContext = tokenData,
				Text = tokenData.Content,
				ContextMenu = TokenContextMenu
			};
			messageTokenTemplate.PreviewMouseDown += delegate
			{
				base.SelectedItem = tokenControl;
			};
			tokenControl.ContentControl = messageTokenTemplate;
		}
		return tokenControl;
	}
}
