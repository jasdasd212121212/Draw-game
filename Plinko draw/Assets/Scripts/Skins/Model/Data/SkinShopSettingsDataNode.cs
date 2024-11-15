using System;
using UnityEngine;

[Serializable]
public class SkinShopSettingsDataNode
{
    [SerializeField] private Sprite _skin;
    
    [Space]

    [SerializeField][Min(1)] private int _cost = 1;
    [SerializeField] private string _name;

    public Sprite Skin => _skin;
    public int Cost => _cost;
    public string Name => _name;
}