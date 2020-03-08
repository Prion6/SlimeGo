using UnityEngine;
using Slime;

namespace SpawnSystem.Slime
{
    [System.Serializable]
    public class Spawnable_Slime : MonoBehaviour,ISpawnable
    {
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
            GameObject copy = Instantiate(gameObject, new Vector3(x, 2, z), Quaternion.identity);
            copy.transform.localScale = new Vector3(scale, scale, scale);
            return copy;
        }

        private void OnMouseDown()
        {
            //Entregar este slime a la variable estatica
        }
    }
}

