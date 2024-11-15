using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class AutoTranslatePresenter
{
    private ILocalEditorPresenter _presenter;
    private LocolizeNode[] _nodes;

    private float _startDelta;
    private float _translatedCount;

    public bool IsInProgress { get; private set; }
    public event Action<float> progressChanged;

    public AutoTranslatePresenter(ILocalEditorPresenter presenter)
    {
        _presenter = presenter;
    }

    public void Translate(int startIndex, int endIndex)
    {
        if (startIndex >= endIndex)
        {
            Debug.LogError($"Critical error -> can`t set a {nameof(endIndex)} >= {nameof(startIndex)}");
            return;
        }

        TranslateAsync(startIndex, endIndex).Forget();
    }

    private async UniTask TranslateAsync(int startIndex, int endIndex)
    {
        IsInProgress = true;

        _translatedCount = 0;
        _startDelta = ((float)(float)endIndex - (float)startIndex);
        _nodes = _presenter.Deserialize();

        progressChanged?.Invoke(0f);

        for (int i = startIndex; i < endIndex; i++)
        {
            await _presenter.Translate(_nodes[i]);
            _translatedCount++;
            progressChanged?.Invoke(_translatedCount / _startDelta);
        }

        IsInProgress = false;
    }
}