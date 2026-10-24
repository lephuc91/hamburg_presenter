using System;
using System.Collections.Generic;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity;

public interface ICopyrightLayout : IEntity, IDisposable
{
	public class Types
	{
		public record Token(TokenType TokenType, string? Text)
		{
			public virtual bool Equals(Token? other)
			{
				if ((object)other != null && TokenType == other.TokenType)
				{
					return Text == other.Text;
				}
				return false;
			}

			public override int GetHashCode()
			{
				HashCode hashCode = default(HashCode);
				hashCode.Add(TokenType);
				hashCode.Add(Text);
				return hashCode.ToHashCode();
			}
		}

		internal static class TokenExtension
		{
			internal static Token Deserialize(Dictionary<string, LoroValue> map)
			{
				return new Token(map.GetEnum<TokenType>("token_type__1"), map.GetNullableString("text__2"));
			}

			internal static Token CreateDefault()
			{
				return new Token(TokenType.Text, null);
			}

			public static LoroValue Serialize(Token instance)
			{
				LoroMap loroMap = new LoroMap();
				loroMap.Insert("token_type__1", instance.TokenType.ToLoroValueLike());
				loroMap.Insert("text__2", instance.Text.ToLoroValueLike());
				return loroMap.GetDeepValue();
			}
		}

		public enum TokenType
		{
			Text,
			Artist,
			Author,
			Publisher,
			Title,
			CopyrightYear,
			LicenseNumber,
			SongNumber
		}
	}

	Pro.Entity.Collections.ICollection<Types.Token> Tokens { get; }
}
