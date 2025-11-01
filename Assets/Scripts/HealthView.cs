using System;
using TMPro;
using UnityEngine;

public class HealthView : MonoBehaviour
{
    public Health PlayerHealth;
    private TMP_Text _healthText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerHealth.OnTakenDamage.AddListener(UpdateText);
        _healthText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateText()
    {
        int hp = Mathf.Max(0, PlayerHealth.Hp);
        _healthText.text = hp.ToString();
    }
}
