using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class AutoTranslaterModeDrawer : IModeDrawer
{
    private AutoTranslatePresenter _presenter;
    private EditorWindow _parentWindow;

    private int _startIndex;
    private int _endIndex;

    private float _progress;

    private int _nodesCount;

    private Action backButton;

    public AutoTranslaterModeDrawer(Action backButton, int nodesCount, AutoTranslatePresenter presenter, EditorWindow parentWindow)
    {
        this.backButton = backButton;
        _nodesCount = nodesCount;
        _presenter = presenter;
        _parentWindow = parentWindow;

        _presenter.progressChanged += OnChangeProgress;
    }

    ~AutoTranslaterModeDrawer()
    {
        _presenter.progressChanged -= OnChangeProgress;
    }

    public void Draw()
    {
        if (_presenter.IsInProgress == false)
        {
            if (GUILayout.Button("Back"))
            {
                backButton?.Invoke();
            }
        }
        
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Start index:");
        _startIndex = EditorGUILayout.IntField(_startIndex);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("End index:");
        _endIndex = EditorGUILayout.IntField(_endIndex);
        EditorGUILayout.EndHorizontal();

        Validate();

        EditorGUILayout.Space(30);

        if (_presenter.IsInProgress == false)
        {
            if (GUILayout.Button("Translate"))
            {
                _presenter.Translate(_startIndex, _endIndex);
            }
        }
        else
        {
            EditorGUI.ProgressBar(new Rect(3, 100, _parentWindow.position.width - 6, 20), _progress, "Translating ...");
        }
    }

    private void Validate()
    {
        _startIndex = Mathf.Clamp(_startIndex, 0, _endIndex);
        _endIndex = Mathf.Clamp(_endIndex, 0, _nodesCount);
    }

    private void OnChangeProgress(float progress)
    {
        _progress = progress;
    }
}