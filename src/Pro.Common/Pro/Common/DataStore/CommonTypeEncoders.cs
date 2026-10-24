using System;
using System.Collections.Generic;
using System.Globalization;
using Pro.Common.Mathematics;
using Pro.Common.Time;
using Pro.Common.Utility;

namespace Pro.Common.DataStore;

public static class CommonTypeEncoders
{
	private sealed class TypeEncoder
	{
		public EncoderDelegate Encoder { get; }

		public DecoderDelegate Decoder { get; }

		public TypeEncoder(EncoderDelegate encoder, DecoderDelegate decoder)
		{
			Encoder = encoder;
			Decoder = decoder;
		}
	}

	private const string DateTimeFormat = "yyyy-MM-ddTHH:mm:sszzz";

	private static Dictionary<Type, TypeEncoder> _typeMap;

	static CommonTypeEncoders()
	{
		_typeMap = new Dictionary<Type, TypeEncoder>();
		RegisterCommonTypes();
	}

	public static bool HasEncoder(this Type type)
	{
		return _typeMap.ContainsKey(type);
	}

	public static bool TryGetEncoder(this Type type, out EncoderDelegate? encoder)
	{
		TypeEncoder value = null;
		bool result = _typeMap.TryGetValue(type, out value);
		encoder = value?.Encoder;
		return result;
	}

	public static bool TryGetDecoder(this Type type, out DecoderDelegate? decoder)
	{
		TypeEncoder value = null;
		bool result = _typeMap.TryGetValue(type, out value);
		decoder = value?.Decoder;
		return result;
	}

	public static EncoderDelegate GetEncoder(this Type type)
	{
		EncoderDelegate encoder = null;
		if (!type.TryGetEncoder(out encoder) || encoder == null)
		{
			throw new Exception($"No encoder was found for the {type.Name} type");
		}
		return encoder;
	}

	public static DecoderDelegate GetDecoder(this Type type)
	{
		DecoderDelegate decoder = null;
		if (!type.TryGetDecoder(out decoder) || decoder == null)
		{
			throw new Exception($"No decoder was found for the {type.Name} type");
		}
		return decoder;
	}

	private static void RegisterType<T>(Func<T?, string> encoder, Func<string, T?> decoder)
	{
		if (_typeMap.ContainsKey(typeof(T)))
		{
			throw new InvalidOperationException("Type is already registered");
		}
		_typeMap.Add(typeof(T), new TypeEncoder((object? v) => encoder((T)v), (string v) => decoder(v)));
	}

	private static void RegisterCommonTypes()
	{
		RegisterType((string? v) => v ?? string.Empty, (string v) => v);
		RegisterType(BooleanExtensions.Encode, BooleanExtensions.Decode);
		RegisterType((byte v) => v.ToString(CultureInfo.InvariantCulture), (string v) => byte.Parse(v, CultureInfo.InvariantCulture));
		RegisterType((sbyte v) => v.ToString(CultureInfo.InvariantCulture), (string v) => sbyte.Parse(v, CultureInfo.InvariantCulture));
		RegisterType((ushort v) => v.ToString(CultureInfo.InvariantCulture), (string v) => ushort.Parse(v, CultureInfo.InvariantCulture));
		RegisterType((short v) => v.ToString(CultureInfo.InvariantCulture), (string v) => short.Parse(v, CultureInfo.InvariantCulture));
		RegisterType((uint v) => v.ToString(CultureInfo.InvariantCulture), (string v) => uint.Parse(v, CultureInfo.InvariantCulture));
		RegisterType((int v) => v.ToString(CultureInfo.InvariantCulture), (string v) => int.Parse(v, CultureInfo.InvariantCulture));
		RegisterType((ulong v) => v.ToString(CultureInfo.InvariantCulture), (string v) => ulong.Parse(v, CultureInfo.InvariantCulture));
		RegisterType((long v) => v.ToString(CultureInfo.InvariantCulture), (string v) => long.Parse(v, CultureInfo.InvariantCulture));
		RegisterType((float v) => v.ToString(CultureInfo.InvariantCulture), (string v) => float.Parse(v, CultureInfo.InvariantCulture));
		RegisterType((double v) => v.ToString(CultureInfo.InvariantCulture), (string v) => double.Parse(v, CultureInfo.InvariantCulture));
		RegisterType(ColorExtensions.EncodeColor, ColorExtensions.DecodeColor);
		RegisterType((Guid v) => (!(v != Guid.Empty)) ? string.Empty : v.ToString().ToUpperInvariant(), (string v) => string.IsNullOrWhiteSpace(v) ? Guid.Empty : Guid.Parse(v));
		RegisterType((DateTime v) => v.ToString("yyyy-MM-ddTHH:mm:sszzz"), (string v) => string.IsNullOrWhiteSpace(v) ? default(DateTime) : DateTime.Parse(v));
		RegisterType((DateTime? v) => v?.ToString("yyyy-MM-ddTHH:mm:sszzz") ?? string.Empty, (string v) => string.IsNullOrWhiteSpace(v) ? ((DateTime?)null) : new DateTime?(DateTime.Parse(v)));
		RegisterType((DateTimeOffset v) => v.ToString("O") ?? string.Empty, (string v) => string.IsNullOrWhiteSpace(v) ? default(DateTimeOffset) : DateTimeOffset.Parse(v));
		RegisterType((DateTimeOffset? v) => v?.ToString("O") ?? string.Empty, (string v) => string.IsNullOrWhiteSpace(v) ? ((DateTimeOffset?)null) : new DateTimeOffset?(DateTimeOffset.Parse(v)));
		RegisterType((Uri? v) => (!(v != null)) ? string.Empty : Uri.EscapeDataString(v.ToString()), (string v) => string.IsNullOrWhiteSpace(v) ? null : new Uri(Uri.UnescapeDataString(v)));
		RegisterType(TimeSliceHelper.Encode, TimeSliceHelper.Decode);
		RegisterType(AngleExtensions.Encode, AngleExtensions.Decode<double>);
		RegisterType(Vector2Extensions.Encode, Vector2Extensions.Decode<double>);
		RegisterType(RectExtensions.Encode, RectExtensions.Decode<double>);
		RegisterType(AngleExtensions.Encode, AngleExtensions.Decode<int>);
		RegisterType(Vector2Extensions.Encode, Vector2Extensions.Decode<int>);
		RegisterType(RectExtensions.Encode, RectExtensions.Decode<int>);
	}
}
