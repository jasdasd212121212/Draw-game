using UnityEngine;

[CreateAssetMenu(fileName = "LineDrawerSettings", menuName = "Game design/Line/LineDrawer")]
public class LineDrawerSettings : ScriptableObject
{
    [SerializeField][Min(0.001f)] private float _distanceThrashold;
    [SerializeField][Min(0.001f)] private float _width;

    public float DistanceThrashold => _distanceThrashold;
    public float Width => _width;
}