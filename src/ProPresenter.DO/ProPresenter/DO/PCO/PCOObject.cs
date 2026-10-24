using System;
using System.Collections.Generic;
using Pro.Common.Components;

namespace ProPresenter.DO.PCO;

public abstract class PCOObject : NotifyPropertyChangedBase
{
	private const string LinkContentToken = "data.links";

	private string? _name;

	private bool _isExpanded;

	private string? _id;

	public string? ID
	{
		get
		{
			return _id;
		}
		protected set
		{
			SetValue("ID", ref _id, value);
		}
	}

	public string? Name
	{
		get
		{
			return _name;
		}
		set
		{
			SetValue("Name", ref _name, value);
		}
	}

	public bool IsExpanded
	{
		get
		{
			return _isExpanded;
		}
		set
		{
			SetValue("IsExpanded", ref _isExpanded, value);
		}
	}

	protected IReadOnlyDictionary<string, Uri> ContentLinks { get; }

	protected PCOObject(string? id, string? name, IReadOnlyDictionary<string, Uri>? links = null)
	{
		ID = id;
		_name = name;
		ContentLinks = links ?? new Dictionary<string, Uri>();
	}
}
