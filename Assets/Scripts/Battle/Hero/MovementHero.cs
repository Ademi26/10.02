using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHero : MonoBehaviour
{
    public SaveHero SaveHero;
    public StatHero StatHero;

    public GameObject Hero; 
    public Animator AnimHero; 

    public bool Running; 

    void Start()
    {
        SaveHero = FindObjectOfType<SaveHero>(); 
        StatHero = FindObjectOfType<StatHero>();

        switch(SaveHero.SkinHero)
        {
            case 1:
                AnimHero.SetInteger("Stand", 1);
                break;
            case 2:
                AnimHero.SetInteger("Stand", 2);
                break;
            case 3:
                AnimHero.SetInteger("Stand", 3);
                break;
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Hero.transform.Translate(0, StatHero.SpeadHero * Time.deltaTime, 0); 
            Running = true; 
        } 
        if (Input.GetKeyUp(KeyCode.W))
        {
            Running = false;
        } 

        if (Input.GetKey(KeyCode.S))
        {
            Hero.transform.Translate(0, -StatHero.SpeadHero * Time.deltaTime, 0);
            Running = true;
        } 
        if (Input.GetKeyUp(KeyCode.S))
        {
            Running = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            Hero.transform.Translate(StatHero.SpeadHero * Time.deltaTime, 0, 0);
            Hero.GetComponent<SpriteRenderer>().flipX = false;

            Running = true;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            Running = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            Hero.transform.Translate(-StatHero.SpeadHero * Time.deltaTime, 0, 0);
            Hero.GetComponent<SpriteRenderer>().flipX = true;

            Running = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            Running = false;
        }

        if(Running == true)
        {
            AnimHero.SetInteger("Running", SaveHero.SkinHero); 
        } 
        else
        {
            AnimHero.SetInteger("Running", 0); 
        }
    }
}
