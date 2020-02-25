using DataSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class InventoryItem : MonoBehaviour
    {
        public ItemSlot slot_Pref;
        public Transform pivot;

        private List<ItemSlot> slots = new List<ItemSlot>();
        private ItemScritable[] items;

        public void Awake()
        {
            items = Resources.LoadAll<ItemScritable>("");
        }


        public void OnEnable()
        {
            foreach (Transform child in pivot.transform)
            {
                GameObject.Destroy(child.gameObject);
            }

            var data = DataManager.LoadData<Data>();
            if (data == null)
            {
                Debug.Log("no hay data guardada: inicia el juego desde la Scena correspondiente 1 vez para generarlo. :D");
                return;
            }

            var acount = data.GetAcount(Globals.playerName);

#if UNITY_EDITOR
            if (acount == null)
            {
                acount = new Acount(Globals.playerName, Globals.playerName);
            }
#endif

            foreach (var item in acount.player.items)
            {
                foreach (var rawItem in items)
                {
                    if (item.name.Equals(rawItem.itemName) || item.name.Equals(rawItem.name))
                    {
                        var newSlot = Instantiate(slot_Pref, pivot);
                        newSlot.SetName(item.name);
                        newSlot.Description = rawItem.description;
                        newSlot.Image = (rawItem.sprite);
                        break;
                    }
                }
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

    }
}