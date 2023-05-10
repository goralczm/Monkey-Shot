using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator anim;
    private string _currState;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ChangeAnimationState(string newState)
    {
        if (newState == _currState)
            return;
        
        _currState = newState;
        anim.Play(_currState);
    }
}
