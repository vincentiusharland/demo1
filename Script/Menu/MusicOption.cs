using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicOption : MonoBehaviour
{
    //reference to Audio Source component
    private AudioSource audioSrc;

    //music volume variable that will be modified
    //by dragging slider knob
    private float musicVolume = 1f;
    // Start is called before the first frame update
    void Start()
    {
        //assign Audio Source component control to it
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //setting volume option of audio source to be equal to musicVolume
        audioSrc.volume = musicVolume;
    }
    //method that is called by slider game object
    //this method take vol value passed by slider
    //and sets it as musicValue
    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
