using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Links;

public class VideoCountdownLinkedVisibilityObject : NotifyPropertyChangedBase, ILinkedVisibilityObject, ILinkedObject, IRenderEquatable<ILinkedVisibilityObject>, IRenderHashable, ICloneable<ILinkedVisibilityObject>, INotifyPropertyChanged
{
	private VideoCountdownVisibilityCriteria _selectedCriterion;

	public VisibilityLinkType Type => VisibilityLinkType.VideoCountdown;

	public string DisplayText => string.Empty;

	public string Content => LocalizedStrings.Get("TEXT_LINK_VIDEO_COUNTDOWN_title");

	public UndoStack? UndoStack { get; set; }

	public VideoCountdownVisibilityCriteria SelectedCriterion
	{
		get
		{
			return _selectedCriterion;
		}
		set
		{
			SetValue("SelectedCriterion", ref _selectedCriterion, value, delegate(VideoCountdownVisibilityCriteria o, VideoCountdownVisibilityCriteria n)
			{
				UndoStack?.Commit(UndoActionTypes.VisibilityLinkChangeTimerCondition.ToAction(), this, "SelectedCriterion", o, n, null, null, autoFinalize: true);
				OnDataModified();
			});
		}
	}

	public event System.Action? DataModified;

	public static ObjectBinder<VideoCountdownLinkedVisibilityObject, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoCountdownVisibility> CreateBinder(VideoCountdownLinkedVisibilityObject left, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoCountdownVisibility right)
	{
		ObjectBinder<VideoCountdownLinkedVisibilityObject, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoCountdownVisibility> objectBinder = new ObjectBinder<VideoCountdownLinkedVisibilityObject, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoCountdownVisibility>(left, right);
		objectBinder.Bind((VideoCountdownLinkedVisibilityObject l) => l.WhenPropertyChanges("SelectedCriterion"), (ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoCountdownVisibility r) => r.VisibilityCriterion.WhenValueChanges, delegate(VideoCountdownLinkedVisibilityObject l, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoCountdownVisibility r)
		{
			r.VisibilityCriterion.Set(l.SelectedCriterion.ToEntityVideoCountdownVisibilityCriterion());
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoCountdownVisibility r, VideoCountdownLinkedVisibilityObject l)
		{
			l.SelectedCriterion = r.VisibilityCriterion.Value.ToVideoCountdownVisibilityCriteria();
		});
		return objectBinder;
	}

	public bool RenderEquals([NotNullWhen(true)] ILinkedVisibilityObject? other)
	{
		if (other is VideoCountdownLinkedVisibilityObject videoCountdownLinkedVisibilityObject)
		{
			return _selectedCriterion == videoCountdownLinkedVisibilityObject._selectedCriterion;
		}
		return false;
	}

	public int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(_selectedCriterion);
	}

	public ILinkedVisibilityObject Clone()
	{
		return new VideoCountdownLinkedVisibilityObject
		{
			SelectedCriterion = SelectedCriterion
		};
	}

	public void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition protoVisibilityLinkCondition)
	{
		protoVisibilityLinkCondition.VideoCountdownVisibility = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.VideoCountdownVisibility
		{
			VisibilityCriterion = SelectedCriterion.ToProtoVideoCountdownVisibilityCriterion()
		};
	}

	public static VideoCountdownLinkedVisibilityObject Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.VideoCountdownVisibility protoVideoCountdownVisibility)
	{
		return new VideoCountdownLinkedVisibilityObject
		{
			SelectedCriterion = protoVideoCountdownVisibility.VisibilityCriterion.ToVideoCountdownVisibilityCriteria()
		};
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}
}
