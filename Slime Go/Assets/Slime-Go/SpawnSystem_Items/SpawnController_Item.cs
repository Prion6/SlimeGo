using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnSystem.Item
{
    public class SpawnController_Item : SpawnController
    {

        // Update is called once per frame
        protected override void Update()
        {
            if (!spawning)
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
            int limit = Random.Range(0, 4);
            for (int i = 1; i < limit; i++)
            {
                if (Random.Range(0f, 1f) <= 0.6f)
                {
                    spawner.Spawn(((Spawner_Item)spawner).spawnableItems[0]);
                }
                else
                {
                    spawner.Spawn(((Spawner_Item)spawner).spawnableItems[Random.Range(1, ((Spawner_Item)spawner).spawnableItems.Count - 1)]);

                }
            } 
        }
    }
}

