using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionPanel : MonoBehaviour
{
    [SerializeField] Animator transitionAnim;

    private void Awake()
    {
        transitionAnim = GetComponent<Animator>();
        transitionAnim.Play("Fade Out");
    }
    private void Update()
    {
        if (transitionAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            gameObject.SetActive(false);
        }
    }

    public void FadeInTransition()
    {
        gameObject.SetActive(true);
        transitionAnim.Play("Fade In");
    }

    public void FadeOutTransition()
    {
        transitionAnim.Play("Fade Out");
        gameObject.SetActive(false);
    }
}
