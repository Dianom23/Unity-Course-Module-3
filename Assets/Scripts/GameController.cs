using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int DestroyedEnemiesCounter;
    public TMP_Text MeteorCounter;

    public GameObject LosePanel;
    public TMP_Text Record;
    public Button RestartButton;
    public Health PlayerHealth;
    public TMP_Text HealthCounter;

    void Start()
    {
        RestartButton.onClick.AddListener(RestartGame);
        PlayerHealth.OnDie.AddListener(OnLose);
        PlayerHealth.OnTakenDamage.AddListener(UpdateHealthText);

        UpdateHealthText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddDestroyedEnemy()
    {
        DestroyedEnemiesCounter++;
        MeteorCounter.text = "Уничтожено " + DestroyedEnemiesCounter;
    }

    public void OnLose()
    {
        int lastRecord = PlayerPrefs.GetInt("Record");

        if (DestroyedEnemiesCounter > lastRecord)
        {
            PlayerPrefs.SetInt("Record", DestroyedEnemiesCounter);
            PlayerPrefs.Save();

            Record.text = "Рекорд " + DestroyedEnemiesCounter;
        }
        else
        {
            Record.text = "Рекорд " + lastRecord;
        }

        LosePanel.SetActive(true);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    private void UpdateHealthText()
    {
        // Если хп будут меньше 0, то хп станут 0, иначе PlayerHealth.Hp
        int hp = Mathf.Max(0, PlayerHealth.Hp);
        // Присваиваем тексту на экране надпись
        HealthCounter.text = "Жизни " + hp;
    }
}

