using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item.Potion
{
    public class Potion : MonoBehaviour
    {
        public int healPower;

        public void Heal(IHealable target)
        {
            target.Heal(healPower);
        }
    }
}