using UnityEngine;
using Slime;

namespace SpawnSystem.Slime
{
    [System.Serializable]
    public class Spawnable_Slime : MonoBehaviour,ISpawnable
    {
        SlimeScriptable slimeData;
        
        public Spawnable_Slime(SlimeType type)
        {
            
        }
        
        public GameObject Spawn(float x, float z)
        {
            var s = Instantiate(gameObject);
            s.gameObject.transform.position = new Vector3(x, 0, z);
            return s;
        }
    }
}

