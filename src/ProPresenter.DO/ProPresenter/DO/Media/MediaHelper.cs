using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Google.Protobuf.Collections;
using Pro.Common.Collections;
using Pro.Common.FileSystem;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.DO.Storage;
using Pro.DO.Triggering;
using Pro.DO.Triggering.CompletionTargets;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;
using Pro.Text;
using Pro.Text.Fills;
using Pro.ssAPI;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Looks;
using ProPresenter.DO.MacroGroups;
using ProPresenter.DO.Macros;
using ProPresenter.DO.Masks;
using ProPresenter.DO.Media.Properties;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Props;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;
using ProPresenter.DO.Themes;

namespace ProPresenter.DO.Media;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(ScaleAlignment), typeof(Pro.SerializationInterop.RVProtoData.Media.Types.ScaleAlignment), SourceToDestinationMethodName = "ToProtoScaleAlignment", DestinationDefaultValue = "MiddleCenter", DestinationToSourceMethodName = "ToScaleAlignment", SourceDefaultValue = "MiddleCenter")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(ScaleAlignment), typeof(IMedia.Types.ScaleAlignment), SourceToDestinationMethodName = "ToEntityScaleAlignment", DestinationToSourceMethodName = "ToScaleAlignment")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(PlaybackBehaviorType), typeof(Pro.SerializationInterop.RVProtoData.Media.Types.TransportProperties.Types.PlaybackBehavior), SourceToDestinationMethodName = "GetProtoPlaybackBehavior", DestinationDefaultValue = "Stop", DestinationToSourceMethodName = "GetPlaybackBehaviorType", SourceDefaultValue = "Stop")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(PlaybackBehaviorType), typeof(IMedia.Types.ITransportProperties.Types.PlaybackBehavior), SourceToDestinationMethodName = "ToEntityPlaybackBehavior", DestinationDefaultValue = "Stop", DestinationToSourceMethodName = "ToPlaybackBehaviorType", SourceDefaultValue = "Stop")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(EndBehaviorType), typeof(Pro.SerializationInterop.RVProtoData.Media.Types.VideoProperties.Types.EndBehavior), SourceToDestinationMethodName = "GetProtoEndBehavior", DestinationDefaultValue = "Stop", DestinationToSourceMethodName = "GetEndBehaviorType", SourceDefaultValue = "HoldLastFrame", UnmatchedSourceNames = new string[] { "HoldLastFrame", "BlackAfterLastFrame", "ClearAfterLastFrame" }, UnmatchedDestinationNames = new string[] { "Stop", "StopOnBlack", "StopOnClear" })]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(EndBehaviorType), typeof(IMedia.Types.IVideoProperties.Types.EndBehavior), SourceToDestinationMethodName = "ToEntityEndBehavior", DestinationDefaultValue = "Stop", DestinationToSourceMethodName = "ToEndBehaviorType", SourceDefaultValue = "HoldLastFrame", UnmatchedSourceNames = new string[] { "HoldLastFrame", "BlackAfterLastFrame", "ClearAfterLastFrame" }, UnmatchedDestinationNames = new string[] { "Stop", "StopOnBlack", "StopOnClear" })]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(AudioType), typeof(Pro.SerializationInterop.RVProtoData.Action.Types.MediaType.Types.Audio.Types.MediaActionAudioType), SourceToDestinationMethodName = "ToProtoAudioType", DestinationDefaultValue = "Tune", DestinationToSourceMethodName = "ToAudioType", SourceDefaultValue = "AudioTrack", UnmatchedSourceNames = new string[] { "AudioTrack", "SoundEffect" }, UnmatchedDestinationNames = new string[] { "Tune", "Sound" })]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(RetriggerBehavior), typeof(Pro.SerializationInterop.RVProtoData.Media.Types.TransportProperties.Types.RetriggerSetting), SourceToDestinationMethodName = "GetProtoRetriggerBehavior", DestinationDefaultValue = "Unset", DestinationToSourceMethodName = "GetRetriggerBehavior", SourceDefaultValue = "Unset")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(RetriggerBehavior), typeof(IMedia.Types.ITransportProperties.Types.RetriggerSetting), SourceToDestinationMethodName = "ToEntityRetriggerBehavior", DestinationDefaultValue = "Unset", DestinationToSourceMethodName = "ToRetriggerBehavior", SourceDefaultValue = "Unset")]
public static class MediaHelper
{
	[CompilerGenerated]
	private sealed class _003CFindAllMedia_003Ed__15 : IEnumerable<MediaBase>, IEnumerable, IEnumerator<MediaBase>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private MediaBase _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private ClosedBezierPath closedBezierPath;

		public ClosedBezierPath _003C_003E3__closedBezierPath;

		private IEnumerator<Paragraph> _003C_003E7__wrap1;

		private IEnumerator<RunBase> _003C_003E7__wrap2;

		MediaBase IEnumerator<MediaBase>.Current
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
		public _003CFindAllMedia_003Ed__15(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if ((uint)(num - -4) <= 1u || num == 1)
			{
				try
				{
					if (num == -4 || num == 1)
					{
						try
						{
						}
						finally
						{
							_003C_003Em__Finally2();
						}
					}
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003C_003E7__wrap1 = null;
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
					_003C_003E7__wrap1 = closedBezierPath.Text.GetEnumerator();
					_003C_003E1__state = -3;
					goto IL_00ec;
				case 1:
					_003C_003E1__state = -4;
					goto IL_00d2;
				case 2:
					{
						_003C_003E1__state = -1;
						break;
					}
					IL_00ec:
					if (_003C_003E7__wrap1.MoveNext())
					{
						Paragraph current = _003C_003E7__wrap1.Current;
						_003C_003E7__wrap2 = current.GetEnumerator();
						_003C_003E1__state = -4;
						goto IL_00d2;
					}
					_003C_003Em__Finally1();
					_003C_003E7__wrap1 = null;
					if (closedBezierPath.Fill is MediaFill { Media: not null } mediaFill)
					{
						_003C_003E2__current = mediaFill.Media;
						_003C_003E1__state = 2;
						return true;
					}
					break;
					IL_00d2:
					while (_003C_003E7__wrap2.MoveNext())
					{
						if (_003C_003E7__wrap2.Current.Settings.Fill is MediaTextFill { Media: VisualMedia media })
						{
							RelativePath sourceFile = media.SourceFile;
							if ((object)sourceFile != null && sourceFile.FullPath != null)
							{
								_003C_003E2__current = media;
								_003C_003E1__state = 1;
								return true;
							}
						}
					}
					_003C_003Em__Finally2();
					_003C_003E7__wrap2 = null;
					goto IL_00ec;
				}
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
			if (_003C_003E7__wrap1 != null)
			{
				_003C_003E7__wrap1.Dispose();
			}
		}

		private void _003C_003Em__Finally2()
		{
			_003C_003E1__state = -3;
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
		IEnumerator<MediaBase> IEnumerable<MediaBase>.GetEnumerator()
		{
			_003CFindAllMedia_003Ed__15 _003CFindAllMedia_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CFindAllMedia_003Ed__ = this;
			}
			else
			{
				_003CFindAllMedia_003Ed__ = new _003CFindAllMedia_003Ed__15(0);
			}
			_003CFindAllMedia_003Ed__.closedBezierPath = _003C_003E3__closedBezierPath;
			return _003CFindAllMedia_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<MediaBase>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	private sealed class _003CFindAllMedia_003Ed__20 : IEnumerable<MediaBase>, IEnumerable, IEnumerator<MediaBase>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private MediaBase _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IEnumerable<Pro.DO.Triggering.IAction> actions;

		public IEnumerable<Pro.DO.Triggering.IAction> _003C_003E3__actions;

		private IEnumerator<MediaAction> _003C_003E7__wrap1;

		MediaBase IEnumerator<MediaBase>.Current
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
		public _003CFindAllMedia_003Ed__20(int _003C_003E1__state)
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
			_003C_003E7__wrap1 = null;
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
					_003C_003E7__wrap1 = actions.OfType<MediaAction>().GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					break;
				}
				while (_003C_003E7__wrap1.MoveNext())
				{
					MediaBase media = _003C_003E7__wrap1.Current.Media;
					if (media != null && media.MediaType.IsAnyOf(MediaType.Audio, MediaType.Video, MediaType.Image))
					{
						_003C_003E2__current = media;
						_003C_003E1__state = 1;
						return true;
					}
				}
				_003C_003Em__Finally1();
				_003C_003E7__wrap1 = null;
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
			if (_003C_003E7__wrap1 != null)
			{
				_003C_003E7__wrap1.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<MediaBase> IEnumerable<MediaBase>.GetEnumerator()
		{
			_003CFindAllMedia_003Ed__20 _003CFindAllMedia_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CFindAllMedia_003Ed__ = this;
			}
			else
			{
				_003CFindAllMedia_003Ed__ = new _003CFindAllMedia_003Ed__20(0);
			}
			_003CFindAllMedia_003Ed__.actions = _003C_003E3__actions;
			return _003CFindAllMedia_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<MediaBase>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	private sealed class _003CFindAllMediaTextFill_003Ed__19 : IEnumerable<MediaTextFill>, IEnumerable, IEnumerator<MediaTextFill>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private MediaTextFill _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IEnumerable<SlideElementBase> elements;

		public IEnumerable<SlideElementBase> _003C_003E3__elements;

		private IEnumerator<ClosedBezierPath> _003C_003E7__wrap1;

		private IEnumerator<Paragraph> _003C_003E7__wrap2;

		private IEnumerator<RunBase> _003C_003E7__wrap3;

		MediaTextFill IEnumerator<MediaTextFill>.Current
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
		public _003CFindAllMediaTextFill_003Ed__19(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if ((uint)(num - -5) <= 2u || num == 1)
			{
				try
				{
					if ((uint)(num - -5) <= 1u || num == 1)
					{
						try
						{
							if (num == -5 || num == 1)
							{
								try
								{
								}
								finally
								{
									_003C_003Em__Finally3();
								}
							}
						}
						finally
						{
							_003C_003Em__Finally2();
						}
					}
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003C_003E7__wrap1 = null;
			_003C_003E7__wrap2 = null;
			_003C_003E7__wrap3 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			try
			{
				int num = _003C_003E1__state;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					_003C_003E1__state = -5;
					goto IL_00d6;
				}
				_003C_003E1__state = -1;
				_003C_003E7__wrap1 = (elements?.OfType<ClosedBezierPath>() ?? Enumerable.Empty<ClosedBezierPath>()).GetEnumerator();
				_003C_003E1__state = -3;
				goto IL_010d;
				IL_010d:
				if (_003C_003E7__wrap1.MoveNext())
				{
					ClosedBezierPath current = _003C_003E7__wrap1.Current;
					_003C_003E7__wrap2 = current.Text.GetEnumerator();
					_003C_003E1__state = -4;
					goto IL_00f0;
				}
				_003C_003Em__Finally1();
				_003C_003E7__wrap1 = null;
				return false;
				IL_00f0:
				if (_003C_003E7__wrap2.MoveNext())
				{
					Paragraph current2 = _003C_003E7__wrap2.Current;
					_003C_003E7__wrap3 = current2.GetEnumerator();
					_003C_003E1__state = -5;
					goto IL_00d6;
				}
				_003C_003Em__Finally2();
				_003C_003E7__wrap2 = null;
				goto IL_010d;
				IL_00d6:
				while (_003C_003E7__wrap3.MoveNext())
				{
					if (_003C_003E7__wrap3.Current.Settings.Fill is MediaTextFill mediaTextFill)
					{
						_003C_003E2__current = mediaTextFill;
						_003C_003E1__state = 1;
						return true;
					}
				}
				_003C_003Em__Finally3();
				_003C_003E7__wrap3 = null;
				goto IL_00f0;
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
			if (_003C_003E7__wrap1 != null)
			{
				_003C_003E7__wrap1.Dispose();
			}
		}

		private void _003C_003Em__Finally2()
		{
			_003C_003E1__state = -3;
			if (_003C_003E7__wrap2 != null)
			{
				_003C_003E7__wrap2.Dispose();
			}
		}

		private void _003C_003Em__Finally3()
		{
			_003C_003E1__state = -4;
			if (_003C_003E7__wrap3 != null)
			{
				_003C_003E7__wrap3.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<MediaTextFill> IEnumerable<MediaTextFill>.GetEnumerator()
		{
			_003CFindAllMediaTextFill_003Ed__19 _003CFindAllMediaTextFill_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CFindAllMediaTextFill_003Ed__ = this;
			}
			else
			{
				_003CFindAllMediaTextFill_003Ed__ = new _003CFindAllMediaTextFill_003Ed__19(0);
			}
			_003CFindAllMediaTextFill_003Ed__.elements = _003C_003E3__elements;
			return _003CFindAllMediaTextFill_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<MediaTextFill>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetProtoMediaFills_003Ed__25 : IEnumerable<Pro.SerializationInterop.RVProtoData.Media>, IEnumerable, IEnumerator<Pro.SerializationInterop.RVProtoData.Media>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private Pro.SerializationInterop.RVProtoData.Media _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IEnumerable<Pro.SerializationInterop.RVProtoData.Slide.Types.Element> protoElements;

		public IEnumerable<Pro.SerializationInterop.RVProtoData.Slide.Types.Element> _003C_003E3__protoElements;

		private IEnumerator<Pro.SerializationInterop.RVProtoData.Slide.Types.Element> _003C_003E7__wrap1;

		private Pro.SerializationInterop.RVProtoData.Slide.Types.Element _003Celement_003E5__3;

		Pro.SerializationInterop.RVProtoData.Media IEnumerator<Pro.SerializationInterop.RVProtoData.Media>.Current
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
		public _003CGetProtoMediaFills_003Ed__25(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if (num == -3 || (uint)(num - 1) <= 1u)
			{
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003C_003E7__wrap1 = null;
			_003Celement_003E5__3 = null;
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
					_003C_003E7__wrap1 = (protoElements ?? Enumerable.Empty<Pro.SerializationInterop.RVProtoData.Slide.Types.Element>()).GetEnumerator();
					_003C_003E1__state = -3;
					goto IL_0130;
				case 1:
					_003C_003E1__state = -3;
					goto IL_00c0;
				case 2:
					{
						_003C_003E1__state = -3;
						goto IL_0129;
					}
					IL_0129:
					_003Celement_003E5__3 = null;
					goto IL_0130;
					IL_0130:
					if (_003C_003E7__wrap1.MoveNext())
					{
						_003Celement_003E5__3 = _003C_003E7__wrap1.Current;
						if (_003Celement_003E5__3.Element_?.Fill != null && _003Celement_003E5__3.Element_.Fill.Media != null)
						{
							_003C_003E2__current = _003Celement_003E5__3.Element_.Fill.Media;
							_003C_003E1__state = 1;
							return true;
						}
						goto IL_00c0;
					}
					_003C_003Em__Finally1();
					_003C_003E7__wrap1 = null;
					return false;
					IL_00c0:
					if (_003Celement_003E5__3.Element_?.Text?.Attributes?.MediaFill != null)
					{
						_003C_003E2__current = _003Celement_003E5__3.Element_.Text.Attributes.MediaFill.Media;
						_003C_003E1__state = 2;
						return true;
					}
					goto IL_0129;
				}
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
			if (_003C_003E7__wrap1 != null)
			{
				_003C_003E7__wrap1.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<Pro.SerializationInterop.RVProtoData.Media> IEnumerable<Pro.SerializationInterop.RVProtoData.Media>.GetEnumerator()
		{
			_003CGetProtoMediaFills_003Ed__25 _003CGetProtoMediaFills_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CGetProtoMediaFills_003Ed__ = this;
			}
			else
			{
				_003CGetProtoMediaFills_003Ed__ = new _003CGetProtoMediaFills_003Ed__25(0);
			}
			_003CGetProtoMediaFills_003Ed__.protoElements = _003C_003E3__protoElements;
			return _003CGetProtoMediaFills_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Pro.SerializationInterop.RVProtoData.Media>)this).GetEnumerator();
		}
	}

	public static void ApplyImportSettings(MediaCue cue, IImport settings)
	{
		MediaBase mediaBase = cue.MediaAction?.Media;
		MediaAction mediaAction = cue.MediaAction;
		if (!(mediaBase is VideoMedia videoMedia))
		{
			if (!(mediaBase is AudioMedia audioMedia))
			{
				if (mediaBase is VisualMedia)
				{
					mediaAction.TriggerLayer = GetTriggerLayer(settings.ImageLayer);
					switch (settings.ImportDurationType)
					{
					case ImportDurationType.Time:
						mediaAction.Duration = settings.ImageDurationTime;
						break;
					case ImportDurationType.Random:
						mediaAction.Duration = TimeSlice.FromSeconds(RandomNumber.Generate(settings.RandomMinTime, settings.RandomMaxTime + 1));
						break;
					}
					cue.CompletionTarget = GetCompletionTarget(settings.ImageNextBehavior);
				}
			}
			else
			{
				switch (settings.AudioPlaybackBehavior)
				{
				default:
					audioMedia.Transport.PlaybackBehaviorType = PlaybackBehaviorType.Stop;
					cue.CompletionTarget = new NoTarget();
					break;
				case AudioBehaviorType.Loop:
					audioMedia.Transport.PlaybackBehaviorType = PlaybackBehaviorType.Loop;
					cue.CompletionTarget = new NoTarget();
					break;
				case AudioBehaviorType.Next:
					audioMedia.Transport.PlaybackBehaviorType = PlaybackBehaviorType.Stop;
					cue.CompletionTarget = new NextTarget();
					break;
				}
			}
		}
		else
		{
			mediaAction.TriggerLayer = GetTriggerLayer(settings.VideoLayer);
			videoMedia.Transport.PlaybackBehaviorType = settings.VideoPlaybackBehavior;
			videoMedia.Video.EndBehavior = settings.VideoEndBehavior;
			cue.CompletionTarget = GetCompletionTarget(settings.VideoNextBehavior);
		}
		if (mediaBase is IDrawMedia drawMedia)
		{
			switch (mediaAction.TriggerLayer)
			{
			case TriggerLayer.Background:
				drawMedia.Drawing.ScaleBehavior = settings.BackgroundScaleBehavior;
				break;
			case TriggerLayer.Foreground:
				drawMedia.Drawing.ScaleBehavior = settings.ForegroundScaleBehavior;
				break;
			}
		}
	}

	public static TriggerLayer GetTriggerLayer(ImportLayer importLayer)
	{
		if (importLayer == ImportLayer.Background || importLayer != ImportLayer.Foreground)
		{
			return TriggerLayer.Background;
		}
		return TriggerLayer.Foreground;
	}

	public static void ApplyImportSettings(MediaCue cue)
	{
		ApplyImportSettings(cue, ProPresenter.DO.Settings.Import.Settings);
	}

	public static void ApplyImportSetingsForSlideMediaAction(this MediaBase media, IImport settings)
	{
		if (!(media is VideoMedia videoMedia))
		{
			if (!(media is AudioMedia audioMedia))
			{
				if (media is VisualMedia visualMedia)
				{
					visualMedia.Drawing.ScaleBehavior = settings.BackgroundScaleBehavior;
				}
			}
			else
			{
				TransportProperties transport = audioMedia.Transport;
				transport.PlaybackBehaviorType = settings.AudioPlaybackBehavior switch
				{
					AudioBehaviorType.Loop => PlaybackBehaviorType.Loop, 
					AudioBehaviorType.Next => PlaybackBehaviorType.Stop, 
					_ => PlaybackBehaviorType.Stop, 
				};
			}
		}
		else
		{
			videoMedia.Transport.PlaybackBehaviorType = settings.VideoPlaybackBehavior;
			videoMedia.Video.EndBehavior = settings.VideoEndBehavior;
			videoMedia.Drawing.ScaleBehavior = settings.BackgroundScaleBehavior;
		}
	}

	private static CompletionTargetBase GetCompletionTarget(CompletionTargetType type)
	{
		return type switch
		{
			CompletionTargetType.Next => new NextTarget(), 
			CompletionTargetType.Random => new RandomTarget(), 
			_ => new NoTarget(), 
		};
	}

	public static ScaleBehavior ToScaleBehavior(this Pro.SerializationInterop.RVProtoData.Media.Types.ScaleBehavior protoScaleBehavior, bool isBlurred)
	{
		return protoScaleBehavior switch
		{
			Pro.SerializationInterop.RVProtoData.Media.Types.ScaleBehavior.Fit => isBlurred ? ScaleBehavior.ScaleAndBlur : ScaleBehavior.ScaleToFit, 
			Pro.SerializationInterop.RVProtoData.Media.Types.ScaleBehavior.Fill => ScaleBehavior.ScaleToFill, 
			Pro.SerializationInterop.RVProtoData.Media.Types.ScaleBehavior.Custom => ScaleBehavior.CustomFit, 
			Pro.SerializationInterop.RVProtoData.Media.Types.ScaleBehavior.Stretch => ScaleBehavior.StretchToFill, 
			_ => ScaleBehavior.ScaleToFit, 
		};
	}

	public static ScaleBehavior ToScaleBehavior(this IMedia.Types.ScaleBehavior entityScaleBehavior, bool isBlurred)
	{
		return entityScaleBehavior switch
		{
			IMedia.Types.ScaleBehavior.Fit => isBlurred ? ScaleBehavior.ScaleAndBlur : ScaleBehavior.ScaleToFit, 
			IMedia.Types.ScaleBehavior.Fill => ScaleBehavior.ScaleToFill, 
			IMedia.Types.ScaleBehavior.Custom => ScaleBehavior.CustomFit, 
			IMedia.Types.ScaleBehavior.Stretch => ScaleBehavior.StretchToFill, 
			_ => ScaleBehavior.ScaleToFit, 
		};
	}

	public static Pro.SerializationInterop.RVProtoData.Media.Types.ScaleBehavior ToProtoScaleBehavior(this ScaleBehavior scaleBehavior, out bool isBlurred)
	{
		isBlurred = false;
		switch (scaleBehavior)
		{
		default:
			return Pro.SerializationInterop.RVProtoData.Media.Types.ScaleBehavior.Fit;
		case ScaleBehavior.ScaleToFill:
			return Pro.SerializationInterop.RVProtoData.Media.Types.ScaleBehavior.Fill;
		case ScaleBehavior.CustomFit:
			return Pro.SerializationInterop.RVProtoData.Media.Types.ScaleBehavior.Custom;
		case ScaleBehavior.StretchToFill:
			return Pro.SerializationInterop.RVProtoData.Media.Types.ScaleBehavior.Stretch;
		case ScaleBehavior.ScaleAndBlur:
			isBlurred = true;
			return Pro.SerializationInterop.RVProtoData.Media.Types.ScaleBehavior.Fit;
		}
	}

	public static IMedia.Types.ScaleBehavior ToEntityScaleBehavior(this ScaleBehavior scaleBehavior, out bool isBlurred)
	{
		isBlurred = false;
		switch (scaleBehavior)
		{
		default:
			return IMedia.Types.ScaleBehavior.Fit;
		case ScaleBehavior.ScaleToFill:
			return IMedia.Types.ScaleBehavior.Fill;
		case ScaleBehavior.CustomFit:
			return IMedia.Types.ScaleBehavior.Custom;
		case ScaleBehavior.StretchToFill:
			return IMedia.Types.ScaleBehavior.Stretch;
		case ScaleBehavior.ScaleAndBlur:
			isBlurred = true;
			return IMedia.Types.ScaleBehavior.Fit;
		}
	}

	public static void FindMedia(this MediaBase media, Action<string> callback)
	{
		if (media is FileMediaBase fileMediaBase && fileMediaBase.SourceFile.IsValid && FilenameExtensions.IsMediaFile(fileMediaBase.SourceFile))
		{
			callback?.Invoke(fileMediaBase.SourceFile);
		}
	}

	public static bool IsValidMediaFilenameToHandle(this string filepath)
	{
		try
		{
			if (string.IsNullOrWhiteSpace(filepath))
			{
				return false;
			}
			if (!filepath.IsVisualMediaFile())
			{
				return false;
			}
			if (Path.GetFileName(filepath).StartsWith("~$"))
			{
				return false;
			}
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public static bool CanDropFile(IEnumerable<FileInfo> files, IPlaylist<MediaCue>? playlist)
	{
		if (files.All((FileInfo f) => f.Attributes == FileAttributes.Directory || f.FullName.IsVisualMediaFile()))
		{
			if (playlist != null)
			{
				return playlist.Type == PlaylistType.Custom;
			}
			return true;
		}
		return false;
	}

	public static bool CanDropFile(IEnumerable<string> files, IPlaylist<MediaCue>? playlist)
	{
		if (files.All((string f) => f.IsVisualMediaFile()))
		{
			if (playlist != null)
			{
				return playlist.Type == PlaylistType.Custom;
			}
			return true;
		}
		return false;
	}

	public static void UpdatePropertiesForTimeline(this MediaAction mediaAction)
	{
		if (mediaAction != null)
		{
			if (mediaAction.Media.MediaType.IsAnyOf(MediaType.Video, MediaType.Image))
			{
				mediaAction.TriggerLayer = TriggerLayer.Background;
			}
			else if (mediaAction.Media.MediaType == MediaType.Audio)
			{
				mediaAction.AudioMedia.AudioType = AudioType.AudioTrack;
			}
		}
	}

	public static void InsertPlaylist(this VisualPlaylist playlist, IVisualPlaylistCollection playlists, Guid? selectedPlaylistId)
	{
		int index = -1;
		VisualGroupPlaylist visualGroupPlaylist = null;
		if (playlists != null && !playlists.GetPlaylists((IPlaylist<MediaCue> p) => p.ID == playlist.ID).Any())
		{
			IPlaylist<MediaCue> playlist2 = ((!selectedPlaylistId.HasValue) ? null : playlists.GetPlaylists((IPlaylist<MediaCue> p) => p.ID == selectedPlaylistId.Value)?.FirstOrDefault());
			if (playlist2 is VisualPlaylist visualPlaylist)
			{
				visualGroupPlaylist = visualPlaylist.PlaylistParent as VisualGroupPlaylist;
				index = ((visualGroupPlaylist != null) ? (visualGroupPlaylist.IndexOf(visualPlaylist) + 1) : (-1));
			}
			else if (playlist2 is VisualGroupPlaylist visualGroupPlaylist2)
			{
				visualGroupPlaylist = visualGroupPlaylist2;
			}
			playlists.AddPlaylist(playlist, visualGroupPlaylist, index);
		}
	}

	[IteratorStateMachine(typeof(_003CFindAllMedia_003Ed__15))]
	public static IEnumerable<MediaBase> FindAllMedia(this ClosedBezierPath closedBezierPath)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CFindAllMedia_003Ed__15(-2)
		{
			_003C_003E3__closedBezierPath = closedBezierPath
		};
	}

	public static IEnumerable<string> FindAllMediaFiles(this IEnumerable<SlideElementBase>? elements)
	{
		return (from m in elements?.FindAllMedia().OfType<FileMediaBase>()
			select m.SourceFile.FullPath into f
			where !string.IsNullOrEmpty(f)
			select (f)) ?? Enumerable.Empty<string>();
	}

	public static IEnumerable<MediaBase> FindAllMedia(this IEnumerable<SlideElementBase>? elements)
	{
		return elements?.OfType<ClosedBezierPath>().SelectMany((ClosedBezierPath c) => c.FindAllMedia()).NonNull() ?? Enumerable.Empty<MediaBase>();
	}

	public static IEnumerable<MediaFill> FindAllMediaFill(this IEnumerable<SlideElementBase>? elements)
	{
		return (from c in elements?.OfType<ClosedBezierPath>()
			select (c.Fill is MediaFill mediaFill) ? mediaFill : null).NonNull() ?? Enumerable.Empty<MediaFill>();
	}

	[IteratorStateMachine(typeof(_003CFindAllMediaTextFill_003Ed__19))]
	public static IEnumerable<MediaTextFill> FindAllMediaTextFill(this IEnumerable<SlideElementBase>? elements)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CFindAllMediaTextFill_003Ed__19(-2)
		{
			_003C_003E3__elements = elements
		};
	}

	[IteratorStateMachine(typeof(_003CFindAllMedia_003Ed__20))]
	public static IEnumerable<MediaBase> FindAllMedia(this IEnumerable<Pro.DO.Triggering.IAction> actions)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CFindAllMedia_003Ed__20(-2)
		{
			_003C_003E3__actions = actions
		};
	}

	public static IEnumerable<string> FindAllMediaFiles(this IEnumerable<Pro.DO.Triggering.IAction> actions)
	{
		return (from m in actions.FindAllMedia().OfType<FileMediaBase>()
			select m.SourceFile.FullPath).NonNull();
	}

	public static IEnumerable<MediaBase> FindAllMedia(this IPlaylist<MediaCue> playlist)
	{
		return playlist.SelectMany((MediaCue c) => c.Actions.FindAllMedia());
	}

	public static IEnumerable<MediaBase> FindAllMedia(this IPlaylist<ProPresenterCue> playlist)
	{
		return playlist.SelectMany((ProPresenterCue c) => c.Actions.FindAllMedia());
	}

	public static IEnumerable<string> GetAllMediaFiles(IProPresenterResourceService resourceService, IAudienceLookCollection looks, IMaskCollection masks)
	{
		List<string> list = new List<string>();
		foreach (ProPresenter.DO.Librarian.ILibrary item in resourceService.LibraryCollection)
		{
			foreach (DocumentCue item2 in item)
			{
				list.AddRange(item2.DocumentAction.Presentation?.GetAllMediaFilePaths() ?? Array.Empty<string>());
			}
		}
		list.AddRange(resourceService.LibraryPlaylists.Flatten().SelectMany((IPlaylist<ProPresenterCue> playlist) => (from m in playlist.FindAllMedia().OfType<FileMediaBase>()
			select m.SourceFile.FullPath).NonNull()));
		list.AddRange(resourceService.AudioPlaylists.Flatten().SelectMany((IPlaylist<MediaCue> playlist) => (from m in playlist.FindAllMedia().OfType<FileMediaBase>()
			select m.SourceFile.FullPath).NonNull()));
		list.AddRange(resourceService.VisualPlaylists.Flatten().SelectMany((IPlaylist<MediaCue> playlist) => (from m in playlist.FindAllMedia().OfType<FileMediaBase>()
			select m.SourceFile.FullPath).NonNull()));
		list.AddRange(resourceService.MacroGroups.SelectMany((MacroGroup g) => g.SelectMany((ProPresenterMacro m) => m.Actions.FindAllMediaFiles())));
		foreach (IPropGroup item3 in resourceService.PropGroupCollection)
		{
			foreach (IPropCue item4 in item3)
			{
				SlideElementCollection elements = (item4.SlideAction?.Slide as CustomSlide)?.Elements;
				list.AddRange(elements.FindAllMediaFiles());
				list.AddRange((from m in item4.Actions.FindAllMedia().OfType<FileMediaBase>()
					select m.SourceFile.FullPath).NonNull());
			}
		}
		if (resourceService.CCLIPresentation is CCLIPresentation cCLIPresentation)
		{
			foreach (TemplateSlide item5 in cCLIPresentation)
			{
				list.AddRange(item5.Slide.Elements.FindAllMediaFiles());
				list.AddRange((from m in item5.Actions.FindAllMedia().OfType<FileMediaBase>()
					select m.SourceFile.FullPath).NonNull());
			}
		}
		foreach (SlideCue mask in masks)
		{
			SlideElementCollection elements2 = (mask.SlideAction?.Slide as CustomSlide)?.Elements;
			list.AddRange(elements2.FindAllMediaFiles());
		}
		foreach (Theme theme in resourceService.Themes)
		{
			foreach (TemplateSlide item6 in theme)
			{
				list.AddRange(item6.Slide.Elements.FindAllMediaFiles());
				list.AddRange((from m in item6.Actions.FindAllMedia().OfType<FileMediaBase>()
					select m.SourceFile.FullPath).NonNull());
			}
		}
		foreach (SlideCue item7 in resourceService.StagePresentation?.Layouts ?? Array.Empty<SlideCue>())
		{
			if (item7.SlideAction?.Slide is CustomSlide customSlide)
			{
				SlideElementCollection elements3 = customSlide.Elements;
				list.AddRange(elements3.FindAllMediaFiles());
			}
		}
		return list.NonNull().Distinct();
	}

	[IteratorStateMachine(typeof(_003CGetProtoMediaFills_003Ed__25))]
	public static IEnumerable<Pro.SerializationInterop.RVProtoData.Media> GetProtoMediaFills(this IEnumerable<Pro.SerializationInterop.RVProtoData.Slide.Types.Element>? protoElements)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGetProtoMediaFills_003Ed__25(-2)
		{
			_003C_003E3__protoElements = protoElements
		};
	}

	public static string? GetProtoMediaFillFile(this Graphics.Types.Fill fill)
	{
		if (fill.Media != null)
		{
			return fill.Media.Image?.File?.LocalUrl.AbsoluteString ?? fill.Media.Video?.File?.LocalUrl.AbsoluteString ?? fill.Media.Audio?.File?.LocalUrl.AbsoluteString ?? null;
		}
		return null;
	}

	public static IEnumerable<Pro.SerializationInterop.RVProtoData.Media> GetProtoMediaFills(this IEnumerable<Pro.SerializationInterop.RVProtoData.Cue> cues)
	{
		if (cues != null)
		{
			List<Pro.SerializationInterop.RVProtoData.Media> list = new List<Pro.SerializationInterop.RVProtoData.Media>();
			{
				foreach (RepeatedField<Pro.SerializationInterop.RVProtoData.Slide.Types.Element> item in cues.SelectMany((Pro.SerializationInterop.RVProtoData.Cue c) => c.Actions.Select((Pro.SerializationInterop.RVProtoData.Action a) => a.Slide?.Presentation?.BaseSlide?.Elements)).NonNull())
				{
					list.AddRange(item.GetProtoMediaFills());
				}
				return list;
			}
		}
		return Enumerable.Empty<Pro.SerializationInterop.RVProtoData.Media>();
	}

	public static int FixMediaFillIds(this IEnumerable<Pro.SerializationInterop.RVProtoData.Cue> cues)
	{
		IEnumerable<IGrouping<UUID, Pro.SerializationInterop.RVProtoData.Media>> enumerable = from f in cues.GetProtoMediaFills()
			group f by f.Uuid into g
			where g.Count() > 1
			select g;
		int num = 0;
		foreach (IGrouping<UUID, Pro.SerializationInterop.RVProtoData.Media> item in enumerable)
		{
			IEnumerable<Pro.SerializationInterop.RVProtoData.Media> enumerable2 = item.Skip(1);
			num += enumerable2.Count();
			foreach (Pro.SerializationInterop.RVProtoData.Media item2 in enumerable2)
			{
				item2.Uuid = Guid.NewGuid().ToUUID();
			}
		}
		return num;
	}

	public static int FixMediaFillIds(this IEnumerable<SlideCue> cues)
	{
		int num = 0;
		foreach (SlideCue cue in cues)
		{
			IEnumerable<IGrouping<Guid, MediaBase>> enumerable = (((cue.SlideAction?.Slide as CustomSlide)?.Elements).FindAllMedia()?.GroupBy((MediaBase m) => m.ID))?.Where((IGrouping<Guid, MediaBase> g) => g.Count() > 1);
			if (enumerable == null)
			{
				continue;
			}
			foreach (IGrouping<Guid, MediaBase> item in enumerable)
			{
				IEnumerable<MediaBase> enumerable2 = item.Skip(1);
				num += enumerable2.Count();
				foreach (MediaBase item2 in enumerable2)
				{
					item2.ResetId();
				}
			}
		}
		return num;
	}

	public static async Task<IEnumerable<string>> GetUnlinkedMediaFilesAsync(IProPresenterResourceService resourceService, IAudienceLookCollection looks, IFileSystem fileSystem, IMaskCollection masks)
	{
		return await Task.Run(delegate
		{
			if (!fileSystem.Directory.Exists(CommonPaths.Media) && !fileSystem.Directory.Exists(CommonPaths.Themes))
			{
				return Enumerable.Empty<string>();
			}
			string[] mediaFileExtensions = FileExtensions.AudioExtensions.SupportedExtensions.Union(FileExtensions.VideoExtensions.SupportedExtensions).Union(FileExtensions.ImageExtensions.SupportedExtensions).ToArray();
			if (!mediaFileExtensions.Any())
			{
				return Enumerable.Empty<string>();
			}
			IEnumerable<string> allMediaFiles = GetAllMediaFiles(resourceService, looks, masks);
			IEnumerable<string> first = from s in fileSystem.Directory.EnumerateFiles(CommonPaths.Media, "*.*", SearchOption.AllDirectories)
				where mediaFileExtensions.Any((string ext) => string.Equals(ext, Path.GetExtension(s), StringComparison.OrdinalIgnoreCase))
				select s;
			IEnumerable<string> second = from s in fileSystem.Directory.EnumerateFiles(CommonPaths.Themes, "*.*", SearchOption.AllDirectories)
				where mediaFileExtensions.Any((string ext) => string.Equals(ext, Path.GetExtension(s), StringComparison.OrdinalIgnoreCase))
				select s;
			return first.Concat(second).Except(allMediaFiles);
		});
	}

	public static Pro.SerializationInterop.RVProtoData.Media.Types.ScaleAlignment ToProtoScaleAlignment(this ScaleAlignment source)
	{
		return source switch
		{
			ScaleAlignment.TopLeft => Pro.SerializationInterop.RVProtoData.Media.Types.ScaleAlignment.TopLeft, 
			ScaleAlignment.TopCenter => Pro.SerializationInterop.RVProtoData.Media.Types.ScaleAlignment.TopCenter, 
			ScaleAlignment.TopRight => Pro.SerializationInterop.RVProtoData.Media.Types.ScaleAlignment.TopRight, 
			ScaleAlignment.MiddleLeft => Pro.SerializationInterop.RVProtoData.Media.Types.ScaleAlignment.MiddleLeft, 
			ScaleAlignment.MiddleCenter => Pro.SerializationInterop.RVProtoData.Media.Types.ScaleAlignment.MiddleCenter, 
			ScaleAlignment.MiddleRight => Pro.SerializationInterop.RVProtoData.Media.Types.ScaleAlignment.MiddleRight, 
			ScaleAlignment.BottomLeft => Pro.SerializationInterop.RVProtoData.Media.Types.ScaleAlignment.BottomLeft, 
			ScaleAlignment.BottomCenter => Pro.SerializationInterop.RVProtoData.Media.Types.ScaleAlignment.BottomCenter, 
			ScaleAlignment.BottomRight => Pro.SerializationInterop.RVProtoData.Media.Types.ScaleAlignment.BottomRight, 
			_ => Pro.SerializationInterop.RVProtoData.Media.Types.ScaleAlignment.MiddleCenter, 
		};
	}

	public static ScaleAlignment ToScaleAlignment(this Pro.SerializationInterop.RVProtoData.Media.Types.ScaleAlignment source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Media.Types.ScaleAlignment.MiddleCenter => ScaleAlignment.MiddleCenter, 
			Pro.SerializationInterop.RVProtoData.Media.Types.ScaleAlignment.TopLeft => ScaleAlignment.TopLeft, 
			Pro.SerializationInterop.RVProtoData.Media.Types.ScaleAlignment.TopCenter => ScaleAlignment.TopCenter, 
			Pro.SerializationInterop.RVProtoData.Media.Types.ScaleAlignment.TopRight => ScaleAlignment.TopRight, 
			Pro.SerializationInterop.RVProtoData.Media.Types.ScaleAlignment.MiddleRight => ScaleAlignment.MiddleRight, 
			Pro.SerializationInterop.RVProtoData.Media.Types.ScaleAlignment.BottomRight => ScaleAlignment.BottomRight, 
			Pro.SerializationInterop.RVProtoData.Media.Types.ScaleAlignment.BottomCenter => ScaleAlignment.BottomCenter, 
			Pro.SerializationInterop.RVProtoData.Media.Types.ScaleAlignment.BottomLeft => ScaleAlignment.BottomLeft, 
			Pro.SerializationInterop.RVProtoData.Media.Types.ScaleAlignment.MiddleLeft => ScaleAlignment.MiddleLeft, 
			_ => ScaleAlignment.MiddleCenter, 
		};
	}

	public static IMedia.Types.ScaleAlignment ToEntityScaleAlignment(this ScaleAlignment source)
	{
		return source switch
		{
			ScaleAlignment.TopLeft => IMedia.Types.ScaleAlignment.TopLeft, 
			ScaleAlignment.TopCenter => IMedia.Types.ScaleAlignment.TopCenter, 
			ScaleAlignment.TopRight => IMedia.Types.ScaleAlignment.TopRight, 
			ScaleAlignment.MiddleLeft => IMedia.Types.ScaleAlignment.MiddleLeft, 
			ScaleAlignment.MiddleCenter => IMedia.Types.ScaleAlignment.MiddleCenter, 
			ScaleAlignment.MiddleRight => IMedia.Types.ScaleAlignment.MiddleRight, 
			ScaleAlignment.BottomLeft => IMedia.Types.ScaleAlignment.BottomLeft, 
			ScaleAlignment.BottomCenter => IMedia.Types.ScaleAlignment.BottomCenter, 
			ScaleAlignment.BottomRight => IMedia.Types.ScaleAlignment.BottomRight, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static ScaleAlignment ToScaleAlignment(this IMedia.Types.ScaleAlignment source)
	{
		return source switch
		{
			IMedia.Types.ScaleAlignment.MiddleCenter => ScaleAlignment.MiddleCenter, 
			IMedia.Types.ScaleAlignment.TopLeft => ScaleAlignment.TopLeft, 
			IMedia.Types.ScaleAlignment.TopCenter => ScaleAlignment.TopCenter, 
			IMedia.Types.ScaleAlignment.TopRight => ScaleAlignment.TopRight, 
			IMedia.Types.ScaleAlignment.MiddleRight => ScaleAlignment.MiddleRight, 
			IMedia.Types.ScaleAlignment.BottomRight => ScaleAlignment.BottomRight, 
			IMedia.Types.ScaleAlignment.BottomCenter => ScaleAlignment.BottomCenter, 
			IMedia.Types.ScaleAlignment.BottomLeft => ScaleAlignment.BottomLeft, 
			IMedia.Types.ScaleAlignment.MiddleLeft => ScaleAlignment.MiddleLeft, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static Pro.SerializationInterop.RVProtoData.Media.Types.TransportProperties.Types.PlaybackBehavior GetProtoPlaybackBehavior(this PlaybackBehaviorType source)
	{
		return source switch
		{
			PlaybackBehaviorType.Stop => Pro.SerializationInterop.RVProtoData.Media.Types.TransportProperties.Types.PlaybackBehavior.Stop, 
			PlaybackBehaviorType.Loop => Pro.SerializationInterop.RVProtoData.Media.Types.TransportProperties.Types.PlaybackBehavior.Loop, 
			PlaybackBehaviorType.LoopForCount => Pro.SerializationInterop.RVProtoData.Media.Types.TransportProperties.Types.PlaybackBehavior.LoopForCount, 
			PlaybackBehaviorType.LoopForTime => Pro.SerializationInterop.RVProtoData.Media.Types.TransportProperties.Types.PlaybackBehavior.LoopForTime, 
			_ => Pro.SerializationInterop.RVProtoData.Media.Types.TransportProperties.Types.PlaybackBehavior.Stop, 
		};
	}

	public static PlaybackBehaviorType GetPlaybackBehaviorType(this Pro.SerializationInterop.RVProtoData.Media.Types.TransportProperties.Types.PlaybackBehavior source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Media.Types.TransportProperties.Types.PlaybackBehavior.Stop => PlaybackBehaviorType.Stop, 
			Pro.SerializationInterop.RVProtoData.Media.Types.TransportProperties.Types.PlaybackBehavior.Loop => PlaybackBehaviorType.Loop, 
			Pro.SerializationInterop.RVProtoData.Media.Types.TransportProperties.Types.PlaybackBehavior.LoopForCount => PlaybackBehaviorType.LoopForCount, 
			Pro.SerializationInterop.RVProtoData.Media.Types.TransportProperties.Types.PlaybackBehavior.LoopForTime => PlaybackBehaviorType.LoopForTime, 
			_ => PlaybackBehaviorType.Stop, 
		};
	}

	public static IMedia.Types.ITransportProperties.Types.PlaybackBehavior ToEntityPlaybackBehavior(this PlaybackBehaviorType source)
	{
		return source switch
		{
			PlaybackBehaviorType.Stop => IMedia.Types.ITransportProperties.Types.PlaybackBehavior.Stop, 
			PlaybackBehaviorType.Loop => IMedia.Types.ITransportProperties.Types.PlaybackBehavior.Loop, 
			PlaybackBehaviorType.LoopForCount => IMedia.Types.ITransportProperties.Types.PlaybackBehavior.LoopForCount, 
			PlaybackBehaviorType.LoopForTime => IMedia.Types.ITransportProperties.Types.PlaybackBehavior.LoopForTime, 
			_ => IMedia.Types.ITransportProperties.Types.PlaybackBehavior.Stop, 
		};
	}

	public static PlaybackBehaviorType ToPlaybackBehaviorType(this IMedia.Types.ITransportProperties.Types.PlaybackBehavior source)
	{
		return source switch
		{
			IMedia.Types.ITransportProperties.Types.PlaybackBehavior.Stop => PlaybackBehaviorType.Stop, 
			IMedia.Types.ITransportProperties.Types.PlaybackBehavior.Loop => PlaybackBehaviorType.Loop, 
			IMedia.Types.ITransportProperties.Types.PlaybackBehavior.LoopForCount => PlaybackBehaviorType.LoopForCount, 
			IMedia.Types.ITransportProperties.Types.PlaybackBehavior.LoopForTime => PlaybackBehaviorType.LoopForTime, 
			_ => PlaybackBehaviorType.Stop, 
		};
	}

	public static Pro.SerializationInterop.RVProtoData.Media.Types.VideoProperties.Types.EndBehavior GetProtoEndBehavior(this EndBehaviorType source)
	{
		return source switch
		{
			EndBehaviorType.HoldLastFrame => Pro.SerializationInterop.RVProtoData.Media.Types.VideoProperties.Types.EndBehavior.Stop, 
			EndBehaviorType.BlackAfterLastFrame => Pro.SerializationInterop.RVProtoData.Media.Types.VideoProperties.Types.EndBehavior.StopOnBlack, 
			EndBehaviorType.ClearAfterLastFrame => Pro.SerializationInterop.RVProtoData.Media.Types.VideoProperties.Types.EndBehavior.StopOnClear, 
			EndBehaviorType.FadeToBlack => Pro.SerializationInterop.RVProtoData.Media.Types.VideoProperties.Types.EndBehavior.FadeToBlack, 
			EndBehaviorType.FadeToClear => Pro.SerializationInterop.RVProtoData.Media.Types.VideoProperties.Types.EndBehavior.FadeToClear, 
			_ => Pro.SerializationInterop.RVProtoData.Media.Types.VideoProperties.Types.EndBehavior.Stop, 
		};
	}

	public static EndBehaviorType GetEndBehaviorType(this Pro.SerializationInterop.RVProtoData.Media.Types.VideoProperties.Types.EndBehavior source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Media.Types.VideoProperties.Types.EndBehavior.Stop => EndBehaviorType.HoldLastFrame, 
			Pro.SerializationInterop.RVProtoData.Media.Types.VideoProperties.Types.EndBehavior.StopOnBlack => EndBehaviorType.BlackAfterLastFrame, 
			Pro.SerializationInterop.RVProtoData.Media.Types.VideoProperties.Types.EndBehavior.StopOnClear => EndBehaviorType.ClearAfterLastFrame, 
			Pro.SerializationInterop.RVProtoData.Media.Types.VideoProperties.Types.EndBehavior.FadeToBlack => EndBehaviorType.FadeToBlack, 
			Pro.SerializationInterop.RVProtoData.Media.Types.VideoProperties.Types.EndBehavior.FadeToClear => EndBehaviorType.FadeToClear, 
			_ => EndBehaviorType.HoldLastFrame, 
		};
	}

	public static IMedia.Types.IVideoProperties.Types.EndBehavior ToEntityEndBehavior(this EndBehaviorType source)
	{
		return source switch
		{
			EndBehaviorType.HoldLastFrame => IMedia.Types.IVideoProperties.Types.EndBehavior.Stop, 
			EndBehaviorType.BlackAfterLastFrame => IMedia.Types.IVideoProperties.Types.EndBehavior.StopOnBlack, 
			EndBehaviorType.ClearAfterLastFrame => IMedia.Types.IVideoProperties.Types.EndBehavior.StopOnClear, 
			EndBehaviorType.FadeToBlack => IMedia.Types.IVideoProperties.Types.EndBehavior.FadeToBlack, 
			EndBehaviorType.FadeToClear => IMedia.Types.IVideoProperties.Types.EndBehavior.FadeToClear, 
			_ => IMedia.Types.IVideoProperties.Types.EndBehavior.Stop, 
		};
	}

	public static EndBehaviorType ToEndBehaviorType(this IMedia.Types.IVideoProperties.Types.EndBehavior source)
	{
		return source switch
		{
			IMedia.Types.IVideoProperties.Types.EndBehavior.Stop => EndBehaviorType.HoldLastFrame, 
			IMedia.Types.IVideoProperties.Types.EndBehavior.StopOnBlack => EndBehaviorType.BlackAfterLastFrame, 
			IMedia.Types.IVideoProperties.Types.EndBehavior.StopOnClear => EndBehaviorType.ClearAfterLastFrame, 
			IMedia.Types.IVideoProperties.Types.EndBehavior.FadeToBlack => EndBehaviorType.FadeToBlack, 
			IMedia.Types.IVideoProperties.Types.EndBehavior.FadeToClear => EndBehaviorType.FadeToClear, 
			_ => EndBehaviorType.HoldLastFrame, 
		};
	}

	public static Pro.SerializationInterop.RVProtoData.Action.Types.MediaType.Types.Audio.Types.MediaActionAudioType ToProtoAudioType(this AudioType source)
	{
		return source switch
		{
			AudioType.AudioTrack => Pro.SerializationInterop.RVProtoData.Action.Types.MediaType.Types.Audio.Types.MediaActionAudioType.Tune, 
			AudioType.SoundEffect => Pro.SerializationInterop.RVProtoData.Action.Types.MediaType.Types.Audio.Types.MediaActionAudioType.Sound, 
			_ => Pro.SerializationInterop.RVProtoData.Action.Types.MediaType.Types.Audio.Types.MediaActionAudioType.Tune, 
		};
	}

	public static AudioType ToAudioType(this Pro.SerializationInterop.RVProtoData.Action.Types.MediaType.Types.Audio.Types.MediaActionAudioType source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Action.Types.MediaType.Types.Audio.Types.MediaActionAudioType.Tune => AudioType.AudioTrack, 
			Pro.SerializationInterop.RVProtoData.Action.Types.MediaType.Types.Audio.Types.MediaActionAudioType.Sound => AudioType.SoundEffect, 
			_ => AudioType.AudioTrack, 
		};
	}

	public static Pro.SerializationInterop.RVProtoData.Media.Types.TransportProperties.Types.RetriggerSetting GetProtoRetriggerBehavior(this RetriggerBehavior source)
	{
		return source switch
		{
			RetriggerBehavior.Unset => Pro.SerializationInterop.RVProtoData.Media.Types.TransportProperties.Types.RetriggerSetting.Unset, 
			RetriggerBehavior.Always => Pro.SerializationInterop.RVProtoData.Media.Types.TransportProperties.Types.RetriggerSetting.Always, 
			RetriggerBehavior.Never => Pro.SerializationInterop.RVProtoData.Media.Types.TransportProperties.Types.RetriggerSetting.Never, 
			RetriggerBehavior.Automatic => Pro.SerializationInterop.RVProtoData.Media.Types.TransportProperties.Types.RetriggerSetting.Automatic, 
			_ => Pro.SerializationInterop.RVProtoData.Media.Types.TransportProperties.Types.RetriggerSetting.Unset, 
		};
	}

	public static RetriggerBehavior GetRetriggerBehavior(this Pro.SerializationInterop.RVProtoData.Media.Types.TransportProperties.Types.RetriggerSetting source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Media.Types.TransportProperties.Types.RetriggerSetting.Unset => RetriggerBehavior.Unset, 
			Pro.SerializationInterop.RVProtoData.Media.Types.TransportProperties.Types.RetriggerSetting.Always => RetriggerBehavior.Always, 
			Pro.SerializationInterop.RVProtoData.Media.Types.TransportProperties.Types.RetriggerSetting.Never => RetriggerBehavior.Never, 
			Pro.SerializationInterop.RVProtoData.Media.Types.TransportProperties.Types.RetriggerSetting.Automatic => RetriggerBehavior.Automatic, 
			_ => RetriggerBehavior.Unset, 
		};
	}

	public static IMedia.Types.ITransportProperties.Types.RetriggerSetting ToEntityRetriggerBehavior(this RetriggerBehavior source)
	{
		return source switch
		{
			RetriggerBehavior.Unset => IMedia.Types.ITransportProperties.Types.RetriggerSetting.Unset, 
			RetriggerBehavior.Always => IMedia.Types.ITransportProperties.Types.RetriggerSetting.Always, 
			RetriggerBehavior.Never => IMedia.Types.ITransportProperties.Types.RetriggerSetting.Never, 
			RetriggerBehavior.Automatic => IMedia.Types.ITransportProperties.Types.RetriggerSetting.Automatic, 
			_ => IMedia.Types.ITransportProperties.Types.RetriggerSetting.Unset, 
		};
	}

	public static RetriggerBehavior ToRetriggerBehavior(this IMedia.Types.ITransportProperties.Types.RetriggerSetting source)
	{
		return source switch
		{
			IMedia.Types.ITransportProperties.Types.RetriggerSetting.Unset => RetriggerBehavior.Unset, 
			IMedia.Types.ITransportProperties.Types.RetriggerSetting.Always => RetriggerBehavior.Always, 
			IMedia.Types.ITransportProperties.Types.RetriggerSetting.Never => RetriggerBehavior.Never, 
			IMedia.Types.ITransportProperties.Types.RetriggerSetting.Automatic => RetriggerBehavior.Automatic, 
			_ => RetriggerBehavior.Unset, 
		};
	}
}
