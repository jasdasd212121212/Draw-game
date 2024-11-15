using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToutchFreeCameraInputSystem : IFreeCameraInputSystem
{
    private Vector3 _currentDirection;

    private EventTrigger _moveUpButton;
    private EventTrigger _moveDownButton;

    public ToutchFreeCameraInputSystem(EventTrigger moveUpButton, EventTrigger moveDownButton)
    {
        _moveUpButton = moveUpButton;
        _moveDownButton = moveDownButton;

        SubscribeToEventTrigger(_moveUpButton, EventTriggerType.PointerDown, OnPressUp);
        SubscribeToEventTrigger(_moveUpButton, EventTriggerType.PointerUp, OnRelease);

        SubscribeToEventTrigger(_moveDownButton, EventTriggerType.PointerDown, OnPressDown);
        SubscribeToEventTrigger(_moveDownButton, EventTriggerType.PointerUp, OnRelease);
    }

    public Vector3 GetDirection()
    {
        return _currentDirection;
    }

    private void SubscribeToEventTrigger(EventTrigger trigger, EventTriggerType type, Action action)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = type;
        entry.callback.AddListener((eventData) => { action?.Invoke(); });
        trigger.triggers.Add(entry);
    }

    private void OnPressUp()
    {
        _currentDirection = Vector3.up;
    }

    private void OnPressDown()
    {
        _currentDirection = Vector3.down;
    }

    private void OnRelease()
    {
        _currentDirection = Vector3.zero;
    }
}