using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Pro.Common.Logging;
using Pro.CoreApplication.Workspace;
using Pro.Loro;
using ProPresenter.DO.CommonPathsWrapper;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.Data;

public class WorkspaceInfoDumper : IWorkspaceInfoDumper
{
	private readonly IDocumentDiagnosticsProvider _documentInfoProvider;

	private readonly ICommonPathsWrapper _commonPaths;

	private readonly ICloudWorkspaceService _cloudWorkspaceService;

	private readonly ILogger _logger;

	public WorkspaceInfoDumper(IDocumentDiagnosticsProvider documentInfoProvider, ICommonPathsWrapper commonPaths, ICloudWorkspaceService cloudWorkspaceService, ILogger logger)
	{
		_documentInfoProvider = documentInfoProvider;
		_commonPaths = commonPaths;
		_cloudWorkspaceService = cloudWorkspaceService;
		_logger = logger;
	}

	public async Task DumpWorkspaceInfoAsync()
	{
		IWorkspace workspace = _commonPaths.Workspaces.FirstOrDefault((IWorkspace w) => w.Active);
		StringBuilder sb = new StringBuilder();
		sb.AppendLine("=== Workspace Info Dump ===");
		StringBuilder stringBuilder = sb;
		StringBuilder stringBuilder2 = stringBuilder;
		StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(10, 1, stringBuilder);
		handler.AppendLiteral("    Name: ");
		handler.AppendFormatted(workspace?.Name ?? "N/A");
		stringBuilder2.AppendLine(ref handler);
		stringBuilder = sb;
		StringBuilder stringBuilder3 = stringBuilder;
		handler = new StringBuilder.AppendInterpolatedStringHandler(10, 1, stringBuilder);
		handler.AppendLiteral("    Path: ");
		handler.AppendFormatted(workspace?.Path ?? "N/A");
		stringBuilder3.AppendLine(ref handler);
		stringBuilder = sb;
		StringBuilder stringBuilder4 = stringBuilder;
		handler = new StringBuilder.AppendInterpolatedStringHandler(10, 1, stringBuilder);
		handler.AppendLiteral("   Cloud: ");
		handler.AppendFormatted((workspace != null && workspace.CloudId.HasValue) ? "YES" : "NO");
		stringBuilder4.AppendLine(ref handler);
		ISyncStatus syncStatus = null;
		try
		{
			syncStatus = await _cloudWorkspaceService.WhenSyncingChanged.Timeout(TimeSpan.FromSeconds(3L)).FirstOrDefaultAsync();
		}
		catch
		{
		}
		string text = ((syncStatus == null) ? "unknown" : ((!syncStatus.IsPaused) ? "active" : "paused"));
		string value = text;
		stringBuilder = sb;
		StringBuilder stringBuilder5 = stringBuilder;
		handler = new StringBuilder.AppendInterpolatedStringHandler(15, 1, stringBuilder);
		handler.AppendLiteral("   Sync state: ");
		handler.AppendFormatted(value);
		stringBuilder5.AppendLine(ref handler);
		sb.AppendLine();
		stringBuilder = sb;
		StringBuilder stringBuilder6 = stringBuilder;
		handler = new StringBuilder.AppendInterpolatedStringHandler(8, 6, stringBuilder);
		handler.AppendLiteral("   ");
		handler.AppendFormatted<string>("UUID", -37);
		handler.AppendLiteral(" ");
		handler.AppendFormatted<string>("KIND", -20);
		handler.AppendLiteral(" ");
		handler.AppendFormatted<string>("LAST SENT VV", -45);
		handler.AppendLiteral(" ");
		handler.AppendFormatted<string>("CURRENT VV", -45);
		handler.AppendLiteral(" ");
		handler.AppendFormatted<string>("STATE", -12);
		handler.AppendLiteral(" ");
		handler.AppendFormatted("FILE NAME");
		stringBuilder6.AppendLine(ref handler);
		stringBuilder = sb;
		StringBuilder stringBuilder7 = stringBuilder;
		handler = new StringBuilder.AppendInterpolatedStringHandler(8, 6, stringBuilder);
		handler.AppendLiteral("   ");
		handler.AppendFormatted<string>("====", -37);
		handler.AppendLiteral(" ");
		handler.AppendFormatted<string>("====", -20);
		handler.AppendLiteral(" ");
		handler.AppendFormatted<string>("============", -45);
		handler.AppendLiteral(" ");
		handler.AppendFormatted<string>("==========", -45);
		handler.AppendLiteral(" ");
		handler.AppendFormatted<string>("=====", -12);
		handler.AppendLiteral(" ");
		handler.AppendFormatted("=========");
		stringBuilder7.AppendLine(ref handler);
		foreach (DocumentInfoEntry documentInfoEntry in _documentInfoProvider.GetDocumentInfoEntries())
		{
			string value2 = "last [" + FormatVersionVector(documentInfoEntry.LastSentVersionVector) + "]";
			string value3 = "current [" + FormatVersionVector(documentInfoEntry.CurrentVersionVector) + "]";
			string value4 = (documentInfoEntry.SentToCore ? "sent" : "pending");
			stringBuilder = sb;
			StringBuilder stringBuilder8 = stringBuilder;
			handler = new StringBuilder.AppendInterpolatedStringHandler(8, 6, stringBuilder);
			handler.AppendLiteral("   ");
			handler.AppendFormatted(documentInfoEntry.Id, -37);
			handler.AppendLiteral(" ");
			handler.AppendFormatted<string>(documentInfoEntry.Kind ?? "unknown", -20);
			handler.AppendLiteral(" ");
			handler.AppendFormatted<string>(value2, -45);
			handler.AppendLiteral(" ");
			handler.AppendFormatted<string>(value3, -45);
			handler.AppendLiteral(" ");
			handler.AppendFormatted<string>(value4, -12);
			handler.AppendLiteral(" ");
			handler.AppendFormatted(documentInfoEntry.FileName ?? "N/A");
			stringBuilder8.AppendLine(ref handler);
		}
		sb.AppendLine("=== End Workspace Info Dump ===");
		string[] array = sb.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
		foreach (string message in array)
		{
			_logger.Info(message);
		}
	}

	private static string FormatVersionVector(byte[]? versionVectorBytes)
	{
		if (versionVectorBytes == null)
		{
			return "N/A";
		}
		try
		{
			using VersionVector versionVector = VersionVector.Decode(versionVectorBytes);
			Dictionary<ulong, int> source = versionVector.ToHashmap();
			return string.Join(", ", source.Select((KeyValuePair<ulong, int> kvp) => $"{kvp.Key}:{kvp.Value}"));
		}
		catch
		{
			return "error";
		}
	}
}
