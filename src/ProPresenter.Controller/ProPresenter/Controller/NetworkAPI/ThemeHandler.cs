using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Pro.Common.Collections;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Themes;

namespace ProPresenter.Controller.NetworkAPI;

public static class ThemeHandler
{
	[CompilerGenerated]
	private sealed class _003CGetThemeGroups_003Ed__10 : IEnumerable<API_v1_ThemeGroup>, IEnumerable, IEnumerator<API_v1_ThemeGroup>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private API_v1_ThemeGroup _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IEnumerable<ThemeContainer> containers;

		public IEnumerable<ThemeContainer> _003C_003E3__containers;

		private int _003Cindex_003E5__2;

		private IEnumerator<ThemeContainer> _003C_003E7__wrap2;

		API_v1_ThemeGroup IEnumerator<API_v1_ThemeGroup>.Current
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
		public _003CGetThemeGroups_003Ed__10(int _003C_003E1__state)
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
					_003Cindex_003E5__2 = 0;
					_003C_003E7__wrap2 = containers.GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					break;
				}
				if (_003C_003E7__wrap2.MoveNext())
				{
					ThemeContainer current = _003C_003E7__wrap2.Current;
					API_v1_ThemeGroup groupNode = new API_v1_ThemeGroup
					{
						Id = new API_v1_Identifier
						{
							Uuid = string.Empty,
							Name = current.Name,
							Index = (uint)_003Cindex_003E5__2++
						}
					};
					if (current.Children.Any())
					{
						current.IntoGroup(groupNode);
					}
					_003C_003E2__current = groupNode;
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
		IEnumerator<API_v1_ThemeGroup> IEnumerable<API_v1_ThemeGroup>.GetEnumerator()
		{
			_003CGetThemeGroups_003Ed__10 _003CGetThemeGroups_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CGetThemeGroups_003Ed__ = this;
			}
			else
			{
				_003CGetThemeGroups_003Ed__ = new _003CGetThemeGroups_003Ed__10(0);
			}
			_003CGetThemeGroups_003Ed__.containers = _003C_003E3__containers;
			return _003CGetThemeGroups_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<API_v1_ThemeGroup>)this).GetEnumerator();
		}
	}

	public static NetworkAPI_v1 Handle(IAPIv1Service service, API_v1_Theme_Request request)
	{
		if (request != null)
		{
			if (request.GetAll != null)
			{
				return GetAll(service);
			}
			API_v1_Theme_Request.Types.GetTheme getTheme = request.GetTheme;
			if (getTheme != null)
			{
				return GetTheme(service, getTheme.Id);
			}
			API_v1_Theme_Request.Types.GetThemeName getThemeName = request.GetThemeName;
			if (getThemeName != null)
			{
				return GetThemeName(service, getThemeName.Id);
			}
			API_v1_Theme_Request.Types.GetThemeSlide getThemeSlide = request.GetThemeSlide;
			if (getThemeSlide != null)
			{
				return GetThemeSlide(service, getThemeSlide.Id, getThemeSlide.ThemeSlide);
			}
			API_v1_Theme_Request.Types.GetThemeSlideThumbnail getThemeSlideThumbnail = request.GetThemeSlideThumbnail;
			if (getThemeSlideThumbnail != null)
			{
				return GetThumbnail(service, getThemeSlideThumbnail.Id, getThemeSlideThumbnail.ThemeSlide, getThemeSlideThumbnail.Quality);
			}
			API_v1_Theme_Request.Types.PutThemeSlide putThemeSlide = request.PutThemeSlide;
			if (putThemeSlide != null)
			{
				return PutThemeSlide(service, putThemeSlide.Id, putThemeSlide.ThemeSlide, putThemeSlide.Slide);
			}
		}
		global::_003CPrivateImplementationDetails_003E.ThrowSwitchExpressionException(request);
		NetworkAPI_v1 result = default(NetworkAPI_v1);
		return result;
	}

	private static NetworkAPI_v1 GetAll(IAPIv1Service service)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().ThemeResponse().GetAll = new API_v1_Theme_Response.Types.GetAll
			{
				Themes = { service.Themes.ThemeTree?.Children.Select((ThemeContainer c) => c.Theme).NonNull().Select(IntoTheme) },
				Groups = { GetThemeGroups(service.Themes.ThemeTree?.Children.Where((ThemeContainer c) => c.Children.Any()) ?? Enumerable.Empty<ThemeContainer>()) }
			};
		});
	}

	private static NetworkAPI_v1 GetTheme(IAPIv1Service service, string id)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (Common.TryFindNode(id, service.Themes.ThemeTree?.Children ?? Enumerable.Empty<ThemeContainer>(), out ItemPacket<ThemeContainer> packet))
			{
				API_v1_Theme_Response aPI_v1_Theme_Response = v1.Action().ThemeResponse();
				Theme theme = packet.Item.Theme;
				aPI_v1_Theme_Response.GetTheme = ((theme != null) ? new API_v1_Theme_Response.Types.GetTheme
				{
					Theme = IntoTheme(theme, (int)packet.Index)
				} : new API_v1_Theme_Response.Types.GetTheme
				{
					Group = GetThemeGroups(packet.Item.ToEnumerable()).First()
				});
			}
			else
			{
				v1.Action().NotFound();
			}
		});
	}

	private static NetworkAPI_v1 GetThemeName(IAPIv1Service service, string id)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (Common.TryFindItem(service.Themes, id, out ItemPacket<Theme> packet))
			{
				v1.Action().ThemeResponse().GetThemeName = new API_v1_Theme_Response.Types.GetThemeName
				{
					Name = packet.Name
				};
			}
			else
			{
				v1.Action().NotFound();
			}
		});
	}

	private static NetworkAPI_v1 GetThemeSlide(IAPIv1Service service, string id, string slideID)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (Common.TryFindNode(id, service.Themes.ThemeTree?.Children ?? Enumerable.Empty<ThemeContainer>(), out ItemPacket<ThemeContainer> packet))
			{
				Theme theme = packet.Item.Theme;
				if (theme != null && Common.TryFindItem(theme, slideID, out ItemPacket<TemplateSlide> packet2))
				{
					v1.Action().ThemeResponse().GetThemeSlide = new API_v1_Theme_Response.Types.GetThemeSlide
					{
						ThemeSlide = IntoSlide(packet2.Item, (int)packet2.Index)
					};
					return;
				}
			}
			v1.Action().NotFound();
		});
	}

	private static NetworkAPI_v1 GetThumbnail(IAPIv1Service service, string id, string slideID, int quality)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (Common.TryFindNode(id, service.Themes.ThemeTree?.Children ?? Enumerable.Empty<ThemeContainer>(), out ItemPacket<ThemeContainer> packet))
			{
				Theme theme = packet.Item.Theme;
				if (theme != null && Common.TryFindItem(theme, slideID, out ItemPacket<TemplateSlide> packet2))
				{
					v1.Action().ThemeResponse().GetThemeSlideThumbnail = new API_v1_Theme_Response.Types.GetThemeSlideThumbnail
					{
						Data = packet2.Item.Slide.ToCue(service.Dependencies.FactoryProvider, service.Dependencies.TransitionDescriptions).GetThumbnail(null, quality)
					};
					return;
				}
			}
			v1.Action().NotFound();
		});
	}

	private static NetworkAPI_v1 PutThemeSlide(IAPIv1Service service, string id, string slideID, API_v1_ThemeSlide protoSlide)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (Common.TryFindNode(id, service.Themes.ThemeTree?.Children ?? Enumerable.Empty<ThemeContainer>(), out ItemPacket<ThemeContainer> packet))
			{
				Theme theme = packet.Item.Theme;
				if (theme != null && Common.TryFindItem(theme, slideID, out ItemPacket<TemplateSlide> template))
				{
					service.Dependencies.UiDispatcher.Invoke(delegate
					{
						API_v1_Color background = protoSlide.Background;
						if (background != null)
						{
							template.Item.Slide.UseBackgroundColor = true;
							template.Item.Slide.BackgroundColor = background.ToColor();
						}
						else
						{
							template.Item.Slide.UseBackgroundColor = false;
						}
						API_v1_Size size = protoSlide.Size;
						if (size != null)
						{
							template.Item.Slide.ChangeSize(size.ToVector());
						}
						API_v1_Identifier id2 = protoSlide.Id;
						if (id2 != null)
						{
							template.Item.Name = id2.Name;
						}
					});
					v1.Action().ThemeResponse().PutThemeSlide = new API_v1_Theme_Response.Types.PutThemeSlide();
					return;
				}
			}
			v1.Action().NotFound();
		});
	}

	private static API_v1_Theme_Response ThemeResponse(this NetworkAPI_v1.Types.Action action)
	{
		return action.ThemeResponse ?? (action.ThemeResponse = new API_v1_Theme_Response());
	}

	private static API_v1_ThemeSlide IntoSlide(TemplateSlide template, int index)
	{
		return new API_v1_ThemeSlide
		{
			Id = Common.ID(template.Slide.ID, template.Name, (uint)index),
			Background = (template.Slide.UseBackgroundColor ? template.Slide.BackgroundColor.ToProtoColor() : null),
			Size = template.Slide.Size.ToSize()
		};
	}

	private static API_v1_Theme IntoTheme(Theme theme, int index)
	{
		return new API_v1_Theme
		{
			Id = new API_v1_Identifier
			{
				Uuid = string.Empty,
				Name = theme.Name,
				Index = (uint)index
			},
			Slides = { theme.Select(IntoSlide) }
		};
	}

	[IteratorStateMachine(typeof(_003CGetThemeGroups_003Ed__10))]
	private static IEnumerable<API_v1_ThemeGroup> GetThemeGroups(IEnumerable<ThemeContainer> containers)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGetThemeGroups_003Ed__10(-2)
		{
			_003C_003E3__containers = containers
		};
	}

	private static void IntoGroup(this ThemeContainer tree, API_v1_ThemeGroup groupNode)
	{
		int index = 0;
		if (tree.Theme != null)
		{
			groupNode.Themes.Add(IntoTheme(tree.Theme, index++));
			return;
		}
		foreach (ThemeContainer child in tree.Children)
		{
			if (child.Theme != null)
			{
				groupNode.Themes.Add(IntoTheme(child.Theme, index++));
				continue;
			}
			API_v1_ThemeGroup aPI_v1_ThemeGroup = new API_v1_ThemeGroup
			{
				Id = Common.ID(child.ID, child.Name, (uint)index)
			};
			groupNode.Groups.Add(aPI_v1_ThemeGroup);
			child.IntoGroup(aPI_v1_ThemeGroup);
		}
	}
}
