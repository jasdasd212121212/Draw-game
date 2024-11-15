using System;
using UnityEngine;

[Serializable]
public class IntDataTransferObject
{
    [SerializeField] private int _data;

    public int Data => _data;

    public IntDataTransferObject(int data)
    {
        _data = data;
    }
}