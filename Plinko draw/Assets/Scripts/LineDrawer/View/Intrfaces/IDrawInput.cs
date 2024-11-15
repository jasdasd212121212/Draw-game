using System;
using UnityEngine;

public interface IDrawInput
{
    event Action<Vector2> pointed;

    event Action lineStarted;
    event Action lineEnded;
}