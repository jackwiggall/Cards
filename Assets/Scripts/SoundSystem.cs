using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    public AudioSource aud;
    public static string play; //current sound to play else null

    //Using a list so only audio in scene needs loaded
    public List<AudioClip> clips;

    void Awake() {
        aud = GetComponent<AudioSource>();
        play = "null";
    }

    void Update() {
        if (play!="null") {
            PlayAudioClip(play);
            play = "null";
        }
    }

    //https://answers.unity.com/questions/847103/find-an-audioclip-by-its-variable-name-and-play-it.html
    //play sound effect wanted
    void PlayAudioClip(string clipToPlay)
    {
        foreach (AudioClip clip in clips)
        {
            if (clip.name == clipToPlay)
            {
                aud.PlayOneShot(clip);
                //Debug.Log("Sound played");
            }
        }
    }

}
