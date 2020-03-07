using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item.Potion
{
    public interface IHealable
    {
        void Heal(double healingAmount);
    }
}
