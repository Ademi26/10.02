using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatHero : MonoBehaviour
{
    public SaveHero SaveHero;
    public GameManager GameManager;

    public GameObject Hero;

    public int HpHero = 3; 
    public float SpeadHero;

    public int UseWeapon; 
    public int SpeadWeaponHero; 
    public int DamageWeapon; 
    public float FlightErrorBullet; 
    public int NumberRound;
    private int MaxNumberRound; 

    public Sprite[] SpriteWeaponHero = new Sprite[5]; 
    public Sprite[] SpriteHero = new Sprite[3]; 

    void Start()
    {
        SaveHero = FindObjectOfType<SaveHero>();
        GameManager = FindObjectOfType<GameManager>();

        GameManager.GameOn = true;
        UseWeapon = SaveHero.WeaponHero; 

        switch (SaveHero.WeaponHero) 
        {
            case 1:
                SpeadWeaponHero = 8;
                DamageWeapon = 1;
                FlightErrorBullet = 0.6f;
                break;
            case 2:
                SpeadWeaponHero = 10;
                DamageWeapon = 1;
                FlightErrorBullet = 0.6f;

                MaxNumberRound = 50;
                NumberRound = MaxNumberRound;
                break;
            case 3:
                SpeadWeaponHero = 15;
                DamageWeapon = 2;
                FlightErrorBullet = 0.5f;

                MaxNumberRound = 60;
                NumberRound = MaxNumberRound;
                break;
            case 4:
                SpeadWeaponHero = 18;
                DamageWeapon = 4;
                FlightErrorBullet = 0.2f;

                MaxNumberRound = 70;
                NumberRound = MaxNumberRound;
                break;
        }
    }

    private void Update()
    {
        if(HpHero <= 0)
        {
            GameManager.GameOn = false; 
            GameManager.Score = 0;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag == "Round") 
        {
            if(NumberRound < MaxNumberRound)
            {
                NumberRound += 35;

                if(NumberRound > MaxNumberRound)
                {
                    NumberRound = MaxNumberRound;
                }
            }
        }

        if(collision.tag == "Hp")
        {
            if(HpHero < 3)
            {
                HpHero += 1;
            }
        }
    }
}
