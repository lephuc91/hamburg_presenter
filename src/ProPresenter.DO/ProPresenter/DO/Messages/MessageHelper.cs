using System.Collections.Generic;
using System.Linq;
using Pro.SerializationInterop.RVProtoData;
using Pro.Text;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Themes;

namespace ProPresenter.DO.Messages;

public static class MessageHelper
{
	public static bool IsDefaultToken(this TextToken token)
	{
		return MessagesPreferences.Settings.DefaultTokens.Any((MessageTextData t) => t.Name == token.Content && t.Text == token.Text);
	}

	public static void ResolveText(this Message message, BezierPath? path)
	{
		TextDocument textDocument = (path as ClosedBezierPath)?.Text;
		if (!(textDocument == null))
		{
			textDocument.Clear();
			textDocument.InsertTextAndParagraphs(0, message.GetMessageText());
		}
	}

	public static void ResolveText(this Pro.SerializationInterop.RVProtoData.Message protoMessage, BezierPath path, IThemeCollection themes)
	{
		Message message = new Message(themes);
		message.Deserialize(protoMessage);
		message.ResolveText(path);
	}

	public static string GetMessageText(this Message message)
	{
		return string.Join(string.Empty, message.EncodeToComponents("${{{0}}}", "${{{0}}}", isFormatting: false));
	}

	public static void SetTokens(this Message message, IEnumerable<API_v1_Message.Types.API_v1_MessageToken> tokens)
	{
		foreach (API_v1_Message.Types.API_v1_MessageToken field in tokens)
		{
			MessageTokenBase messageTokenBase = message.Tokens.Cast<MessageTokenBase>().FirstOrDefault((MessageTokenBase t) => t.Content == field.Name);
			if (messageTokenBase != null && messageTokenBase is TextToken textToken)
			{
				textToken.Text = field.Text.Text;
			}
		}
	}

	public static string GetMessageTextPreview(this Message message, IEnumerable<API_v1_Message.Types.API_v1_MessageToken> tokens)
	{
		Message message2 = message.Clone();
		message2.SetTokens(tokens);
		return message2.GetMessageText();
	}
}
