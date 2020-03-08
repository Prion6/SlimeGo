using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slime
{
    
    public class SlimeData
    {
        public SlimeType type;
        public int live;
        public int maxLive;
        public float mass;

        public SlimeData(string type, int live, int maxLive, float mass)
        {
            foreach(SlimeType t in System.Enum.GetValues(typeof(SlimeType)))
            {
                if(t.ToString().Equals(type))
                {
                    this.type = t;
                    break;
                }
            }
            this.live = live;
            this.maxLive = maxLive;
            this.mass = mass;
        }
    }
}

