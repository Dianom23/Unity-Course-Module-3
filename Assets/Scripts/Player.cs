using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float Speed = 5; // Скорость движения
    public Vector2 MaxDistance; // Координаты максимальной дистанции полёта от центра
    private Rigidbody2D _rb; // Компонент физики
    private Vector2 _moveDirection; // Направление движения

    public Laser LaserPrefab; // Заготовка лазера
    public Transform ShootPoint; // Точка выстрела
    public float ShootDelay = 0.1f; // Задержка между выстрелами

    private bool _isShooting; // Стреляем ли мы сейчас
    private float _shootTimer; // Таймер для стрельбы.

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        Vector2 newPosition = _rb.position + _moveDirection * Speed * Time.fixedDeltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, -MaxDistance.x, MaxDistance.x);
        newPosition.y = Mathf.Clamp(newPosition.y, -MaxDistance.y, MaxDistance.y);

        _rb.MovePosition(newPosition);
    }

    void Update()
    {
        if (_isShooting == true)
        {
            _shootTimer += Time.deltaTime;

            if (_shootTimer >= ShootDelay)
            {
                _shootTimer = 0;
                Shoot();
            }
        }
    }

    public void OnMove(InputValue value)
    {
        _moveDirection = value.Get<Vector2>();
    }

    public void OnAttack(InputValue value)
    {
        if (value.Get<float>() == 1)
        {
            _isShooting = true;
        }
        else
        {
            _isShooting = false;
        }
    }

    private void Shoot()
    {
        Instantiate(LaserPrefab, ShootPoint.position, Quaternion.identity);
    }
}
