using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBall : MonoBehaviour, ILevelElementActiveSettable
{
    private Rigidbody2D _self;

    private void Awake()
    {
        InitializePhysics();
    }

    public void SetActive(bool state)
    {
        InitializePhysics();

        _self.bodyType = state == false ? RigidbodyType2D.Static : RigidbodyType2D.Dynamic;
    }

    private void InitializePhysics()
    {
        if (_self == null)
        {
            _self = GetComponent<Rigidbody2D>();
        }
    }
}