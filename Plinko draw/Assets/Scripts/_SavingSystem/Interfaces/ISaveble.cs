using Cysharp.Threading.Tasks;
using System;

public interface ISaveble<T>
{
    event Action dataChecnged;
    event Action loaded;

    UniTask<T> GetData(bool isFirstSave);
    void SetData(T data);   
}