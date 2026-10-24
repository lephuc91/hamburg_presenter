using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.Components;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Storage;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Media.Properties.File;

namespace ProPresenter.DO.Media.Properties;

public class FileProperties : ObservableObject, ICloneable<FileProperties>
{
	[ObservableProperty]
	private RelativePath? _sourceFile;

	[ObservableProperty]
	private IRemoteFileProperties? _remoteProperties;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public RelativePath? SourceFile
	{
		get
		{
			return _sourceFile;
		}
		set
		{
			if (!EqualityComparer<RelativePath>.Default.Equals(_sourceFile, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SourceFile);
				_sourceFile = value;
				OnSourceFileChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SourceFile);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRemoteFileProperties? RemoteProperties
	{
		get
		{
			return _remoteProperties;
		}
		set
		{
			if (!EqualityComparer<IRemoteFileProperties>.Default.Equals(_remoteProperties, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.RemoteProperties);
				_remoteProperties = value;
				OnRemotePropertiesChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.RemoteProperties);
			}
		}
	}

	public event System.Action? DataModified;

	public static ObjectBinder<FileProperties, IFileProperties> CreateBinder(FileProperties left, IFileProperties right)
	{
		ObjectBinder<FileProperties, IFileProperties> objectBinder = new ObjectBinder<FileProperties, IFileProperties>(left, right);
		objectBinder.Bind((FileProperties l) => l.WhenPropertyChanges("SourceFile"), (IFileProperties r) => r.LocalUrl.WhenValueChanges, delegate(FileProperties l, IFileProperties r)
		{
			r.LocalUrl.Set(RelativePath.Create(l.SourceFile ?? RelativePath.Empty()));
		}, delegate(IFileProperties r, FileProperties l)
		{
			l.SourceFile = RelativePath.Create(r.LocalUrl.Value, out URL _);
		}).Bind((FileProperties l) => l.WhenPropertyChanges("RemoteProperties"), (IFileProperties r) => r.RemoteProperties.WhenValueChanges, delegate(FileProperties l, IFileProperties r)
		{
			if (l.RemoteProperties is ProContentFileProperties proContentFileProperties)
			{
				r.RemoteProperties.Value.Procontent.Value.DownloadIdentifier.Set(proContentFileProperties.DownloadId);
			}
			else
			{
				r.RemoteProperties.Value.Procontent.Value.DownloadIdentifier.Set(null);
			}
		}, delegate(IFileProperties r, FileProperties l)
		{
			if (!string.IsNullOrEmpty(r.RemoteProperties.Value.Procontent.Value.DownloadIdentifier.Value))
			{
				l.RemoteProperties = new ProContentFileProperties(r.RemoteProperties.Value.Procontent.Value.DownloadIdentifier.Value);
			}
			else
			{
				l.RemoteProperties = null;
			}
		});
		return objectBinder;
	}

	public void SerializeToEntity(IFileProperties file)
	{
		file.LocalUrl.Set(RelativePath.Create(SourceFile ?? RelativePath.Empty()));
		file.RemoteProperties.Value.Procontent.Value.DownloadIdentifier.Set((RemoteProperties as ProContentFileProperties)?.DownloadId ?? "");
	}

	public void DeserializeEntity(IFileProperties file)
	{
		SourceFile = RelativePath.Create(file.LocalUrl.Value, out URL _);
		if (!string.IsNullOrEmpty(file.RemoteProperties.Value.Procontent.Value.DownloadIdentifier.Value))
		{
			RemoteProperties = new ProContentFileProperties(file.RemoteProperties.Value.Procontent.Value.DownloadIdentifier.Value ?? string.Empty);
		}
		else
		{
			RemoteProperties = null;
		}
	}

	public Pro.SerializationInterop.RVProtoData.FileProperties Serialize()
	{
		return new Pro.SerializationInterop.RVProtoData.FileProperties
		{
			LocalUrl = SourceFile?.Serialize(),
			RemoteProperties = RemoteProperties?.Serialize()
		};
	}

	public void Deserialize(Pro.SerializationInterop.RVProtoData.FileProperties protoFileProperties)
	{
		if (protoFileProperties != null)
		{
			SourceFile = new RelativePath(protoFileProperties.LocalUrl);
			if (protoFileProperties.RemoteProperties?.Procontent != null)
			{
				RemoteProperties = new ProContentFileProperties(protoFileProperties.RemoteProperties.Procontent.DownloadIdentifier);
			}
		}
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	public FileProperties Clone()
	{
		return new FileProperties
		{
			SourceFile = SourceFile?.Clone(),
			RemoteProperties = RemoteProperties?.Clone()
		};
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnSourceFileChanged(RelativePath? value)
	{
		OnDataModified();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnRemotePropertiesChanged(IRemoteFileProperties? value)
	{
		OnDataModified();
	}
}
