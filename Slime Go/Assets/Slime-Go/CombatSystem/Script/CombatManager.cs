using DataSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public Fighter avatar;

    private float lastTime = 0;
    private float timer = 0;
    private int enemyAttackCount = 0;
    private Data data;
    public int waitTime = 1;
    
    private void Start()
    {
        lastTime = Time.time;
        data = DataManager.LoadData<Data>();
    }

    private void Update()
    {
        timer = Time.time;
        if (timer >= lastTime + waitTime && avatar.status == Fighter.FightingActions.IDDLE)
        {
            float rand = Random.Range(0.0f, 1.0f);
            
            if (rand >= 0 && rand < 0.4)
            {
                avatar.Attack();
                enemyAttackCount++;
                Debug.Log("ataco");
            }
            if (rand >= 0.4 && rand < 0.6)
            { avatar.DodgeRight();
                Debug.Log("dodge right");
            }
            if (rand >= 0.6 && rand < 0.8)
            {
                avatar.DodgeLeft();
                Debug.Log("dodge left");
            }
            if (enemyAttackCount > 10 && rand >= 0.8 && rand <= 1)
             {
                avatar.SuperAttack();
                Debug.Log("super attack");
             }
            lastTime = Time.time;
        }
    }
}