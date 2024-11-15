using UnityEngine;

public class LineViewRenderer : LineViewRoundBase
{
    private int MIN_POINTS_COUNT_TO_FAST_UPDATE = 3;

    public override void OnAddPoint(Vector3 point)
    {
        if (Points.Count < MIN_POINTS_COUNT_TO_FAST_UPDATE)
        {
            RespawnLine();
        }
        else
        {
            LineRenderer.Renderer.positionCount++;
            LineRenderer.Renderer.SetPosition(LineRenderer.Renderer.positionCount - 1, new Vector3(point.x, point.y, 0f));
        }
    }

    private void RespawnLine()
    {
        LineRenderer.Renderer.positionCount = Points.Count;

        for (int i = 0; i < Points.Count; i++)
        {
            LineRenderer.Renderer.SetPosition(i, new Vector3(Points[i].x, Points[i].y, 0f));
        }
    }
}