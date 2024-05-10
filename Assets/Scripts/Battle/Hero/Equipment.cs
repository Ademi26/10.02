using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public GameObject Hero;

    public int OptionEquipment; 
    private float TimeDestroy = 7f;

    void Start()
    {
        Hero = GameObject.Find("Hero");
    }

    void Update()
    {
        TimeDestroy -= 1 * Time.deltaTime; 

        if(TimeDestroy <= 0) 
        {
            DestroyEquipment();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Hero")
        {
            DestroyEquipment();
        }
    }

    public void DestroyEquipment() 
    {
        Destroy(gameObject);
    }
}
