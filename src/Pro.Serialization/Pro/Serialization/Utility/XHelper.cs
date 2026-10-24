using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml.Linq;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Common.Nullability;
using Pro.Serialization.XSerialization;

namespace Pro.Serialization.Utility;

public static class XHelper
{
	public static T? ReadFile<T>(string file, Func<XDocument, bool>? validator = null)
	{
		if ((bool)TryReadFile<T>(file, out T data, validator))
		{
			return data;
		}
		throw new Exception("Failed to load the file");
	}

	public static FileIOResult TryReadFile<T>(string file, out T? data, Func<XDocument, bool>? validator = null)
	{
		FileIOResult fileIOResult = FileHelper.WaitForFileAccess(file, enforceFileExists: true, null);
		if (!fileIOResult)
		{
			data = default(T);
			Log.Warning($"Failed to gain read access to file [{file}]");
			return fileIOResult;
		}
		data = default(T);
		try
		{
			XDocument xDocument = XDocument.Load(file);
			if (validator != null && !validator(xDocument))
			{
				return FileIOResult.InvalidOperation(file);
			}
			(xDocument?.Root).ThrowWhenNull("document?.Root");
			data = Deserializer.DeserializeNode<T>(xDocument.Root, GetRootNamespace(xDocument));
			Log.Info($"Opened [{file}]");
			return FileIOResult.Success();
		}
		catch (Exception ex)
		{
			Log.Error(ex.ToString());
			return FileIOResult.Exception(file, ex);
		}
	}

	public static T? ReadRawData<T>(string rawData, Func<XDocument, bool>? validator = null)
	{
		if (TryReadRawData<T>(rawData, out T data, validator))
		{
			return data;
		}
		throw new Exception("Failed to read the data");
	}

	public static bool TryReadRawData<T>(string rawData, out T? data, Func<XDocument, bool>? validator = null)
	{
		XDocument xDocument = XDocument.Parse(rawData);
		if (validator != null && !validator(xDocument))
		{
			data = default(T);
			return false;
		}
		if (xDocument.Root != null)
		{
			data = Deserializer.DeserializeNode<T>(xDocument.Root, GetRootNamespace(xDocument));
			return true;
		}
		data = default(T);
		return false;
	}

	public static FileIOResult WriteFile<T>(string file, T data, Func<XDocument, bool>? validator = null)
	{
		FileIOResult fileIOResult = FileHelper.WaitForFileAccess(file, enforceFileExists: false, null);
		if (!fileIOResult)
		{
			Log.Warning($"Failed to gain write access to file [{file}]");
			return fileIOResult;
		}
		XDocument xDocument = new XDocument(Serializer.SerializeNode(data));
		if (validator != null && !validator(xDocument))
		{
			return FileIOResult.InvalidArgument(file);
		}
		SaveOptions options = SaveOptions.DisableFormatting;
		xDocument.Save(file, options);
		Log.Info($"Saved [{file}]");
		return FileIOResult.Success();
	}

	public static T? ReadFile<T, I>(string file, Func<XDocument, bool>? validator = null, Type[]? subTypes = null) where T : IList<I>
	{
		if (TryReadFile<T, I>(file, out T data, validator, subTypes))
		{
			return data;
		}
		throw new Exception("Failed to load the file");
	}

	public static bool TryReadFile<T, I>(string file, [NotNullWhen(true)] out T? data, Func<XDocument, bool>? validator = null, Type[]? subTypes = null) where T : IList<I>
	{
		if (!FileHelper.WaitForFileAccess(file, enforceFileExists: true, null))
		{
			data = default(T);
			Log.Warning($"Failed to gain read access to file [{file}]");
			return false;
		}
		XDocument xDocument = XDocument.Load(file);
		if (validator != null && !validator(xDocument))
		{
			data = default(T);
			return false;
		}
		if (xDocument.Root == null)
		{
			data = default(T);
			return false;
		}
		data = Deserializer.DeserializeArrayNode<T, I>(xDocument.Root, GetRootNamespace(xDocument), subTypes);
		Log.Info($"Opened [{file}]");
		return true;
	}

	public static void WriteFile<T, I>(string file, T data, Func<XDocument, bool>? validator = null) where T : IList, IList<I>
	{
		if (!FileHelper.WaitForFileAccess(file, enforceFileExists: false, null))
		{
			Log.Warning($"Failed to gain write access to file [{file}]");
			return;
		}
		XDocument xDocument = new XDocument(Serializer.SerializeArrayNode(data));
		if (validator != null && !validator(xDocument))
		{
			throw new Exception("Serialized data is not valid");
		}
		SaveOptions options = SaveOptions.DisableFormatting;
		xDocument.Save(file, options);
		Log.Info($"Saved [{file}]");
	}

	private static string GetRootNamespace(XDocument document)
	{
		return document.Root?.Attributes().FirstOrDefault((XAttribute a) => a.IsNamespaceDeclaration)?.Value ?? string.Empty;
	}
}
