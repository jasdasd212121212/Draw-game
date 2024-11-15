using System.Collections.Generic;
using UnityEngine;

public class ScreenSideObjectParenter : MonoBehaviour
{
    [SerializeField] private Side _side;
    [SerializeField] private GameObject _target;
    [SerializeField] private float _offset;

    private Camera _mainCamera;

    private Dictionary<Side, KeyValuePair<Vector3, int>> _directions = new Dictionary<Side, KeyValuePair<Vector3, int>>
    {
        { Side.Top, new KeyValuePair<Vector3, int>(Vector3.up, 3) }, 
        { Side.Bottom, new KeyValuePair<Vector3, int>(Vector3.down, 2) }, 
        { Side.Left, new KeyValuePair<Vector3, int>(Vector3.left, 0) }, 
        { Side.Right, new KeyValuePair<Vector3, int>(Vector3.right, 1) }
    };

    enum Side
    {
        Top,
        Bottom,
        Left,
        Right
    }

    private void Start()
    {
        _mainCamera = Camera.main;
        Vector3 currentDirection = _directions[_side].Key;

        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_mainCamera);
        Ray ray = new Ray(_mainCamera.transform.position, currentDirection);

        planes[_directions[_side].Value].Raycast(ray, out float distance);

        _target.transform.position = _mainCamera.transform.position;
        _target.transform.position = _target.transform.position + currentDirection * distance;

        _target.transform.position = new Vector3(_target.transform.position.x, _target.transform.position.y, 0f);
    }
}