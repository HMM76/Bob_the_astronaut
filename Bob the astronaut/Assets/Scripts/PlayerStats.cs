using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public float maxHP;
    public float currentHP;
    public float armor;
    public int damage;
    bool isDead = false;
    bool canTakeDamage;
    public int gold;

    public Text HPTextOut;

    void Start()
    {
        currentHP = maxHP;
        HPTextOut.text = currentHP + "/" + maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(collision.gameObject.GetComponent<Enemy>().damage);
        }
        if (collision.gameObject.CompareTag("Drug"))
        {
            Heal();
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            AddGold(collision.gameObject.GetComponent<Coin>().CoinCost);
        }
        /*if (collision.gameObject.CompareTag("EnemyHead"))
        {
            GameObject head = collision.gameObject;
            GameObject enemy = head.transform.parent.gameObject;
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            enemyScript.TakeDamage();
        }*/
    }

    void AddGold(int CoinCost)
    {
        gold += CoinCost;
        Debug.Log(gold);
    }
    void Heal()
    {
        currentHP += 20;
        if(currentHP > maxHP)
        {
            currentHP = maxHP;
        }
        HPTextOut.text = currentHP + "/" + maxHP;
    }
    void TakeDamage(int inputDamage)
    {
        currentHP -= inputDamage;
        if(currentHP <= 0)
        {
            isDead = true;
            GameOver();
        }
        HPTextOut.text = currentHP + "/" + maxHP;
    }
    void GameOver()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
