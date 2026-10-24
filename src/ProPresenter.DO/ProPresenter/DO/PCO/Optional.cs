namespace ProPresenter.DO.PCO;

internal class Optional<T>
{
	public T? Data { get; }

	public bool Success { get; }

	public Optional(T data)
	{
		Data = data;
		Success = true;
	}

	public Optional()
	{
		Success = false;
	}
}
