using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class LineViewRoundBase : MonoBehaviour
{
    [Inject] private LineDrawModel _model;

    protected GameObject Line { get; private set; }
    protected LineRendererShell LineRenderer { get; private set; }
    protected IReadOnlyList<Vector3> Points => _model.Points;

    public void OnStartLine(LineRendererShell line)
    {
        Line = line.gameObject;
        LineRenderer = line;

        OnLineStarted();
    }

    public virtual void OnEndLine(Vector3[] points) { }
    public virtual void OnAddPoint(Vector3 point) { }
    protected virtual void OnLineStarted() { }
}