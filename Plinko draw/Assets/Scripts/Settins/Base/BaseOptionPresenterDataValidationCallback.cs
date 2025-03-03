public class BaseOptionPresenterDataValidationCallback<T>
{
    public bool IsValid { get; private set; }
    public T Data { get; private set; }

    public BaseOptionPresenterDataValidationCallback(bool isValid, T data)
    {
        IsValid = isValid;
        Data = data;
    }
}