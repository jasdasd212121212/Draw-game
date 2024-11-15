using UnityEngine;

public class PlayerFollowCamera : CameraBase
{
    [SerializeField] private Transform _target;

    private void Update()
    {
        SetPosition(new Vector3(Position.x, _target.position.y, Position.z));
    }
}