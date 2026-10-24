using System;
using System.Windows.Threading;
using Pro.Common.ErrorReporting;
using Pro.DO.Storage;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.InputActionMap;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.Sync.Local;

public class LocalFileRepository : SyncFileRepositoryBase
{
	private readonly IOutputConfiguration _outputConfiguration;

	private readonly IInputActions _inputActions;

	private readonly Dispatcher _dispatcher;

	protected override RelativePath Repo => new RelativePath(CommonPaths.Base, isDirectory: true);

	public LocalFileRepository(ISyncDataProvider dataProvider, IOutputConfiguration outputConfiguration, IErrorReporter errorReporter, IInputActions inputActions)
		: base(dataProvider, errorReporter)
	{
		_outputConfiguration = outputConfiguration;
		_inputActions = inputActions;
		_dispatcher = Dispatcher.CurrentDispatcher;
	}

	protected override string Convert(string path)
	{
		return path.ConvertToLocalFile(ProPresenter.DO.Settings.Sync.Settings.LocalSyncSource);
	}

	protected override void OnModify(ISyncData data, Action<double> progress)
	{
		SyncFileData fileData = data as SyncFileData;
		if (fileData == null)
		{
			return;
		}
		switch (fileData.FileType)
		{
		case SyncFileType.Library:
			if (ProPresenter.DO.Settings.Sync.Settings.LocalSyncIncludeLibraryDoc)
			{
				Write(data, progress);
			}
			break;
		case SyncFileType.Configuration:
		{
			if (!ProPresenter.DO.Settings.Sync.Settings.LocalSyncIncludeUserData)
			{
				break;
			}
			progress?.Invoke(0.0);
			string name2 = fileData.Name;
			_dispatcher.Invoke((System.Action)delegate
			{
				string text = name2;
				if (text != null)
				{
					switch (text.Length)
					{
					case 8:
						switch (text[0])
						{
						case 'C':
						{
							if (text == "Calendar" && (bool)ProtoHelper.TryReadFile<Pro.SerializationInterop.RVProtoData.Calendar>(fileData.FullPath, out Pro.SerializationInterop.RVProtoData.Calendar data12))
							{
								if (data12 != null)
								{
									DataVault.Calendar.Deserialize(data12, removeExisting: false);
								}
								DataVault.Calendar.Save();
							}
							break;
						}
						case 'M':
						{
							if (text == "Messages" && (bool)ProtoHelper.TryReadFile<MessageDocument>(fileData.FullPath, out MessageDocument data11))
							{
								if (data11 != null)
								{
									DataVault.Messages.Deserialize(data11.Messages, removeExisting: false);
								}
								DataVault.Messages.Save();
							}
							break;
						}
						}
						break;
					case 6:
						switch (text[0])
						{
						case 'G':
						{
							if (text == "Groups" && (bool)ProtoHelper.TryReadFile<ProGroupsDocument>(fileData.FullPath, out ProGroupsDocument data8))
							{
								if (data8 != null)
								{
									DataVault.GroupLabels.Deserialize(data8.Groups, removeExisting: false);
								}
								DataVault.GroupLabels.Save();
							}
							break;
						}
						case 'L':
						{
							if (text == "Labels" && (bool)ProtoHelper.TryReadFile<ProLabelsDocument>(fileData.FullPath, out ProLabelsDocument data10))
							{
								if (data10 != null)
								{
									DataVault.SlideLabels.Deserialize(data10.Labels, removeExisting: false);
								}
								DataVault.SlideLabels.Save();
							}
							break;
						}
						case 'T':
						{
							if (text == "Timers" && (bool)ProtoHelper.TryReadFile<TimersDocument>(fileData.FullPath, out TimersDocument data9))
							{
								if (data9 != null)
								{
									DataVault.TimerDocument.Deserialize(data9, removeExisting: false);
								}
								DataVault.TimerDocument.Save();
							}
							break;
						}
						case 'M':
						{
							if (text == "Macros" && (bool)ProtoHelper.TryReadFile<MacrosDocument>(fileData.FullPath, out MacrosDocument data7))
							{
								if (data7 != null)
								{
									DataVault.MacroGroups.Deserialize(data7);
								}
								DataVault.MacroGroups.Save();
							}
							break;
						}
						}
						break;
					case 5:
						switch (text[0])
						{
						case 'P':
						{
							if (text == "Props" && (bool)ProtoHelper.TryReadFile<PropDocument>(fileData.FullPath, out PropDocument data6))
							{
								if (data6 != null)
								{
									DataVault.PropCueCollection.Deserialize(data6, removeExisting: false);
								}
								DataVault.PropCueCollection.Save();
							}
							break;
						}
						case 'S':
						{
							if (text == "Stage" && (bool)ProtoHelper.TryReadFile<Stage.Types.Document>(fileData.FullPath, out Stage.Types.Document data5))
							{
								if (data5 != null)
								{
									DataVault.StagePresentation.DeserializeStageDocument(data5, removeExisting: false);
								}
								DataVault.StagePresentation.Save();
							}
							break;
						}
						}
						break;
					case 11:
						switch (text[0])
						{
						case 'C':
						{
							if (text == "ClearGroups" && (bool)ProtoHelper.TryReadFile<ClearGroupsDocument>(fileData.FullPath, out ClearGroupsDocument data4))
							{
								if (data4 != null)
								{
									DataVault.ClearGroups.Deserialize(data4);
								}
								DataVault.ClearGroups.Save();
							}
							break;
						}
						case 'K':
						{
							if (text == "KeyMappings" && (bool)ProtoHelper.TryReadFile<KeyMappingDocument>(fileData.FullPath, out KeyMappingDocument data3))
							{
								_inputActions.Deserialize(data3);
							}
							break;
						}
						}
						break;
					case 4:
					{
						if (text == "CCLI" && (bool)ProtoHelper.TryReadFile<Template.Types.Document>(fileData.FullPath, out Template.Types.Document data13))
						{
							if (data13 != null)
							{
								DataVault.CCLIPresentation.Deserialize(data13, removeExisting: false);
							}
							DataVault.CCLIPresentation.Save();
						}
						break;
					}
					case 9:
					{
						if (text == "Workspace" && (bool)ProtoHelper.TryReadFile<ProPresenterWorkspace>(fileData.FullPath, out ProPresenterWorkspace data2))
						{
							if (data2 != null)
							{
								_outputConfiguration.Deserialize(data2, removeExisting: false);
							}
							_outputConfiguration.Save();
						}
						break;
					}
					case 7:
					case 10:
						break;
					}
				}
			});
			progress?.Invoke(100.0);
			break;
		}
		case SyncFileType.Media:
			if (ProPresenter.DO.Settings.Sync.Settings.LocalSyncIncludeMedia)
			{
				Write(data, progress);
			}
			break;
		case SyncFileType.Playlist:
		{
			if (!ProPresenter.DO.Settings.Sync.Settings.LocalSyncIncludePlaylists)
			{
				break;
			}
			progress?.Invoke(0.0);
			string name = fileData.Name;
			if ((bool)ProtoHelper.TryReadFile<PlaylistDocument>(fileData.FullPath, out PlaylistDocument protoPlaylist))
			{
				_dispatcher.Invoke((System.Action)delegate
				{
					switch (name)
					{
					case "Audio":
						DataVault.AudioPlaylistCollection.Deserialize(protoPlaylist, removeExisting: false);
						DataVault.AudioPlaylistCollection.Save();
						break;
					case "Library":
						DataVault.LibraryPlaylistCollection.Deserialize(protoPlaylist, removeExisting: false);
						DataVault.LibraryPlaylistCollection.Save();
						break;
					case "Media":
						DataVault.VisualPlaylistCollection.Deserialize(protoPlaylist, removeExisting: false);
						DataVault.VisualPlaylistCollection.Save();
						break;
					}
				});
			}
			progress?.Invoke(100.0);
			break;
		}
		case SyncFileType.Theme:
			if (ProPresenter.DO.Settings.Sync.Settings.LocalSyncIncludeTemplates)
			{
				Write(data, progress);
			}
			break;
		}
	}
}
