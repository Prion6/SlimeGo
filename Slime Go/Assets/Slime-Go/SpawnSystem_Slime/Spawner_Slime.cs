using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slime;

namespace SpawnSystem.Slime
{
    public class Spawner_Slime : Spawner
    {
        public List<Spawnable_Slime> spawnableSlimes;
        
        protected override void Awake()
        {
            base.Awake();
            SpawnController_Slime spawnManager = FindObjectOfType<SpawnController_Slime>();
            spawnManager.spawners.Add(this);
        }
    }
}


