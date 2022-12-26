using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static float healthTotal;
    public static float healthCurrent;
    [SerializeField] private Image _healthBarTotal;
    [SerializeField] private Image _healthBarCurrent;    
    // Start is called before the first frame update
    void Awake()
    {
        _healthBarCurrent.fillAmount = 0.3f;
        _healthBarTotal.fillAmount = 0.5f;
        healthCurrent = 0.3f;
        healthTotal = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthCurrent <= 0)
        {
        }
        else if (healthCurrent > healthTotal)
        {
            healthCurrent = healthTotal;
            _healthBarCurrent.fillAmount = healthCurrent;
        }
        else
            _healthBarCurrent.fillAmount = healthCurrent;
    } 
    public static void IncreaseHealth()
    {
        healthCurrent += 0.1f;
    }
    public static void DecreaseHealth()
    {
        //if (healthCurrent == 0.1f)
        //    healthCurrent = 0f;
        //else
            healthCurrent -= 0.1f;
    }
}
