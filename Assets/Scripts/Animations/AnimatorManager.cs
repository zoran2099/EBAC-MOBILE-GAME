using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public enum AnimationType
    {
        IDLE, RUN, DEAD
    }

    public Animator animator;
    public List<AnimatorSetup> animatorSetup;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayAnimation(AnimationType.IDLE);

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayAnimation(AnimationType.RUN);

        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlayAnimation(AnimationType.DEAD);

        }
    }

    public void PlayAnimation(AnimationType type, float currentSpeedFactor = 1f)
    {
        Debug.Log("_current speed Factor " + currentSpeedFactor);

        animatorSetup.ForEach(setup => { if (setup.type == type) 
            { 
                animator.SetTrigger(setup.trigger); 
                animator.speed = setup.speedAnimation * currentSpeedFactor;
            } });
    }
}
[System.Serializable]
public class AnimatorSetup
{
    public AnimatorManager.AnimationType type;
    public string trigger;
    public float speedAnimation = 1f;

}