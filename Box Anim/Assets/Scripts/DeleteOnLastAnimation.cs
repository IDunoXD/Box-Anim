using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnLastAnimation : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    public string LastAnimationName;
    AnimatorStateInfo state;
    void Update()
    {
        state = animator.GetCurrentAnimatorStateInfo(0);
        if(state.IsName(LastAnimationName) && state.normalizedTime >= 1)
            Destroy(transform.gameObject);
    }
}
