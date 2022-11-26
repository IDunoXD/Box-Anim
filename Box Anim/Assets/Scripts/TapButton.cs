using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapButton : MonoBehaviour
{
    [SerializeField]
    Animator BoxAnimator;
    bool AnimationStarted = false, hover = false, OneTimeTrigger = false, Stop = true;
    float BeginTime;
    void Update()
    {
        if(!AnimationStarted && BoxAnimator.GetCurrentAnimatorStateInfo(0).IsName("Tap")){ //check if tap object animation begun
            BeginTime = Time.time;
            AnimationStarted = true;
        }
        if(AnimationStarted && Time.time-BeginTime>1.5f && Stop){ //pause tap animation
            Stop = false;
            OneTimeTrigger = true;
            BoxAnimator.speed=0;
        }
        if(AnimationStarted && hover && Input.GetKeyDown(KeyCode.Mouse0) && OneTimeTrigger){ //after mouse input continue animation
            OneTimeTrigger = false;
            BoxAnimator.speed=1;
        }
    }    
    private void OnMouseEnter(){hover=true;}
    private void OnMouseExit(){hover=false;}
}
