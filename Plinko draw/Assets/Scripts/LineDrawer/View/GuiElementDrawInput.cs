using System;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class GuiElementDrawInput : MonoBehaviour, IDrawInput, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public event Action<Vector2> pointed;
    public event Action lineStarted;
    public event Action lineEnded;

    public void OnPointerDown(PointerEventData eventData)
    {
        lineStarted?.Invoke();
    }

    public void OnDrag(PointerEventData eventData)
    {
        pointed?.Invoke(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        lineEnded?.Invoke();
    }
}