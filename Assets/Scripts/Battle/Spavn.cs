using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spavn : MonoBehaviour
{
    public GameObject[] PrefEnemy = new GameObject[4];
    public GameObject[] SpavnEnemy = new GameObject[4];

    public GameObject Hp;
    public GameObject Round;

    private int OptionEnemy;
    private int OptionSpavn;

    private float RandomPosotionX;
    private float RandomPosotionY;
    private int RandomEquipment;
    private float TimeSpavnEquipment = 15;

    public float TimeSpavnEnemy = 0.8f;

    void Update()
    {
        TimeSpavnEnemy -= 1 * Time.deltaTime;
        TimeSpavnEquipment -= 1 * Time.deltaTime;

        if(TimeSpavnEnemy <= 0)
        {
            OptionSpavn = Random.Range(0, 4); 
            OptionEnemy = Random.Range(0, 4);

            Instantiate(PrefEnemy[OptionEnemy], SpavnEnemy[OptionSpavn].transform.position, Quaternion.identity);
            TimeSpavnEnemy = 0.8f;
        }

        if(TimeSpavnEquipment <= 0)
        {
            RandomPosotionX = Random.Range(-7f, 7f); 
            RandomPosotionY = Random.Range(-5f, 5f); 
            RandomEquipment = Random.Range(1, 3); 

            if(RandomEquipment == 1)
            {
                Instantiate(Round, new Vector3(RandomPosotionX, RandomPosotionY, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(Hp, new Vector3(RandomPosotionX, RandomPosotionY, 0), Quaternion.identity);
            }

            TimeSpavnEquipment = 15f; 
        }
    }
}
