using DataSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Slime;

namespace InventorySystem
{
    public class InventorySlime : MonoBehaviour
    {
        public SlimeSlot slot_Pref;
        public Transform pivot;

        private List<SlimeSlot> slots = new List<SlimeSlot>();
        private SlimeScriptable[] slimes;

        public void Awake()
        {
            slimes = Resources.LoadAll<SlimeScriptable>("");         
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

            foreach (var slime in acount.player.slimes)
            {
                foreach (var rawSlimes in slimes)
                {
                    if (slime.name.Equals(rawSlimes.slimeName) || slime.name.Equals(rawSlimes.name))
                    {
                        var newSlot = Instantiate(slot_Pref, pivot);
                        newSlot.TextName = (slime.name);
                        newSlot.TextWeigth = Math.Round(slime.weight, 2) + " Kg";
                        newSlot.Image = rawSlimes.InventoryImage;
                        newSlot.BarAmount = slime.life / (slime.maxLife * 1f);
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

