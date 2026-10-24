using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Pro.Common.Dispatcher;
using Pro.Common.Nullability;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Props;

namespace ProPresenter.Controller.NetworkAPI;

public static class PropHandler
{
	[CompilerGenerated]
	private sealed class _003CProtoProps_003Ed__14 : IEnumerable<API_v1_PropData>, IEnumerable, IEnumerator<API_v1_PropData>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private API_v1_PropData _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IEnumerable<IPropCue> props;

		public IEnumerable<IPropCue> _003C_003E3__props;

		private uint _003Cindex_003E5__2;

		private IEnumerator<IPropCue> _003C_003E7__wrap2;

		API_v1_PropData IEnumerator<API_v1_PropData>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CProtoProps_003Ed__14(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003C_003E7__wrap2 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			try
			{
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003Cindex_003E5__2 = 0u;
					if (props == null)
					{
						return false;
					}
					_003C_003E7__wrap2 = props.GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					break;
				}
				if (_003C_003E7__wrap2.MoveNext())
				{
					IPropCue current = _003C_003E7__wrap2.Current;
					_003C_003E2__current = ProtoProp(new Identification(current.ID, current.Name, _003Cindex_003E5__2++), current.SlideAction?.AutoClearDuration ?? 0.0, current.SlideAction?.AutoClearEnabled ?? false);
					_003C_003E1__state = 1;
					return true;
				}
				_003C_003Em__Finally1();
				_003C_003E7__wrap2 = null;
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			_003C_003E1__state = -1;
			if (_003C_003E7__wrap2 != null)
			{
				_003C_003E7__wrap2.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<API_v1_PropData> IEnumerable<API_v1_PropData>.GetEnumerator()
		{
			_003CProtoProps_003Ed__14 _003CProtoProps_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CProtoProps_003Ed__ = this;
			}
			else
			{
				_003CProtoProps_003Ed__ = new _003CProtoProps_003Ed__14(0);
			}
			_003CProtoProps_003Ed__.props = _003C_003E3__props;
			return _003CProtoProps_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<API_v1_PropData>)this).GetEnumerator();
		}
	}

	public static NetworkAPI_v1 Handle(IPropSource props, ITriggering triggering, IUiDispatcher dispatcher, API_v1_Prop_Request request)
	{
		if (request != null)
		{
			if (request.Props != null)
			{
				return Props(props, triggering.ActiveProps);
			}
			API_v1_Prop_Request.Types.GetProp getProp = request.GetProp;
			if (getProp != null)
			{
				return Prop(props, getProp.Id, triggering.ActiveProps);
			}
			API_v1_Prop_Request.Types.DeleteProp deleteProp = request.DeleteProp;
			if (deleteProp != null)
			{
				return Delete(props, deleteProp.Id, dispatcher);
			}
			API_v1_Prop_Request.Types.TriggerProp triggerProp = request.TriggerProp;
			if (triggerProp != null)
			{
				return Trigger(props, triggering, triggerProp.Id);
			}
			API_v1_Prop_Request.Types.ClearProp clearProp = request.ClearProp;
			if (clearProp != null)
			{
				return Clear(props, triggering, clearProp.Id);
			}
			API_v1_Prop_Request.Types.GetThumbnail getThumbnail = request.GetThumbnail;
			if (getThumbnail != null)
			{
				return GetThumbnail(props, getThumbnail.Id, getThumbnail.Quality);
			}
			API_v1_Prop_Request.Types.PutProp putProp = request.PutProp;
			if (putProp != null)
			{
				return PutProp(props, dispatcher, putProp);
			}
			API_v1_Prop_Request.Types.PutPropCollection putPropCollection = request.PutPropCollection;
			if (putPropCollection != null)
			{
				return PutPropCollection(props, dispatcher, putPropCollection);
			}
			API_v1_Prop_Request.Types.PostPropCollections postPropCollections = request.PostPropCollections;
			if (postPropCollections != null)
			{
				return PostPropCollection(props, dispatcher, postPropCollections);
			}
			API_v1_Prop_Request.Types.DeletePropCollection deletePropCollection = request.DeletePropCollection;
			if (deletePropCollection != null)
			{
				return DeleteCollection(props, dispatcher, deletePropCollection);
			}
		}
		global::_003CPrivateImplementationDetails_003E.ThrowSwitchExpressionException(request);
		NetworkAPI_v1 result = default(NetworkAPI_v1);
		return result;
	}

	public static NetworkAPI_v1 Props(IPropSource props, IEnumerable<IPropCue> activeProps)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			NetworkAPI_v1.Types.Action action = v1.Action();
			action.UpdateIdentifier = "/v1/props";
			action.PropResponse().Props = new API_v1_Prop_Response.Types.Props
			{
				Props_ = { props.FlatCollection.Select((IPropCue c, int index) => new API_v1_PropData
				{
					Id = Common.ID(c, (uint)index),
					IsActive = activeProps.Contains(c)
				}) }
			};
		});
	}

	private static NetworkAPI_v1 Prop(IPropSource props, string id, IEnumerable<IPropCue> activeProps)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (Common.TryFindItem(props.FlatCollection, id, out ItemPacket<IPropCue> packet))
			{
				v1.Action().PropResponse().GetProp = new API_v1_Prop_Response.Types.GetProp
				{
					Prop = new API_v1_PropData
					{
						Id = Common.ID(packet),
						IsActive = activeProps.Contains<IPropCue>(props.FlatCollection.ElementAtOrDefault((int)packet.Index))
					}
				};
			}
			else
			{
				v1.Action().NotFound();
			}
		});
	}

	private static NetworkAPI_v1 Delete(IPropSource props, string id, IUiDispatcher dispatcher)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (Common.TryFindItem(props.FlatCollection, id, out ItemPacket<IPropCue> prop))
			{
				dispatcher.Invoke(delegate
				{
					props.RemoveProp(prop.Item);
				});
				v1.Action().PropResponse().DeleteProp = new API_v1_Prop_Response.Types.DeleteProp();
			}
			else
			{
				v1.Action().NotFound();
			}
		});
	}

	private static NetworkAPI_v1 Trigger(IPropSource props, ITriggering triggering, string id)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (Common.TryFindItem(props.FlatCollection, id, out ItemPacket<IPropCue> packet))
			{
				IPropCue item = packet.Item;
				if (!triggering.ActiveProps.Contains(item))
				{
					item.ThrowWhenNull("cue");
					triggering.TriggerProp(item);
				}
				v1.Action().PropResponse().TriggerProp = new API_v1_Prop_Response.Types.TriggerProp();
			}
			else
			{
				v1.Action().NotFound();
			}
		});
	}

	private static NetworkAPI_v1 Clear(IPropSource props, ITriggering triggering, string id)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (Common.TryFindItem(props.FlatCollection, id, out ItemPacket<IPropCue> packet))
			{
				triggering.ClearProp(packet.Item);
				v1.Action().PropResponse().ClearProp = new API_v1_Prop_Response.Types.ClearProp();
			}
			else
			{
				v1.Action().NotFound();
			}
		});
	}

	private static NetworkAPI_v1 GetThumbnail(IPropSource props, string id, int quality)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (Common.TryFindItem(props.FlatCollection, id, out ItemPacket<IPropCue> packet))
			{
				v1.Action().PropResponse().GetThumbnail = new API_v1_Prop_Response.Types.GetThumbnail
				{
					Data = packet.Item.SlideAction.GetThumbnail(null, quality)
				};
			}
			else
			{
				v1.Action().NotFound();
			}
		});
	}

	private static API_v1_Prop_Response PropResponse(this NetworkAPI_v1.Types.Action action)
	{
		return action.PropResponse = new API_v1_Prop_Response();
	}

	private static NetworkAPI_v1 PutProp(IPropSource propSource, IUiDispatcher dispatcher, API_v1_Prop_Request.Types.PutProp propUpdate)
	{
		NetworkAPI_v1 networkAPI_v = new NetworkAPI_v1();
		if (Common.TryFindItem(propSource.FlatCollection, propUpdate.Id, out ItemPacket<IPropCue> packet))
		{
			dispatcher.Invoke(delegate
			{
				packet.Item.UndoStack?.StartIgnoring();
				if (!propUpdate.NameChange.NullableIsNullOrEmpty())
				{
					packet.Item.Name = propUpdate.NameChange;
				}
				if (propUpdate.AutoClearChange != null && packet.Item.SlideAction != null)
				{
					packet.Item.SlideAction.AutoClearDuration = propUpdate.AutoClearChange.AutoClearDuration;
					packet.Item.SlideAction.AutoClearEnabled = propUpdate.AutoClearChange.AutoClearEnabled;
				}
				packet.Item.UndoStack?.StopIgnoring();
			});
			networkAPI_v.Action().PropResponse().PutProp = new API_v1_Prop_Response.Types.PutProp
			{
				Prop = ProtoProp(new Identification(packet.ID, packet.Item.Name, packet.Index), packet.Item.SlideAction?.AutoClearDuration ?? 0.0, packet.Item.SlideAction?.AutoClearEnabled ?? false)
			};
		}
		else
		{
			networkAPI_v.Action().NotFound();
		}
		return networkAPI_v;
	}

	private static NetworkAPI_v1 PostPropCollection(IPropSource propSource, IUiDispatcher dispatcher, API_v1_Prop_Request.Types.PostPropCollections collection)
	{
		NetworkAPI_v1 v1 = new NetworkAPI_v1();
		dispatcher.Invoke(delegate
		{
			int index;
			IPropGroup propGroup = propSource.CreateGroup(collection.Name, out index);
			if (propGroup != null)
			{
				v1.Action().PropResponse().PostPropCollections = new API_v1_Prop_Response.Types.PostPropCollections
				{
					PropCollection = PropCollection(new Identification(propGroup.ID, propGroup.Name, (uint)index), propGroup.SingleMode, ProtoProps(propGroup))
				};
			}
			else
			{
				v1.Action().NotFound();
			}
		});
		return v1;
	}

	private static NetworkAPI_v1 PutPropCollection(IPropSource propSource, IUiDispatcher dispatcher, API_v1_Prop_Request.Types.PutPropCollection collection)
	{
		NetworkAPI_v1 v1 = new NetworkAPI_v1();
		dispatcher.Invoke(delegate
		{
			if (Common.TryFindItem(propSource.PropGroups, collection.Id, out ItemPacket<IPropGroup> packet))
			{
				packet.Item.UndoStack?.StartIgnoring();
				if (collection.Changes.Id != null && !string.IsNullOrEmpty(collection.Changes.Id.Name))
				{
					packet.Item.Name = collection.Changes.Id.Name;
				}
				packet.Item.SingleMode = collection.Changes.SinglePropEnabled;
				foreach (API_v1_PropData prop in collection.Changes.Props)
				{
					if (Common.TryFindItem(packet.Item, prop.Id, out ItemPacket<IPropCue> packet2) && packet2.Item.SlideAction != null)
					{
						packet2.Item.SlideAction.AutoClearDuration = prop.AutoClearDuration;
						packet2.Item.SlideAction.AutoClearEnabled = prop.AutoClearEnabled;
					}
				}
				packet.Item.UndoStack?.StopIgnoring();
				v1.Action().PropResponse().PutPropCollection = new API_v1_Prop_Response.Types.PutPropCollection
				{
					PropCollection = PropCollection(new Identification(packet.ID, packet.Item.Name, packet.Index), packet.Item.SingleMode, ProtoProps(packet.Item))
				};
			}
			else
			{
				v1.Action().NotFound();
			}
		});
		return v1;
	}

	private static NetworkAPI_v1 DeleteCollection(IPropSource propSource, IUiDispatcher dispatcher, API_v1_Prop_Request.Types.DeletePropCollection collection)
	{
		NetworkAPI_v1 v1 = new NetworkAPI_v1();
		dispatcher.Invoke(delegate
		{
			if (Common.TryFindItem(propSource.PropGroups, collection.Id, out ItemPacket<IPropGroup> packet))
			{
				propSource.RemoveGroup(packet.Item);
				v1.Action().PropResponse().DeletePropCollection = new API_v1_Prop_Response.Types.DeletePropCollection();
			}
			else
			{
				v1.Action().NotFound();
			}
		});
		return v1;
	}

	private static API_v1_PropData ProtoProp(Identification p, double autoClearDuration, bool autoClearEnabled)
	{
		return new API_v1_PropData
		{
			Id = Common.ID(p),
			AutoClearDuration = autoClearDuration,
			AutoClearEnabled = autoClearEnabled
		};
	}

	private static API_v1_PropCollection PropCollection(Identification p, bool singlePropEnabled, IEnumerable<API_v1_PropData> props)
	{
		return new API_v1_PropCollection
		{
			Id = Common.ID(p),
			SinglePropEnabled = singlePropEnabled,
			Props = { props }
		};
	}

	[IteratorStateMachine(typeof(_003CProtoProps_003Ed__14))]
	private static IEnumerable<API_v1_PropData> ProtoProps(IEnumerable<IPropCue>? props)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CProtoProps_003Ed__14(-2)
		{
			_003C_003E3__props = props
		};
	}
}
