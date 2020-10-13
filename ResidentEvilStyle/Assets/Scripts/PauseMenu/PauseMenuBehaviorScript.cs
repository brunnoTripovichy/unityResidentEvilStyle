using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuBehaviorScript : MonoBehaviour
{

    public void SetPauseMenuState(bool value)
    {
        gameObject.SetActive(value);
    }

    public void FadeOut()
    {
        Animator animator = gameObject.GetComponent<Animator>();
        animator.SetTrigger("FadeOut");
    }
}
