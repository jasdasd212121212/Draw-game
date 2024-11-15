using System;

public interface ISaveble<T>
{
    event Action dataChecnged;
    event Action loaded;

    T GetData();
    void SetData(T data);   
}