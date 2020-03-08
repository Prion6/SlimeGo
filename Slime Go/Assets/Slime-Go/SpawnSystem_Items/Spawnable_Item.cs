using DataSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnSystem.Item
{
    [System.Serializable]
    public class Spawnable_Item : MonoBehaviour, ISpawnable
    {
        public DataSystem.Item item = new DataSystem.Item("1",1);

        public GameObject Spawn(float x, float z)
        {
            return Instantiate(gameObject, new Vector3(x, transform.position.y + 1, z), Quaternion.identity);
        }
        
        private void OnMouseDown()
        {
            try
            {
                var d = DataManager.LoadData<Data>();
                var acount = d.GetAcount(Globals.playerName);
                acount.player.items.Add(item);
                DataManager.SaveData<Data>(d);
                Debug.Log("Yay");
                Destroy(this.gameObject);
            }
            catch(Exception e)
            {
                Debug.Log("Ouch");
            }
        }
    }
}

