using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float Speed = 2;
    public int Damange = 1;
    private Rigidbody2D _rb;

    private GameController _gameController;
    private Health _health;


    void Start()
    {
        //Получаем компонент жизней с метеорита
        _health = GetComponent<Health>();
        //Находим первый объект компонентом GameController на сцене
        _gameController = FindFirstObjectByType<GameController>();

        //Метод AddDestroyedEnemy у GameController подписываем на событие OnDie от Health
        _health.OnDie.AddListener(_gameController.AddDestroyedEnemy);

        _rb = GetComponent<Rigidbody2D>();
        _rb.linearVelocityY = -Speed;

        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health health))
        {
            health.TakeDamage(Damange);
            Destroy(gameObject);
        }
    }
}


