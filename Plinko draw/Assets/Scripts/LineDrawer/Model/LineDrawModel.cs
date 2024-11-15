using System;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawModel
{
    private List<Vector3> _points = new List<Vector3>();

    private bool _isStarted;

    public IReadOnlyList<Vector3> Points => _points;

    public event Action<Vector3[]> drawEnded;
    public event Action<Vector3> pointAdden;
    public event Action drawStarted;

    public void StartNewLine()
    {
        if (_isStarted == true)
        {
            Debug.LogError($"Critical error -> can`t start not ended line");
            return;
        }

        _points.Clear();
        _points = new List<Vector3>();

        _isStarted = true;

        drawStarted?.Invoke();
    }

    public void AddPoint(Vector3 point)
    {
        if (_points == null || _isStarted == false)
        {
            Debug.LogError($"Critical error -> can`t add point to not started line; Points: {_points}");
            return;
        }

        _points.Add(point);
        pointAdden?.Invoke(point);
    }

    public void EndLine()
    {
        if (_isStarted == false)
        {
            Debug.LogError($"Critical error -> can`t end not started line");
            return;
        }

        _isStarted = false;

        if (_points.Count == 0)
        {
            return;
        }

        drawEnded?.Invoke(_points.ToArray());
    }
}