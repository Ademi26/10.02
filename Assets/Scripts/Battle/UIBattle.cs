using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBattle : MonoBehaviour
{
    public GameManager GameManager;
    public StatHero StatHero;

    public Text ScoreText; 
    public Text TextNumberRound;
    public Text TextHp;

    public Image WeaponIcon;

    public GameObject DeadWindov;

    void Start()
    {
        GameManager = FindObjectOfType<GameManager>();
        StatHero = FindObjectOfType<StatHero>();
    }

    void Update()
    {
        ScoreText.text = ""+GameManager.Score; 
        TextHp.text = "Hp " + StatHero.HpHero;

        if(StatHero.UseWeapon != 1)
        {
            WeaponIcon.GetComponent<Image>().sprite = StatHero.SpriteWeaponHero[StatHero.UseWeapon]; 
            TextNumberRound.fontSize = 120; 
            TextNumberRound.text = " "+ StatHero.NumberRound; 
        }
        else 
        {
            WeaponIcon.GetComponent<Image>().sprite = StatHero.SpriteWeaponHero[1]; 
            TextNumberRound.fontSize = 70; 
            TextNumberRound.text = "No Limit"; 
        }

        if(StatHero.HpHero <= 0) 
        {
            DeadWindov.SetActive(true);
        }
    }
}
