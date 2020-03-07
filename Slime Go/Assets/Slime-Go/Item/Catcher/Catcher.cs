using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item.Catcher
{
    public class Catcher : MonoBehaviour
    {
        public bool Catch(ICatchable catchable)
        {
            return catchable.CatchAtempt();
        }
    }
}

