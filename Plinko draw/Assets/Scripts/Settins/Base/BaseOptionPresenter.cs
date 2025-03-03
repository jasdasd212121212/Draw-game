using Cysharp.Threading.Tasks;
using System;

public abstract class BaseOptionPresenter<T> : ISaveble<T>
{
    private T _state;

    protected readonly BaseOptionView<T> View;

    public event Action dataChecnged;
    public event Action loaded;

    public BaseOptionPresenter(BaseOptionView<T> view)
    {
        View = view;
        View.stateChanged += OnViewChanged;
    }

    ~BaseOptionPresenter()
    {
        if (View != null)
        {
            View.stateChanged -= OnViewChanged;
        }
    }

    protected abstract void Apply(T data);
    protected abstract UniTask<T> GetDefaultData();
    protected virtual async UniTask<BaseOptionPresenterDataValidationCallback<T>> ValidateDefaultData(T currentDefaultData) 
    {
        await UniTask.Delay(0);
        return new(true, default); 
    }

    public async UniTask<T> GetData(bool isFirstSave)
    {
        T data;
        T defaultData = await GetDefaultData();
        BaseOptionPresenterDataValidationCallback<T> validationCallback = await ValidateDefaultData(defaultData);

        if (isFirstSave)
        {
            data = defaultData;
            ApplyData(data);
        }
        else
        {
            if (_state != null)
            {
                data = _state;
            }
            else
            {
                data = defaultData;
                ApplyData(data);
            }
        }

        if (validationCallback.IsValid == false)
        {
            ApplyData(validationCallback.Data);
        }

        return validationCallback.IsValid ? data : validationCallback.Data;
    }

    public void SetData(T data)
    {
        _state = View.State;
        ApplyData(data);
        loaded?.Invoke();
    }

    private void ApplyData(T data)
    {
        Apply(data);
        View.Display(data);
    }

    private void OnViewChanged()
    {
        _state = View.State;
        Apply(_state);

        dataChecnged?.Invoke();
    }
}