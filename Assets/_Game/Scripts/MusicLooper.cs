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

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = mySongInfo.myClip;
        startLoop = mySongInfo.startLoop;
        endLoop = mySongInfo.endLoop;
        audioSource.Play();
    }

    void Update()
    {
        currentPos = (float)audioSource.timeSamples;
        Debug.Log(currentPos);

        if (currentPos >= endLoop)
        {
            audioSource.timeSamples = (int)startLoop;
            audioSource.Play();
        }
    }
}
