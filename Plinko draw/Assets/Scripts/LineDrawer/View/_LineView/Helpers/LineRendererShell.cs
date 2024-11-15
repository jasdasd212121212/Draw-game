using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineRendererShell : MonoBehaviour
{
    private LineRenderer _self;

    public LineRenderer Renderer
    {
        get
        {
            if (_self == null)
            {
                _self = GetComponent<LineRenderer>();
            }

            return _self;
        }
    }

    private void Awake()
    {
        _self = GetComponent<LineRenderer>();
    }
}