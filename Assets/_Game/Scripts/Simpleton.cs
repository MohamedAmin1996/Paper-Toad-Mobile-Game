using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simpleton : MonoBehaviour
{
    private Simpleton Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
