using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesUI : MonoBehaviour
{
    TextMeshProUGUI myText;
    int lives = 3;

    private void Awake()
    {
        myText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        myText.text = lives.ToString();
    }

    public void AddLives()
    {
        lives++;
    }
}
