using System;
using System.Linq;
using System.Reactive.Linq;
using Pro.Common.Collections;
using Pro.Common.Dispatcher;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.CCLI;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(CCLITokenType), typeof(CopyrightLayout.Types.TokenType), DestinationToSourceMethodName = "ToTokenType", SourceToDestinationMethodName = "ToProtoTokenType", ExcludeDestinationNames = new string[] { "Text" })]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(ICopyrightLayout.Types.TokenType), typeof(CopyrightLayout.Types.TokenType), DestinationToSourceMethodName = "ToEntityTokenType", SourceToDestinationMethodName = "ToProtoTokenType")]
public static class CCLIHelper
{
	public static string GeneratePlaceholderText(IGeneral general)
	{
		return ParseCCLIText(general);
	}

	private static string ParseCCLIText(IGeneral genreal, CCLIData? data = null)
	{
		string text = genreal.CCLILayoutData.Text ?? string.Empty;
		int count = genreal.CCLILayoutData.Tokens.Count;
		(from t in genreal.CCLILayoutData.Tokens.OfType<CCLIToken>()
			orderby t.Index
			select t).Reverse().ForEach(delegate(CCLIToken t)
		{
			text = text.Insert((t.Index - --count).Clamp(0, text.Length), GetTokenContent(t, data));
		});
		return text;
	}

	private static string GetTokenContent(CCLIToken t, CCLIData? data)
	{
		if (data == null)
		{
			return t.Content;
		}
		return t.TokenType switch
		{
			CCLITokenType.Artist => data.Artist, 
			CCLITokenType.Author => data.Author, 
			CCLITokenType.Publisher => data.Publisher, 
			CCLITokenType.Title => data.Title, 
			CCLITokenType.CopyrightYear => data.Copyright, 
			CCLITokenType.LicenseNumber => DataVault.CCLIPresentation?.License ?? string.Empty, 
			CCLITokenType.SongNumber => data.SongNumber, 
			_ => throw new NotSupportedException(), 
		};
	}

	public static ObjectBinder<ICCLILayoutData, ICopyrightLayout> Bind(this ICCLILayoutData model, ICopyrightLayout layout, IUiScheduler scheduler)
	{
		ObjectBinder<ICCLILayoutData, ICopyrightLayout> objectBinder = new ObjectBinder<ICCLILayoutData, ICopyrightLayout>(model, layout);
		objectBinder.Bind((ICCLILayoutData m) => m.WhenPropertyChanges("Text").CombineLatest(m.Tokens.WhenCollectionChanges()), (ICopyrightLayout e) => e.Tokens.WhenCollectionChanges, delegate(ICCLILayoutData model, ICopyrightLayout entity)
		{
			model.Serialize().Tokens.SynchronizeTo(entity.Tokens.Items, (CopyrightLayout.Types.Token t, ICopyrightLayout.Types.Token e) => t.TokenType == e.TokenType.ToProtoTokenType() && t.Text == e.Text, delegate(CopyrightLayout.Types.Token t, int index)
			{
				entity.Tokens.Insert(index, new ICopyrightLayout.Types.Token(t.TokenType.ToEntityTokenType(), t.Text));
			}, entity.Tokens.Move, delegate(int index)
			{
				entity.Tokens.RemoveAt(index);
			});
		}, delegate(ICopyrightLayout entity, ICCLILayoutData model)
		{
			CopyrightLayout copyrightLayout = new CopyrightLayout();
			copyrightLayout.Tokens.AddRange(entity.Tokens.Items.Select((ICopyrightLayout.Types.Token t) => new CopyrightLayout.Types.Token
			{
				Text = t.Text,
				TokenType = t.TokenType.ToProtoTokenType()
			}));
			model.Deserialize(copyrightLayout);
		}, null, scheduler.Scheduler);
		return objectBinder;
	}

	public static CopyrightLayout.Types.TokenType ToProtoTokenType(this CCLITokenType source)
	{
		return source switch
		{
			CCLITokenType.Artist => CopyrightLayout.Types.TokenType.Artist, 
			CCLITokenType.Author => CopyrightLayout.Types.TokenType.Author, 
			CCLITokenType.Publisher => CopyrightLayout.Types.TokenType.Publisher, 
			CCLITokenType.Title => CopyrightLayout.Types.TokenType.Title, 
			CCLITokenType.CopyrightYear => CopyrightLayout.Types.TokenType.CopyrightYear, 
			CCLITokenType.LicenseNumber => CopyrightLayout.Types.TokenType.LicenseNumber, 
			CCLITokenType.SongNumber => CopyrightLayout.Types.TokenType.SongNumber, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static CCLITokenType ToTokenType(this CopyrightLayout.Types.TokenType source)
	{
		return source switch
		{
			CopyrightLayout.Types.TokenType.Artist => CCLITokenType.Artist, 
			CopyrightLayout.Types.TokenType.Author => CCLITokenType.Author, 
			CopyrightLayout.Types.TokenType.Publisher => CCLITokenType.Publisher, 
			CopyrightLayout.Types.TokenType.Title => CCLITokenType.Title, 
			CopyrightLayout.Types.TokenType.CopyrightYear => CCLITokenType.CopyrightYear, 
			CopyrightLayout.Types.TokenType.LicenseNumber => CCLITokenType.LicenseNumber, 
			CopyrightLayout.Types.TokenType.SongNumber => CCLITokenType.SongNumber, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static CopyrightLayout.Types.TokenType ToProtoTokenType(this ICopyrightLayout.Types.TokenType source)
	{
		return source switch
		{
			ICopyrightLayout.Types.TokenType.Text => CopyrightLayout.Types.TokenType.Text, 
			ICopyrightLayout.Types.TokenType.Artist => CopyrightLayout.Types.TokenType.Artist, 
			ICopyrightLayout.Types.TokenType.Author => CopyrightLayout.Types.TokenType.Author, 
			ICopyrightLayout.Types.TokenType.Publisher => CopyrightLayout.Types.TokenType.Publisher, 
			ICopyrightLayout.Types.TokenType.Title => CopyrightLayout.Types.TokenType.Title, 
			ICopyrightLayout.Types.TokenType.CopyrightYear => CopyrightLayout.Types.TokenType.CopyrightYear, 
			ICopyrightLayout.Types.TokenType.LicenseNumber => CopyrightLayout.Types.TokenType.LicenseNumber, 
			ICopyrightLayout.Types.TokenType.SongNumber => CopyrightLayout.Types.TokenType.SongNumber, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static ICopyrightLayout.Types.TokenType ToEntityTokenType(this CopyrightLayout.Types.TokenType source)
	{
		return source switch
		{
			CopyrightLayout.Types.TokenType.Text => ICopyrightLayout.Types.TokenType.Text, 
			CopyrightLayout.Types.TokenType.Artist => ICopyrightLayout.Types.TokenType.Artist, 
			CopyrightLayout.Types.TokenType.Author => ICopyrightLayout.Types.TokenType.Author, 
			CopyrightLayout.Types.TokenType.Publisher => ICopyrightLayout.Types.TokenType.Publisher, 
			CopyrightLayout.Types.TokenType.Title => ICopyrightLayout.Types.TokenType.Title, 
			CopyrightLayout.Types.TokenType.CopyrightYear => ICopyrightLayout.Types.TokenType.CopyrightYear, 
			CopyrightLayout.Types.TokenType.LicenseNumber => ICopyrightLayout.Types.TokenType.LicenseNumber, 
			CopyrightLayout.Types.TokenType.SongNumber => ICopyrightLayout.Types.TokenType.SongNumber, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}
}
