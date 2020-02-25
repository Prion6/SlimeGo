using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Fighter : MonoBehaviour
{
    public enum FightingActions
    {
        IDDLE, ATTACK, SUPERATTACK, DODGE_LEFT, DODGE_RIGHT, DAMAGED, DEAD, WIN
    }

    public Animator anim;

    public FightingActions status;

    public void Attack()
    {
        if (status == FightingActions.IDDLE)
            anim.SetTrigger("Attack");
    }

    public void SuperAttack()
    {
        if (status == FightingActions.IDDLE)
            anim.SetTrigger("SuperAttack");
    }

    public void DodgeLeft()
    {
        if (status == FightingActions.IDDLE)
            anim.SetTrigger("DodgeLeft");
    }

    public void DodgeRight()
    {
        if (status == FightingActions.IDDLE)
            anim.SetTrigger("DodgeRight");
    }

    protected virtual void CastAttack()
    {

    }

    protected virtual void CastSuperAttack()
    {

    }

    protected virtual void RecieveDamage()
    {

    }

    protected virtual void MoveLeft()
    {

    }

    protected virtual void MoveRight()
    {

    }

    public virtual void StartingAction(FightingActions startingAction)
    {
        switch (startingAction)
        {
            case FightingActions.IDDLE:
                break;
            case FightingActions.ATTACK:
                CastAttack();
                break;
            case FightingActions.SUPERATTACK:
                CastSuperAttack();
                break;
            case FightingActions.DODGE_LEFT:
                MoveLeft();
                break;
            case FightingActions.DODGE_RIGHT:
                MoveRight();
                break;
            case FightingActions.DAMAGED:
                RecieveDamage();
                break;
            case FightingActions.DEAD:
                break;
            case FightingActions.WIN:
                break;
        }
    }

    public virtual void EndingAction(FightingActions endingAction)
    {

    }

    public virtual void PerformingAction(FightingActions currentAction)
    {

    }
}
