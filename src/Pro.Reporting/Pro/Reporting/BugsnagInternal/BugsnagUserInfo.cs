using System;
using Pro.Common.DataStore;

namespace Pro.Reporting.BugsnagInternal;

public class BugsnagUserInfo : StoreBase, IIdProvider
{
	public Guid Id
	{
		get
		{
			string key = "Id";
			bool usedDefaultValue;
			Guid value = GetValue(key, out usedDefaultValue, Guid.NewGuid());
			if (usedDefaultValue)
			{
				SetValue(key, value);
			}
			return value;
		}
	}

	public BugsnagUserInfo()
		: base(StoreBase.MakeRegistryStorage("HKEY_CURRENT_USER\\Software\\Renewed Vision\\ProPresenter\\Bugsnag.UserInformation"))
	{
		RegisterCustomType((Guid? value) => (!value.HasValue) ? string.Empty : value.Value.ToString(), (string value) => (!string.IsNullOrEmpty(value)) ? new Guid?(Guid.Parse(value)) : ((Guid?)null));
	}
}
