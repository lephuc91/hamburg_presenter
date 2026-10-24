using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.UI;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class MainViewStageEditor : IMessage<MainViewStageEditor>, IMessage, IEquatable<MainViewStageEditor>, IDeepCloneable<MainViewStageEditor>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum StageSource
		{
			[OriginalName("STAGE_SOURCE_UNKNOWN")]
			Unknown,
			[OriginalName("TOOLBAR")]
			Toolbar,
			[OriginalName("APPLICATION_MENU")]
			ApplicationMenu,
			[OriginalName("LOWER_RIGHT")]
			LowerRight
		}
	}

	private static readonly MessageParser<MainViewStageEditor> _parser = new MessageParser<MainViewStageEditor>(() => new MainViewStageEditor());

	private UnknownFieldSet _unknownFields;

	public const int SourceFieldNumber = 1;

	private Types.StageSource source_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<MainViewStageEditor> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsUIReflection.Descriptor.MessageTypes[19];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.StageSource Source
	{
		get
		{
			return source_;
		}
		set
		{
			source_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MainViewStageEditor()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MainViewStageEditor(MainViewStageEditor other)
		: this()
	{
		source_ = other.source_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MainViewStageEditor Clone()
	{
		return new MainViewStageEditor(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as MainViewStageEditor);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(MainViewStageEditor other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Source != other.Source)
		{
			return false;
		}
		return object.Equals(_unknownFields, other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override int GetHashCode()
	{
		int num = 1;
		if (Source != 0)
		{
			num ^= Source.GetHashCode();
		}
		if (_unknownFields != null)
		{
			num ^= _unknownFields.GetHashCode();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override string ToString()
	{
		return JsonFormatter.ToDiagnosticString(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void WriteTo(CodedOutputStream output)
	{
		if (Source != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)Source);
		}
		if (_unknownFields != null)
		{
			_unknownFields.WriteTo(output);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int CalculateSize()
	{
		int num = 0;
		if (Source != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Source);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(MainViewStageEditor other)
	{
		if (other != null)
		{
			if (other.Source != 0)
			{
				Source = other.Source;
			}
			_unknownFields = UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(CodedInputStream input)
	{
		uint num;
		while ((num = input.ReadTag()) != 0 && (num & 7) != 4)
		{
			if (num != 8)
			{
				_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
			}
			else
			{
				Source = (Types.StageSource)input.ReadEnum();
			}
		}
	}
}
