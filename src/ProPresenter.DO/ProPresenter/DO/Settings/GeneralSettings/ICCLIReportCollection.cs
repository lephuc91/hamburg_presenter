using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Pro.Common.Collections;

namespace ProPresenter.DO.Settings.GeneralSettings;

public interface ICCLIReportCollection : INotifyEnumerableChanged<CCLIReport>, IEnumerable<CCLIReport>, IEnumerable, INotifyCollectionChanged
{
	event Action DataModified;

	CCLIReport Add(CCLIReport report);

	void Clear();
}
