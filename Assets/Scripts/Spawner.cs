using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Meteor MeteorPrefab;
    public float SpawnDelay = 2;
    public float WidthSpawner = 8;
    public float YPosition = 6;
    private float _spawnTimer;
    
    public float SpeedIncreasePerStage = 1f;       // На сколько увеличивать скорость метеорита каждые 10 сек
    public float SpawnDelayDecreasePerStage = 0.2f; // На сколько уменьшать задержку спавна каждые 10 сек
    public float StageInterval = 10f;              // Интервал в секундах между стадиями

    private float _stageTimer;  //Таймер для подсчёта времени стадии
    private float _currentSpawnDelay; // Текущее время спавна метеоритов
    private float _currentMeteorSpeed; // Текущее скорость метеоритов

    void Start()
    {
        _currentSpawnDelay = SpawnDelay; // Текущее время спавна приравниваем к начальному
        _currentMeteorSpeed = MeteorPrefab.Speed; // Текущую скорость метеорита приравниваем к начальной.
    }

    void Update()
    {
        _spawnTimer += Time.deltaTime;
        _stageTimer += Time.deltaTime;

        if (_spawnTimer >= _currentSpawnDelay)
        {
            _spawnTimer = 0;
            Spawn();
        }

        if(_stageTimer >= StageInterval) // Если сработал таймер
        {
            _stageTimer = 0; // Сбрасываем таймер
            _currentMeteorSpeed += SpeedIncreasePerStage; // Увеличиваем скорость метеоритов
            // Уменьшаем время спавна, но значение может стать 0 и меньше. Поэтому используем
            // Метод Mathf.Max, который выберет большее значение из
            // 0.1 или _currentSpawnDelay - SpawnDelayDecreasePerStage
            _currentSpawnDelay = Mathf.Max(0.1f, _currentSpawnDelay - SpawnDelayDecreasePerStage); 
        }
    }

    private void Spawn()
    {
        Meteor newMeteor = Instantiate(MeteorPrefab);
        float xPosition = Random.Range(-WidthSpawner, WidthSpawner);
        newMeteor.transform.position = new Vector2(xPosition, YPosition);
        newMeteor.Speed = _currentMeteorSpeed;
    }
}


