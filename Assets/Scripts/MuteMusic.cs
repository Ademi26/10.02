using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MuteMusic : MonoBehaviour
{
    public GameManager GameManager;
    public GameObject[] ButtonMusic;

    void Start()
    {
        GameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (GameManager.GetComponent<MusicGame>().MusicOn[0] == true)
        {
            ButtonMusic[0].GetComponent<Image>().color = new Color(80, 80, 80);
        }
        else
        {
            ButtonMusic[0].GetComponent<Image>().color = new Color(0, 0, 0);
        }

        if (GameManager.GetComponent<MusicGame>().MusicOn[1] == true)
        {
            ButtonMusic[1].GetComponent<Image>().color = new Color(80, 80, 80);
        }
        else
        {
            ButtonMusic[1].GetComponent<Image>().color = new Color(0, 0, 0);
        }
    }

    public void MusicMute()
    {
        if (GameManager.GetComponent<MusicGame>().MusicOn[0] == true)
        {
            GameManager.GetComponent<MusicGame>().MusicOn[0] = false;
            GameManager.GetComponent<MusicGame>().AudioSours.GetComponent<AudioSource>().mute = true;
            ButtonMusic[0].GetComponent<Image>().color = new Color(80,80,80);
        }
        else
        {
            GameManager.GetComponent<MusicGame>().MusicOn[0] = true;
            GameManager.GetComponent<MusicGame>().AudioSours.GetComponent<AudioSource>().mute = false;
            GameManager.GetComponent<MusicGame>().AudioSours.GetComponent<AudioSource>().Play();
            ButtonMusic[0].GetComponent<Image>().color = new Color(0, 0, 0);
        }
    }
    public void AudioMute()
    {
        if (GameManager.GetComponent<MusicGame>().MusicOn[1] == true)
        {
            GameManager.GetComponent<MusicGame>().MusicOn[1] = false;
            ButtonMusic[1].GetComponent<Image>().color = new Color(80, 80, 80);
        }
        else
        {
            GameManager.GetComponent<MusicGame>().MusicOn[1] = true;
            ButtonMusic[1].GetComponent<Image>().color = new Color(0, 0, 0);
        }
    }
}
