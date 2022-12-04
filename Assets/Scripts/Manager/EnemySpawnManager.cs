using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawnManager : MonoBehaviour
{
    public static EnemySpawnManager instance;

    [SerializeField] Transform _stageLimitBottomLeft;
    [SerializeField] Transform _stageLimitTopRight;

    [SerializeField] private float waveDelay;

    [SerializeField] private List<EnemyWave> enemyWaves;

    private List<GameObject> spawnedEnemies;
    public int _currentWaveCount = 0;
    public int _maxWaveCount;
    private float timer;

    // Singleton
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
    }

    private void Start()
    {
        spawnedEnemies = new List<GameObject>();
        _maxWaveCount = enemyWaves.Count;
        timer = 0f;
    }

    private void Update()
    {
        if (_currentWaveCount >= _maxWaveCount) return;

        timer += Time.deltaTime;
        if (timer <= waveDelay) return;

        SpawnCurrentWaveEnemies(_currentWaveCount);
    }

    private void SpawnCurrentWaveEnemies(int waveCount)
    {
        foreach (Enemy e in enemyWaves[waveCount].enemies)
        {
            Vector3 spawnPosition = GetSpawnPosition();
            Enemy newEnemy = SpawnEnemy(e, spawnPosition);
            AddSpawnedEnemy(newEnemy.gameObject);
        }

        enemyWaves[waveCount].enemies.Clear();
    }

    private Enemy SpawnEnemy(Enemy enemy, Vector3 position)
    {
        return Instantiate(enemy, position, Quaternion.identity);
    }

    private Vector3 GetSpawnPosition()
    {
        Vector3 spawnPos;
        switch (Random.Range(0, 4))
        {
            case 0:
                spawnPos = new Vector3(
                    Random.Range(_stageLimitBottomLeft.position.x, _stageLimitTopRight.position.x), _stageLimitTopRight.position.y);
                return spawnPos;
            case 1:
                spawnPos = new Vector3(
                    _stageLimitBottomLeft.position.x, Random.Range(_stageLimitBottomLeft.position.y, _stageLimitTopRight.position.y));
                return spawnPos;
            case 2:
                spawnPos = new Vector3(
                    Random.Range(_stageLimitBottomLeft.position.x, _stageLimitTopRight.position.x), _stageLimitBottomLeft.position.y);
                return spawnPos;
            case 3:
                spawnPos = new Vector3(
                    _stageLimitTopRight.position.x, Random.Range(_stageLimitBottomLeft.position.y, _stageLimitTopRight.position.y));
                return spawnPos;
            default:
                return new Vector3(0, 0);
        }
    }

    public void AddSpawnedEnemy(GameObject enemy)
    {
        spawnedEnemies.Add(enemy);
    }

    public void RemoveSpawnedEnemy(GameObject enemy)
    {
        spawnedEnemies.Remove(enemy);

        if (spawnedEnemies.Count <= 0 && enemyWaves[_currentWaveCount].enemies.Count <= 0)
        {
            _currentWaveCount++;
            Debug.Log("YO");
            timer = 0f;
        }
    }
}

[System.Serializable]
public class EnemyWave
{
    public List<Enemy> enemies;
}
