using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manager : MonoBehaviour
{
    public List<AudioClip> Clips;
    public List<string> ClipNames;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent <AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startMusic(string Name)
    {
        int lIndex = ClipNames.FindIndex(clipname => clipname == Name );
        if (lIndex != -1 && lIndex < Clips.Count && audioSource.clip != Clips[lIndex])
        {
            audioSource.Stop();
            audioSource.clip = Clips[lIndex]; 
            audioSource.Play();
        }
    }
}
