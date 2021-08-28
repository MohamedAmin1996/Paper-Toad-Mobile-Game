using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    bool activated = false;
    public void SwitchScene(int goToSceneIndex)
    {
        if (!activated)
        {
            SceneManager.LoadSceneAsync(goToSceneIndex);
            activated = true;
        }
    }
}
