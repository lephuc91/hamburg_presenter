using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class SlideElementTextRenderInfo : IMessage<SlideElementTextRenderInfo>, IMessage, IEquatable<SlideElementTextRenderInfo>, IDeepCloneable<SlideElementTextRenderInfo>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum LayerType
		{
			[OriginalName("LAYER_TYPE_COMPOSITE")]
			Composite,
			[OriginalName("LAYER_TYPE_MASK")]
			Mask,
			[OriginalName("LAYER_TYPE_OVER")]
			Over,
			[OriginalName("LAYER_TYPE_UNDER")]
			Under
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Layer : IMessage<Layer>, IMessage, IEquatable<Layer>, IDeepCloneable<Layer>
		{
			public enum AdvancedFillOneofCase
			{
				None = 0,
				CutOutFill = 2,
				MediaFill = 3,
				BackgroundEffect = 4
			}

			private static readonly MessageParser<Layer> _parser = new MessageParser<Layer>(() => new Layer());

			private UnknownFieldSet _unknownFields;

			public const int LayerTypeFieldNumber = 1;

			private LayerType layerType_;

			public const int CutOutFillFieldNumber = 2;

			public const int MediaFillFieldNumber = 3;

			public const int BackgroundEffectFieldNumber = 4;

			public const int TextBuildIndexFieldNumber = 5;

			private int textBuildIndex_;

			private object advancedFill_;

			private AdvancedFillOneofCase advancedFillCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Layer> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => SlideElementTextRenderInfo.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public LayerType LayerType
			{
				get
				{
					return layerType_;
				}
				set
				{
					layerType_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Graphics.Types.Text.Types.CutOutFill CutOutFill
			{
				get
				{
					if (advancedFillCase_ != AdvancedFillOneofCase.CutOutFill)
					{
						return null;
					}
					return (Graphics.Types.Text.Types.CutOutFill)advancedFill_;
				}
				set
				{
					advancedFill_ = value;
					advancedFillCase_ = ((value != null) ? AdvancedFillOneofCase.CutOutFill : AdvancedFillOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Graphics.Types.Text.Types.MediaFill MediaFill
			{
				get
				{
					if (advancedFillCase_ != AdvancedFillOneofCase.MediaFill)
					{
						return null;
					}
					return (Graphics.Types.Text.Types.MediaFill)advancedFill_;
				}
				set
				{
					advancedFill_ = value;
					advancedFillCase_ = ((value != null) ? AdvancedFillOneofCase.MediaFill : AdvancedFillOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Graphics.Types.BackgroundEffect BackgroundEffect
			{
				get
				{
					if (advancedFillCase_ != AdvancedFillOneofCase.BackgroundEffect)
					{
						return null;
					}
					return (Graphics.Types.BackgroundEffect)advancedFill_;
				}
				set
				{
					advancedFill_ = value;
					advancedFillCase_ = ((value != null) ? AdvancedFillOneofCase.BackgroundEffect : AdvancedFillOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int TextBuildIndex
			{
				get
				{
					return textBuildIndex_;
				}
				set
				{
					textBuildIndex_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AdvancedFillOneofCase AdvancedFillCase => advancedFillCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Layer()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Layer(Layer other)
				: this()
			{
				layerType_ = other.layerType_;
				textBuildIndex_ = other.textBuildIndex_;
				switch (other.AdvancedFillCase)
				{
				case AdvancedFillOneofCase.CutOutFill:
					CutOutFill = other.CutOutFill.Clone();
					break;
				case AdvancedFillOneofCase.MediaFill:
					MediaFill = other.MediaFill.Clone();
					break;
				case AdvancedFillOneofCase.BackgroundEffect:
					BackgroundEffect = other.BackgroundEffect.Clone();
					break;
				}
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Layer Clone()
			{
				return new Layer(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearAdvancedFill()
			{
				advancedFillCase_ = AdvancedFillOneofCase.None;
				advancedFill_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Layer);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Layer other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (LayerType != other.LayerType)
				{
					return false;
				}
				if (!object.Equals(CutOutFill, other.CutOutFill))
				{
					return false;
				}
				if (!object.Equals(MediaFill, other.MediaFill))
				{
					return false;
				}
				if (!object.Equals(BackgroundEffect, other.BackgroundEffect))
				{
					return false;
				}
				if (TextBuildIndex != other.TextBuildIndex)
				{
					return false;
				}
				if (AdvancedFillCase != other.AdvancedFillCase)
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
				if (LayerType != 0)
				{
					num ^= LayerType.GetHashCode();
				}
				if (advancedFillCase_ == AdvancedFillOneofCase.CutOutFill)
				{
					num ^= CutOutFill.GetHashCode();
				}
				if (advancedFillCase_ == AdvancedFillOneofCase.MediaFill)
				{
					num ^= MediaFill.GetHashCode();
				}
				if (advancedFillCase_ == AdvancedFillOneofCase.BackgroundEffect)
				{
					num ^= BackgroundEffect.GetHashCode();
				}
				if (TextBuildIndex != 0)
				{
					num ^= TextBuildIndex.GetHashCode();
				}
				num ^= (int)advancedFillCase_;
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
				if (LayerType != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)LayerType);
				}
				if (advancedFillCase_ == AdvancedFillOneofCase.CutOutFill)
				{
					output.WriteRawTag(18);
					output.WriteMessage(CutOutFill);
				}
				if (advancedFillCase_ == AdvancedFillOneofCase.MediaFill)
				{
					output.WriteRawTag(26);
					output.WriteMessage(MediaFill);
				}
				if (advancedFillCase_ == AdvancedFillOneofCase.BackgroundEffect)
				{
					output.WriteRawTag(34);
					output.WriteMessage(BackgroundEffect);
				}
				if (TextBuildIndex != 0)
				{
					output.WriteRawTag(40);
					output.WriteInt32(TextBuildIndex);
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
				if (LayerType != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)LayerType);
				}
				if (advancedFillCase_ == AdvancedFillOneofCase.CutOutFill)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(CutOutFill);
				}
				if (advancedFillCase_ == AdvancedFillOneofCase.MediaFill)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(MediaFill);
				}
				if (advancedFillCase_ == AdvancedFillOneofCase.BackgroundEffect)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(BackgroundEffect);
				}
				if (TextBuildIndex != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(TextBuildIndex);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Layer other)
			{
				if (other == null)
				{
					return;
				}
				if (other.LayerType != 0)
				{
					LayerType = other.LayerType;
				}
				if (other.TextBuildIndex != 0)
				{
					TextBuildIndex = other.TextBuildIndex;
				}
				switch (other.AdvancedFillCase)
				{
				case AdvancedFillOneofCase.CutOutFill:
					if (CutOutFill == null)
					{
						CutOutFill = new Graphics.Types.Text.Types.CutOutFill();
					}
					CutOutFill.MergeFrom(other.CutOutFill);
					break;
				case AdvancedFillOneofCase.MediaFill:
					if (MediaFill == null)
					{
						MediaFill = new Graphics.Types.Text.Types.MediaFill();
					}
					MediaFill.MergeFrom(other.MediaFill);
					break;
				case AdvancedFillOneofCase.BackgroundEffect:
					if (BackgroundEffect == null)
					{
						BackgroundEffect = new Graphics.Types.BackgroundEffect();
					}
					BackgroundEffect.MergeFrom(other.BackgroundEffect);
					break;
				}
				_unknownFields = UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(CodedInputStream input)
			{
				uint num;
				while ((num = input.ReadTag()) != 0 && (num & 7) != 4)
				{
					switch (num)
					{
					default:
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
						break;
					case 8u:
						LayerType = (LayerType)input.ReadEnum();
						break;
					case 18u:
					{
						Graphics.Types.Text.Types.CutOutFill cutOutFill = new Graphics.Types.Text.Types.CutOutFill();
						if (advancedFillCase_ == AdvancedFillOneofCase.CutOutFill)
						{
							cutOutFill.MergeFrom(CutOutFill);
						}
						input.ReadMessage(cutOutFill);
						CutOutFill = cutOutFill;
						break;
					}
					case 26u:
					{
						Graphics.Types.Text.Types.MediaFill mediaFill = new Graphics.Types.Text.Types.MediaFill();
						if (advancedFillCase_ == AdvancedFillOneofCase.MediaFill)
						{
							mediaFill.MergeFrom(MediaFill);
						}
						input.ReadMessage(mediaFill);
						MediaFill = mediaFill;
						break;
					}
					case 34u:
					{
						Graphics.Types.BackgroundEffect backgroundEffect = new Graphics.Types.BackgroundEffect();
						if (advancedFillCase_ == AdvancedFillOneofCase.BackgroundEffect)
						{
							backgroundEffect.MergeFrom(BackgroundEffect);
						}
						input.ReadMessage(backgroundEffect);
						BackgroundEffect = backgroundEffect;
						break;
					}
					case 40u:
						TextBuildIndex = input.ReadInt32();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<SlideElementTextRenderInfo> _parser = new MessageParser<SlideElementTextRenderInfo>(() => new SlideElementTextRenderInfo());

	private UnknownFieldSet _unknownFields;

	public const int LayersFieldNumber = 1;

	private static readonly FieldCodec<Types.Layer> _repeated_layers_codec = FieldCodec.ForMessage(10u, Types.Layer.Parser);

	private readonly RepeatedField<Types.Layer> layers_ = new RepeatedField<Types.Layer>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<SlideElementTextRenderInfo> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProCoreReflection.Descriptor.MessageTypes[9];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Types.Layer> Layers => layers_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SlideElementTextRenderInfo()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SlideElementTextRenderInfo(SlideElementTextRenderInfo other)
		: this()
	{
		layers_ = other.layers_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SlideElementTextRenderInfo Clone()
	{
		return new SlideElementTextRenderInfo(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as SlideElementTextRenderInfo);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(SlideElementTextRenderInfo other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!layers_.Equals(other.layers_))
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
		num ^= layers_.GetHashCode();
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
		layers_.WriteTo(output, _repeated_layers_codec);
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
		num += layers_.CalculateSize(_repeated_layers_codec);
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(SlideElementTextRenderInfo other)
	{
		if (other != null)
		{
			layers_.Add(other.layers_);
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
			if (num != 10)
			{
				_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
			}
			else
			{
				layers_.AddEntriesFrom(input, _repeated_layers_codec);
			}
		}
	}
}
