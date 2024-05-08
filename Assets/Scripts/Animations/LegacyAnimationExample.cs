using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * For exercise purposes
 */
public class LegacyAnimationExample : MonoBehaviour
{    
    public AnimationClip clipIdle;
    public AnimationClip clipRun;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) {
            PlayAnimation(clipIdle);

        } else if (Input.GetKeyDown(KeyCode.R))
        {
            PlayAnimation(clipRun);

        }
    }

    private void PlayAnimation(AnimationClip clip)
    {
        var anim = GetComponent<Animation>();
        if (anim != null)
        {
            anim.CrossFade(clip.name);
        }
    }
}
