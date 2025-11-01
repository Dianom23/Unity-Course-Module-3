using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int Hp = 1;
    public UnityEvent OnDie;
    public UnityEvent OnTakenDamage;
    public AudioClip ExplosionSound;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
     
    public void TakeDamage(int damage)
    {
        Hp -= damage;

        OnTakenDamage.Invoke();

        if (Hp <= 0)
        {
            PlayExplosionSound();
            OnDie.Invoke();
            Destroy(gameObject);
        }
    }

    private void PlayExplosionSound()
    {
        // Создаём  временный (temp) объект (пустышку), 
        // который будет использоваться только для проигрывания звука
        // new GameObject() создаёт пустышку на сцене
        GameObject temp = new GameObject();
        // Добавляем на этот объект компонент AudioSource
        // AddComponent<AudioSource>() создаёт компонент и возвращает ссылку на него
        AudioSource audioSource = temp.AddComponent<AudioSource>();
        // Указываем звуковой клип, который нужно проиграть
        audioSource.clip = ExplosionSound;
        // Запускаем воспроизведение звука
        audioSource.Play();
        // Удаляем временный объект после того, как звук полностью завершится
        // ExplosionSound.length - длительность звука в секундах
        Destroy(temp, ExplosionSound.length);
    }

}
