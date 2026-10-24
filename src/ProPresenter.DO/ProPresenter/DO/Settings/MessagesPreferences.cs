using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Pro.Common.DataStore;
using Pro.Localization;
using ProPresenter.DO.Messages;

namespace ProPresenter.DO.Settings;

public class MessagesPreferences : StoreBase
{
	private const string SettingsFile = "MessagesPreferences.proPref";

	private static readonly string Name = LocalizedStrings.Get("MESSAGES_WINDOW_TOKEN_NAME_title");

	private static readonly string Message = LocalizedStrings.Get("MESSAGES_WINDOW_TOKEN_MESSAGE_title");

	private static readonly string Room = LocalizedStrings.Get("MESSAGES_WINDOW_TOKEN_ROOM_title");

	private static readonly MessagesPreferences _settings = new MessagesPreferences();

	public static MessagesPreferences Settings => _settings;

	public List<MessageTextData> DefaultTokens
	{
		get
		{
			return GetValue("DefaultTokens", new string[3] { Name, Message, Room }.Select((string s) => new MessageTextData(s, string.Empty)).ToList());
		}
		set
		{
			SetValue("DefaultTokens", value);
			OnPropertyChanged("DefaultTokens");
		}
	}

	public List<MessageTextData>? TextTokens
	{
		get
		{
			return GetValue("TextTokens", new List<MessageTextData>());
		}
		set
		{
			SetValue("TextTokens", value);
			OnPropertyChanged("TextTokens");
		}
	}

	public bool IsEditing
	{
		get
		{
			return GetValue("IsEditing", defaultValue: false);
		}
		set
		{
			SetValue("IsEditing", value);
			OnPropertyChanged("IsEditing");
		}
	}

	public Guid SelectedMessageID
	{
		get
		{
			return GetValue("SelectedMessageID", Guid.Empty);
		}
		set
		{
			SetValue("SelectedMessageID", value);
			OnPropertyChanged("SelectedMessageID");
		}
	}

	public MessagesPreferences()
		: base(Path.Combine(CommonPaths.Preferences, "MessagesPreferences.proPref"))
	{
		RegisterCustomType((MessageTextData t) => t.Encode(), MessageTextData.Decode);
		RegisterListType(delegate(MessageTextData t, List<MessageTextData> l)
		{
			l.Add(t);
		});
	}
}
