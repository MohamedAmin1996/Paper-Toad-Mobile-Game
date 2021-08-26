using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarUI : MonoBehaviour
{
    [SerializeField] GameObject[] stars;
    [SerializeField] Sprite offImage;
    [SerializeField] Sprite onImage;

    private void Start()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].GetComponent<Image>().sprite = offImage;
        }
    }

    public void CollectStar(int value)
    {
        stars[value].GetComponent<Image>().sprite = onImage;
    }



}
