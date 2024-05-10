using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameManager GameManager;
    public SaveHero SaveHero;

    private string OptionWeaponBay; 
    private int OptionWeapon = 1; 
    public Sprite[] WeaponSprite;
    public GameObject WeaponIcon; 
    public Text WeaponText; 
    public Text BayWeaponText;

    public int OptionSkin = 1;
    public Sprite[] SkinSprite;
    public GameObject HeroSkin;

    public Text MoneyText;

    void Start()
    {
        GameManager = FindObjectOfType<GameManager>();
        SaveHero = FindObjectOfType<SaveHero>();
    }

    void Update()
    {
        MoneyText.text = "Money = "+SaveHero.Coin;

        switch(OptionWeapon)
        {
            case 1:
                if(SaveHero.BayWeaponHero[1] == 1) 
                {
                    if(SaveHero.WeaponHero == 1)
                    {
                        OptionWeaponBay = "Used";                    
                    }
                    else
                    {
                        OptionWeaponBay = "Use";
                    }
                }
                else
                {
                    OptionWeaponBay = "Bay";
                }

                BayWeaponText.text = "" + OptionWeaponBay;
                WeaponText.text = "Revolver \nDamage = 1 \nSpeed = 8 \nScatter = 6 \nBullet = No limit";
                break;
            case 2:
                if (SaveHero.BayWeaponHero[2] == 1)
                {
                    if (SaveHero.WeaponHero == 2)
                    {
                        OptionWeaponBay = "Used";
                    }
                    else
                    {
                        OptionWeaponBay = "Use";
                    }

                    BayWeaponText.text = "" + OptionWeaponBay;
                }
                else
                {
                    OptionWeaponBay = "Bay"; 
                    BayWeaponText.text = "400"; 
                }

                WeaponText.text = "Rifle \nDamage = 1 \nSpeed = 10 \nScatter = 8 \nBullet = 50";
                break;
            case 3:
                if (SaveHero.BayWeaponHero[3] == 1)
                {
                    if (SaveHero.WeaponHero == 3)
                    {
                        OptionWeaponBay = "Used";
                    }
                    else
                    {
                        OptionWeaponBay = "Use";
                    }
                    BayWeaponText.text = "" + OptionWeaponBay;
                }
                else
                {
                    OptionWeaponBay = "Bay";
                    BayWeaponText.text = "800";
                }

                WeaponText.text = "Chopper \nDamage = 2 \nSpeed = 15 \nScatter = 5 \nBullet = 60";
                break;
            case 4:
                if (SaveHero.BayWeaponHero[4] == 1)
                {
                    if (SaveHero.WeaponHero == 4)
                    {
                        OptionWeaponBay = "Used";
                    }
                    else
                    {
                        OptionWeaponBay = "Use";
                    }
                    BayWeaponText.text = "" + OptionWeaponBay;
                }
                else
                {
                    OptionWeaponBay = "Bay";
                    BayWeaponText.text = "1200";
                }

                WeaponText.text = "M Chopeer \nDamage = 4 \nSpeed = 18 \nScatter = 2 \nBullet = 70";
                break;
        }
    }

    public void ScrollingWeaponsRight() 
    {
        if(OptionWeapon >= 1 && OptionWeapon < 4)
        {
            OptionWeapon ++; 
            WeaponIcon.GetComponent<Image>().sprite = WeaponSprite[OptionWeapon];
        }
    }
    public void ScrollingWeaponsLeft()
    {
        if(OptionWeapon > 1 && OptionWeapon <= 4)
        {
            OptionWeapon --;
            WeaponIcon.GetComponent<Image>().sprite = WeaponSprite[OptionWeapon];
        }
    }

    public void ScrollingSkinsRight()
    {
        if(OptionSkin >= 1 && OptionSkin < 3)
        {
            OptionSkin ++;
            HeroSkin.GetComponent<Image>().sprite = SkinSprite[OptionSkin];
        }
    }
    public void ScrollingSkrinsLeft()
    {
        if (OptionSkin > 1 && OptionSkin <= 3)
        {
            OptionSkin--;
            HeroSkin.GetComponent<Image>().sprite = SkinSprite[OptionSkin];
        }
    }

    public void BayUseWeapon() 
    {
        switch(OptionWeaponBay)
        {
            case "Bay":
                switch(OptionWeapon)
                {
                    case 2:
                        if (SaveHero.Coin >= 400)
                        {
                            SaveHero.Coin -= 400; 
                            SaveHero.BayWeaponHero[2] = 1;
                            SaveHero.WeaponHero = 2;
                        }
                        break;
                    case 3:
                        if (SaveHero.Coin >= 800)
                        {
                            SaveHero.Coin -= 800;
                            SaveHero.BayWeaponHero[3] = 1;
                            SaveHero.WeaponHero = 3;
                        }
                        break;
                    case 4:
                        if (SaveHero.Coin >= 1200)
                        {
                            SaveHero.Coin -= 1200;
                            SaveHero.BayWeaponHero[4] = 1;
                            SaveHero.WeaponHero = 4;
                        }
                        break;
                }
                break;
            case "Use": 
                SaveHero.WeaponHero = OptionWeapon;
                break;
        }
    }
    public void UseSkin() 
    {
        SaveHero.SkinHero = OptionSkin;
    }
}
