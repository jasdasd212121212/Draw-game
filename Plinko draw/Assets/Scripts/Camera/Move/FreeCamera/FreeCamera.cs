using UnityEngine;
using Zenject;

public class FreeCamera : CameraBase
{
    [SerializeField][Min(0.0001f)] private float _speed;

    [Inject] private IFreeCameraInputSystem _input;

    private void Update()
    {
        SetPosition(Position + _input.GetDirection() * _speed * Time.deltaTime);
    }
}