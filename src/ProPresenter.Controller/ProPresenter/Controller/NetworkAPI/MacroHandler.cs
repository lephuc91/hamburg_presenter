using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using Pro.Common.Dispatcher;
using Pro.DO.Triggering;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.MacroGroups;
using ProPresenter.DO.Macros;

namespace ProPresenter.Controller.NetworkAPI;

public static class MacroHandler
{
	[CompilerGenerated]
	private sealed class _003CMacros_003Ed__12 : IEnumerable<API_v1_Macro>, IEnumerable, IEnumerator<API_v1_Macro>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private API_v1_Macro _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IEnumerable<ProPresenterMacro> macros;

		public IEnumerable<ProPresenterMacro> _003C_003E3__macros;

		private uint _003Cindex_003E5__2;

		private IEnumerator<ProPresenterMacro> _003C_003E7__wrap2;

		API_v1_Macro IEnumerator<API_v1_Macro>.Current
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
		public _003CMacros_003Ed__12(int _003C_003E1__state)
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
					if (macros == null)
					{
						return false;
					}
					_003C_003E7__wrap2 = macros.GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					break;
				}
				if (_003C_003E7__wrap2.MoveNext())
				{
					ProPresenterMacro current = _003C_003E7__wrap2.Current;
					_003C_003E2__current = Macro(new Identification(current.ID, current.Name, _003Cindex_003E5__2++), current.Color, current.ImageType);
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
		IEnumerator<API_v1_Macro> IEnumerable<API_v1_Macro>.GetEnumerator()
		{
			_003CMacros_003Ed__12 _003CMacros_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CMacros_003Ed__ = this;
			}
			else
			{
				_003CMacros_003Ed__ = new _003CMacros_003Ed__12(0);
			}
			_003CMacros_003Ed__.macros = _003C_003E3__macros;
			return _003CMacros_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<API_v1_Macro>)this).GetEnumerator();
		}
	}

	public static NetworkAPI_v1? Handle(IAPIv1Service service, API_v1_Macro_Request r)
	{
		IMacroSource macroSource = service.MacroSource;
		IUiDispatcher uiDispatcher = service.Dependencies.UiDispatcher;
		ITriggering triggering = service.Triggering;
		return r.RequestCase switch
		{
			API_v1_Macro_Request.RequestOneofCase.Macros => GetMacros(macroSource, r.Macros), 
			API_v1_Macro_Request.RequestOneofCase.GetMacro => GetMacro(macroSource, r.GetMacro), 
			API_v1_Macro_Request.RequestOneofCase.PutMacro => PutMacro(macroSource, uiDispatcher, r.PutMacro), 
			API_v1_Macro_Request.RequestOneofCase.DeleteMacro => DeleteMacro(macroSource, uiDispatcher, r.DeleteMacro), 
			API_v1_Macro_Request.RequestOneofCase.TriggerMacro => TriggerMacro(macroSource, triggering, r.TriggerMacro), 
			API_v1_Macro_Request.RequestOneofCase.PostMacroCollections => PostMacroCollections(macroSource, uiDispatcher, r.PostMacroCollections), 
			API_v1_Macro_Request.RequestOneofCase.PutMacroCollection => PutMacroCollection(macroSource, uiDispatcher, r.PutMacroCollection), 
			API_v1_Macro_Request.RequestOneofCase.DeleteMacroCollection => DeleteMacroCollection(macroSource, uiDispatcher, r.DeleteMacroCollection), 
			API_v1_Macro_Request.RequestOneofCase.PutMacroIcon => PutMacroIcon(macroSource, uiDispatcher, r.PutMacroIcon), 
			_ => null, 
		};
	}

	private static NetworkAPI_v1 GetMacros(IMacroSource macroSource, API_v1_Macro_Request.Types.Macros? _)
	{
		return UpdateMacros(macroSource, _);
	}

	public static NetworkAPI_v1 UpdateMacros(IMacroSource macroSource, API_v1_Macro_Request.Types.Macros? _)
	{
		NetworkAPI_v1 networkAPI_v = new NetworkAPI_v1();
		networkAPI_v.StreamingAction("/v1/macros").MacroResponse().Macros = new API_v1_Macro_Response.Types.Macros
		{
			Macros_ = { Macros(macroSource?.FlatCollection) }
		};
		return networkAPI_v;
	}

	private static NetworkAPI_v1 GetMacro(IMacroSource macroSource, API_v1_Macro_Request.Types.GetMacro id)
	{
		NetworkAPI_v1 networkAPI_v = new NetworkAPI_v1();
		if (Common.TryFindItem(macroSource.FlatCollection, id.Id, out ItemPacket<ProPresenterMacro> packet))
		{
			networkAPI_v.Action().MacroResponse().GetMacro = new API_v1_Macro_Response.Types.GetMacro
			{
				Macro = Macro(packet, packet.Item.Color, packet.Item.ImageType)
			};
		}
		else
		{
			networkAPI_v.Action().NotFound();
		}
		return networkAPI_v;
	}

	private static NetworkAPI_v1 PutMacro(IMacroSource macroSource, IUiDispatcher dispatcher, API_v1_Macro_Request.Types.PutMacro macroUpdate)
	{
		NetworkAPI_v1 networkAPI_v = new NetworkAPI_v1();
		if (Common.TryFindItem(macroSource.FlatCollection, macroUpdate.Id, out ItemPacket<ProPresenterMacro> packet))
		{
			dispatcher.Invoke(delegate
			{
				packet.Item.UndoStack?.StartIgnoring();
				if (!string.IsNullOrEmpty(macroUpdate.NameChange))
				{
					packet.Item.Name = macroUpdate.NameChange;
				}
				if (macroUpdate.ColorChange != null)
				{
					packet.Item.Color = macroUpdate.ColorChange.ToColor();
				}
				if (Enum.TryParse<MacrosDocument.Types.Macro.Types.ImageType>(macroUpdate.ImageTypeChange, out var result))
				{
					packet.Item.ImageType = result.ToImageType();
				}
				packet.Item.UndoStack?.StopIgnoring();
			});
			networkAPI_v.Action().MacroResponse().PutMacro = new API_v1_Macro_Response.Types.PutMacro
			{
				Macro = Macro(new Identification(packet.ID, packet.Item.Name, packet.Index), packet.Item.Color, packet.Item.ImageType)
			};
		}
		else
		{
			networkAPI_v.Action().NotFound();
		}
		return networkAPI_v;
	}

	private static NetworkAPI_v1 DeleteMacro(IMacroSource macroSource, IUiDispatcher dispatcher, API_v1_Macro_Request.Types.DeleteMacro id)
	{
		NetworkAPI_v1 networkAPI_v = new NetworkAPI_v1();
		if (Common.TryFindItem(macroSource.FlatCollection, id.Id, out ItemPacket<ProPresenterMacro> packet))
		{
			dispatcher.Invoke(delegate
			{
				macroSource.RemoveMacro(packet.Item);
			});
			networkAPI_v.Action().MacroResponse().DeleteMacro = new API_v1_Macro_Response.Types.DeleteMacro();
		}
		else
		{
			networkAPI_v.Action().NotFound();
		}
		return networkAPI_v;
	}

	private static NetworkAPI_v1 TriggerMacro(IMacroSource macroSource, ITriggering triggering, API_v1_Macro_Request.Types.TriggerMacro id)
	{
		NetworkAPI_v1 networkAPI_v = new NetworkAPI_v1();
		if (Common.TryFindItem(macroSource.FlatCollection, id.Id, out ItemPacket<ProPresenterMacro> packet))
		{
			triggering.TriggerMacro(packet.Item);
			networkAPI_v.Action().MacroResponse().TriggerMacro = new API_v1_Macro_Response.Types.TriggerMacro();
		}
		else
		{
			networkAPI_v.Action().NotFound();
		}
		return networkAPI_v;
	}

	private static NetworkAPI_v1 PostMacroCollections(IMacroSource macroSource, IUiDispatcher dispatcher, API_v1_Macro_Request.Types.PostMacroCollections data)
	{
		NetworkAPI_v1 v1 = new NetworkAPI_v1();
		dispatcher.Invoke(delegate
		{
			int index;
			MacroGroup macroGroup = macroSource.CreateMacroGroup(data.Name, out index);
			if (macroGroup != null)
			{
				v1.Action().MacroResponse().PostMacroCollections = new API_v1_Macro_Response.Types.PostMacroCollections
				{
					MacroCollection = MacroCollection(new Identification(macroGroup.ID, macroGroup.Name, (uint)index), Macros(macroGroup))
				};
			}
			else
			{
				v1.Action().NotFound();
			}
		});
		return v1;
	}

	private static NetworkAPI_v1? PutMacroCollection(IMacroSource macroSource, IUiDispatcher dispatcher, API_v1_Macro_Request.Types.PutMacroCollection data)
	{
		NetworkAPI_v1 v1 = new NetworkAPI_v1();
		dispatcher.Invoke(delegate
		{
			if (Common.TryFindItem(macroSource.MacroGroups, data.Id, out ItemPacket<MacroGroup> packet))
			{
				packet.Item.UndoStack?.StartIgnoring();
				foreach (API_v1_Macro macro in data.Changes.Macros)
				{
					if (macro != null && Common.TryFindItem(packet.Item, macro.Id, out ItemPacket<ProPresenterMacro> packet2))
					{
						packet2.Item.Color = macro.Color.ToColor();
						if (Enum.TryParse<MacrosDocument.Types.Macro.Types.ImageType>(macro.ImageType, ignoreCase: true, out var result))
						{
							packet2.Item.ImageType = result.ToImageType();
						}
					}
				}
				packet.Item.UndoStack?.StopIgnoring();
				v1.Action().MacroResponse().PutMacroCollection = new API_v1_Macro_Response.Types.PutMacroCollection
				{
					MacroCollection = MacroCollection(packet, Macros(packet.Item))
				};
			}
			else
			{
				v1.Action().NotFound();
			}
		});
		return v1;
	}

	private static NetworkAPI_v1? DeleteMacroCollection(IMacroSource macroSource, IUiDispatcher dispatcher, API_v1_Macro_Request.Types.DeleteMacroCollection data)
	{
		NetworkAPI_v1 v1 = new NetworkAPI_v1();
		dispatcher.Invoke(delegate
		{
			if (Common.TryFindItem(macroSource.MacroGroups, data.Id, out ItemPacket<MacroGroup> packet))
			{
				macroSource.RemoveMacroGroup(packet.Item);
				v1.Action().MacroResponse().DeleteMacroCollection = new API_v1_Macro_Response.Types.DeleteMacroCollection();
			}
			else
			{
				v1.Action().NotFound();
			}
		});
		return v1;
	}

	private static NetworkAPI_v1? PutMacroIcon(IMacroSource macroSource, IUiDispatcher dispatcher, API_v1_Macro_Request.Types.PutMacroIcon data)
	{
		NetworkAPI_v1 v1 = new NetworkAPI_v1();
		dispatcher.Invoke(delegate
		{
			if (Common.TryFindItem(macroSource.FlatCollection, data.Id, out ItemPacket<ProPresenterMacro> packet))
			{
				packet.Item.Icon = data.Icon.ToBitmapSource();
				packet.Item.ImageType = ImageType.Custom;
			}
			else
			{
				v1.Action().NotFound();
			}
		});
		return v1;
	}

	private static API_v1_Macro_Response MacroResponse(this NetworkAPI_v1.Types.Action action)
	{
		return action.MacroResponse ?? (action.MacroResponse = new API_v1_Macro_Response());
	}

	[IteratorStateMachine(typeof(_003CMacros_003Ed__12))]
	private static IEnumerable<API_v1_Macro> Macros(IEnumerable<ProPresenterMacro>? macros)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CMacros_003Ed__12(-2)
		{
			_003C_003E3__macros = macros
		};
	}

	private static API_v1_Macro Macro(Identification p, System.Windows.Media.Color color, ImageType imageType)
	{
		return new API_v1_Macro
		{
			Id = Common.ID(p),
			Color = color.ToProtoColor(),
			ImageType = imageType.ToProtoImageType().ToString()
		};
	}

	private static API_v1_Macro_Collection MacroCollection(Identification p, IEnumerable<API_v1_Macro> macros)
	{
		return new API_v1_Macro_Collection
		{
			Id = Common.ID(p),
			Macros = { macros }
		};
	}
}
