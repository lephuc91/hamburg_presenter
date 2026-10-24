using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Pro.Common.Collections;

namespace ProPresenter.DO.Settings.GeneralSettings;

public class CCLIReportCollection : ImmutableObservableCollection<CCLIReport>, ICCLIReportCollection, INotifyEnumerableChanged<CCLIReport>, IEnumerable<CCLIReport>, IEnumerable, INotifyCollectionChanged
{
	public event Action? DataModified;

	public CCLIReportCollection()
	{
		base.CollectionChanged += CCLIReportCollection_CollectionChanged;
	}

	private void CCLIReportCollection_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<CCLIReport>().ForEach(delegate(CCLIReport r)
		{
			r.DataModified -= OnDataModified;
		});
		e.NewItems?.OfType<CCLIReport>().ForEach(delegate(CCLIReport r)
		{
			r.DataModified += OnDataModified;
		});
		OnDataModified();
	}

	public CCLIReport Add(CCLIReport report)
	{
		CCLIReport cCLIReport = base.Collection.FirstOrDefault((CCLIReport r) => r.CCLINumber == report.CCLINumber && r.DateUsed.Month == report.DateUsed.Month && r.DateUsed.Day == report.DateUsed.Day && r.DateUsed.Year == report.DateUsed.Year);
		if (cCLIReport != null)
		{
			return cCLIReport;
		}
		base.Collection.Add(report);
		return report;
	}

	public void Clear()
	{
		base.Collection.Clear();
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}
}
