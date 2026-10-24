using System;
using System.ComponentModel;
using Pro.Common.Components.Reversibility;
using Pro.DO.Token;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.CCLI;

public interface ICCLILayoutData : INotifyPropertyChanged
{
	string Text { get; set; }

	TokenCollection<CCLIToken> Tokens { get; }

	UndoStack UndoStack { get; }

	event System.Action DataModified;

	CopyrightLayout Serialize();

	void Deserialize(CopyrightLayout layout);
}
