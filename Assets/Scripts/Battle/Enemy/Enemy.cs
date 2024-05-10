using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameManager GameManager;
    public StatHero StatHero;
    public SaveHero SaveHero;
    public GameObject Hero;

    public int OptionEnemy;

    public int HpEnemy;
    public float SpeedEnemy;
    public int StrengthEnemy;

    public Animator AnimEnemy;

    void Start()
    {
        StatHero = FindObjectOfType<StatHero>();
        SaveHero = FindObjectOfType<SaveHero>();
        GameManager = FindObjectOfType<GameManager>();

        Hero = GameObject.Find("Hero");

        AnimEnemy.SetBool("RunEnemy", true);
    }

    void Update()
    {
        if(HpEnemy > 0)
        {
            if(GameManager.GameOn == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, Hero.GetComponent<Transform>().position, SpeedEnemy * Time.deltaTime); 

                if (gameObject.transform.position.x > Hero.transform.position.x)
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                }
                else 
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }
            }
        }
        else if (HpEnemy <= 0)
        {
            AnimEnemy.SetBool("DeadEnemy", true); 
            gameObject.tag = "Untagged"; 
            EnemyDestroy();
        }
    }

    public void EnemyDestroy()
    {
        GameManager.Score += 1;

        switch (OptionEnemy)
        {
            case 1:
                SaveHero.Coin += 1;
                break;
            case 2:
                SaveHero.Coin += 3;
                break;
            case 3:
                SaveHero.Coin += 5;
                break;
            case 4:
                SaveHero.Coin += 8;
                break;
        } 
        Destroy(gameObject); 
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            HpEnemy -= StatHero.DamageWeapon;
        }

        if(collision.tag == "Hero")
        {
            Hero.GetComponent<StatHero>().HpHero -= StrengthEnemy;
        }
    }
}
