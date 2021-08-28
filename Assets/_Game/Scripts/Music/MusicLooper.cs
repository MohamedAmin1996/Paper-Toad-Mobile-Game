using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLooper : MonoBehaviour
{
    [SerializeField] MusicInfo mySongInfo;
    [SerializeField] float startLoop;
    [SerializeField] float endLoop;
    AudioSource audioSource;
    float currentPos;

    [SerializeField] float hZ;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = mySongInfo.myClip;
        startLoop = mySongInfo.startLoop;
        endLoop = mySongInfo.endLoop;
        audioSource.Play();

        hZ = audioSource.clip.samples;
    }

    void Update()
    {
        currentPos = (float)audioSource.timeSamples;
       // Debug.Log(currentPos);

        if (currentPos >= endLoop)
        {
            //Debug.Log("Repeat");
            audioSource.timeSamples = (int)startLoop;
            audioSource.Play();
        }


    }
}
