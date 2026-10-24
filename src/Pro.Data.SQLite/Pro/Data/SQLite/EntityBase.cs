using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Pro.Common;
using Pro.Common.Components;
using Pro.Common.Extensions;

namespace Pro.Data.SQLite;

public abstract class EntityBase : NotifyPropertyChangedBase, IComparable, ICloneable
{
	public const uint DEFAULT_VERSION = 0u;

	private static readonly ConcurrentDictionary<Type, ConcurrentBag<string>> IGNORED_PROPERTIES = new ConcurrentDictionary<Type, ConcurrentBag<string>>();

	private readonly Type _type;

	private IDatabase? _database;

	private Guid _primaryKey;

	private uint _version;

	[Ignore]
	public IDatabase? Database
	{
		get
		{
			return _database;
		}
		set
		{
			SetValue("Database", ref _database, value, OnDatabaseChanged);
		}
	}

	[PrimaryKey]
	[Unique]
	[NotNull]
	public Guid PrimaryKey
	{
		get
		{
			return _primaryKey;
		}
		set
		{
			SetValue("PrimaryKey", ref _primaryKey, value);
		}
	}

	[ColumnOrder(10000)]
	public uint Version
	{
		get
		{
			return _version;
		}
		set
		{
			SetValue("Version", ref _version, value);
		}
	}

	protected EntityBase()
	{
		_type = GetType();
		IGNORED_PROPERTIES.TryAdd(_type, new ConcurrentBag<string>());
		InitializeIgnoredProperties();
		PrimaryKey = Guid.NewGuid();
		Version = 0u;
	}

	protected EntityBase(IDatabase database)
		: this()
	{
		Database = database;
	}

	public virtual int CompareTo(object? target)
	{
		if (!(target is EntityBase entityBase))
		{
			return -1;
		}
		if (this == entityBase)
		{
			return 0;
		}
		if (PrimaryKey.Equals(entityBase.PrimaryKey))
		{
			return 0;
		}
		return 1;
	}

	public virtual bool Delete()
	{
		if (Database == null)
		{
			throw new DatabaseException("The database associated with the entity can not be null when performing the the Delete operation.");
		}
		return Database.Delete(this) > 0;
	}

	public override bool Equals(object? obj)
	{
		return CompareTo(obj) == 0;
	}

	public override int GetHashCode()
	{
		return PrimaryKey.ToByteArray().Aggregate(17, (int current, byte b) => current * 31 + b.GetHashCode());
	}

	public static string? GetTableName<TEntity>()
	{
		return typeof(TEntity).GetCustomAttribute<TableAttribute>()?.TableName;
	}

	public virtual bool Save()
	{
		if (Database == null)
		{
			throw new DatabaseException("The database associated with the entity can not be null when performing the the Save operation.");
		}
		return Database.InsertOrUpdate(this) > 0;
	}

	public virtual bool Save(IDatabase database)
	{
		if (database == null)
		{
			throw new DatabaseException("The database associated with the entity can not be null when performing the the Save operation.");
		}
		if (Database == null)
		{
			Database = database;
		}
		return database.InsertOrUpdate(this) > 0;
	}

	protected virtual void OnDatabaseChanged(IDatabase oldValue, IDatabase newValue)
	{
	}

	internal virtual object CloneBase()
	{
		return this.DeepCopy();
	}

	object ICloneable.Clone()
	{
		return CloneBase();
	}

	private void InitializeIgnoredProperties()
	{
		PropertyInfo[] properties = _type.GetProperties(BindingFlags.Public);
		foreach (PropertyInfo propertyInfo in properties)
		{
			if (!IGNORED_PROPERTIES[_type].Contains(propertyInfo.Name) && _type.GetProperty(propertyInfo.Name)?.GetCustomAttribute<IgnoreAttribute>() != null && !IGNORED_PROPERTIES[_type].Contains(propertyInfo.Name))
			{
				IGNORED_PROPERTIES[_type].Add(propertyInfo.Name);
			}
		}
	}
}
public abstract class EntityBase<TEntity> : EntityBase, ICloneable<TEntity>, ISynchronizable<TEntity> where TEntity : EntityBase
{
	protected EntityBase()
	{
	}

	protected EntityBase(IDatabase database)
		: base(database)
	{
	}

	public TEntity Clone()
	{
		return (TEntity)CloneBase();
	}

	public static IEnumerable<TEntity> Query(IDatabase database)
	{
		return database.Select<TEntity>();
	}

	public static TEntity? Query(IDatabase database, Guid primaryKey)
	{
		QueryBuilder<TEntity> queryBuilder = new QueryBuilder<TEntity>(database);
		queryBuilder.Select();
		queryBuilder.Where((TEntity e) => e.PrimaryKey == primaryKey);
		return queryBuilder.ExecuteQuery().FirstOrDefault();
	}

	public void Reset()
	{
		IDatabase database = base.Database;
		if (database != null)
		{
			TEntity source = Query(database, base.PrimaryKey);
			SynchronizeFrom(source);
		}
	}

	public virtual void SynchronizeFrom(TEntity? source)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (!source.PrimaryKey.Equals(base.PrimaryKey))
		{
			throw new DatabaseException("The primary keys of the target and source entities must match.");
		}
	}

	public virtual void SynchronizeTo(TEntity target)
	{
		if (target == null)
		{
			throw new ArgumentNullException("target");
		}
		if (!target.PrimaryKey.Equals(base.PrimaryKey))
		{
			throw new DatabaseException("The primary keys of the target and source entities must match.");
		}
	}
}
