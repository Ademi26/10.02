using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MowmentScene : MonoBehaviour
{
    public GameManager GameManager;

    private void Start()
    {
        GameManager = FindObjectOfType<GameManager>();
    }

    public void SceneLobby()
    {
        SceneManager.LoadScene("Lobby");

        if (SceneManager.GetActiveScene().name == "Battle")
        {
            GameManager.GetComponent<AudioSource>().clip = GameManager.GetComponent<MusicGame>().Music[0];
            GameManager.GetComponent<AudioSource>().Play();
        }
    }

    public void SceneBattle() 
    {
        SceneManager.LoadScene("Battle");

        if (SceneManager.GetActiveScene().name != "Battle")
        {
            GameManager.GetComponent<AudioSource>().clip = GameManager.GetComponent<MusicGame>().Music[1];
            GameManager.GetComponent<AudioSource>().Play();
        }
    }

    public void SceneShop() 
    {
        SceneManager.LoadScene("Shop");

        if (SceneManager.GetActiveScene().name == "Battle")
        {
            GameManager.GetComponent<AudioSource>().clip = GameManager.GetComponent<MusicGame>().Music[0];
            GameManager.GetComponent<AudioSource>().Play();
        }
    }
}
