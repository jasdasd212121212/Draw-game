using UnityEngine;
using Zenject;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerSkinView : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    [Inject] private SkinSystemModel _model;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        _model.loaded += Display;
        Display();
    }

    private void OnDestroy()
    {
        _model.loaded -= Display;
    }

    private void Display()
    {
        _spriteRenderer.sprite = _model.CurrentSkin;
    }
}