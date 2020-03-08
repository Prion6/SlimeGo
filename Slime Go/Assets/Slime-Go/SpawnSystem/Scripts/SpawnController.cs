using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnSystem
{
    public abstract class SpawnController : MonoBehaviour
    {
        public List<Spawner> spawners;
        public int minSpawns;
        public int maxSpawns;
        public bool spawning;
        public float coolDown;
        private float timer;

        public void Start()
        {
            timer = coolDown;
        }


        protected virtual void Update()
        {
            timer += Time.deltaTime;
            if(timer >= coolDown && spawning)
            {
                int count = 0;
                foreach(Spawner s in spawners)
                {
                    count += s.spawned.Count;
                }
                if(count < minSpawns)
                {
                    Spawn();
                    timer = 0;
                }
            }
        }
        
        protected void Spawn()
        {
            foreach (Spawner s in spawners)
            {
                MakeSpawn(s);
            }
        }

        public abstract void MakeSpawn(Spawner spawner);
    }
}
