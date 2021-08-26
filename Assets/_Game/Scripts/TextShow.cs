using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextShow : MonoBehaviour
{
    public PlayerController playerController;
    public TextMeshProUGUI myText;


    private void Update()
    {
        myText.text = "Current State: " + playerController.stateID;
    }
}
