using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Pro.Serialization.Utility;

namespace Pro.Serialization.DataManagement;

public class XSyncedData<T> : SyncedData<XSyncedData<T>, T> where T : class
{
	private readonly Func<XDocument, bool>? _validator;

	public XSyncedData(string targetDirectory, string targetFilename, Action<T> dataUpdated, Action<DataClearSource> dataCleared, SyncedFileValidateParseDelegate<XSyncedData<T>, T?>? validateParse = null, Func<XDocument, bool>? validator = null)
		: base(targetDirectory, targetFilename, dataUpdated, dataCleared, validateParse)
	{
		_validator = validator;
		ParseFile();
	}

	protected override bool OnTryParseFile(string filename, string fullPath, out T? data)
	{
		return XHelper.TryReadFile<T>(fullPath, out data, _validator);
	}

	protected override void OnWriteFile(string filename, string fullPath, T data)
	{
		XHelper.WriteFile(fullPath, data, _validator);
	}
}
public class XSyncedData<T, I> : SyncedData<XSyncedData<T, I>, T> where T : class, IList, IList<I>
{
	private readonly Func<XDocument, bool>? _validator;

	private readonly Type[]? _knownTypes;

	public XSyncedData(string targetDirectory, string targetFilename, Action<T> dataUpdated, Action<DataClearSource> dataCleared, SyncedFileValidateParseDelegate<XSyncedData<T, I>, T?>? validateParse = null, Func<XDocument, bool>? validator = null, Type[]? knownTypes = null)
		: base(targetDirectory, targetFilename, dataUpdated, dataCleared, validateParse)
	{
		_validator = validator;
		_knownTypes = knownTypes;
		ParseFile();
	}

	protected override bool OnTryParseFile(string filename, string fullPath, out T? data)
	{
		return XHelper.TryReadFile<T, I>(fullPath, out data, _validator, _knownTypes);
	}

	protected override void OnWriteFile(string filename, string fullPath, T data)
	{
		XHelper.WriteFile<T, I>(fullPath, data, _validator);
	}
}
