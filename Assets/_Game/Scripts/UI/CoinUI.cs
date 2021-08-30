using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    TextMeshProUGUI myText;
    int count = 0;

    LivesUI livesUI;


    private void Awake()
    {
        myText = GetComponent<TextMeshProUGUI>();
        livesUI = GameObject.FindObjectOfType<LivesUI>();
    }

    void Update()
    {
        myText.text = count.ToString();

    }


    public void AddCoin(int value) 
    {
        count += value;

        if (count == 100)
        {
            livesUI.AddLives();
            count = 0;
        }

    }
}
