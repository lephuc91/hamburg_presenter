using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Export.Requests;

public class DocumentExportRequest : NotifyPropertyChangedBase, IExportRequest
{
	private string _currentItemName = string.Empty;

	private bool _archiving;

	public int ItemCount { get; private set; }

	public IEnumerable<IPresentation> Documents { get; }

	public DocumentExportOption DocumentExportOption { get; }

	public string CurrentItemName
	{
		get
		{
			return _currentItemName;
		}
		set
		{
			SetValue("CurrentItemName", ref _currentItemName, value);
		}
	}

	public bool Archiving
	{
		get
		{
			return _archiving;
		}
		set
		{
			SetValue("Archiving", ref _archiving, value);
		}
	}

	public DocumentExportRequest(IEnumerable<IPresentation> documents, DocumentExportOption option)
	{
		Documents = documents;
		DocumentExportOption = option;
		documents?.ForEach(delegate(IPresentation d)
		{
			d.FindMedia(delegate
			{
				ItemCount++;
			});
		});
		ItemCount += documents?.Count() ?? 0;
	}
}
