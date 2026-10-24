using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.DataStore.Storage;
using Pro.Common.Logging;
using Pro.Common.Operations;
using Pro.Common.Utility;

namespace Pro.Common.DataStore;

public abstract class StoreBase : NotifyPropertyChangedBase
{
	private readonly IStorage _storage;

	private readonly Dictionary<Type, EncoderDelegate> _encoderMap = new Dictionary<Type, EncoderDelegate>();

	private readonly Dictionary<Type, DecoderDelegate> _decoderMap = new Dictionary<Type, DecoderDelegate>();

	private readonly Dictionary<string, ConversionDelegate> _encoderConversionMap = new Dictionary<string, ConversionDelegate>();

	private readonly Dictionary<string, ConversionDelegate> _decoderConversionMap = new Dictionary<string, ConversionDelegate>();

	private readonly Dictionary<string, (object? value, bool usedDefault)> _valueMap = new Dictionary<string, (object, bool)>();

	protected StoreBase(string filename, bool allowWriting = true, bool groupWrites = true)
		: this(MakeFileStorage(filename, allowWriting, groupWrites))
	{
	}

	protected StoreBase(IStorage storage)
	{
		_storage = storage;
	}

	protected static IStorage MakeFileStorage(string filename, bool allowWriting = true, bool groupWrites = true, bool overrideUnitTestDetection = false)
	{
		if (!overrideUnitTestDetection && UnitTestDetector.IsInUnitTest)
		{
			return new MemoryStorage(allowWriting);
		}
		return new FileStorage(filename, allowWriting, groupWrites);
	}

	protected static IStorage MakeRegistryStorage(string rootKey, string path, bool overrideUnitTestDetection = false)
	{
		return MakeRegistryStorage(rootKey + "\\" + path, overrideUnitTestDetection);
	}

	protected static IStorage MakeRegistryStorage(string fullPath, bool overrideUnitTestDetection = false)
	{
		if (!overrideUnitTestDetection && UnitTestDetector.IsInUnitTest)
		{
			return new MemoryStorage();
		}
		return new RegistryStorage(fullPath);
	}

	protected void RegisterCustomType<T>(Func<T, string> encoder, Func<string, T> decoder)
	{
		_decoderMap.Add(typeof(T), (string v) => decoder(v));
		_encoderMap.Add(typeof(T), (object? v) => (v != null) ? encoder((T)v) : string.Empty);
	}

	protected void RegisterEnumType<T>() where T : Enum
	{
		if (!typeof(T).IsEnum)
		{
			throw new ArgumentException("T must be Enum");
		}
		RegisterCustomType((T v) => v.Cast<long, T>().ToString() ?? string.Empty, (string v) => (T)Enum.Parse(typeof(T), v));
	}

	protected void RegisterArrayType<TItem>()
	{
		DecoderDelegate decoder = GetDecoder(typeof(TItem));
		EncoderDelegate encoder = GetEncoder(typeof(TItem));
		RegisterCustomType((TItem[] list) => JsonSerializer.Serialize(list?.Select((TItem item) => encoder(item))), (string serialized) => JsonSerializer.Deserialize<IEnumerable<string>>(serialized)?.Select((string item) => (TItem)decoder(item)).ToArray());
	}

	protected void RegisterListType<TItem>()
	{
		RegisterListType(delegate(TItem item, List<TItem> list)
		{
			if (item != null)
			{
				list.Add(item);
			}
		});
	}

	protected void RegisterListType<TItem, TList>() where TList : IList<TItem>, new()
	{
		RegisterListType(delegate(TItem item, TList list)
		{
			if (item != null)
			{
				list.Add(item);
			}
		});
	}

	protected void RegisterListType<TItem, TList>(Action<TItem, TList> addAction) where TList : IList<TItem>, new()
	{
		DecoderDelegate decoder = GetDecoder(typeof(TItem));
		EncoderDelegate encoder = GetEncoder(typeof(TItem));
		RegisterCustomType((TList list) => JsonSerializer.Serialize(list.Select((TItem item) => encoder(item))), delegate(string serialized)
		{
			TList list2 = new TList();
			JsonSerializer.Deserialize<IEnumerable<string>>(serialized)?.ForEach(delegate(string item)
			{
				TItem val = (TItem)decoder(item);
				if (val != null)
				{
					addAction(val, list2);
				}
			});
			return list2;
		});
	}

	protected void RegisterDictionaryType<TKey, TValue, TDictionary>() where TDictionary : IDictionary<TKey, TValue>, new()
	{
		RegisterDictionaryType(delegate(TKey? k, TValue? v, TDictionary d)
		{
			if (k != null && v != null)
			{
				d.Add(k, v);
			}
		});
	}

	protected void RegisterDictionaryType<TKey, TValue, TDictionary>(Action<TKey?, TValue?, TDictionary> addAction) where TDictionary : IDictionary<TKey, TValue>, new()
	{
		DecoderDelegate keyDecoder = GetDecoder(typeof(TKey));
		EncoderDelegate keyEncoder = GetEncoder(typeof(TKey));
		DecoderDelegate valueDecoder = GetDecoder(typeof(TValue));
		EncoderDelegate valueEncoder = GetEncoder(typeof(TValue));
		RegisterCustomType((TDictionary dictionary) => JsonSerializer.Serialize(dictionary.Select<KeyValuePair<TKey, TValue>, KeyValuePair<string, string>>((KeyValuePair<TKey, TValue> pair) => new KeyValuePair<string, string>(keyEncoder(pair.Key), valueEncoder(pair.Value)))), delegate(string serialized)
		{
			TDictionary dictionary2 = new TDictionary();
			JsonSerializer.Deserialize<IEnumerable<KeyValuePair<string, string>>>(serialized)?.ForEach(delegate(KeyValuePair<string, string> item)
			{
				addAction((TKey)keyDecoder(item.Key), (TValue)valueDecoder(item.Value), dictionary2);
			});
			return dictionary2;
		});
	}

	protected void RegisterKeyConversion(string key, ConversionDelegate encoderConversion, ConversionDelegate decoderConversion)
	{
		_encoderConversionMap.Add(key, encoderConversion);
		_decoderConversionMap.Add(key, decoderConversion);
	}

	protected T? GetValue<T>(string key, out bool usedDefaultValue, T? defaultValue = default(T?), bool ignoreUsedDefault = false)
	{
		usedDefaultValue = false;
		lock (_valueMap)
		{
			if (_valueMap.TryGetValue(key, out (object, bool) value))
			{
				Type underlyingType = Nullable.GetUnderlyingType(typeof(T));
				bool flag = underlyingType != null;
				if (value.Item2 && !ignoreUsedDefault)
				{
					usedDefaultValue = true;
					return defaultValue;
				}
				if ((value.Item1 == null && (typeof(T).IsClass || flag)) || (value.Item1 != null && (value.Item1.GetType() == typeof(T) || value.Item1.GetType() == underlyingType)))
				{
					return (T)value.Item1;
				}
				throw new Exception("The stored type for this key doesn't match");
			}
		}
		object obj = null;
		string value2 = null;
		if (_storage.TryReadValue(key, out value2))
		{
			if (_decoderConversionMap.TryGetValue(key, out ConversionDelegate value3))
			{
				value2 = value3(value2);
			}
			try
			{
				obj = Decode(typeof(T), value2);
			}
			catch
			{
				Log.Warning("Failed to decode the value for {0}, falling back to the default value", key);
				usedDefaultValue = true;
				obj = defaultValue;
			}
		}
		else
		{
			usedDefaultValue = true;
			obj = defaultValue;
		}
		lock (_valueMap)
		{
			_valueMap[key] = (obj, usedDefaultValue);
		}
		return (T)obj;
	}

	protected T? GetValue<T>(string key, T? defaultValue = default(T?))
	{
		bool usedDefaultValue;
		return GetValue(key, out usedDefaultValue, defaultValue, ignoreUsedDefault: true);
	}

	protected void SetValue(string key, object value)
	{
		lock (_valueMap)
		{
			_valueMap[key] = (value, false);
		}
		string value2 = Encode(value.GetType(), value);
		if (_encoderConversionMap.TryGetValue(key, out ConversionDelegate value3))
		{
			value2 = value3(value2);
		}
		_storage.WriteValue(key, value2);
	}

	protected void SetValue<T>(string key, T? value)
	{
		lock (_valueMap)
		{
			_valueMap[key] = (value, false);
		}
		string value2 = Encode(typeof(T), value);
		if (_encoderConversionMap.TryGetValue(key, out ConversionDelegate value3))
		{
			value2 = value3(value2);
		}
		_storage.WriteValue(key, value2);
	}

	public void RemoveValue(string key)
	{
		lock (_valueMap)
		{
			_valueMap.Remove(key);
		}
		_storage.RemoveValue(key);
	}

	private object? Decode(Type type, string value)
	{
		return GetDecoder(type)(value);
	}

	private string Encode(Type type, object? value)
	{
		return GetEncoder(type)(value);
	}

	private DecoderDelegate GetDecoder(Type type)
	{
		if ((!_decoderMap.TryGetValue(type, out DecoderDelegate value) && !type.TryGetDecoder(out value)) || value == null)
		{
			throw new Exception($"No decoder was found for {type.Name} type");
		}
		return value;
	}

	private EncoderDelegate GetEncoder(Type type)
	{
		if ((!_encoderMap.TryGetValue(type, out EncoderDelegate value) && !type.TryGetEncoder(out value)) || value == null)
		{
			throw new Exception($"No encoder was found for {type.Name} type");
		}
		return value;
	}

	public virtual void Reload()
	{
		_valueMap.Clear();
		_storage.Reload();
	}

	public void UpdateSettingsFile()
	{
		_storage.UpdateSettingsFile();
	}
}
