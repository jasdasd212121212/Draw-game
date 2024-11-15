using System;
using UnityEngine;

public class PlinkoBonusModel
{
    private int _bonus;
    private int _ballsCount;
    private int _evaluatedBallsCount;
    private float _coeficient;

    public int TotalRevenue => Mathf.RoundToInt((float)((float)_bonus * (float)_ballsCount) * _coeficient);
    public bool IsEnded => _evaluatedBallsCount == _ballsCount;

    public event Action ended;

    public PlinkoBonusModel(float coeficient)
    {
        _coeficient = coeficient;
    }

    public void EvaluateBonus(int value)
    {
        if (value < 0)
        {
            Debug.LogError($"Critical error -> can`t evaluate coeficient with value: {value} < 0");
            return;
        }

        _bonus += value;
        _evaluatedBallsCount++;

        if (IsEnded == true)
        {
            ended?.Invoke();
        }
    }

    public void SetBallsCount(int value)
    {
        if (value < 0)
        {
            Debug.LogError($"Critical error -> can`t set ball count with value: {value} < 0");
            return;
        }

        _ballsCount = value;
    }
}