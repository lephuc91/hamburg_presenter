using System;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using ProPresenter.DO.Settings.Communication.Model;

namespace ProPresenter.DO.Settings.Communication;

[JsonSourceGenerationOptions(JsonSerializerDefaults.Web, WriteIndented = false)]
[JsonSerializable(typeof(DeviceInfo))]
[GeneratedCode("System.Text.Json.SourceGeneration", "9.0.12.47515")]
internal class DeviceInfoSerializationSourceGenerationContext : JsonSerializerContext, IJsonTypeInfoResolver
{
	private JsonTypeInfo<bool>? _Boolean;

	private JsonTypeInfo<DeviceInfo>? _DeviceInfo;

	private JsonTypeInfo<MidiConnectedDeviceInfo>? _MidiConnectedDeviceInfo;

	private JsonTypeInfo<MidiConnectedDeviceInfo[]>? _MidiConnectedDeviceInfoArray;

	private JsonTypeInfo<MidiDeviceInfo>? _MidiDeviceInfo;

	private JsonTypeInfo<Guid>? _Guid;

	private JsonTypeInfo<string>? _String;

	private JsonTypeInfo<uint>? _UInt32;

	private JsonTypeInfo<ushort>? _UInt16;

	private static readonly JsonSerializerOptions s_defaultOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web)
	{
		WriteIndented = false
	};

	private const BindingFlags InstanceMemberBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

	private static readonly JsonEncodedText PropName_name = JsonEncodedText.Encode("name");

	private static readonly JsonEncodedText PropName_manufacturerID = JsonEncodedText.Encode("manufacturerID");

	private static readonly JsonEncodedText PropName_productID = JsonEncodedText.Encode("productID");

	private static readonly JsonEncodedText PropName_driverVersion = JsonEncodedText.Encode("driverVersion");

	private static readonly JsonEncodedText PropName_id = JsonEncodedText.Encode("id");

	private static readonly JsonEncodedText PropName_label = JsonEncodedText.Encode("label");

	private static readonly JsonEncodedText PropName_reconnect = JsonEncodedText.Encode("reconnect");

	private static readonly JsonEncodedText PropName_activeInputs = JsonEncodedText.Encode("activeInputs");

	private static readonly JsonEncodedText PropName_activeOutputs = JsonEncodedText.Encode("activeOutputs");

	public JsonTypeInfo<bool> Boolean => _Boolean ?? (_Boolean = (JsonTypeInfo<bool>)base.Options.GetTypeInfo(typeof(bool)));

	public JsonTypeInfo<DeviceInfo> DeviceInfo => _DeviceInfo ?? (_DeviceInfo = (JsonTypeInfo<DeviceInfo>)base.Options.GetTypeInfo(typeof(DeviceInfo)));

	public JsonTypeInfo<MidiConnectedDeviceInfo> MidiConnectedDeviceInfo => _MidiConnectedDeviceInfo ?? (_MidiConnectedDeviceInfo = (JsonTypeInfo<MidiConnectedDeviceInfo>)base.Options.GetTypeInfo(typeof(MidiConnectedDeviceInfo)));

	public JsonTypeInfo<MidiConnectedDeviceInfo[]> MidiConnectedDeviceInfoArray => _MidiConnectedDeviceInfoArray ?? (_MidiConnectedDeviceInfoArray = (JsonTypeInfo<MidiConnectedDeviceInfo[]>)base.Options.GetTypeInfo(typeof(MidiConnectedDeviceInfo[])));

	public JsonTypeInfo<MidiDeviceInfo> MidiDeviceInfo => _MidiDeviceInfo ?? (_MidiDeviceInfo = (JsonTypeInfo<MidiDeviceInfo>)base.Options.GetTypeInfo(typeof(MidiDeviceInfo)));

	public JsonTypeInfo<Guid> Guid => _Guid ?? (_Guid = (JsonTypeInfo<Guid>)base.Options.GetTypeInfo(typeof(Guid)));

	public JsonTypeInfo<string> String => _String ?? (_String = (JsonTypeInfo<string>)base.Options.GetTypeInfo(typeof(string)));

	public JsonTypeInfo<uint> UInt32 => _UInt32 ?? (_UInt32 = (JsonTypeInfo<uint>)base.Options.GetTypeInfo(typeof(uint)));

	public JsonTypeInfo<ushort> UInt16 => _UInt16 ?? (_UInt16 = (JsonTypeInfo<ushort>)base.Options.GetTypeInfo(typeof(ushort)));

	public static DeviceInfoSerializationSourceGenerationContext Default { get; } = new DeviceInfoSerializationSourceGenerationContext(new JsonSerializerOptions(s_defaultOptions));

	protected override JsonSerializerOptions? GeneratedSerializerOptions { get; } = s_defaultOptions;

	private JsonTypeInfo<bool> Create_Boolean(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<bool> jsonTypeInfo))
		{
			jsonTypeInfo = JsonMetadataServices.CreateValueInfo<bool>(options, JsonMetadataServices.BooleanConverter);
		}
		((JsonTypeInfo)jsonTypeInfo).OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private JsonTypeInfo<DeviceInfo> Create_DeviceInfo(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<DeviceInfo> jsonTypeInfo))
		{
			JsonObjectInfoValues<DeviceInfo> jsonObjectInfoValues = new JsonObjectInfoValues<DeviceInfo>();
			jsonObjectInfoValues.ObjectCreator = () => new DeviceInfo();
			jsonObjectInfoValues.ObjectWithParameterizedConstructorCreator = null;
			jsonObjectInfoValues.PropertyMetadataInitializer = (JsonSerializerContext _) => DeviceInfoPropInit(options);
			jsonObjectInfoValues.ConstructorParameterMetadataInitializer = null;
			jsonObjectInfoValues.set_ConstructorAttributeProviderFactory((Func<ICustomAttributeProvider>)(() => typeof(DeviceInfo).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null)));
			jsonObjectInfoValues.SerializeHandler = null;
			JsonObjectInfoValues<DeviceInfo> objectInfo = jsonObjectInfoValues;
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		((JsonTypeInfo)jsonTypeInfo).OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] DeviceInfoPropInit(JsonSerializerOptions options)
	{
		return new JsonPropertyInfo[0];
	}

	private JsonTypeInfo<MidiConnectedDeviceInfo> Create_MidiConnectedDeviceInfo(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<MidiConnectedDeviceInfo> jsonTypeInfo))
		{
			JsonObjectInfoValues<MidiConnectedDeviceInfo> jsonObjectInfoValues = new JsonObjectInfoValues<MidiConnectedDeviceInfo>();
			jsonObjectInfoValues.ObjectCreator = null;
			jsonObjectInfoValues.ObjectWithParameterizedConstructorCreator = (object[] args) => new MidiConnectedDeviceInfo((string)args[0], (ushort)args[1], (ushort)args[2], (uint)args[3]);
			jsonObjectInfoValues.PropertyMetadataInitializer = (JsonSerializerContext _) => MidiConnectedDeviceInfoPropInit(options);
			jsonObjectInfoValues.ConstructorParameterMetadataInitializer = MidiConnectedDeviceInfoCtorParamInit;
			jsonObjectInfoValues.set_ConstructorAttributeProviderFactory((Func<ICustomAttributeProvider>)(() => typeof(MidiConnectedDeviceInfo).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[4]
			{
				typeof(string),
				typeof(ushort),
				typeof(ushort),
				typeof(uint)
			}, null)));
			jsonObjectInfoValues.SerializeHandler = MidiConnectedDeviceInfoSerializeHandler;
			JsonObjectInfoValues<MidiConnectedDeviceInfo> objectInfo = jsonObjectInfoValues;
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		((JsonTypeInfo)jsonTypeInfo).OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] MidiConnectedDeviceInfoPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[4];
		JsonPropertyInfoValues<string> jsonPropertyInfoValues = new JsonPropertyInfoValues<string>();
		jsonPropertyInfoValues.IsProperty = true;
		jsonPropertyInfoValues.IsPublic = true;
		jsonPropertyInfoValues.IsVirtual = false;
		jsonPropertyInfoValues.DeclaringType = typeof(MidiConnectedDeviceInfo);
		jsonPropertyInfoValues.Converter = null;
		jsonPropertyInfoValues.Getter = (object obj) => ((MidiConnectedDeviceInfo)obj).Name;
		jsonPropertyInfoValues.Setter = delegate
		{
			throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
		};
		jsonPropertyInfoValues.IgnoreCondition = null;
		jsonPropertyInfoValues.HasJsonInclude = false;
		jsonPropertyInfoValues.IsExtensionData = false;
		jsonPropertyInfoValues.NumberHandling = null;
		jsonPropertyInfoValues.PropertyName = "Name";
		jsonPropertyInfoValues.JsonPropertyName = "name";
		jsonPropertyInfoValues.set_AttributeProviderFactory((Func<ICustomAttributeProvider>)(() => typeof(MidiConnectedDeviceInfo).GetProperty("Name", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)));
		JsonPropertyInfoValues<string> propertyInfo = jsonPropertyInfoValues;
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		array[0].IsGetNullable = false;
		array[0].IsSetNullable = false;
		JsonPropertyInfoValues<ushort> jsonPropertyInfoValues2 = new JsonPropertyInfoValues<ushort>();
		jsonPropertyInfoValues2.IsProperty = true;
		jsonPropertyInfoValues2.IsPublic = true;
		jsonPropertyInfoValues2.IsVirtual = false;
		jsonPropertyInfoValues2.DeclaringType = typeof(MidiConnectedDeviceInfo);
		jsonPropertyInfoValues2.Converter = null;
		jsonPropertyInfoValues2.Getter = (object obj) => ((MidiConnectedDeviceInfo)obj).ManufacturerID;
		jsonPropertyInfoValues2.Setter = delegate
		{
			throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
		};
		jsonPropertyInfoValues2.IgnoreCondition = null;
		jsonPropertyInfoValues2.HasJsonInclude = false;
		jsonPropertyInfoValues2.IsExtensionData = false;
		jsonPropertyInfoValues2.NumberHandling = null;
		jsonPropertyInfoValues2.PropertyName = "ManufacturerID";
		jsonPropertyInfoValues2.JsonPropertyName = "manufacturerID";
		jsonPropertyInfoValues2.set_AttributeProviderFactory((Func<ICustomAttributeProvider>)(() => typeof(MidiConnectedDeviceInfo).GetProperty("ManufacturerID", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(ushort), Array.Empty<Type>(), null)));
		JsonPropertyInfoValues<ushort> propertyInfo2 = jsonPropertyInfoValues2;
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		JsonPropertyInfoValues<ushort> jsonPropertyInfoValues3 = new JsonPropertyInfoValues<ushort>();
		jsonPropertyInfoValues3.IsProperty = true;
		jsonPropertyInfoValues3.IsPublic = true;
		jsonPropertyInfoValues3.IsVirtual = false;
		jsonPropertyInfoValues3.DeclaringType = typeof(MidiConnectedDeviceInfo);
		jsonPropertyInfoValues3.Converter = null;
		jsonPropertyInfoValues3.Getter = (object obj) => ((MidiConnectedDeviceInfo)obj).ProductID;
		jsonPropertyInfoValues3.Setter = delegate
		{
			throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
		};
		jsonPropertyInfoValues3.IgnoreCondition = null;
		jsonPropertyInfoValues3.HasJsonInclude = false;
		jsonPropertyInfoValues3.IsExtensionData = false;
		jsonPropertyInfoValues3.NumberHandling = null;
		jsonPropertyInfoValues3.PropertyName = "ProductID";
		jsonPropertyInfoValues3.JsonPropertyName = "productID";
		jsonPropertyInfoValues3.set_AttributeProviderFactory((Func<ICustomAttributeProvider>)(() => typeof(MidiConnectedDeviceInfo).GetProperty("ProductID", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(ushort), Array.Empty<Type>(), null)));
		JsonPropertyInfoValues<ushort> propertyInfo3 = jsonPropertyInfoValues3;
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		JsonPropertyInfoValues<uint> jsonPropertyInfoValues4 = new JsonPropertyInfoValues<uint>();
		jsonPropertyInfoValues4.IsProperty = true;
		jsonPropertyInfoValues4.IsPublic = true;
		jsonPropertyInfoValues4.IsVirtual = false;
		jsonPropertyInfoValues4.DeclaringType = typeof(MidiConnectedDeviceInfo);
		jsonPropertyInfoValues4.Converter = null;
		jsonPropertyInfoValues4.Getter = (object obj) => ((MidiConnectedDeviceInfo)obj).DriverVersion;
		jsonPropertyInfoValues4.Setter = delegate
		{
			throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
		};
		jsonPropertyInfoValues4.IgnoreCondition = null;
		jsonPropertyInfoValues4.HasJsonInclude = false;
		jsonPropertyInfoValues4.IsExtensionData = false;
		jsonPropertyInfoValues4.NumberHandling = null;
		jsonPropertyInfoValues4.PropertyName = "DriverVersion";
		jsonPropertyInfoValues4.JsonPropertyName = "driverVersion";
		jsonPropertyInfoValues4.set_AttributeProviderFactory((Func<ICustomAttributeProvider>)(() => typeof(MidiConnectedDeviceInfo).GetProperty("DriverVersion", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(uint), Array.Empty<Type>(), null)));
		JsonPropertyInfoValues<uint> propertyInfo4 = jsonPropertyInfoValues4;
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		return array;
	}

	private void MidiConnectedDeviceInfoSerializeHandler(Utf8JsonWriter writer, MidiConnectedDeviceInfo? value)
	{
		if ((object)value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_name, value.Name);
		writer.WriteNumber(PropName_manufacturerID, value.ManufacturerID);
		writer.WriteNumber(PropName_productID, value.ProductID);
		writer.WriteNumber(PropName_driverVersion, value.DriverVersion);
		writer.WriteEndObject();
	}

	private static JsonParameterInfoValues[] MidiConnectedDeviceInfoCtorParamInit()
	{
		JsonParameterInfoValues[] array = new JsonParameterInfoValues[4];
		JsonParameterInfoValues jsonParameterInfoValues = new JsonParameterInfoValues();
		jsonParameterInfoValues.Name = "Name";
		jsonParameterInfoValues.ParameterType = typeof(string);
		jsonParameterInfoValues.Position = 0;
		jsonParameterInfoValues.HasDefaultValue = false;
		jsonParameterInfoValues.DefaultValue = null;
		jsonParameterInfoValues.set_IsNullable(false);
		array[0] = jsonParameterInfoValues;
		JsonParameterInfoValues jsonParameterInfoValues2 = new JsonParameterInfoValues();
		jsonParameterInfoValues2.Name = "ManufacturerID";
		jsonParameterInfoValues2.ParameterType = typeof(ushort);
		jsonParameterInfoValues2.Position = 1;
		jsonParameterInfoValues2.HasDefaultValue = false;
		jsonParameterInfoValues2.DefaultValue = null;
		jsonParameterInfoValues2.set_IsNullable(false);
		array[1] = jsonParameterInfoValues2;
		JsonParameterInfoValues jsonParameterInfoValues3 = new JsonParameterInfoValues();
		jsonParameterInfoValues3.Name = "ProductID";
		jsonParameterInfoValues3.ParameterType = typeof(ushort);
		jsonParameterInfoValues3.Position = 2;
		jsonParameterInfoValues3.HasDefaultValue = false;
		jsonParameterInfoValues3.DefaultValue = null;
		jsonParameterInfoValues3.set_IsNullable(false);
		array[2] = jsonParameterInfoValues3;
		JsonParameterInfoValues jsonParameterInfoValues4 = new JsonParameterInfoValues();
		jsonParameterInfoValues4.Name = "DriverVersion";
		jsonParameterInfoValues4.ParameterType = typeof(uint);
		jsonParameterInfoValues4.Position = 3;
		jsonParameterInfoValues4.HasDefaultValue = false;
		jsonParameterInfoValues4.DefaultValue = null;
		jsonParameterInfoValues4.set_IsNullable(false);
		array[3] = jsonParameterInfoValues4;
		return array;
	}

	private JsonTypeInfo<MidiConnectedDeviceInfo[]> Create_MidiConnectedDeviceInfoArray(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<MidiConnectedDeviceInfo[]> jsonTypeInfo))
		{
			JsonCollectionInfoValues<MidiConnectedDeviceInfo[]> collectionInfo = new JsonCollectionInfoValues<MidiConnectedDeviceInfo[]>
			{
				ObjectCreator = null,
				SerializeHandler = MidiConnectedDeviceInfoArraySerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateArrayInfo(options, collectionInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		((JsonTypeInfo)jsonTypeInfo).OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private void MidiConnectedDeviceInfoArraySerializeHandler(Utf8JsonWriter writer, MidiConnectedDeviceInfo[]? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartArray();
		for (int i = 0; i < value.Length; i++)
		{
			MidiConnectedDeviceInfoSerializeHandler(writer, value[i]);
		}
		writer.WriteEndArray();
	}

	private JsonTypeInfo<MidiDeviceInfo> Create_MidiDeviceInfo(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<MidiDeviceInfo> jsonTypeInfo))
		{
			JsonObjectInfoValues<MidiDeviceInfo> jsonObjectInfoValues = new JsonObjectInfoValues<MidiDeviceInfo>();
			jsonObjectInfoValues.ObjectCreator = null;
			jsonObjectInfoValues.ObjectWithParameterizedConstructorCreator = (object[] args) => new MidiDeviceInfo((Guid)args[0], (string)args[1], (bool)args[2], (MidiConnectedDeviceInfo[])args[3], (MidiConnectedDeviceInfo[])args[4]);
			jsonObjectInfoValues.PropertyMetadataInitializer = (JsonSerializerContext _) => MidiDeviceInfoPropInit(options);
			jsonObjectInfoValues.ConstructorParameterMetadataInitializer = MidiDeviceInfoCtorParamInit;
			jsonObjectInfoValues.set_ConstructorAttributeProviderFactory((Func<ICustomAttributeProvider>)(() => typeof(MidiDeviceInfo).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[5]
			{
				typeof(Guid),
				typeof(string),
				typeof(bool),
				typeof(MidiConnectedDeviceInfo[]),
				typeof(MidiConnectedDeviceInfo[])
			}, null)));
			jsonObjectInfoValues.SerializeHandler = MidiDeviceInfoSerializeHandler;
			JsonObjectInfoValues<MidiDeviceInfo> objectInfo = jsonObjectInfoValues;
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		((JsonTypeInfo)jsonTypeInfo).OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] MidiDeviceInfoPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[5];
		JsonPropertyInfoValues<Guid> jsonPropertyInfoValues = new JsonPropertyInfoValues<Guid>();
		jsonPropertyInfoValues.IsProperty = true;
		jsonPropertyInfoValues.IsPublic = true;
		jsonPropertyInfoValues.IsVirtual = false;
		jsonPropertyInfoValues.DeclaringType = typeof(MidiDeviceInfo);
		jsonPropertyInfoValues.Converter = null;
		jsonPropertyInfoValues.Getter = (object obj) => ((MidiDeviceInfo)obj).Id;
		jsonPropertyInfoValues.Setter = delegate
		{
			throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
		};
		jsonPropertyInfoValues.IgnoreCondition = null;
		jsonPropertyInfoValues.HasJsonInclude = false;
		jsonPropertyInfoValues.IsExtensionData = false;
		jsonPropertyInfoValues.NumberHandling = null;
		jsonPropertyInfoValues.PropertyName = "Id";
		jsonPropertyInfoValues.JsonPropertyName = "id";
		jsonPropertyInfoValues.set_AttributeProviderFactory((Func<ICustomAttributeProvider>)(() => typeof(MidiDeviceInfo).GetProperty("Id", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(Guid), Array.Empty<Type>(), null)));
		JsonPropertyInfoValues<Guid> propertyInfo = jsonPropertyInfoValues;
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		JsonPropertyInfoValues<string> jsonPropertyInfoValues2 = new JsonPropertyInfoValues<string>();
		jsonPropertyInfoValues2.IsProperty = true;
		jsonPropertyInfoValues2.IsPublic = true;
		jsonPropertyInfoValues2.IsVirtual = false;
		jsonPropertyInfoValues2.DeclaringType = typeof(MidiDeviceInfo);
		jsonPropertyInfoValues2.Converter = null;
		jsonPropertyInfoValues2.Getter = (object obj) => ((MidiDeviceInfo)obj).Label;
		jsonPropertyInfoValues2.Setter = delegate
		{
			throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
		};
		jsonPropertyInfoValues2.IgnoreCondition = null;
		jsonPropertyInfoValues2.HasJsonInclude = false;
		jsonPropertyInfoValues2.IsExtensionData = false;
		jsonPropertyInfoValues2.NumberHandling = null;
		jsonPropertyInfoValues2.PropertyName = "Label";
		jsonPropertyInfoValues2.JsonPropertyName = "label";
		jsonPropertyInfoValues2.set_AttributeProviderFactory((Func<ICustomAttributeProvider>)(() => typeof(MidiDeviceInfo).GetProperty("Label", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)));
		JsonPropertyInfoValues<string> propertyInfo2 = jsonPropertyInfoValues2;
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		array[1].IsGetNullable = false;
		array[1].IsSetNullable = false;
		JsonPropertyInfoValues<bool> jsonPropertyInfoValues3 = new JsonPropertyInfoValues<bool>();
		jsonPropertyInfoValues3.IsProperty = true;
		jsonPropertyInfoValues3.IsPublic = true;
		jsonPropertyInfoValues3.IsVirtual = false;
		jsonPropertyInfoValues3.DeclaringType = typeof(MidiDeviceInfo);
		jsonPropertyInfoValues3.Converter = null;
		jsonPropertyInfoValues3.Getter = (object obj) => ((MidiDeviceInfo)obj).Reconnect;
		jsonPropertyInfoValues3.Setter = delegate
		{
			throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
		};
		jsonPropertyInfoValues3.IgnoreCondition = null;
		jsonPropertyInfoValues3.HasJsonInclude = false;
		jsonPropertyInfoValues3.IsExtensionData = false;
		jsonPropertyInfoValues3.NumberHandling = null;
		jsonPropertyInfoValues3.PropertyName = "Reconnect";
		jsonPropertyInfoValues3.JsonPropertyName = "reconnect";
		jsonPropertyInfoValues3.set_AttributeProviderFactory((Func<ICustomAttributeProvider>)(() => typeof(MidiDeviceInfo).GetProperty("Reconnect", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(bool), Array.Empty<Type>(), null)));
		JsonPropertyInfoValues<bool> propertyInfo3 = jsonPropertyInfoValues3;
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		JsonPropertyInfoValues<MidiConnectedDeviceInfo[]> jsonPropertyInfoValues4 = new JsonPropertyInfoValues<MidiConnectedDeviceInfo[]>();
		jsonPropertyInfoValues4.IsProperty = true;
		jsonPropertyInfoValues4.IsPublic = true;
		jsonPropertyInfoValues4.IsVirtual = false;
		jsonPropertyInfoValues4.DeclaringType = typeof(MidiDeviceInfo);
		jsonPropertyInfoValues4.Converter = null;
		jsonPropertyInfoValues4.Getter = (object obj) => ((MidiDeviceInfo)obj).ActiveInputs;
		jsonPropertyInfoValues4.Setter = delegate
		{
			throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
		};
		jsonPropertyInfoValues4.IgnoreCondition = null;
		jsonPropertyInfoValues4.HasJsonInclude = false;
		jsonPropertyInfoValues4.IsExtensionData = false;
		jsonPropertyInfoValues4.NumberHandling = null;
		jsonPropertyInfoValues4.PropertyName = "ActiveInputs";
		jsonPropertyInfoValues4.JsonPropertyName = "activeInputs";
		jsonPropertyInfoValues4.set_AttributeProviderFactory((Func<ICustomAttributeProvider>)(() => typeof(MidiDeviceInfo).GetProperty("ActiveInputs", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(MidiConnectedDeviceInfo[]), Array.Empty<Type>(), null)));
		JsonPropertyInfoValues<MidiConnectedDeviceInfo[]> propertyInfo4 = jsonPropertyInfoValues4;
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		array[3].IsGetNullable = false;
		array[3].IsSetNullable = false;
		JsonPropertyInfoValues<MidiConnectedDeviceInfo[]> jsonPropertyInfoValues5 = new JsonPropertyInfoValues<MidiConnectedDeviceInfo[]>();
		jsonPropertyInfoValues5.IsProperty = true;
		jsonPropertyInfoValues5.IsPublic = true;
		jsonPropertyInfoValues5.IsVirtual = false;
		jsonPropertyInfoValues5.DeclaringType = typeof(MidiDeviceInfo);
		jsonPropertyInfoValues5.Converter = null;
		jsonPropertyInfoValues5.Getter = (object obj) => ((MidiDeviceInfo)obj).ActiveOutputs;
		jsonPropertyInfoValues5.Setter = delegate
		{
			throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
		};
		jsonPropertyInfoValues5.IgnoreCondition = null;
		jsonPropertyInfoValues5.HasJsonInclude = false;
		jsonPropertyInfoValues5.IsExtensionData = false;
		jsonPropertyInfoValues5.NumberHandling = null;
		jsonPropertyInfoValues5.PropertyName = "ActiveOutputs";
		jsonPropertyInfoValues5.JsonPropertyName = "activeOutputs";
		jsonPropertyInfoValues5.set_AttributeProviderFactory((Func<ICustomAttributeProvider>)(() => typeof(MidiDeviceInfo).GetProperty("ActiveOutputs", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(MidiConnectedDeviceInfo[]), Array.Empty<Type>(), null)));
		JsonPropertyInfoValues<MidiConnectedDeviceInfo[]> propertyInfo5 = jsonPropertyInfoValues5;
		array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
		array[4].IsGetNullable = false;
		array[4].IsSetNullable = false;
		return array;
	}

	private void MidiDeviceInfoSerializeHandler(Utf8JsonWriter writer, MidiDeviceInfo? value)
	{
		if ((object)value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_id, value.Id);
		writer.WriteString(PropName_label, value.Label);
		writer.WriteBoolean(PropName_reconnect, value.Reconnect);
		writer.WritePropertyName(PropName_activeInputs);
		MidiConnectedDeviceInfoArraySerializeHandler(writer, value.ActiveInputs);
		writer.WritePropertyName(PropName_activeOutputs);
		MidiConnectedDeviceInfoArraySerializeHandler(writer, value.ActiveOutputs);
		writer.WriteEndObject();
	}

	private static JsonParameterInfoValues[] MidiDeviceInfoCtorParamInit()
	{
		JsonParameterInfoValues[] array = new JsonParameterInfoValues[5];
		JsonParameterInfoValues jsonParameterInfoValues = new JsonParameterInfoValues();
		jsonParameterInfoValues.Name = "Id";
		jsonParameterInfoValues.ParameterType = typeof(Guid);
		jsonParameterInfoValues.Position = 0;
		jsonParameterInfoValues.HasDefaultValue = false;
		jsonParameterInfoValues.DefaultValue = null;
		jsonParameterInfoValues.set_IsNullable(false);
		array[0] = jsonParameterInfoValues;
		JsonParameterInfoValues jsonParameterInfoValues2 = new JsonParameterInfoValues();
		jsonParameterInfoValues2.Name = "Label";
		jsonParameterInfoValues2.ParameterType = typeof(string);
		jsonParameterInfoValues2.Position = 1;
		jsonParameterInfoValues2.HasDefaultValue = false;
		jsonParameterInfoValues2.DefaultValue = null;
		jsonParameterInfoValues2.set_IsNullable(false);
		array[1] = jsonParameterInfoValues2;
		JsonParameterInfoValues jsonParameterInfoValues3 = new JsonParameterInfoValues();
		jsonParameterInfoValues3.Name = "Reconnect";
		jsonParameterInfoValues3.ParameterType = typeof(bool);
		jsonParameterInfoValues3.Position = 2;
		jsonParameterInfoValues3.HasDefaultValue = false;
		jsonParameterInfoValues3.DefaultValue = null;
		jsonParameterInfoValues3.set_IsNullable(false);
		array[2] = jsonParameterInfoValues3;
		JsonParameterInfoValues jsonParameterInfoValues4 = new JsonParameterInfoValues();
		jsonParameterInfoValues4.Name = "ActiveInputs";
		jsonParameterInfoValues4.ParameterType = typeof(MidiConnectedDeviceInfo[]);
		jsonParameterInfoValues4.Position = 3;
		jsonParameterInfoValues4.HasDefaultValue = false;
		jsonParameterInfoValues4.DefaultValue = null;
		jsonParameterInfoValues4.set_IsNullable(false);
		array[3] = jsonParameterInfoValues4;
		JsonParameterInfoValues jsonParameterInfoValues5 = new JsonParameterInfoValues();
		jsonParameterInfoValues5.Name = "ActiveOutputs";
		jsonParameterInfoValues5.ParameterType = typeof(MidiConnectedDeviceInfo[]);
		jsonParameterInfoValues5.Position = 4;
		jsonParameterInfoValues5.HasDefaultValue = false;
		jsonParameterInfoValues5.DefaultValue = null;
		jsonParameterInfoValues5.set_IsNullable(false);
		array[4] = jsonParameterInfoValues5;
		return array;
	}

	private JsonTypeInfo<Guid> Create_Guid(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<Guid> jsonTypeInfo))
		{
			jsonTypeInfo = JsonMetadataServices.CreateValueInfo<Guid>(options, JsonMetadataServices.GuidConverter);
		}
		((JsonTypeInfo)jsonTypeInfo).OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private JsonTypeInfo<string> Create_String(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<string> jsonTypeInfo))
		{
			jsonTypeInfo = JsonMetadataServices.CreateValueInfo<string>(options, JsonMetadataServices.StringConverter);
		}
		((JsonTypeInfo)jsonTypeInfo).OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private JsonTypeInfo<uint> Create_UInt32(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<uint> jsonTypeInfo))
		{
			jsonTypeInfo = JsonMetadataServices.CreateValueInfo<uint>(options, JsonMetadataServices.UInt32Converter);
		}
		((JsonTypeInfo)jsonTypeInfo).OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private JsonTypeInfo<ushort> Create_UInt16(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ushort> jsonTypeInfo))
		{
			jsonTypeInfo = JsonMetadataServices.CreateValueInfo<ushort>(options, JsonMetadataServices.UInt16Converter);
		}
		((JsonTypeInfo)jsonTypeInfo).OriginatingResolver = this;
		return jsonTypeInfo;
	}

	public DeviceInfoSerializationSourceGenerationContext()
		: base(null)
	{
	}

	public DeviceInfoSerializationSourceGenerationContext(JsonSerializerOptions options)
		: base(options)
	{
	}

	private static bool TryGetTypeInfoForRuntimeCustomConverter<TJsonMetadataType>(JsonSerializerOptions options, out JsonTypeInfo<TJsonMetadataType> jsonTypeInfo)
	{
		JsonConverter runtimeConverterForType = GetRuntimeConverterForType(typeof(TJsonMetadataType), options);
		if (runtimeConverterForType != null)
		{
			jsonTypeInfo = JsonMetadataServices.CreateValueInfo<TJsonMetadataType>(options, runtimeConverterForType);
			return true;
		}
		jsonTypeInfo = null;
		return false;
	}

	private static JsonConverter? GetRuntimeConverterForType(Type type, JsonSerializerOptions options)
	{
		for (int i = 0; i < options.Converters.Count; i++)
		{
			JsonConverter jsonConverter = options.Converters[i];
			if (jsonConverter != null && jsonConverter.CanConvert(type))
			{
				return ExpandConverter(type, jsonConverter, options, validateCanConvert: false);
			}
		}
		return null;
	}

	private static JsonConverter ExpandConverter(Type type, JsonConverter converter, JsonSerializerOptions options, bool validateCanConvert = true)
	{
		if (validateCanConvert && !converter.CanConvert(type))
		{
			throw new InvalidOperationException($"The converter '{converter.GetType()}' is not compatible with the type '{type}'.");
		}
		if (converter is JsonConverterFactory jsonConverterFactory)
		{
			converter = jsonConverterFactory.CreateConverter(type, options);
			if (converter == null || converter is JsonConverterFactory)
			{
				throw new InvalidOperationException($"The converter '{jsonConverterFactory.GetType()}' cannot return null or a JsonConverterFactory instance.");
			}
		}
		return converter;
	}

	public override JsonTypeInfo? GetTypeInfo(Type type)
	{
		JsonTypeInfo result = default(JsonTypeInfo);
		base.Options.TryGetTypeInfo(type, ref result);
		return result;
	}

	JsonTypeInfo? IJsonTypeInfoResolver.GetTypeInfo(Type type, JsonSerializerOptions options)
	{
		if (type == typeof(bool))
		{
			return Create_Boolean(options);
		}
		if (type == typeof(DeviceInfo))
		{
			return Create_DeviceInfo(options);
		}
		if (type == typeof(MidiConnectedDeviceInfo))
		{
			return Create_MidiConnectedDeviceInfo(options);
		}
		if (type == typeof(MidiConnectedDeviceInfo[]))
		{
			return Create_MidiConnectedDeviceInfoArray(options);
		}
		if (type == typeof(MidiDeviceInfo))
		{
			return Create_MidiDeviceInfo(options);
		}
		if (type == typeof(Guid))
		{
			return Create_Guid(options);
		}
		if (type == typeof(string))
		{
			return Create_String(options);
		}
		if (type == typeof(uint))
		{
			return Create_UInt32(options);
		}
		if (type == typeof(ushort))
		{
			return Create_UInt16(options);
		}
		return null;
	}
}
