using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D enemyRB;
    int direction = 5;
    public int maxHP;
    int currentHP;
    public int damage;
    bool isDead;

    public GameObject[] drop;

    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        currentHP = maxHP;
    }

    void Update()
    {
        enemyRB.velocity = new Vector2(direction, enemyRB.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            direction *= -1;
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(collision.gameObject.GetComponent<Bullet>().BulletDamage);
        }
    }
    public void TakeDamage(int inputDamage)
    {
        currentHP -= inputDamage;
        if (currentHP <= 0)
        {
            isDead = true;
            Death();
        }
    }
    public void Death()
    {
        GameObject RandomDrop = drop[Random.Range(0, drop.Length)];
        Instantiate(RandomDrop, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
