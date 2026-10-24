using System;
using System.Diagnostics.CodeAnalysis;
using Pro.Common.Components.Reversibility;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Links;

public class GroupNameLinkedObject : LinkedTextObjectBase
{
	private GroupSourceType _groupSource;

	public override LinkedTextType LinkedTextType => LinkedTextType.GroupName;

	public GroupSourceType GroupSource
	{
		get
		{
			return _groupSource;
		}
		set
		{
			SetValue("GroupSource", ref _groupSource, value, delegate(GroupSourceType o, GroupSourceType n)
			{
				base.UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.GroupSource), this, "GroupSource", o, n);
				OnDataModified();
			});
		}
	}

	public override string DisplayText => LocalizedStrings.Get(LinkedTextType) + " - " + LocalizedStrings.Get(GroupSource);

	public override FormattingType FormattingType => FormattingType.None;

	public static ObjectBinder<GroupNameLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IGroupName> CreateBinder(GroupNameLinkedObject left, ISlide.Types.IElement.Types.IDataLink.Types.IGroupName right)
	{
		ObjectBinder<GroupNameLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IGroupName> objectBinder = new ObjectBinder<GroupNameLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IGroupName>(left, right);
		objectBinder.Bind((GroupNameLinkedObject l) => l.WhenPropertyChanges("GroupSource"), (ISlide.Types.IElement.Types.IDataLink.Types.IGroupName r) => r.GroupSource.WhenValueChanges, delegate(GroupNameLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.IGroupName r)
		{
			r.GroupSource.Set(l.GroupSource.ToEntityGroupSource());
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IGroupName r, GroupNameLinkedObject l)
		{
			l.GroupSource = r.GroupSource.Value.ToGroupSourceType();
		});
		return objectBinder;
	}

	public GroupNameLinkedObject()
	{
	}

	public GroupNameLinkedObject(GroupSourceType groupSource)
	{
		_groupSource = groupSource;
	}

	public override bool RenderEquals([NotNullWhen(true)] ILinkedTextObject? other)
	{
		if (other is GroupNameLinkedObject groupNameLinkedObject)
		{
			return _groupSource == groupNameLinkedObject._groupSource;
		}
		return false;
	}

	public override int GetRenderHashCode()
	{
		return _groupSource.GetHashCode();
	}

	public override ILinkedTextObject Clone()
	{
		return new GroupNameLinkedObject(_groupSource);
	}

	public override void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink)
	{
		dataLink.GroupName = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.GroupName
		{
			GroupSource = GroupSource.ToProtoGroupSource()
		};
	}

	public static GroupNameLinkedObject Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.GroupName protoGroupName)
	{
		return new GroupNameLinkedObject
		{
			GroupSource = protoGroupName.GroupSource.ToGroupSourceType()
		};
	}

	public override string GetText(ILinkData? linkData)
	{
		if (linkData == null)
		{
			return LocalizedStrings.Get(LinkedTextType);
		}
		return GroupSource switch
		{
			GroupSourceType.CurrentSlide => linkData.GroupInformation?.CurrentSlideGroup?.Label?.Text ?? string.Empty, 
			GroupSourceType.NextSlide => linkData.GroupInformation?.NextSlideGroup?.Label?.Text ?? string.Empty, 
			GroupSourceType.NextGroup => linkData.GroupInformation?.NextArrangementGroup?.Label?.Text ?? string.Empty, 
			_ => throw new NotSupportedException(), 
		};
	}
}
