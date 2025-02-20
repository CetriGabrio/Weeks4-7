using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 100;
    public Slider healthBar;

    void Start()
    {
        curHealth = maxHealth;
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DamagePlayer(10);
        }
    }

    public void DamagePlayer(int damage)
    {
        curHealth -= damage;
        SetHealth(curHealth);

        if (curHealth == 0)
        {
            Die();
        }
    }

    public void SetHealth(int hp)
    {
        healthBar.value = hp;
    }

    void Die()
    {
        Debug.Log("Player died!");
        Destroy(gameObject);
    }
}

