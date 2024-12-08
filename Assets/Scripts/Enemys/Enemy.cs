using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int MaxHealth;
    int currentHealth;

    private void Start()
    {
        currentHealth = MaxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0 )
        {
            Debug.Log("DIIIIIE");
            Destroy(gameObject);

        }
    }






}
