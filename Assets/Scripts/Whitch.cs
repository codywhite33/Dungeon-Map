using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Whitch : MonoBehaviour
{

    public float damage;
    public float startHealth = 100;

    [HideInInspector]

    private float health;

    public GameObject deathEffect;

    [Header("Unity Stuff")]

    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
    }

    public void TakeDamage (int damage)
    {
        health -= damage;

        healthBar.fillAmount = health / startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
