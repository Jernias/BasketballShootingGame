using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip swishSound;
    static AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        swishSound = Resources.Load<AudioClip>("swishSound");

        source = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "swishSound":
                source.PlayOneShot(swishSound);
                break;
            case "intro":
                break;
        }
    }
}
