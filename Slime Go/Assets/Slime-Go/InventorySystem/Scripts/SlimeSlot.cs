using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public class SlimeSlot : MonoBehaviour
    {
        [SerializeField] private Text textName;
        [SerializeField] private Text textWeigth;
        [SerializeField] private Image image;
        [SerializeField] private Bar barLife;

        public string TextName { get => textName.text; set => textName.text = value; }
        public Sprite Image { get => image.sprite; set => image.sprite = value; }
        public string TextWeigth { get => textWeigth.text; set => textWeigth.text = value; }
        public float BarAmount { get => barLife.Amount; set => barLife.Amount = value; }

        void Awake()
        {

        }
    }
}
