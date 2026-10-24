using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.CCLI;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Themes;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.DO.Presentation;

public interface ICCLIPresentation : INotifyPropertyChanged, INotifyEnumerableChanged<TemplateSlide>, IEnumerable<TemplateSlide>, IEnumerable, INotifyCollectionChanged, IDocumentProvider
{
	bool Display { get; set; }

	CCLIDisplayType DisplayType { get; set; }

	string License { get; set; }

	UndoStack UndoStack { get; }

	ICCLILayoutData Layout { get; }

	CCLIDocument Serialize();
}
