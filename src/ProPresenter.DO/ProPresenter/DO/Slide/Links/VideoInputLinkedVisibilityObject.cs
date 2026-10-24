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

public class VideoInputLinkedVisibilityObject : NotifyPropertyChangedBase, ILinkedVisibilityObject, ILinkedObject, IRenderEquatable<ILinkedVisibilityObject>, IRenderHashable, ICloneable<ILinkedVisibilityObject>, INotifyPropertyChanged
{
	private int _videoInputIndex;

	private VideoInputVisibilityCriteria _selectedCriterion;

	public VisibilityLinkType Type => VisibilityLinkType.VideoInput;

	public string Content => LocalizedStrings.Get("VISIBILITY_LINK_VIDEO_INPUT_title");

	public UndoStack? UndoStack { get; set; }

	public string DisplayText => string.Empty;

	public int VideoInputIndex
	{
		get
		{
			return _videoInputIndex;
		}
		set
		{
			SetValue("VideoInputIndex", ref _videoInputIndex, value, delegate(int o, int n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.VisibilityLinkChangeVideoInputIndex), this, "VideoInputIndex", o, n);
				OnDataModified();
			});
		}
	}

	public VideoInputVisibilityCriteria SelectedCriterion
	{
		get
		{
			return _selectedCriterion;
		}
		set
		{
			SetValue("SelectedCriterion", ref _selectedCriterion, value, delegate(VideoInputVisibilityCriteria o, VideoInputVisibilityCriteria n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.VisibilityLinkChangeVideoInputCriterion), this, "SelectedCriterion", o, n);
				OnDataModified();
			});
		}
	}

	public event System.Action? DataModified;

	public static ObjectBinder<VideoInputLinkedVisibilityObject, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoInputVisibility> CreateBinder(VideoInputLinkedVisibilityObject left, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoInputVisibility right)
	{
		ObjectBinder<VideoInputLinkedVisibilityObject, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoInputVisibility> objectBinder = new ObjectBinder<VideoInputLinkedVisibilityObject, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoInputVisibility>(left, right);
		objectBinder.Bind((VideoInputLinkedVisibilityObject l) => l.WhenPropertyChanges("SelectedCriterion"), (ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoInputVisibility r) => r.VisibilityCriterion.WhenValueChanges, delegate(VideoInputLinkedVisibilityObject l, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoInputVisibility r)
		{
			r.VisibilityCriterion.Set(l.SelectedCriterion.ToEntityVideoInputVisibilityCriterion());
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoInputVisibility r, VideoInputLinkedVisibilityObject l)
		{
			l.SelectedCriterion = r.VisibilityCriterion.Value.ToVideoInputVisibilityCriteria();
		}).Bind((VideoInputLinkedVisibilityObject l) => l.WhenPropertyChanges("VideoInputIndex"), (ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoInputVisibility r) => r.VideoInputIndex.WhenValueChanges, delegate(VideoInputLinkedVisibilityObject l, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoInputVisibility r)
		{
			r.VideoInputIndex.Set(l.VideoInputIndex);
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IVideoInputVisibility r, VideoInputLinkedVisibilityObject l)
		{
			l.VideoInputIndex = r.VideoInputIndex.Value;
		});
		return objectBinder;
	}

	public bool RenderEquals([NotNullWhen(true)] ILinkedVisibilityObject? other)
	{
		if (other is VideoInputLinkedVisibilityObject videoInputLinkedVisibilityObject && _videoInputIndex == videoInputLinkedVisibilityObject._videoInputIndex)
		{
			return _selectedCriterion == videoInputLinkedVisibilityObject._selectedCriterion;
		}
		return false;
	}

	public int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(_videoInputIndex, _selectedCriterion);
	}

	public ILinkedVisibilityObject Clone()
	{
		return new VideoInputLinkedVisibilityObject
		{
			VideoInputIndex = VideoInputIndex,
			SelectedCriterion = SelectedCriterion
		};
	}

	public void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition protoVisibilityLinkCondition)
	{
		protoVisibilityLinkCondition.VideoInputVisibility = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.VideoInputVisibility
		{
			VideoInputIndex = VideoInputIndex,
			VisibilityCriterion = SelectedCriterion.ToProtoVideoInputVisibilityCriteria()
		};
	}

	public static VideoInputLinkedVisibilityObject Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.VideoInputVisibility protoVideoInputVisibility)
	{
		return new VideoInputLinkedVisibilityObject
		{
			VideoInputIndex = protoVideoInputVisibility.VideoInputIndex,
			SelectedCriterion = protoVideoInputVisibility.VisibilityCriterion.ToVideoInputVisibilityCriteria()
		};
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}
}
