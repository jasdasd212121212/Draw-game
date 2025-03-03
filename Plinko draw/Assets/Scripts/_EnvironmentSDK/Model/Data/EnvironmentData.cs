using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentData : IReadOnlyEnvironmentData
{
    private Dictionary<Type, EnvironmentDataSegment> _data = new Dictionary<Type, EnvironmentDataSegment>();

    private bool _isWriteDone;

    public void WriteSegemnt<T>(T segment) where T : EnvironmentDataSegment
    {
        if (_data.ContainsKey(typeof(T)))
        {
            Debug.LogError($"Critical error -> segment early has been adden: {typeof(T)}");
            return;
        }

        _data.Add(typeof(T), segment);
    }

    public void EndWrite() => _isWriteDone = true;

    public async UniTask<T> ReadSegment<T>() where T : EnvironmentDataSegment
    {
        await UniTask.WaitWhile(() => _isWriteDone == false);

        if (!_data.ContainsKey(typeof(T)))
        {
            Debug.LogError($"Critical error -> can`t read not existed segement: {typeof(T)}");
            return null;
        }

        return _data[typeof(T)] as T;
    }
}