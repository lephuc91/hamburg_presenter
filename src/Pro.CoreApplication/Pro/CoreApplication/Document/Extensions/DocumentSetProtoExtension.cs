using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Pro.CoreApplication.Document.Intrinsic;
using Pro.CoreApplication.Document.Presentation;
using Pro.CoreApplication.Document.Theme;
using Pro.SerializationInterop.RVProtoData.Service.Document;

namespace Pro.CoreApplication.Document.Extensions;

internal static class DocumentSetProtoExtension
{
	[CompilerGenerated]
	private sealed class _003CToDocuments_003Ed__0 : IEnumerable<IDocument>, IEnumerable, IEnumerator<IDocument>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private IDocument _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private DocumentSet documentSet;

		public DocumentSet _003C_003E3__documentSet;

		private IEnumerator<Pro.SerializationInterop.RVProtoData.Service.Document.Intrinsic> _003C_003E7__wrap1;

		private IEnumerator<Pro.SerializationInterop.RVProtoData.Service.Document.Document> _003C_003E7__wrap2;

		IDocument IEnumerator<IDocument>.Current
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
		public _003CToDocuments_003Ed__0(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			switch (_003C_003E1__state)
			{
			case -3:
			case 1:
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
				break;
			case -4:
			case 2:
				try
				{
				}
				finally
				{
					_003C_003Em__Finally2();
				}
				break;
			case -5:
			case 3:
				try
				{
				}
				finally
				{
					_003C_003Em__Finally3();
				}
				break;
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
					_003C_003E7__wrap1 = documentSet.Intrinsics.GetEnumerator();
					_003C_003E1__state = -3;
					goto IL_0079;
				case 1:
					_003C_003E1__state = -3;
					goto IL_0079;
				case 2:
					_003C_003E1__state = -4;
					goto IL_00e1;
				case 3:
					{
						_003C_003E1__state = -5;
						break;
					}
					IL_0079:
					if (_003C_003E7__wrap1.MoveNext())
					{
						Pro.SerializationInterop.RVProtoData.Service.Document.Intrinsic current = _003C_003E7__wrap1.Current;
						_003C_003E2__current = current.ToIntrinsicDocument();
						_003C_003E1__state = 1;
						return true;
					}
					_003C_003Em__Finally1();
					_003C_003E7__wrap1 = null;
					_003C_003E7__wrap2 = documentSet.Presentations.GetEnumerator();
					_003C_003E1__state = -4;
					goto IL_00e1;
					IL_00e1:
					if (_003C_003E7__wrap2.MoveNext())
					{
						Pro.SerializationInterop.RVProtoData.Service.Document.Document current2 = _003C_003E7__wrap2.Current;
						_003C_003E2__current = current2.ToPresentationDocument();
						_003C_003E1__state = 2;
						return true;
					}
					_003C_003Em__Finally2();
					_003C_003E7__wrap2 = null;
					_003C_003E7__wrap2 = documentSet.Themes.GetEnumerator();
					_003C_003E1__state = -5;
					break;
				}
				if (_003C_003E7__wrap2.MoveNext())
				{
					Pro.SerializationInterop.RVProtoData.Service.Document.Document current3 = _003C_003E7__wrap2.Current;
					_003C_003E2__current = current3.ToThemeDocument();
					_003C_003E1__state = 3;
					return true;
				}
				_003C_003Em__Finally3();
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
			if (_003C_003E7__wrap1 != null)
			{
				_003C_003E7__wrap1.Dispose();
			}
		}

		private void _003C_003Em__Finally2()
		{
			_003C_003E1__state = -1;
			if (_003C_003E7__wrap2 != null)
			{
				_003C_003E7__wrap2.Dispose();
			}
		}

		private void _003C_003Em__Finally3()
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
		IEnumerator<IDocument> IEnumerable<IDocument>.GetEnumerator()
		{
			_003CToDocuments_003Ed__0 _003CToDocuments_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CToDocuments_003Ed__ = this;
			}
			else
			{
				_003CToDocuments_003Ed__ = new _003CToDocuments_003Ed__0(0);
			}
			_003CToDocuments_003Ed__.documentSet = _003C_003E3__documentSet;
			return _003CToDocuments_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<IDocument>)this).GetEnumerator();
		}
	}

	[IteratorStateMachine(typeof(_003CToDocuments_003Ed__0))]
	public static IEnumerable<IDocument> ToDocuments(this DocumentSet documentSet)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CToDocuments_003Ed__0(-2)
		{
			_003C_003E3__documentSet = documentSet
		};
	}

	private static IDocument ToIntrinsicDocument(this Pro.SerializationInterop.RVProtoData.Service.Document.Intrinsic intrinsic)
	{
		Guid id = Guid.Parse(intrinsic.Uuid);
		byte[] data = intrinsic.Body.ToByteArray();
		return intrinsic.Kind switch
		{
			Pro.SerializationInterop.RVProtoData.Service.Document.Intrinsic.Types.Kind.Workspace => new WorkspaceDocument(data, id), 
			Pro.SerializationInterop.RVProtoData.Service.Document.Intrinsic.Types.Kind.Timers => new TimersDocument(data, id), 
			Pro.SerializationInterop.RVProtoData.Service.Document.Intrinsic.Types.Kind.Props => new PropsDocument(data, id), 
			Pro.SerializationInterop.RVProtoData.Service.Document.Intrinsic.Types.Kind.Labels => new LabelsDocument(data, id), 
			Pro.SerializationInterop.RVProtoData.Service.Document.Intrinsic.Types.Kind.Macros => new MacrosDocument(data, id), 
			Pro.SerializationInterop.RVProtoData.Service.Document.Intrinsic.Types.Kind.Messages => new MessagesDocument(data, id), 
			Pro.SerializationInterop.RVProtoData.Service.Document.Intrinsic.Types.Kind.Stage => new StageDocument(data, id), 
			Pro.SerializationInterop.RVProtoData.Service.Document.Intrinsic.Types.Kind.KeyMappings => new KeyMappingsDocument(data, id), 
			Pro.SerializationInterop.RVProtoData.Service.Document.Intrinsic.Types.Kind.Groups => new GroupsDocument(data, id), 
			Pro.SerializationInterop.RVProtoData.Service.Document.Intrinsic.Types.Kind.ClearGroups => new ClearGroupsDocument(data, id), 
			Pro.SerializationInterop.RVProtoData.Service.Document.Intrinsic.Types.Kind.Calendar => new CalendarDocument(data, id), 
			Pro.SerializationInterop.RVProtoData.Service.Document.Intrinsic.Types.Kind.Ccli => new CCLIDocument(data, id), 
			Pro.SerializationInterop.RVProtoData.Service.Document.Intrinsic.Types.Kind.LibraryData => new LibraryDataDocument(data, id), 
			Pro.SerializationInterop.RVProtoData.Service.Document.Intrinsic.Types.Kind.PlaylistAudio => new PlaylistAudioDocument(data, id), 
			Pro.SerializationInterop.RVProtoData.Service.Document.Intrinsic.Types.Kind.PlaylistLibrary => new PlaylistLibraryDocument(data, id), 
			Pro.SerializationInterop.RVProtoData.Service.Document.Intrinsic.Types.Kind.PlaylistMedia => new PlaylistMediaDocument(data, id), 
			Pro.SerializationInterop.RVProtoData.Service.Document.Intrinsic.Types.Kind.PlaylistTemplates => new PlaylistTemplatesDocument(data, id), 
			_ => throw new NotSupportedException($"Intrinsic document kind '{intrinsic.Kind}' is not supported."), 
		};
	}

	private static IDocument ToPresentationDocument(this Pro.SerializationInterop.RVProtoData.Service.Document.Document protoPresentation)
	{
		Guid id = Guid.Parse(protoPresentation.Uuid);
		string path = protoPresentation.Path;
		return protoPresentation.BodyCase switch
		{
			Pro.SerializationInterop.RVProtoData.Service.Document.Document.BodyOneofCase.Ready => new ReadyPresentationDocument(path, id, protoPresentation.Ready.Data.ToByteArray()), 
			Pro.SerializationInterop.RVProtoData.Service.Document.Document.BodyOneofCase.Remote => new RemotePresentationDocument(path, id), 
			_ => throw new NotSupportedException($"Presentation document body '{protoPresentation.BodyCase}' is not supported to be received."), 
		};
	}

	private static IDocument ToThemeDocument(this Pro.SerializationInterop.RVProtoData.Service.Document.Document protoTheme)
	{
		Guid id = Guid.Parse(protoTheme.Uuid);
		string path = protoTheme.Path;
		return protoTheme.BodyCase switch
		{
			Pro.SerializationInterop.RVProtoData.Service.Document.Document.BodyOneofCase.Ready => new ReadyThemeDocument(path, id, protoTheme.Ready.Data.ToByteArray()), 
			Pro.SerializationInterop.RVProtoData.Service.Document.Document.BodyOneofCase.Remote => new RemoteThemeDocument(path, id), 
			_ => throw new NotSupportedException($"Theme document body '{protoTheme.BodyCase}' is not supported to be received."), 
		};
	}
}
