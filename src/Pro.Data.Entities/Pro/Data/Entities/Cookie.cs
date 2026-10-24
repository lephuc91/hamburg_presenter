using System;
using Pro.Data.SQLite;

namespace Pro.Data.Entities;

[Table("Cookies")]
public class Cookie : EntityBase<Cookie>
{
	private string _domain;

	private DateTime _expiration;

	private string _name;

	private string _value;

	public string Domain
	{
		get
		{
			return _domain;
		}
		set
		{
			SetValue("Domain", ref _domain, value);
		}
	}

	public DateTime Expiration
	{
		get
		{
			return _expiration;
		}
		set
		{
			SetValue("Expiration", ref _expiration, value);
		}
	}

	[Ignore]
	public bool IsExpired
	{
		get
		{
			if (!string.IsNullOrEmpty(Value))
			{
				return DateTime.UtcNow > Expiration;
			}
			return false;
		}
	}

	public string Name
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

	public string Value
	{
		get
		{
			return _value;
		}
		set
		{
			SetValue("Value", ref _value, value);
		}
	}

	public Cookie()
	{
		_name = string.Empty;
		_domain = string.Empty;
		_value = string.Empty;
	}

	public Cookie(string name, string value, string domain, DateTime expiration)
	{
		_name = name;
		_value = value;
		_domain = domain;
		_expiration = expiration;
	}
}
