using UnityEngine;

public class Laser : MonoBehaviour
{
    public int Damage = 1;
    public float Speed = 5;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.linearVelocityY = Speed;

        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health heath))
        {
            heath.TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
}
