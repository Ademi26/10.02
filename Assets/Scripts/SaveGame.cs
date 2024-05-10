using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    private SaveHero SaveHero;

    private void Start()
    {
        SaveHero = FindAnyObjectByType<SaveHero>();
    }

    public void Save()
    {
        PlayerPrefs.SetInt("WeaponHeroSave", SaveHero.WeaponHero);
        PlayerPrefs.SetInt("SkinHeroSave", SaveHero.SkinHero);
        PlayerPrefs.SetInt("CoinSave", SaveHero.Coin);

        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt("BayWeaponHeroSave"+i, SaveHero.BayWeaponHero[i]);
        }

        PlayerPrefs.Save();
        Debug.Log("Game data saved!");
    }
 
    public void Load()
    {
        SaveHero.WeaponHero = PlayerPrefs.GetInt("WeaponHeroSave");
        SaveHero.SkinHero = PlayerPrefs.GetInt("SkinHeroSave");
        SaveHero.Coin = PlayerPrefs.GetInt("CoinSave");

        for (int i = 0; i < 5; i++)
        {
            SaveHero.BayWeaponHero[i] = PlayerPrefs.GetInt("BayWeaponHeroSave" + i);
        }

        Debug.Log("Game data loaded!");
    }
}
