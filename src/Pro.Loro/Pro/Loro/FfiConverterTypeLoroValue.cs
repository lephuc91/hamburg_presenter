namespace Pro.Loro;

internal class FfiConverterTypeLoroValue : FfiConverterRustBuffer<LoroValue>
{
	public static FfiConverterRustBuffer<LoroValue> INSTANCE = new FfiConverterTypeLoroValue();

	public override LoroValue Read(BigEndianStream stream)
	{
		int num = stream.ReadInt();
		return num switch
		{
			1 => new LoroValue.Null(), 
			2 => new LoroValue.Bool(FfiConverterBoolean.INSTANCE.Read(stream)), 
			3 => new LoroValue.Double(FfiConverterDouble.INSTANCE.Read(stream)), 
			4 => new LoroValue.I64(FfiConverterInt64.INSTANCE.Read(stream)), 
			5 => new LoroValue.Binary(FfiConverterByteArray.INSTANCE.Read(stream)), 
			6 => new LoroValue.String(FfiConverterString.INSTANCE.Read(stream)), 
			7 => new LoroValue.List(FfiConverterSequenceTypeLoroValue.INSTANCE.Read(stream)), 
			8 => new LoroValue.Map(FfiConverterDictionaryStringTypeLoroValue.INSTANCE.Read(stream)), 
			9 => new LoroValue.Container(FfiConverterTypeContainerID.INSTANCE.Read(stream)), 
			_ => throw new InternalException($"invalid enum value '{num}' in FfiConverterTypeLoroValue.Read()"), 
		};
	}

	public override int AllocationSize(LoroValue value)
	{
		if (!(value is LoroValue.Null))
		{
			if (!(value is LoroValue.Bool @bool))
			{
				if (!(value is LoroValue.Double @double))
				{
					if (!(value is LoroValue.I64 i))
					{
						if (!(value is LoroValue.Binary binary))
						{
							if (!(value is LoroValue.String @string))
							{
								if (!(value is LoroValue.List list))
								{
									if (!(value is LoroValue.Map map))
									{
										if (value is LoroValue.Container container)
										{
											return 4 + FfiConverterTypeContainerID.INSTANCE.AllocationSize(container.value);
										}
										throw new InternalException($"invalid enum value '{value}' in FfiConverterTypeLoroValue.AllocationSize()");
									}
									return 4 + FfiConverterDictionaryStringTypeLoroValue.INSTANCE.AllocationSize(map.value);
								}
								return 4 + FfiConverterSequenceTypeLoroValue.INSTANCE.AllocationSize(list.value);
							}
							return 4 + FfiConverterString.INSTANCE.AllocationSize(@string.value);
						}
						return 4 + FfiConverterByteArray.INSTANCE.AllocationSize(binary.value);
					}
					return 4 + FfiConverterInt64.INSTANCE.AllocationSize(i.value);
				}
				return 4 + FfiConverterDouble.INSTANCE.AllocationSize(@double.value);
			}
			return 4 + FfiConverterBoolean.INSTANCE.AllocationSize(@bool.value);
		}
		return 4;
	}

	public override void Write(LoroValue value, BigEndianStream stream)
	{
		if (!(value is LoroValue.Null))
		{
			if (!(value is LoroValue.Bool @bool))
			{
				if (!(value is LoroValue.Double @double))
				{
					if (!(value is LoroValue.I64 i))
					{
						if (!(value is LoroValue.Binary binary))
						{
							if (!(value is LoroValue.String @string))
							{
								if (!(value is LoroValue.List list))
								{
									if (!(value is LoroValue.Map map))
									{
										if (!(value is LoroValue.Container container))
										{
											throw new InternalException($"invalid enum value '{value}' in FfiConverterTypeLoroValue.Write()");
										}
										stream.WriteInt(9);
										FfiConverterTypeContainerID.INSTANCE.Write(container.value, stream);
									}
									else
									{
										stream.WriteInt(8);
										FfiConverterDictionaryStringTypeLoroValue.INSTANCE.Write(map.value, stream);
									}
								}
								else
								{
									stream.WriteInt(7);
									FfiConverterSequenceTypeLoroValue.INSTANCE.Write(list.value, stream);
								}
							}
							else
							{
								stream.WriteInt(6);
								FfiConverterString.INSTANCE.Write(@string.value, stream);
							}
						}
						else
						{
							stream.WriteInt(5);
							FfiConverterByteArray.INSTANCE.Write(binary.value, stream);
						}
					}
					else
					{
						stream.WriteInt(4);
						FfiConverterInt64.INSTANCE.Write(i.value, stream);
					}
				}
				else
				{
					stream.WriteInt(3);
					FfiConverterDouble.INSTANCE.Write(@double.value, stream);
				}
			}
			else
			{
				stream.WriteInt(2);
				FfiConverterBoolean.INSTANCE.Write(@bool.value, stream);
			}
		}
		else
		{
			stream.WriteInt(1);
		}
	}
}
