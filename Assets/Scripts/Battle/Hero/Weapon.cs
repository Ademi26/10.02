using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameManager GameManager;
    public SaveHero SaveHero;
    public StatHero StatHero;

    public GameObject Bullet;

    public GameObject AudioHero;
    private bool AudioHeroOn;

    private void Start()
    {
        GameManager = FindObjectOfType<GameManager>();
        SaveHero = FindObjectOfType<SaveHero>();
        StatHero = FindObjectOfType<StatHero>();

        gameObject.GetComponent<SpriteRenderer>().sprite = StatHero.SpriteWeaponHero[SaveHero.WeaponHero]; 

        AudioHeroOn = GameManager.GetComponent<MusicGame>().MusicOn[1];
    }

    void Update()
    {
        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; 

        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg; 
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);

        if(Input.GetMouseButtonDown(0))
        {
            if(StatHero.UseWeapon != 1 && StatHero.NumberRound > 0) 
            {
                Instantiate(Bullet, transform.position, Quaternion.identity);
                StatHero.NumberRound -= 1;

                if (AudioHeroOn == true)
                {
                    AudioHero.GetComponent<AudioSource>().Play();
                }
            }
            else if(StatHero.UseWeapon == 1) 
            {
                Instantiate(Bullet, transform.position, Quaternion.identity);

                if (AudioHeroOn == true)
                {
                    AudioHero.GetComponent<AudioSource>().Play();
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Q))  
        {
            if (StatHero.UseWeapon != 1) 
            {
                StatHero.UseWeapon = 1;
                gameObject.GetComponent<SpriteRenderer>().sprite = StatHero.SpriteWeaponHero[1];

                StatHero.SpeadWeaponHero = 8;
                StatHero.DamageWeapon = 1;
                StatHero.FlightErrorBullet = 0.6f;
            }
            else if (StatHero.UseWeapon == 1)
            {
                StatHero.UseWeapon = SaveHero.WeaponHero; 
                gameObject.GetComponent<SpriteRenderer>().sprite = StatHero.SpriteWeaponHero[SaveHero.WeaponHero];

                switch (SaveHero.WeaponHero) 
                {
                    case 2:
                        StatHero.SpeadWeaponHero = 10;
                        StatHero.DamageWeapon = 1;
                        StatHero.FlightErrorBullet = 0.6f;
                        break;
                    case 3:
                        StatHero.SpeadWeaponHero = 15;
                        StatHero.DamageWeapon = 2;
                        StatHero.FlightErrorBullet = 0.5f;
                        break;
                    case 4:
                        StatHero.SpeadWeaponHero = 18;
                        StatHero.DamageWeapon = 4;
                        StatHero.FlightErrorBullet = 0.2f;
                        break;
                }
            }
        }
    }
}
