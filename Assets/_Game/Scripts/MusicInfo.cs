using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MusicData", menuName = "ScriptableObjects/Music Data Collection", order = 100)]
public class MusicInfo : ScriptableObject
{
   public AudioClip myClip;
   public float startLoop;
   public float endLoop;
   public float samplingRate;
}
