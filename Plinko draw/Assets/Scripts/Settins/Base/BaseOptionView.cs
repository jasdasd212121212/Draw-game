using System;
using UnityEngine;

public abstract class BaseOptionView<T> : MonoBehaviour
{
    public event Action stateChanged;

    public abstract T State { get; }

    public abstract void Display(T data);
    protected void CallChange() => stateChanged?.Invoke();
}