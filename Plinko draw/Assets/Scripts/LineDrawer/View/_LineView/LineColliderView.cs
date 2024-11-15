using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LineColliderView : LineViewRoundBase
{
    [Inject] private LineDrawerSettings _settings;

    private PolygonCollider2D _collider;

    protected override void OnLineStarted()
    {
        _collider = Line.AddComponent<PolygonCollider2D>();
        _collider.pathCount = 0;
    }

    public override void OnAddPoint(Vector3 point)
    {
        if (Points.Count >= 2)
        {
            _collider.pathCount++;
            _collider.SetPath(_collider.pathCount - 1, BuildGroup(Points[Points.Count - 2], point));
        }
    }

    private Vector2[] BuildGroup(Vector3 start, Vector3 end)
    {
        Vector2[] positions = { start, end };

        float m = (positions[1].y - positions[0].y) / (positions[1].x - positions[0].x);
        float deltaX = (_settings.Width / 2f) * (m / Mathf.Pow(m * m + 1, 0.5f));
        float deltaY = (_settings.Width / 2f) * (1 / Mathf.Pow(1 + m * m, 0.5f));

        deltaX = float.IsNaN(deltaX) ? _settings.Width / 2 : deltaX;
        deltaY = float.IsNaN(deltaY) ? _settings.Width / 2 : deltaY;

        Vector2[] offsets = new Vector2[2];
        offsets[0] = new Vector2(-deltaX, deltaY);
        offsets[1] = new Vector2(deltaX, -deltaY);

        List<Vector2> colliderPoints = new List<Vector2> {
            positions[0] + offsets[0],
            positions[1] + offsets[0],
            positions[1] + offsets[1],
            positions[0] + offsets[1]
        };

        return colliderPoints.ToArray();
    }
}