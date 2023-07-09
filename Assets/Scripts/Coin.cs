using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action Collected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            Collected.Invoke();
            Destroy(gameObject);
        }
    }
}