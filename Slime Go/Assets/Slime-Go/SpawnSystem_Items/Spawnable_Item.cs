using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnSystem.Item
{
    [System.Serializable]
    public class Spawnable_Item : MonoBehaviour, ISpawnable
    {
        public GameObject Spawn(float x, float z)
        {
            return Instantiate(gameObject, new Vector3(x, 0, z), Quaternion.identity);
        }
    }
}

