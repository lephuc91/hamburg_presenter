namespace ProPresenter.Registration.CallbackHandlers.Dialogs;

public record ButtonDescriptor<T>(string Key, T Result, params string[] Parameters);
