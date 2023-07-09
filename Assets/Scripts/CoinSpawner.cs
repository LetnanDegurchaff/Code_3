using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private float _respawnTime;

    private Coin _coin;
    private Coroutine _coroutine;
    private WaitForSeconds _respawnTimeWait;

    private void Awake()
    {
        _respawnTimeWait = new WaitForSeconds(_respawnTime);

        _coroutine = null;

        SpawnCoin();
    }

    public void StartRespawnTimer()
    {
        _coroutine = StartCoroutine(RespawnCoin());
    }

    private IEnumerator RespawnCoin()
    {
        yield return _respawnTimeWait;

        SpawnCoin();
    }

    private void SpawnCoin()
    {
        _coin = Instantiate<Coin>
        (_coinPrefab, transform.position, Quaternion.identity);

        _coin.Collected += StartRespawnTimer;
    }
}