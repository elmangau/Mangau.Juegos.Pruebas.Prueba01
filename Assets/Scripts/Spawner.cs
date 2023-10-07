using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject toSpawn;

    private float _nextInterval = 0f;
    public float intervalMin = 2f;
    public float intervalMax = 5f;

    public Vector2 spawnMin = new(13f, -5f);
    public Vector2 spawnMax = new(13f, +5f);

    void Update()
    {
        _nextInterval -= Time.deltaTime;

        if (_nextInterval < 0f && toSpawn != null)
        {
            _nextInterval = Random.Range(intervalMin, intervalMax);
            var pos = new Vector3(Random.Range(spawnMin.x, spawnMax.x), Random.Range(spawnMin.y, spawnMax.y), 0f);

            Instantiate(toSpawn, pos, Quaternion.identity);
        }
    }
}
