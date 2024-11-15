using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Finish : MonoBehaviour
{
    public event Action finished;

    private void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerBall>() != null)
        {
            finished?.Invoke();
        }
    }
}