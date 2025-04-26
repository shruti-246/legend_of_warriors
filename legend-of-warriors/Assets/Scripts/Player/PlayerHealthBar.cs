using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Slider slider;

    void Start()
    {
        slider.maxValue = playerHealth.health;
    }

    void Update()
    {
        slider.value = playerHealth.health;
    }
}