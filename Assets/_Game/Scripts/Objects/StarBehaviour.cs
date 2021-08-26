using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBehaviour : MonoBehaviour
{
    [Range(0, 2)]
    [SerializeField] int value;
    private StarUI starUI;

    private void Start()
    {
        starUI = GameObject.FindObjectOfType<StarUI>();
    }
    private void OnTriggerEnter(Collider other)
    {
        starUI.CollectStar(value);
        Destroy(gameObject);
    }
}
