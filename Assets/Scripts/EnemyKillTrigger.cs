using UnityEngine;
using UnityEngine.Events;

public class EnemyKillTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _enemyKilled;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Destroy(collision.gameObject);
            _enemyKilled.Invoke();
        }
    }
}
