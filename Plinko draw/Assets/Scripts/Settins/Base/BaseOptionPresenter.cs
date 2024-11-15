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
    protected abstract T GetDefaultData();

    public T GetData()
    {
        T data;

        if (_state != null)
        {
            data = _state;
        }
        else
        {
            data = GetDefaultData();
        }

        return data;
    }

    public void SetData(T data)
    {
        Apply(data);
        View.Display(data);

        loaded?.Invoke();
    }

    private void OnViewChanged()
    {
        _state = View.State;
        Apply(_state);

        dataChecnged?.Invoke();
    }
}