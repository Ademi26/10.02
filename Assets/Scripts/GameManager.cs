using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool StartGame;
    public bool GameOn;

    public int Score;

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        if(StartGame == false)
        {
            StartGame = true;
            Lobby();
        }
    }

    public void Lobby()

        SceneManager.LoadScene("Lobby");
    }
}
