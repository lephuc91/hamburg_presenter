using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.DO.Application;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Cues;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Slide;

namespace ProPresenter.DO.Arrangements;

public class CueCollection : ImmutableObservableCollection<SlideCue>
{
	private readonly IPresentation _presentation;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	public event Action<CueCollection>? DataModified;

	public CueCollection(IPresentation presentation, IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions)
	{
		_presentation = presentation;
		_factoryProvider = factoryProvider;
		_transitionDescriptions = transitionDescriptions;
	}

	public void AddCue(SlideBase slide)
	{
		AddCue(new SlideCue(_factoryProvider, slide, _transitionDescriptions));
	}

	public void AddCue(SlideCue cue)
	{
		AddCues(new global::_003C_003Ez__ReadOnlySingleElementList<SlideCue>(cue));
	}

	public void AddCues(IEnumerable<SlideCue> cues)
	{
		InsertCues(base.Count, cues);
	}

	public void InsertCue(int index, SlideCue cue)
	{
		InsertCues(index, new global::_003C_003Ez__ReadOnlySingleElementList<SlideCue>(cue));
	}

	public void InsertCues(int index, IEnumerable<SlideCue> cues, bool isReversible = true)
	{
		OnInsertCues(index, cues, isReversible);
	}

	public void RemoveCue(SlideCue cue)
	{
		RemoveCues(new global::_003C_003Ez__ReadOnlySingleElementList<SlideCue>(cue));
	}

	public void RemoveCues(IEnumerable<SlideCue> cues)
	{
		OnRemoveCues(cues, isReversible: true);
	}

	public void Clear()
	{
		RemoveCues(base.Collection);
	}

	public void Move(int fromIndex, int toIndex)
	{
		base.Collection.Move(fromIndex, toIndex);
		OnDataModified();
	}

	private void OnInsertCues(int index, IEnumerable<SlideCue> slides, bool isReversible)
	{
		index = base.Collection.ClampIndexExclusive(index);
		insert();
		if (isReversible)
		{
			_presentation.UndoStack.Commit(UndoActionTypes.AddSlide.ToAction(), remove, insert);
		}
		OnDataModified();
		void insert()
		{
			slides.ForEach(SetupCue);
			base.Collection.InsertRange(index, slides);
		}
		void remove()
		{
			slides.ForEach(TearDownCue);
			if (base.Collection.Any())
			{
				base.Collection.RemoveAtRange(index, slides.Count());
			}
		}
	}

	private void OnRemoveCues(IEnumerable<SlideCue> cues, bool isReversible)
	{
		KeyValuePair<int, SlideCue>[] indices = (from i in cues.ToDictionary((SlideCue s) => base.Collection.IndexOf(s), (SlideCue s) => s)
			orderby i.Key
			select i).ToArray();
		if (indices.Any((KeyValuePair<int, SlideCue> i) => i.Key < 0))
		{
			throw new InvalidOperationException("Collection does not contain one or more slides");
		}
		remove();
		if (isReversible)
		{
			_presentation.UndoStack.Commit(UndoActionTypes.RemoveSlides.ToAction(), insert, remove);
		}
		OnDataModified();
		void insert()
		{
			KeyValuePair<int, SlideCue>[] array = indices;
			for (int j = 0; j < array.Length; j++)
			{
				KeyValuePair<int, SlideCue> keyValuePair2 = array[j];
				var (index2, cue2) = (KeyValuePair<int, SlideCue>)(ref keyValuePair2);
				InsertCue(index2, cue2);
			}
		}
		void remove()
		{
			foreach (var (index, cue) in indices.Reverse())
			{
				base.Collection.RemoveAt(index);
				TearDownCue(cue);
			}
		}
	}

	private void SetupCue(SlideCue cue)
	{
		cue.DataModified += CueChanged;
		cue.UndoStack = _presentation.UndoStack;
		cue.SetParentPresentation(_presentation);
	}

	private void TearDownCue(SlideCue cue)
	{
		cue.DataModified -= CueChanged;
		cue.UndoStack = null;
		cue.ClearParentPresentation();
	}

	private void CueChanged(Pro.DO.Triggering.Cue cue)
	{
		OnDataModified();
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke(this);
	}

	public void Deserialize(IEnumerable<Pro.SerializationInterop.RVProtoData.Cue> data, ApplicationData? applicationData, string containerId)
	{
		base.Collection.DeserializeCollection(data, delegate(SlideCue c, Pro.SerializationInterop.RVProtoData.Cue p)
		{
			Guid iD = c.ID;
			Guid? obj = p.Uuid?.ToGuid();
			return iD == obj;
		}, (Pro.SerializationInterop.RVProtoData.Cue p) => new SlideCue(_factoryProvider), delegate
		{
		}, RemoveCue, delegate(SlideCue c, Pro.SerializationInterop.RVProtoData.Cue p)
		{
			c.DataModified -= CueChanged;
			c.UpdateContainerId(containerId);
			c.ProtoDeserialize(p, applicationData, containerId);
			c.DataModified += CueChanged;
			if (!base.Collection.Contains(c))
			{
				AddCue(c);
			}
		});
	}
}
