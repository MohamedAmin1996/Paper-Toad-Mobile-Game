using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionPanel : MonoBehaviour
{
    Animator transitionAnim;
    [SerializeField] string outEffect;
    [SerializeField] string inEffect;

    private void Awake()
    {
        transitionAnim = GetComponent<Animator>();
        transitionAnim.Play(outEffect);
    }
    private void Update()
    {
        if (transitionAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            gameObject.SetActive(false);
        }
    }

    public void InEffectTransition()
    {
        gameObject.SetActive(true);
        transitionAnim.Play(inEffect);
    }

    public void OutEffectTransition()
    {
        transitionAnim.Play(outEffect);
        gameObject.SetActive(false);
    }
}
