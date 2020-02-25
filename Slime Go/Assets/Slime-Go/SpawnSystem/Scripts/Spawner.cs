using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnSystem
{
    public class Spawner : MonoBehaviour
    {
        public float radius;
        public List<GameObject> spawned;
        public int minSpawns;
        public int maxSpawns;

        // Start is called before the first frame update
        protected virtual void Awake()
        {
            spawned = new List<GameObject>();
        }
        
        public void Spawn(ISpawnable s)
        {
            if(spawned.Count < maxSpawns)
            {
                float x = transform.position.x + (2*Random.Range(0, radius) - radius);
                float z = transform.position.z + (2*Random.Range(0, radius) - radius);
                spawned.Add(s.Spawn(x, z));
            }
        }
    }
}
