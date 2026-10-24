using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Abstractions;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common.Collections;
using Pro.Common.Logging;
using Pro.Localization;
using Pro.Reporting.UserFeedback.AttachmentUpload.Model;
using Pro.UI.DialogService;
using ProPresenter.DO;
using ProPresenter.UI.UserAttachments;

namespace ProPresenter.UI.ViewModels.UserAttachments;

public class UserAttachmentCollectionVM : ObservableCollection<IUserAttachment>, IUserAttachmentCollectionVM, IEnumerable<IUserAttachment>, IEnumerable
{
	private readonly IFileSystem _fileSystem;

	private readonly IUserAttachmentVMFactory _userAttachmentVMFactory;

	private readonly IUserAttachSettings _userAttachSettings;

	private readonly ILogger _logger;

	private readonly string _uploadTempDir;

	public UserAttachmentCollectionVM(IFileSystem fileSystem, IUserAttachmentVMFactory userAttachmentVMFactory, IUserAttachSettings userAttachSettings, ILogger logger)
	{
		_fileSystem = fileSystem;
		_userAttachmentVMFactory = userAttachmentVMFactory;
		_userAttachSettings = userAttachSettings;
		_logger = logger;
		string randomFileName = _fileSystem.Path.GetRandomFileName();
		_uploadTempDir = _fileSystem.Path.Combine(CommonPaths.DefaultTemp, randomFileName);
		_fileSystem.Directory.CreateDirectory(_uploadTempDir);
	}

	public async Task AddAsync(string fileName)
	{
		string fileName2 = _fileSystem.Path.GetFileName(fileName);
		string newFile = _fileSystem.Path.Combine(_uploadTempDir, fileName2);
		IUserAttachment userAttachment = await Task.Run(delegate
		{
			try
			{
				_fileSystem.File.Copy(fileName, newFile, overwrite: true);
				return _userAttachmentVMFactory.CreateUserAttachmentVM(newFile);
			}
			catch (Exception ex)
			{
				_logger.Error("Unable to copy file - " + fileName + " to " + newFile);
				_logger.Error(ex);
				return (IUserAttachment)null;
			}
		});
		if (userAttachment != null)
		{
			Add(userAttachment);
		}
	}

	public async Task AddAsync(IReadOnlyList<string> fileNames)
	{
		await Task.WhenAll(fileNames.Select((string a) => AddAsync(a)));
	}

	public void Add(IEnumerable<IUserAttachment> attachments)
	{
		attachments.ForEach(delegate(IUserAttachment x)
		{
			Add(x);
		});
	}

	public new void Add(IUserAttachment attachment)
	{
		if (IsAllowedToBeAdded(attachment))
		{
			base.Add(attachment);
		}
	}

	private bool IsAllowedToBeAdded(IUserAttachment attachment)
	{
		attachment.Validate(_userAttachSettings);
		UserAttachmentLimit userAttachmentLimit = _userAttachSettings.AttachmentLimits.FirstOrDefault((UserAttachmentLimit x) => attachment.Extension.EndsWith(x.Extension, StringComparison.InvariantCultureIgnoreCase));
		if (!attachment.Exists)
		{
			throw new ArgumentException("FileName does not exist", "FileName");
		}
		if (userAttachmentLimit == null)
		{
			ShowAlert(string.Format(LocalizedStrings.Get("USER_FEEDBACK_ATTACHMENT_ERROR_INVALID_FILE_TYPE_message"), attachment.Extension, string.Join(", ", _userAttachSettings.AttachmentLimits.Select((UserAttachmentLimit x) => x.Extension))));
			return false;
		}
		if (Contains(attachment))
		{
			return false;
		}
		if (userAttachmentLimit.MaxQuantity > 0 && this.Count((IUserAttachment x) => x.Extension.Equals(attachment.Extension)) > userAttachmentLimit.MaxQuantity)
		{
			ShowAlert(LocalizedStrings.Get("USER_FEEDBACK_ATTACHMENT_ERROR_TOO_MANY_message", new object[1] { userAttachmentLimit.MaxQuantity }));
			return false;
		}
		if (_userAttachSettings.MaxAttachments > 0 && this.Count() > _userAttachSettings.MaxAttachments)
		{
			ShowAlert(LocalizedStrings.Get("USER_FEEDBACK_ATTACHMENT_ERROR_TOO_MANY_message", new object[1] { _userAttachSettings.MaxAttachments }));
			return false;
		}
		return true;
	}

	private void ShowAlert(string message)
	{
		_logger.Warning(message);
		MessageDialogService.ShowAlert(message);
	}

	void IUserAttachmentCollectionVM.Remove(IUserAttachment attachment)
	{
		Remove(attachment);
	}

	public List<Attachment> ToFileAttachments()
	{
		return (from a in this
			where a.IsReadyToSend
			select a into i
			select i.ToFileAttachment()).ToList();
	}
}
