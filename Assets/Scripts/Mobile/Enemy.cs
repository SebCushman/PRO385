using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 10;
    public int health;
    public float speed = 5f;

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            TakeDamage(2);
        }
    }

    void TakeDamage(int damage)
    {
        FindObjectOfType<AudioManager>().Play("Hit");
        health -= damage;
        //Hurt Animation

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        FindObjectOfType<Game>().score++;
        if (FindObjectOfType<Game>().score >= FindObjectOfType<Game>().total)
        {
            FindObjectOfType<Game>().GameWin();
        }
    }
}
