using UnityEngine;
using DG.Tweening;
using Unity.Mathematics;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;

    private void Start()
    {
        Vector3 firstPosition = transform.position;
        Vector3 secondPosition = _target.transform.position;

        Vector3 uTurn = new Vector3(0, 180, 0);;

        float moveDuration = (secondPosition.x - firstPosition.x) / _speed;
        float rotateDuration = 0.001f;

        Sequence sequence = DOTween.Sequence();

        sequence.Append
            (transform.DOMove(secondPosition, moveDuration).SetEase(Ease.Linear));
        sequence.Append
            (transform.DORotate(uTurn, rotateDuration).SetEase(Ease.Linear));
        sequence.Append
            (transform.DOMove(firstPosition, moveDuration).SetEase(Ease.Linear));
        sequence.Append
            (transform.DORotate(Vector3.zero, rotateDuration).SetEase(Ease.Linear));

        sequence.SetLoops(-1, LoopType.Restart);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
            Destroy(collision.gameObject);
    }
}
