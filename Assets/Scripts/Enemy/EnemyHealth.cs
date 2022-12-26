using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float heightKnockPlayer;
    public int enemyHealth;
    public GameObject deathEffect;
    public int pointOnDeath;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            SoundManager.PlaySound(1);
            Instantiate(deathEffect, transform.position,transform.rotation);
            Destroy(gameObject);
            
        }


    }
    public void GiveDamage(int dameToGive)
    {
        enemyHealth -= dameToGive;

    }
}
