using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public StatHero StatHero;

    public float HpBullet; 
    public int FlightRandom;

    void Start()
    {
        StatHero = FindObjectOfType<StatHero>();
        FlightRandom = Random.Range(0, 2);

        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; 

        if(FlightRandom == 0)
        {
            float rotateZ = Mathf.Atan2(diference.y += StatHero.FlightErrorBullet, diference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
        }
        else
        {
            float rotateZ = Mathf.Atan2(diference.y -= StatHero.FlightErrorBullet, diference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
        }
    }

    void Update()
    {
        transform.Translate(StatHero.SpeadWeaponHero * Time.deltaTime,0,0); 

        HpBullet -= 1.5f * Time.deltaTime; 

        if(HpBullet <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
