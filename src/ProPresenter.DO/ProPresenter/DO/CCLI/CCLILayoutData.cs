using System;
using System.Collections.Generic;
using System.ComponentModel;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.DO.Token;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.CCLI;

public class CCLILayoutData : NotifyPropertyChangedBase, ICCLILayoutData, INotifyPropertyChanged
{
	private string _text;

	public string Text
	{
		get
		{
			return _text;
		}
		set
		{
			SetValue("Text", ref _text, value, delegate(string o, string n)
			{
				UndoStack?.Commit(UndoActionTypes.CCLILayoutText.ToAction(), this, "Text", o, n);
				OnDataModified();
			});
		}
	}

	public TokenCollection<CCLIToken> Tokens { get; } = new TokenCollection<CCLIToken>();

	public UndoStack UndoStack { get; } = new UndoStack();

	public event System.Action? DataModified;

	public CCLILayoutData(string cCLILayoutText, IEnumerable<CCLIToken> tokens)
	{
		_text = cCLILayoutText;
		tokens.ForEach(delegate(CCLIToken t)
		{
			Tokens.Add(t);
		});
		Tokens.CollectionChanged += delegate
		{
			OnDataModified();
		};
		Tokens.UndoStack = UndoStack;
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	public CopyrightLayout Serialize()
	{
		CopyrightLayout copyrightLayout = new CopyrightLayout();
		int num = 0;
		foreach (var item3 in Tokens.Enumerate())
		{
			CCLIToken item = item3.Item1;
			int item2 = item3.Item2;
			int num2 = Math.Min(item.Index - item2, Text.Length) - num;
			if (num2 > 0)
			{
				copyrightLayout.Tokens.Add(ProtoToken(Text.Substring(num, num2)));
				num += num2;
			}
			copyrightLayout.Tokens.Add(ProtoToken(item));
		}
		if (num < Text.Length)
		{
			copyrightLayout.Tokens.Add(ProtoToken(Text.Substring(num)));
		}
		return copyrightLayout;
	}

	public void Deserialize(CopyrightLayout layout)
	{
		int num = 0;
		_text = string.Empty;
		Tokens.Clear();
		foreach (CopyrightLayout.Types.Token token in layout.Tokens)
		{
			if (token.TokenType != 0)
			{
				Tokens.Add(new CCLIToken(token.TokenType.ToTokenType())
				{
					Index = num + Tokens.Count
				});
			}
			else
			{
				num += token.Text.Length;
				_text += token.Text;
			}
		}
		OnPropertyChanged("Text");
		OnDataModified();
	}

	private static CopyrightLayout.Types.Token ProtoToken(string text)
	{
		return new CopyrightLayout.Types.Token
		{
			TokenType = CopyrightLayout.Types.TokenType.Text,
			Text = text
		};
	}

	private static CopyrightLayout.Types.Token ProtoToken(CCLIToken token)
	{
		return new CopyrightLayout.Types.Token
		{
			TokenType = token.TokenType.ToProtoTokenType()
		};
	}
}
