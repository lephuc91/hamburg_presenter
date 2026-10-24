#define TRACE
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugsnag;
using Pro.Common.Collections;
using Pro.Common.HTTP;
using RestSharp;

namespace Pro.Reporting.BugsnagInternal;

internal class ProBugsnagDelivery : IDelivery
{
	private class ResentPayload : IPayload
	{
		private readonly byte[] _payload = Array.Empty<byte>();

		public Uri? Endpoint { get; }

		public KeyValuePair<string, string>[] Headers { get; } = Array.Empty<KeyValuePair<string, string>>();

		public bool IsValid { get; }

		public ResentPayload(string filename)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			string[] source = new string[2] { "Content-Type", "Host" };
			try
			{
				using (FileStream input = File.OpenRead(filename))
				{
					using BinaryReader binaryReader = new BinaryReader(input);
					string text = binaryReader.ReadString();
					int num = binaryReader.ReadInt32();
					if (text != "Unsent crash report".PadRight(32) || num != 118292480)
					{
						return;
					}
					Endpoint = new Uri(binaryReader.ReadString());
					while (true)
					{
						string key = binaryReader.ReadString();
						if (!(key != string.Empty))
						{
							break;
						}
						string value = binaryReader.ReadString();
						if (source.FindIndex((string header) => header == key) == -1)
						{
							dictionary.Add(key, value);
						}
						else
						{
							dictionary.Add("X-Pro-Unsent" + key, value);
						}
					}
					int num2 = binaryReader.ReadInt32();
					if (num2 != 0)
					{
						_payload = binaryReader.ReadBytes(num2);
					}
				}
				dictionary.Add("UnsentFileName", filename);
				Headers = dictionary.ToArray();
				IsValid = true;
			}
			catch
			{
			}
		}

		public byte[] Serialize()
		{
			return _payload;
		}
	}

	private const string InternalContentTypeHeader = "X-Pro-UnsentContent-Type";

	private const string InternalUnsetFileNameHeader = "UnsentFileName";

	private readonly IRestClientFactory _restClientFactory;

	private readonly IConfiguration _configuration;

	internal ProBugsnagDelivery(IRestClientFactory restClientFactory, IConfiguration configuration)
	{
		_restClientFactory = restClientFactory;
		_configuration = configuration;
		Task.Run(delegate
		{
			RemoveOldErrorFiles();
			QueueUnsentReports();
		});
	}

	private static void RemoveOldErrorFiles()
	{
		Stargazer.GetAppInfo(out string reportRootPath, out string _, out string _);
		List<string> list = new List<string>();
		try
		{
			foreach (string item in Directory.EnumerateFiles(reportRootPath))
			{
				try
				{
					if (DateTime.Now - File.GetLastWriteTime(item) > TimeSpan.FromDays(90))
					{
						list.Add(item);
					}
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
		foreach (string item2 in list)
		{
			try
			{
				File.Delete(item2);
			}
			catch
			{
			}
		}
	}

	private void QueueUnsentReports()
	{
		Stargazer.GetAppInfo(out string reportRootPath, out string _, out string _);
		foreach (string item in Directory.EnumerateFiles(reportRootPath, "*.unsent"))
		{
			ResentPayload resentPayload = new ResentPayload(item);
			if (resentPayload.IsValid)
			{
				Send(resentPayload);
			}
		}
	}

	public void Send(IPayload payload)
	{
		try
		{
			byte[] array = payload.Serialize();
			if (array != null)
			{
				HTTPSend(payload.Endpoint, payload.Headers, array);
			}
		}
		catch (Exception value)
		{
			Trace.WriteLine(value);
		}
	}

	private static byte[] MakeMinidumpContent(string endpointString, byte[] report, out Uri newEndpoint, out string newContentType)
	{
		string[] array = endpointString.Split('|');
		newEndpoint = new Uri(array[0]);
		string path = array[1];
		newContentType = "multipart/form-data;boundary=BOUNDARY";
		UTF8Encoding uTF8Encoding = new UTF8Encoding();
		byte[] bytes = uTF8Encoding.GetBytes("\r\n--BOUNDARY");
		byte[] bytes2 = uTF8Encoding.GetBytes("\r\nContent-Disposition: form-data; name=\"event\"\r\n\r\n");
		byte[] bytes3 = uTF8Encoding.GetBytes("\r\nContent-Disposition: form-data; name=\"upload_file_minidump\"; filename=\"crash.dmp\"\r\nContent-Type: application/octet-stream\r\n\r\n");
		byte[] bytes4 = uTF8Encoding.GetBytes("--\r\n");
		byte[] second = File.ReadAllBytes(path);
		return bytes.Concat(bytes2).Concat(report).Concat(bytes)
			.Concat(bytes3)
			.Concat(second)
			.Concat(bytes)
			.Concat(bytes4)
			.ToArray();
	}

	private static void WriteUnsentFile(Uri endpoint, Dictionary<string, string> headers, byte[] content, string contentType)
	{
		try
		{
			Stargazer.GetAppInfo(out string reportRootPath, out string _, out string appName);
			string reportName = Stargazer.GetReportName(appName);
			string text = endpoint.Host.Split('.')[0];
			using FileStream output = File.Create(Path.Combine(reportRootPath, reportName + "_" + text + ".unsent"));
			using BinaryWriter binaryWriter = new BinaryWriter(output);
			binaryWriter.Write("Unsent crash report".PadRight(32));
			binaryWriter.Write(118292480);
			binaryWriter.Write(endpoint.ToString());
			foreach (KeyValuePair<string, string> header in headers)
			{
				binaryWriter.Write(header.Key);
				binaryWriter.Write(header.Value);
			}
			binaryWriter.Write("X-Pro-UnsentContent-Type");
			binaryWriter.Write(contentType);
			binaryWriter.Write(string.Empty);
			binaryWriter.Write(content.Length);
			binaryWriter.Write(content);
		}
		catch
		{
		}
	}

	private void HTTPSend(Uri endpoint, KeyValuePair<string, string>[] headers, byte[] report)
	{
		string text = endpoint.ToString();
		string newContentType = "application/json";
		byte[] array = report;
		if (text.Contains("|"))
		{
			array = MakeMinidumpContent(text, report, out endpoint, out newContentType);
		}
		Dictionary<string, string> dictionary = new Dictionary<string, string> { ["Bugsnag-Sent-At"] = DateTime.UtcNow.ToString("o", CultureInfo.InvariantCulture) };
		string text2 = null;
		for (int i = 0; i < headers.Length; i++)
		{
			KeyValuePair<string, string> keyValuePair = headers[i];
			string key = keyValuePair.Key;
			if (!(key == "X-Pro-UnsentContent-Type"))
			{
				if (key == "UnsentFileName")
				{
					text2 = keyValuePair.Value;
				}
				else
				{
					dictionary[keyValuePair.Key] = keyValuePair.Value;
				}
			}
			else
			{
				newContentType = keyValuePair.Value;
			}
		}
		bool flag = text2 != null;
		try
		{
			IRestClient client = _restClientFactory.Get(delegate(RestClientOptions options)
			{
				options.BaseUrl = endpoint;
				options.Proxy = _configuration.Proxy;
			});
			RestRequest request = new RestRequest();
			foreach (KeyValuePair<string, string> item in dictionary)
			{
				request.AddHeader(item.Key, item.Value);
			}
			request.AddBody(array, newContentType);
			if (!client.ExecutePost(request).IsSuccessful)
			{
				if (flag)
				{
					flag = false;
				}
				else
				{
					WriteUnsentFile(endpoint, dictionary, array, newContentType);
				}
			}
		}
		catch
		{
			if (flag)
			{
				flag = false;
			}
			else
			{
				WriteUnsentFile(endpoint, dictionary, array, newContentType);
			}
		}
		if (flag && File.Exists(text2))
		{
			File.Delete(text2);
		}
	}
}
