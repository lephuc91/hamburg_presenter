using System;
using System.Globalization;
using System.Reflection;
using Pro.Common.Extensions;

namespace Pro.Data.SQLite;

public class Column
{
	public object? DefaultValue { get; }

	public bool HasDefaultValue { get; }

	public bool IsEntityName { get; }

	public bool IsNotNull { get; }

	public bool IsPrimaryKey { get; }

	public bool IsUnique { get; }

	public string Name { get; }

	public int Order { get; }

	public string ParameterName => "@" + Name;

	public int PrimaryKeyOrder { get; }

	public PropertyInfo PropertyInfo { get; }

	public Type Type { get; }

	public Column(PropertyInfo propertyInfo)
	{
		PrimaryKeyAttribute customAttribute = propertyInfo.GetCustomAttribute<PrimaryKeyAttribute>();
		UniqueAttribute customAttribute2 = propertyInfo.GetCustomAttribute<UniqueAttribute>();
		NotNullAttribute customAttribute3 = propertyInfo.GetCustomAttribute<NotNullAttribute>();
		ColumnOrderAttribute customAttribute4 = propertyInfo.GetCustomAttribute<ColumnOrderAttribute>();
		DefaultValueAttribute customAttribute5 = propertyInfo.GetCustomAttribute<DefaultValueAttribute>();
		EntityNameColumnAttribute customAttribute6 = propertyInfo.GetCustomAttribute<EntityNameColumnAttribute>();
		PropertyInfo = propertyInfo;
		Name = propertyInfo.Name;
		Type = propertyInfo.PropertyType;
		IsPrimaryKey = customAttribute != null;
		IsUnique = customAttribute2 != null;
		IsNotNull = customAttribute3 != null;
		PrimaryKeyOrder = customAttribute?.Order ?? 0;
		IsEntityName = customAttribute6 != null;
		if (customAttribute5 != null && !Type.IsInstanceOfType(customAttribute5.Value))
		{
			throw new DatabaseException($"The default type '{customAttribute5.Value.GetType()}' is not assignable to '{Type}'.");
		}
		HasDefaultValue = customAttribute5 != null;
		DefaultValue = ((customAttribute5 != null) ? customAttribute5.Value : (Type.IsValueType ? Activator.CreateInstance(Type) : null));
		if (customAttribute != null)
		{
			Order = -1;
		}
		else
		{
			Order = customAttribute4?.Order ?? 0;
		}
	}

	public object GetValue(object source)
	{
		return PropertyInfo.GetValue(source) ?? DBNull.Value;
	}

	public void SetValue(object target, object value)
	{
		PropertyInfo.SetValue(target, (value is DBNull) ? null : value.TypeConversionCast(Type));
	}

	internal string FormatValueString(object? value)
	{
		if (Type == typeof(byte[]))
		{
			return ParameterName;
		}
		if (Type.IsEnum)
		{
			return ((int?)value)?.ToString() ?? "null";
		}
		if (value == null || value is DBNull)
		{
			return "NULL";
		}
		if (value is string || value is Guid || value is char)
		{
			return "'" + Convert.ToString(value)?.Replace("'", "''") + "'";
		}
		if (value is DateTime dateTime)
		{
			return "'" + dateTime.ToString("o", CultureInfo.InvariantCulture) + "'";
		}
		return value.ToString() ?? string.Empty;
	}
}
