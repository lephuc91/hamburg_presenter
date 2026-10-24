namespace Pro.Loro;

internal class FfiConverterTypeLoroError : FfiConverterRustBuffer<LoroException>, CallStatusErrorHandler<LoroException>
{
	public static FfiConverterTypeLoroError INSTANCE = new FfiConverterTypeLoroError();

	public override LoroException Read(BigEndianStream stream)
	{
		int num = stream.ReadInt();
		return num switch
		{
			1 => new LoroException.UnmatchedContext(FfiConverterString.INSTANCE.Read(stream)), 
			2 => new LoroException.DecodeVersionVectorException(FfiConverterString.INSTANCE.Read(stream)), 
			3 => new LoroException.DecodeException(FfiConverterString.INSTANCE.Read(stream)), 
			4 => new LoroException.DecodeDataCorruptionException(FfiConverterString.INSTANCE.Read(stream)), 
			5 => new LoroException.DecodeChecksumMismatchException(FfiConverterString.INSTANCE.Read(stream)), 
			6 => new LoroException.IncompatibleFutureEncodingException(FfiConverterString.INSTANCE.Read(stream)), 
			7 => new LoroException.JsException(FfiConverterString.INSTANCE.Read(stream)), 
			8 => new LoroException.LockException(FfiConverterString.INSTANCE.Read(stream)), 
			9 => new LoroException.DuplicatedTransactionException(FfiConverterString.INSTANCE.Read(stream)), 
			10 => new LoroException.NotFoundException(FfiConverterString.INSTANCE.Read(stream)), 
			11 => new LoroException.TransactionException(FfiConverterString.INSTANCE.Read(stream)), 
			12 => new LoroException.OutOfBound(FfiConverterString.INSTANCE.Read(stream)), 
			13 => new LoroException.UsedOpId(FfiConverterString.INSTANCE.Read(stream)), 
			14 => new LoroException.TreeException(FfiConverterString.INSTANCE.Read(stream)), 
			15 => new LoroException.ArgErr(FfiConverterString.INSTANCE.Read(stream)), 
			16 => new LoroException.AutoCommitNotStarted(FfiConverterString.INSTANCE.Read(stream)), 
			17 => new LoroException.StyleConfigMissing(FfiConverterString.INSTANCE.Read(stream)), 
			18 => new LoroException.Unknown(FfiConverterString.INSTANCE.Read(stream)), 
			19 => new LoroException.FrontiersNotFound(FfiConverterString.INSTANCE.Read(stream)), 
			20 => new LoroException.ImportWhenInTxn(FfiConverterString.INSTANCE.Read(stream)), 
			21 => new LoroException.MisuseDetachedContainer(FfiConverterString.INSTANCE.Read(stream)), 
			22 => new LoroException.NotImplemented(FfiConverterString.INSTANCE.Read(stream)), 
			23 => new LoroException.ReattachAttachedContainer(FfiConverterString.INSTANCE.Read(stream)), 
			24 => new LoroException.EditWhenDetached(FfiConverterString.INSTANCE.Read(stream)), 
			25 => new LoroException.UndoInvalidIdSpan(FfiConverterString.INSTANCE.Read(stream)), 
			26 => new LoroException.UndoWithDifferentPeerId(FfiConverterString.INSTANCE.Read(stream)), 
			27 => new LoroException.InvalidJsonSchema(FfiConverterString.INSTANCE.Read(stream)), 
			28 => new LoroException.Utf8InUnicodeCodePoint(FfiConverterString.INSTANCE.Read(stream)), 
			29 => new LoroException.Utf16InUnicodeCodePoint(FfiConverterString.INSTANCE.Read(stream)), 
			30 => new LoroException.EndIndexLessThanStartIndex(FfiConverterString.INSTANCE.Read(stream)), 
			31 => new LoroException.InvalidRootContainerName(FfiConverterString.INSTANCE.Read(stream)), 
			32 => new LoroException.ImportUpdatesThatDependsOnOutdatedVersion(FfiConverterString.INSTANCE.Read(stream)), 
			33 => new LoroException.ImportUnsupportedEncodingMode(FfiConverterString.INSTANCE.Read(stream)), 
			34 => new LoroException.SwitchToVersionBeforeShallowRoot(FfiConverterString.INSTANCE.Read(stream)), 
			35 => new LoroException.ContainerDeleted(FfiConverterString.INSTANCE.Read(stream)), 
			36 => new LoroException.ConcurrentOpsWithSamePeerId(FfiConverterString.INSTANCE.Read(stream)), 
			37 => new LoroException.InvalidPeerId(FfiConverterString.INSTANCE.Read(stream)), 
			38 => new LoroException.ContainersNotFound(FfiConverterString.INSTANCE.Read(stream)), 
			39 => new LoroException.UndoGroupAlreadyStarted(FfiConverterString.INSTANCE.Read(stream)), 
			_ => throw new InternalException($"invalid error value '{num}' in FfiConverterTypeLoroError.Read()"), 
		};
	}

	public override int AllocationSize(LoroException value)
	{
		return 4 + FfiConverterString.INSTANCE.AllocationSize(value.Message);
	}

	public override void Write(LoroException value, BigEndianStream stream)
	{
		if (!(value is LoroException.UnmatchedContext))
		{
			if (!(value is LoroException.DecodeVersionVectorException))
			{
				if (!(value is LoroException.DecodeException))
				{
					if (!(value is LoroException.DecodeDataCorruptionException))
					{
						if (!(value is LoroException.DecodeChecksumMismatchException))
						{
							if (!(value is LoroException.IncompatibleFutureEncodingException))
							{
								if (!(value is LoroException.JsException))
								{
									if (!(value is LoroException.LockException))
									{
										if (!(value is LoroException.DuplicatedTransactionException))
										{
											if (!(value is LoroException.NotFoundException))
											{
												if (!(value is LoroException.TransactionException))
												{
													if (!(value is LoroException.OutOfBound))
													{
														if (!(value is LoroException.UsedOpId))
														{
															if (!(value is LoroException.TreeException))
															{
																if (!(value is LoroException.ArgErr))
																{
																	if (!(value is LoroException.AutoCommitNotStarted))
																	{
																		if (!(value is LoroException.StyleConfigMissing))
																		{
																			if (!(value is LoroException.Unknown))
																			{
																				if (!(value is LoroException.FrontiersNotFound))
																				{
																					if (!(value is LoroException.ImportWhenInTxn))
																					{
																						if (!(value is LoroException.MisuseDetachedContainer))
																						{
																							if (!(value is LoroException.NotImplemented))
																							{
																								if (!(value is LoroException.ReattachAttachedContainer))
																								{
																									if (!(value is LoroException.EditWhenDetached))
																									{
																										if (!(value is LoroException.UndoInvalidIdSpan))
																										{
																											if (!(value is LoroException.UndoWithDifferentPeerId))
																											{
																												if (!(value is LoroException.InvalidJsonSchema))
																												{
																													if (!(value is LoroException.Utf8InUnicodeCodePoint))
																													{
																														if (!(value is LoroException.Utf16InUnicodeCodePoint))
																														{
																															if (!(value is LoroException.EndIndexLessThanStartIndex))
																															{
																																if (!(value is LoroException.InvalidRootContainerName))
																																{
																																	if (!(value is LoroException.ImportUpdatesThatDependsOnOutdatedVersion))
																																	{
																																		if (!(value is LoroException.ImportUnsupportedEncodingMode))
																																		{
																																			if (!(value is LoroException.SwitchToVersionBeforeShallowRoot))
																																			{
																																				if (!(value is LoroException.ContainerDeleted))
																																				{
																																					if (!(value is LoroException.ConcurrentOpsWithSamePeerId))
																																					{
																																						if (!(value is LoroException.InvalidPeerId))
																																						{
																																							if (!(value is LoroException.ContainersNotFound))
																																							{
																																								if (!(value is LoroException.UndoGroupAlreadyStarted))
																																								{
																																									throw new InternalException($"invalid error value '{value}' in FfiConverterTypeLoroError.Write()");
																																								}
																																								stream.WriteInt(39);
																																							}
																																							else
																																							{
																																								stream.WriteInt(38);
																																							}
																																						}
																																						else
																																						{
																																							stream.WriteInt(37);
																																						}
																																					}
																																					else
																																					{
																																						stream.WriteInt(36);
																																					}
																																				}
																																				else
																																				{
																																					stream.WriteInt(35);
																																				}
																																			}
																																			else
																																			{
																																				stream.WriteInt(34);
																																			}
																																		}
																																		else
																																		{
																																			stream.WriteInt(33);
																																		}
																																	}
																																	else
																																	{
																																		stream.WriteInt(32);
																																	}
																																}
																																else
																																{
																																	stream.WriteInt(31);
																																}
																															}
																															else
																															{
																																stream.WriteInt(30);
																															}
																														}
																														else
																														{
																															stream.WriteInt(29);
																														}
																													}
																													else
																													{
																														stream.WriteInt(28);
																													}
																												}
																												else
																												{
																													stream.WriteInt(27);
																												}
																											}
																											else
																											{
																												stream.WriteInt(26);
																											}
																										}
																										else
																										{
																											stream.WriteInt(25);
																										}
																									}
																									else
																									{
																										stream.WriteInt(24);
																									}
																								}
																								else
																								{
																									stream.WriteInt(23);
																								}
																							}
																							else
																							{
																								stream.WriteInt(22);
																							}
																						}
																						else
																						{
																							stream.WriteInt(21);
																						}
																					}
																					else
																					{
																						stream.WriteInt(20);
																					}
																				}
																				else
																				{
																					stream.WriteInt(19);
																				}
																			}
																			else
																			{
																				stream.WriteInt(18);
																			}
																		}
																		else
																		{
																			stream.WriteInt(17);
																		}
																	}
																	else
																	{
																		stream.WriteInt(16);
																	}
																}
																else
																{
																	stream.WriteInt(15);
																}
															}
															else
															{
																stream.WriteInt(14);
															}
														}
														else
														{
															stream.WriteInt(13);
														}
													}
													else
													{
														stream.WriteInt(12);
													}
												}
												else
												{
													stream.WriteInt(11);
												}
											}
											else
											{
												stream.WriteInt(10);
											}
										}
										else
										{
											stream.WriteInt(9);
										}
									}
									else
									{
										stream.WriteInt(8);
									}
								}
								else
								{
									stream.WriteInt(7);
								}
							}
							else
							{
								stream.WriteInt(6);
							}
						}
						else
						{
							stream.WriteInt(5);
						}
					}
					else
					{
						stream.WriteInt(4);
					}
				}
				else
				{
					stream.WriteInt(3);
				}
			}
			else
			{
				stream.WriteInt(2);
			}
		}
		else
		{
			stream.WriteInt(1);
		}
	}
}
