using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.Components;

namespace ProPresenter.DO.Messages;

public class MessageTextData : ObservableObject, ICloneable<MessageTextData>
{
	[ObservableProperty]
	private string _name;

	[ObservableProperty]
	private string _text;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Name
	{
		get
		{
			return _name;
		}
		[MemberNotNull("_name")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_name, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Name);
				_name = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Name);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Text
	{
		get
		{
			return _text;
		}
		[MemberNotNull("_text")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_text, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Text);
				_text = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Text);
			}
		}
	}

	public MessageTextData(string name, string text)
	{
		_name = name;
		_text = text;
	}

	internal string Encode()
	{
		global::_003C_003Ey__InlineArray2<string> buffer = default(global::_003C_003Ey__InlineArray2<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<string>, string>(ref buffer, 0) = Name;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<string>, string>(ref buffer, 1) = Text;
		return string.Join("|", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray2<string>, string>(in buffer, 2));
	}

	internal static MessageTextData Decode(string data)
	{
		int num = data.LastIndexOf('|');
		return new MessageTextData(data.Substring(0, num), data.Substring(num + 1, data.Length - (num + 1)));
	}

	public MessageTextData Clone()
	{
		return new MessageTextData(Name, Text);
	}
}
