using UnityEngine;
using Zenject;

public class LineView : MonoBehaviour
{
    [SerializeField] private LineRendererShell _linePrefab;
    [SerializeField] private LineViewRoundBase[] _viewRounds;

    [Inject] private LineDrawModel _model;
    [Inject] private LineDrawerSettings _settings;

    private MonoFactory<LineRendererShell> _lineViewFactory;

    private float LINE_WIDTH_COEFICIENT = 10;

    private void Awake()
    {
        _lineViewFactory = new MonoFactory<LineRendererShell>(_linePrefab, null);

        _model.drawStarted += OnStartDraw;
        _model.drawEnded += OnEndDraw;
        _model.pointAdden += OnAddPoint;
    }

    private void OnDestroy()
    {
        _model.drawStarted -= OnStartDraw;
        _model.drawEnded -= OnEndDraw;
        _model.pointAdden -= OnAddPoint;
    }

    private void OnStartDraw()
    {
        LineRendererShell line = _lineViewFactory.Create();
        line.transform.position = Vector3.zero;

        AnimationCurve width = new AnimationCurve();
        width.AddKey(0, _settings.Width * LINE_WIDTH_COEFICIENT);
        width.AddKey(1, _settings.Width * LINE_WIDTH_COEFICIENT);

        line.Renderer.widthCurve = width;

        foreach (LineViewRoundBase view in _viewRounds)
        {
            view.OnStartLine(line);
        }
    }

    private void OnEndDraw(Vector3[] line)
    {
        foreach (LineViewRoundBase view in _viewRounds)
        {
            view.OnEndLine(line);
        }
    }

    private void OnAddPoint(Vector3 point)
    {
        foreach (LineViewRoundBase view in _viewRounds)
        {
            view.OnAddPoint(point);
        }
    }
}