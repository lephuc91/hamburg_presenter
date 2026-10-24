using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.UI;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ClearGroupsChangeVisibility : IMessage<ClearGroupsChangeVisibility>, IMessage, IEquatable<ClearGroupsChangeVisibility>, IDeepCloneable<ClearGroupsChangeVisibility>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum Visibility
		{
			[OriginalName("VISIBILITY_UNKNOWN")]
			Unknown,
			[OriginalName("SHOWN")]
			Shown,
			[OriginalName("HIDDEN")]
			Hidden
		}
	}

	private static readonly MessageParser<ClearGroupsChangeVisibility> _parser = new MessageParser<ClearGroupsChangeVisibility>(() => new ClearGroupsChangeVisibility());

	private UnknownFieldSet _unknownFields;

	public const int VisibilityFieldNumber = 1;

	private Types.Visibility visibility_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ClearGroupsChangeVisibility> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsUIReflection.Descriptor.MessageTypes[62];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Visibility Visibility
	{
		get
		{
			return visibility_;
		}
		set
		{
			visibility_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ClearGroupsChangeVisibility()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ClearGroupsChangeVisibility(ClearGroupsChangeVisibility other)
		: this()
	{
		visibility_ = other.visibility_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ClearGroupsChangeVisibility Clone()
	{
		return new ClearGroupsChangeVisibility(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ClearGroupsChangeVisibility);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ClearGroupsChangeVisibility other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Visibility != other.Visibility)
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
		if (Visibility != 0)
		{
			num ^= Visibility.GetHashCode();
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
		if (Visibility != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)Visibility);
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
		if (Visibility != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Visibility);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ClearGroupsChangeVisibility other)
	{
		if (other != null)
		{
			if (other.Visibility != 0)
			{
				Visibility = other.Visibility;
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
				Visibility = (Types.Visibility)input.ReadEnum();
			}
		}
	}
}
