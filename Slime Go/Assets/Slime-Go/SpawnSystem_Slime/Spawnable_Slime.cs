using UnityEngine;
using Slime;
using DataSystem;

namespace SpawnSystem.Slime
{
    [System.Serializable]
    public class Spawnable_Slime : MonoBehaviour,ISpawnable
    {
        public SlimeType type;
        private float mass;
        public float maxScale;
        public float minScale;
        public float maxMass;
        public float minMass;

        public GameObject Spawn(float x, float z)
        {
            mass = Random.Range(minMass, maxMass);
            float m = (maxScale - minScale) / (maxMass - minMass);
            float scale = m * mass;
            GameObject copy = Instantiate(gameObject);
            copy.transform.position = new Vector3(x, 2, z);
            copy.transform.localScale = new Vector3(scale, scale, scale);
            return copy;
        }

        private void OnMouseDown()
        {
            float m = (25 - 200) / (maxMass - minMass);
            int maxLife = (int)(m * mass);
            try
            {
                var d = DataManager.LoadData<Data>();
                var acount = d.GetAcount(Globals.playerName);
                DataSystem.Slime s = acount.player.GetBestSlime();
                SlimeData player = new SlimeData(s.mainType, s.life, s.maxLife, s.weight);
                SlimeData enemy = new SlimeData(type.ToString(), maxLife, maxLife, mass);
                StartCoroutine(CombatManager.InitBattle(player, enemy));
            }
            catch (System.Exception e)
            {
                Debug.Log("error");
            }
        }
    }
}

