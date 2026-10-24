using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Pro.Common.Strings;

namespace Pro.Common.Security;

public static class HashingExtensions
{
	public static byte[] RawHash(this string data)
	{
		return Encoding.UTF8.GetBytes(data).RawHash();
	}

	public static byte[] RawHash(this byte[] data)
	{
		return data.RawHash(SHA256.Create);
	}

	public static byte[] RawHash(this Stream data)
	{
		return data.RawHash(SHA256.Create);
	}

	public static byte[] RawHash<T>(this string data, Func<T> createHash) where T : HashAlgorithm
	{
		return Encoding.UTF8.GetBytes(data).RawHash(createHash);
	}

	public static byte[] RawHash<T>(this byte[] data, Func<T> createHash) where T : HashAlgorithm
	{
		using T val = createHash();
		return val.ComputeHash(data);
	}

	public static byte[] RawHash<T>(this Stream data, Func<T> createHash) where T : HashAlgorithm
	{
		using T val = createHash();
		return val.ComputeHash(data);
	}

	public static string Hash(this string data, bool uppercase = true)
	{
		return Encoding.UTF8.GetBytes(data).Hash(uppercase);
	}

	public static string Hash(this byte[] data, bool uppercase = true)
	{
		return data.Hash(SHA256.Create, uppercase);
	}

	public static string Hash(this Stream data, bool uppercase = true)
	{
		return data.Hash(SHA256.Create, uppercase);
	}

	public static string Hash<T>(this string data, Func<T> createHash, bool uppercase = true) where T : HashAlgorithm
	{
		return Encoding.UTF8.GetBytes(data).Hash(createHash, uppercase);
	}

	public static string Hash<T>(this byte[] data, Func<T> createHash, bool uppercase = true) where T : HashAlgorithm
	{
		return data.RawHash(createHash).ToHexString(uppercase);
	}

	public static string Hash<T>(this Stream data, Func<T> createHash, bool uppercase = true) where T : HashAlgorithm
	{
		return data.RawHash(createHash).ToHexString(uppercase);
	}
}
