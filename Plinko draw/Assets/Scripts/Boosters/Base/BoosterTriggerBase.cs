using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class BoosterTriggerBase : MonoBehaviour
{
    public event Action entered;
    public event Action stay;

    protected void Awake()
    {   
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D body = null;

        if (collision.gameObject.TryGetComponent(out body) == true)
        {
            OnBodyEnter(body);
            entered?.Invoke();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Rigidbody2D body = null;

        if (collision.gameObject.TryGetComponent(out body) == true)
        {
            OnBodyStay(body);
            stay?.Invoke();
        }
    }

    protected virtual void OnBodyEnter(Rigidbody2D body) { }
    protected virtual void OnBodyStay(Rigidbody2D body) { }
}