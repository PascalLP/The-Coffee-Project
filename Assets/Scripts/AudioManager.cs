using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static public AudioManager instance;

    public AudioSource fxSource;
    public AudioClip clickSound;
   
    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("Music");
        GameObject[] fxObj = GameObject.FindGameObjectsWithTag("SoundFX");
        if (musicObj.Length > 1 || fxObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayClickSound()
    {
        Debug.Log("Playing click sound");
        fxSource.PlayOneShot(clickSound);
    }
}
