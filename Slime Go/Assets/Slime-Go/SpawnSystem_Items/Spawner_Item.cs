using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnSystem.Item
{
    public class Spawner_Item : Spawner
    {
        public List<Spawnable_Item> spawnableItems;

        protected override void Awake()
        {
            base.Awake();
            SpawnController_Item spawnManager = FindObjectOfType<SpawnController_Item>();
        }
    }
}
