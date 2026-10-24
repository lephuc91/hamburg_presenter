using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.Mathematics;
using Pro.UI;
using Pro.UI.Controls;
using ProPresenter.DO.Cues;
using ProPresenter.DO.MultiTracks;
using ProPresenter.DO.SongSelect;
using ProPresenter.UI.ViewModels.QuickSearch;

namespace ProPresenter.UI.Search;

internal class ItemListBox : DragDropListBox<object>
{
	private sealed class SearchItemTemplateSelector : DataTemplateSelector
	{
		public override DataTemplate SelectTemplate(object? item, DependencyObject container)
		{
			if (!(item is DocumentCue))
			{
				if (!(item is SongSelectSearchResult))
				{
					if (item is MultiTracksSearchResult)
					{
						return findTemplate("MultiTracksTemplate");
					}
					return base.SelectTemplate(item, container) ?? throw new ArgumentNullException();
				}
				return findTemplate("SongSelectTemplate");
			}
			return findTemplate("CueTemplate");
			DataTemplate findTemplate(string key)
			{
				return (DataTemplate)((FrameworkElement)(object)container).FindResource(key);
			}
		}
	}

	protected override IDragDropCollection<object>? SourceCollection => null;

	public ItemListBox()
	{
		base.ItemTemplateSelector = new SearchItemTemplateSelector();
	}

	protected override bool CanDrag()
	{
		return (base.DataContext as IQuickSearchVM)?.ActivePage?.CanDrag == true;
	}

	protected override void StartDrag(IEnumerable<object> items, Visual dragVisual, DragDropEffects effects, Vector2<double> offset)
	{
		object obj = items.FirstOrDefault();
		if (!(obj is ProPresenterCue))
		{
			if (!(obj is ISongSelectSearchResult))
			{
				if (obj is IMultiTracksSearchResult)
				{
					doDrag<IMultiTracksSearchResult>();
				}
			}
			else
			{
				doDrag<ISongSelectSearchResult>();
			}
		}
		else
		{
			doDrag<ProPresenterCue>();
		}
		void doDrag<T>()
		{
			base.DragSource.StartDrag(new DraggedItems<T>(null, items.Cast<T>().ToArray()), dragVisual, effects, offset);
		}
	}
}
