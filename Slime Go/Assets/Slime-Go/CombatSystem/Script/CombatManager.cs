using DataSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Slime;
using UnityEngine.UI;

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

    public List<UsableButton> potions = new List<UsableButton>();
    public UsableButton catcher;


    public List<FighterData> fighters = new List<FighterData>();
    /*
    public enum Skins
    {
        ELECTRIC, FIRE, GEMS, ICE, LAVA, LIGHT, METAL, ROCK, SPIKES, WATER 
    }*/

    public SlimeData toCatch;
    public int playerInitialLive;

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
        manager.toCatch = enemy;
        manager.player.Init(manager.fighters[(int)player.type].basicAttack, manager.fighters[(int)player.type].specialAttack, manager.fighters[(int)player.type].model);
        manager.player.LateInit(player.mass, player.type);
        Debug.Log("MP: " + player.mass);
        manager.enemy.Init(manager.fighters[(int)enemy.type].basicAttack, manager.fighters[(int)enemy.type].specialAttack, manager.fighters[(int)enemy.type].model);
        manager.enemy.LateInit(enemy.mass, enemy.type);
        Debug.Log("Enemy: " + enemy.type);

        manager.InitButtons();
    }

    public void InitButtons()
    {
        var data = DataManager.LoadData<Data>();
        if (data == null) return;
        var acount = data.GetAcount(Globals.playerName);

        foreach (var item in acount.player.items)
        {
            if (item.name.Equals("Small Potion"))
                this.potions[0].SetAmount(item.amount);

            if (item.name.Equals("Small Medium"))
                this.potions[1].SetAmount(item.amount);

            if (item.name.Equals("Small Big"))
                this.potions[2].SetAmount(item.amount);

            if (item.name.Equals("Catcher"))
                catcher.SetAmount(item.amount);
        }

        if (this.potions[0].amount <= 0)
            this.potions[0].button.interactable = false;

        if (this.potions[1].amount <= 0)
            this.potions[1].button.interactable = false;

        if (this.potions[2].amount <= 0)
            this.potions[2].button.interactable = false;

        if (this.catcher.amount <= 0)
            this.catcher.button.interactable = false;


        this.potions[0].SetAmount(1);
        this.potions[0].button.onClick.AddListener(() => {
            player.currentLife = Mathf.Min(player.currentLife + 20, player.maxLife);
            this.potions[0].SetAmount(this.potions[0].amount -1);
            if (this.potions[0].amount <= 0)
                this.potions[0].button.interactable = false;
        });

        this.potions[1].button.onClick.AddListener(() => {
            player.currentLife = Mathf.Min(player.currentLife + 20, player.maxLife);
            this.potions[1].SetAmount(this.potions[1].amount - 1);
            if (this.potions[1].amount <= 0)
                this.potions[1].button.interactable = false;
        });

        this.potions[2].button.onClick.AddListener(() => {
            player.currentLife = Mathf.Min(player.currentLife + 20, player.maxLife);
            this.potions[2].SetAmount(this.potions[2].amount - 1);
            if (this.potions[2].amount <= 0)
                this.potions[2].button.interactable = false;
        });

        this.catcher.button.onClick.AddListener(() => {
        var r = Random.Range(0, 100);
        if (this.enemy.currentLife / this.enemy.maxLife <= 0.1f)
        {
            if (r < 90)
                Globals.mesageCatcher = "Capturaste al slime.";
            else
                Globals.mesageCatcher = "El slime se ha escapado.";
        }
        else if (this.enemy.currentLife / this.enemy.maxLife <= 0.3f)
        {
            if (r < 33)
                Globals.mesageCatcher = "Capturaste al slime.";
            else
                Globals.mesageCatcher = "El slime se ha escapado.";
        }
        else if (this.enemy.currentLife / this.enemy.maxLife <= 0.5f)
        {
            if (r < 10)
                Globals.mesageCatcher = "Capturaste al slime.";
            else
                Globals.mesageCatcher = "El slime se ha escapado.";
        }
        else
        {
            Globals.mesageCatcher = "";
        }

        if (Globals.mesageCatcher.Equals("Capturaste al slime."))
        {
            try
            {
                var d = DataManager.LoadData<Data>();
                var a = d.GetAcount(Globals.playerName);
                a.player.slimes.Add(new DataSystem.Slime("Slime " + toCatch.type.ToString(), toCatch.maxLive, toCatch.maxLive, toCatch.mass, toCatch.type.ToString()));
                DataManager.SaveData<Data>(d);
                }
                catch
                {

                }
            }

            SceneManager.LoadScene("MainScreen");

            this.catcher.SetAmount(this.catcher.amount - 1);
            if (this.catcher.amount <= 0)
                this.catcher.button.interactable = false;
        });
    }

    public void Win()
    {
        FindObjectOfType<SoundManager>().Play("Win sound");
        gameover = true;
        FindObjectOfType<FighterInput>().enabled = false;
        EndFight();
        SceneManager.LoadScene("MainScreen");

    }

    public void Lose()
    {
        FindObjectOfType<SoundManager>().Play("Lose");
        gameover = true;
        FindObjectOfType<FighterInput>().enabled = false;
        EndFight();
        SceneManager.LoadScene("MainScreen");
    }

    public void EndFight()
    {
        try
        {
            var d = DataManager.LoadData<Data>();
            var acount = d.GetAcount(Globals.playerName);
            foreach(DataSystem.Slime s in acount.player.slimes)
            {
                if(s.weight == player.weigth && s.mainType.Equals(player.type.ToString()))
                {
                    s.life = (int)player.currentLife;
                    DataManager.SaveData<Data>(d);
                    return;
                }
            }
        }
        catch { }
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