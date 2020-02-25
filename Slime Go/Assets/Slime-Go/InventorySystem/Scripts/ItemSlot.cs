using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace InventorySystem
{
    public class ItemSlot : MonoBehaviour
    {

        [SerializeField] private Text textName;
        [SerializeField] private Text textDescription;
        [SerializeField] private Text textAmount;
        [SerializeField] private Image image;

        public string TextName { get => textName.text; set => textName.text = value; }
        public string Description { get => textDescription.text; set => textDescription.text = value; }
        public string Amount { get => textAmount.text; set => textAmount.text = value; }
        public Sprite Image { get => image.sprite; set => image.sprite = value; }

        void Awake()
        {

        }

        public void SetName(string text)
        {
            this.textName.text = text;
        }
    }
}
