using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    TextMeshProUGUI myText;
    int count = 0;

    private void Awake()
    {
        myText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        myText.text = count.ToString();
    }


    public void AddCoin(int value) 
    {
        count += value;
    }
}
