using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Fighter : MonoBehaviour
{
    public enum FightingActions
    {
        IDDLE, ATTACK, SUPERATTACK, DODGE_LEFT, DODGE_RIGHT, DAMAGED, DEAD, WIN
    }

    public Animator anim;
    public Proyectile proyectile;
    public Image healthBar;

    public float maxLife = 100;
    private float currentLife = 100;

    public Transform model;
    public FightingActions status;

    public UnityEngine.Events.UnityEvent onDead;

    public void Init(Proyectile proyectile, GameObject model)
    {
        this.proyectile = proyectile;
        var m = Instantiate(model, this.model);
    }

    public void Attack()
    {
        if (status == FightingActions.IDDLE)
        {
            proyectile.Shoot(transform.position + transform.forward, transform.rotation);
            anim.SetTrigger("Attack");
        }
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
        currentLife -= 10;

        currentLife = Mathf.Clamp(currentLife, 0, maxLife);

        if (currentLife == 0)
        {
            onDead.Invoke();
            gameObject.SetActive(false);
        }

        healthBar.fillAmount = currentLife / maxLife;
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
