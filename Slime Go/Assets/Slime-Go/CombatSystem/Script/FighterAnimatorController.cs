using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterAnimatorController : StateMachineBehaviour
{
    public Fighter.FightingActions action;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var fighter = animator.GetComponent<Fighter>();
        fighter.status = action;

        fighter.StartingAction(action);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var fighter = animator.GetComponent<Fighter>();
        fighter.PerformingAction(action);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var fighter = animator.GetComponent<Fighter>();
        fighter.EndingAction(action);
    }
}
