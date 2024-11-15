using UnityEngine;
using Zenject;

public class LineDrawerPresenter : MonoBehaviour
{
    [Inject] private LineDrawerSettings _settings;
    [Inject] private LineDrawModel _model;
    [Inject] private IDrawInput _input;

    [Inject] private LineDrawerAmountModel _amountModel;

    private Camera _cachedCamera;

    private void Awake()
    {
        _cachedCamera = Camera.main;

        _input.lineStarted += OnStart;
        _input.pointed += OnDraw;
        _input.lineEnded += OnEnd;
    }

    private void OnDestroy()
    {
        _input.lineStarted -= OnStart;
        _input.pointed -= OnDraw;
        _input.lineEnded -= OnEnd;
    }

    private void OnStart()
    {
        _model.StartNewLine();
    }

    private void OnDraw(Vector2 point)
    {
        Vector3 newPoint = _cachedCamera.ScreenToWorldPoint(new Vector3(point.x, point.y, 0f));

        if (_model.Points.Count >= 1)
        {
            if (Vector3.Distance(newPoint, _model.Points[_model.Points.Count - 1]) < _settings.DistanceThrashold)
            {
                return;
            }
        }

        if (_amountModel.Amount <= 0)
        {
            return;
        }

        _model.AddPoint(newPoint);
        _amountModel.DecreaseAmount();
    }

    private void OnEnd()
    {
        _model.EndLine();
    }
}