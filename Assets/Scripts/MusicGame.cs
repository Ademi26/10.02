using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MusicGame : MonoBehaviour
{
    public GameObject AudioSours;
    public AudioClip[] Music;
    public bool[] MusicOn;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Start")
        {
            AudioSours.GetComponent<AudioSource>().clip = Music[0];
            AudioSours.GetComponent<AudioSource>().Play();
        }
    }
}
