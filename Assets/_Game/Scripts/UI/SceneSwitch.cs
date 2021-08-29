using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    [SerializeField] TransitionPanel transitionPanel;
    bool activated = false;

    public void SwitchScene(int goToSceneIndex)
    {
        if (!activated)
        {
            StartCoroutine(LoadScene(goToSceneIndex));
            activated = true;
        }
    }

    IEnumerator LoadScene(int goToSceneIndex)
    {
        transitionPanel.FadeInTransition();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadSceneAsync(goToSceneIndex); 
    }
}
