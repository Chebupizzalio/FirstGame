using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnim : StateMachineBehaviour
{
    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        animator.SetInteger("AnimID", Random.Range(0, 3));
    }
}
