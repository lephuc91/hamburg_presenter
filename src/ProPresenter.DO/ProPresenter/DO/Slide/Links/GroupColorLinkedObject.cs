using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Media;
using Pro.Common.Components.Reversibility;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;

namespace ProPresenter.DO.Slide.Links;

public class GroupColorLinkedObject : LinkedFillObjectBase
{
	private GroupSourceType _groupSource;

	public override LinkedFillType LinkedFillType => LinkedFillType.GroupColor;

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
				base.UndoStack?.Commit(UndoActionTypes.LinkGroupColor.ToAction(), this, "GroupSource", o, n, null, null, autoFinalize: true);
			});
		}
	}

	public override string DisplayText => LocalizedStrings.Get(LinkedFillType) + " - " + LocalizedStrings.Get(GroupSource);

	public static ObjectBinder<GroupColorLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IGroupColor> CreateBinder(GroupColorLinkedObject? left, ISlide.Types.IElement.Types.IDataLink.Types.IGroupColor? right)
	{
		ObjectBinder<GroupColorLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IGroupColor> objectBinder = new ObjectBinder<GroupColorLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IGroupColor>(left, right);
		objectBinder.Bind((GroupColorLinkedObject l) => l.WhenPropertyChanges("GroupSource"), (ISlide.Types.IElement.Types.IDataLink.Types.IGroupColor r) => r.GroupSource.WhenValueChanges, delegate(GroupColorLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.IGroupColor r)
		{
			r.GroupSource.Set(l.GroupSource.ToEntityGroupSource());
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IGroupColor r, GroupColorLinkedObject l)
		{
			l.GroupSource = r.GroupSource.Value.ToGroupSourceType();
		});
		return objectBinder;
	}

	public GroupColorLinkedObject()
	{
	}

	public GroupColorLinkedObject(GroupSourceType groupSource)
	{
		_groupSource = groupSource;
	}

	public override bool RenderEquals([NotNullWhen(true)] ILinkedFillObject? other)
	{
		if (other is GroupColorLinkedObject groupColorLinkedObject)
		{
			return GroupSource == groupColorLinkedObject.GroupSource;
		}
		return false;
	}

	public override int GetRenderHashCode()
	{
		return GroupSource.GetHashCode();
	}

	public override IFill GetFill(ILinkData? linkData)
	{
		return new SolidColorFill
		{
			Color = (getColor() ?? Colors.Transparent)
		};
		System.Windows.Media.Color? getColor()
		{
			return GroupSource switch
			{
				GroupSourceType.CurrentSlide => linkData?.GroupInformation?.CurrentSlideGroup?.Label?.Color, 
				GroupSourceType.NextSlide => linkData?.GroupInformation?.NextSlideGroup?.Label?.Color, 
				GroupSourceType.NextGroup => linkData?.GroupInformation?.NextArrangementGroup?.Label?.Color, 
				_ => throw new NotSupportedException(), 
			};
		}
	}

	public override ILinkedFillObject Clone()
	{
		return new GroupColorLinkedObject(_groupSource);
	}

	public override void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink)
	{
		dataLink.GroupColor = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.GroupColor
		{
			GroupSource = GroupSource.ToProtoGroupSource()
		};
	}

	public static GroupColorLinkedObject Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.GroupColor protoGroupName)
	{
		return new GroupColorLinkedObject(protoGroupName.GroupSource.ToGroupSourceType());
	}
}
