using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinBehaviour : MonoBehaviour
{
    private CoinUI coinUI;
    [SerializeField] int value = 1;

    private void Start()
    {
        coinUI = GameObject.FindObjectOfType<CoinUI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        coinUI.AddCoin(value);
        Destroy(gameObject);
    }
}
