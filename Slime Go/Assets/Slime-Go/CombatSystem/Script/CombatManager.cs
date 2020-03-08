using DataSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Slime;

public class CombatManager : MonoBehaviour
{
    public Fighter player;
    public Fighter enemy;

    private float lastTime = 0;
    private float timer = 0;
    private int enemyAttackCount = 0;
    private Data data;
    public int waitTime = 1;


    private bool gameover;

    public List<FighterData> fighters = new List<FighterData>();
    /*
    public enum Skins
    {
        ELECTRIC, FIRE, GEMS, ICE, LAVA, LIGHT, METAL, ROCK, SPIKES, WATER 
    }*/

    private void Start()
    {
        lastTime = Time.time;
        data = DataManager.LoadData<Data>();

        FindObjectOfType<SoundManager>().Play("battle theme");

        //DEBUG!
        var a = Random.Range(0, 9);
        var b = Random.Range(0, 9);
        //player.Init(fighters[a].basicAttack, fighters[a].model);
        //enemy.Init(fighters[b].basicAttack, fighters[b].model);
    }

    //Con esta linea inicias una batalla entre dos slimes randoms, usenla para el bien de la nacion slime o7.
    //StartCoroutine(CombatManager.InitBattle((CombatManager.Skins) UnityEngine.Random.Range(0, 9), (CombatManager.Skins) UnityEngine.Random.Range(0, 9), 1));

    public static IEnumerator InitBattle(SlimeData player, SlimeData enemy, int potions)
    {
        Scene current = SceneManager.GetActiveScene();
        AsyncOperation async = SceneManager.LoadSceneAsync("Combat Doyo", UnityEngine.SceneManagement.LoadSceneMode.Additive);
        async.allowSceneActivation = true;
        while (!async.isDone)
        {
            yield return new WaitForSeconds(Time.deltaTime);
        }

        SceneManager.UnloadSceneAsync(current);

        var manager = FindObjectOfType<CombatManager>();
        manager.player.Init(manager.fighters[(int)player.type].basicAttack, manager.fighters[(int)player.type].specialAttack, manager.fighters[(int)player.type].model);
        manager.enemy.Init(manager.fighters[(int)enemy.type].basicAttack, manager.fighters[(int)enemy.type].specialAttack, manager.fighters[(int)enemy.type].model);
    }

    public void Win()
    {
        FindObjectOfType<SoundManager>().Play("Win sound");
        print("GANE!");
        gameover = true;
        FindObjectOfType<FighterInput>().enabled = false;
    }

    public void Lose()
    {
        FindObjectOfType<SoundManager>().Play("Lose");
        print("PERDI!");
        gameover = true;
        FindObjectOfType<FighterInput>().enabled = false;
    }

    private void Update()
    {
        if (gameover)
            return;

        timer = Time.time;
        if (timer >= lastTime + waitTime && enemy.status == Fighter.FightingActions.IDDLE)
        {
            float rand = Random.Range(0.0f, 1.0f);
            
            if (rand >= 0 && rand < 0.4)
            {
                enemy.Attack();
                enemyAttackCount++;
            }
            if (rand >= 0.4 && rand < 0.6)
            { enemy.DodgeRight();
            }
            if (rand >= 0.6 && rand < 0.8)
            {
                enemy.DodgeLeft();
            }
            if (enemyAttackCount > 10 && rand >= 0.8 && rand <= 1)
             {
                enemy.SuperAttack();
             }
            lastTime = Time.time;
        }
    }

    [System.Serializable]
    public struct FighterData
    {
        public GameObject model;
        public Proyectile basicAttack;
        public Proyectile specialAttack;
    }
}