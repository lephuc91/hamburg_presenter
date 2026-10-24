using System;

namespace ProPresenter.Registration.CallbackHandlers.Dialogs;

public interface IRegistrationCallbackDialogProvider
{
	void ShowExpiration(int days);

	bool ShowInAppRenewalStore();

	void ShowInAppBibleStore();

	void ShowDialog<T>(TextDescriptor title, TextDescriptor message, params ButtonDescriptor<T>[] buttons) where T : struct;

	void ShowDialog<T>(TextDescriptor title, TextDescriptor message, Action<T>? continuation, params ButtonDescriptor<T>[] buttons) where T : struct;

	void ShowDialog<T>(TextDescriptor title, TextDescriptor message, T closeResult, params ButtonDescriptor<T>[] buttons) where T : struct;

	void ShowDialog<T>(TextDescriptor title, TextDescriptor message, T closeResult, Action<T>? continuation, params ButtonDescriptor<T>[] buttons) where T : struct;

	void ShowError(TextDescriptor title, TextDescriptor message);

	void ShowErrorWithCheckbox(TextDescriptor title, TextDescriptor message, TextDescriptor checkboxTitle, Action<bool> continuation);

	void ShowSettings();
}
