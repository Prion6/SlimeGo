using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slime;

namespace SpawnSystem.Slime
{
    public class SpawnController_Slime : SpawnController
    {
        private void Start()
        {
            
        }

        protected override void Update()
        {
            if(!spawning)
            {
                foreach (Spawner s in spawners)
                {
                    s.minSpawns = (int)Mathf.Ceil(minSpawns / spawners.Count);
                    s.maxSpawns = (int)Mathf.Ceil(maxSpawns / spawners.Count);
                }
                if (spawners.Count != 0)
                    spawning = true;
            }
            base.Update();
        }

        public override void MakeSpawn(Spawner spawner)
        {
            spawner.Spawn(((Spawner_Slime)spawner).spawnableSlimes[Random.Range(0, ((Spawner_Slime)spawner).spawnableSlimes.Count-1)]);
        }
    }

}
