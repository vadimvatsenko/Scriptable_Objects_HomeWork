using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class HealthSystem : MonoBehaviour
{
    private CharacterStats _characterStats;
   
    private Image _healthCircle;
    private TextMeshProUGUI _healthText;

    private int _prevHealth;

    private void Awake()
    {
        
        _characterStats = Resources.Load<CharacterStats>("ScriptableObjects/NewCharacterStats");
    }
    private void Start()
    {       
        

        _healthCircle = this.transform.GetChild(0).GetComponent<Image>();
        _healthText = this.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        _prevHealth = _characterStats.health;

        _healthText.text = _characterStats.health.ToString();
       
        ChengeHealthBarValue(_characterStats.health);
    }


    private void ChengeHealthBarValue(int health)
    {
        StartCoroutine(SmoothChangeHelthBarValue(health));
    }

    private IEnumerator SmoothChangeHelthBarValue(int health)
    {
        float duration = 0.5f; 
        float elapsedTime = 0; 
        float startHeath = _characterStats.health; 
        // test
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime; 

            float percentageComplete = Mathf.Clamp01(elapsedTime / duration); 

            float currentHealth = Mathf.Lerp(startHeath, health, percentageComplete);

            _healthCircle.fillAmount = currentHealth / 100f;

            _healthCircle.color = Color.Lerp(Color.red, Color.green, _healthCircle.fillAmount);

            if (_healthCircle.fillAmount <= 0)
            {
                _healthText.text = "Dead";
            }
            else
            {
                _healthText.text = (Mathf.RoundToInt(_healthCircle.fillAmount * 100)).ToString() + "%";
            }

            _healthText.color = _healthCircle.color;

            yield return null;
        }
        _prevHealth = health;
    }
}

