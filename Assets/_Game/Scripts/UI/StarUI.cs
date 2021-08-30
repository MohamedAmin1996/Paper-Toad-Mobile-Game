using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarUI : MonoBehaviour
{
    [SerializeField] GameObject[] stars;
    [SerializeField] Sprite offImage;
    [SerializeField] Sprite onImage;

    [SerializeField] GameObject mainButton;

    private void Start()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].GetComponent<Image>().sprite = offImage;
        }

        mainButton.SetActive(false);
    }

    private void Update()
    {
        if (stars[0].GetComponent<Image>().sprite == onImage && stars[1].GetComponent<Image>().sprite == onImage && stars[2].GetComponent<Image>().sprite == onImage)
        {
            mainButton.SetActive(true);
        }
    }

    public void CollectStar(int value)
    {
        stars[value].GetComponent<Image>().sprite = onImage;
    }



}
